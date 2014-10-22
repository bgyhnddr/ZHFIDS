using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Text;

namespace data
{
    public partial class Gate : global.BaseForm
    {
        private int CurrentPage;
        private int CurrentADPage = 0;
        private int ADCount;
        private Font FlightFont;
        private string Flight=string.Empty;
        private string STDTime = string.Empty;
        private string RemarkText = string.Empty;
        private Color RemarkTextColor = Color.White;
        private string Tovia = string.Empty;
        private string Toviaen = string.Empty;
        private DataSetGate.GateDataTable GateTable = new DataSetGate.GateDataTable();
        private DataSetGateTableAdapters.GateTableAdapter GateAdapter = new DataSetGateTableAdapters.GateTableAdapter();
        private List<Image> ADList = new List<Image>();
        private FontStyle fontStyle = FontStyle.Regular;
        private List<DataSetGate.GateRow> GateList = new List<DataSetGate.GateRow>();
        private System.Windows.Forms.Timer LTimer;
        private System.Windows.Forms.Timer ADTimer;

        public Gate()
        {
            InitializeComponent();
            filetransfer.FileIO.StartFileListen(this, new filetransfer.FileIO.FinishHandle(() =>
            {
                global.Function.InitLogo();
                pictureBoxMark.GetPictureList(global.Variable.IMAGEFolder);
            }));
            global.Function.CreateAccessTimer(AccessTimer);
        }

        private void InitAD()
        {
            ADList.Clear();
            DirectoryInfo di = new DirectoryInfo(global.Variable.ADFolder);
            FileInfo[] files = di.GetFiles();
            ADCount = files.Length;
            foreach (var file in files)
            {
                if (file.Extension == ".jpg")
                {
                    ADList.Add(Image.FromFile(file.FullName));
                }
            }
            if (ADTimer != null)
            {
                ADTimer.Stop();
            }
            SetAD();
            ADTimer = new System.Windows.Forms.Timer();
            ADTimer.Interval = global.Variable.ADInterval * 1000;
            ADTimer.Tick += new EventHandler((o, e) =>
            {
                SetAD();
            });
            ADTimer.Start();
        }

        private void SetCSS()
        {
            pictureBoxMark.Width = Width;

            panelContent.Width = panelTips.Width = panelAD.Width = Width;

            panelTitle.BackColor = fidsstyle.Style.RowBackColor;
            panelTitle.Height = (int)(Height * 0.20);
            panelContent.Location = new Point(0, panelTitle.Height);
            panelContent.Height = (int)(Height * 0.35);
            panelTips.BackColor = fidsstyle.Style.RowBackColor;
            panelTips.Location = new Point(0, panelContent.Location.Y + panelContent.Height);
            panelTips.Height = (int)(Height * 0.20);
            UpdateStyles();

            panelAD.Height = Height - panelTips.Location.Y - panelTips.Height;
            panelAD.Location = new Point(0, panelTips.Location.Y + panelContent.Height);

            FlightFont = new Font("黑体", panelTitle.Height / 2, fontStyle, System.Drawing.GraphicsUnit.Pixel);

            Graphics g = Graphics.FromHwnd(this.Handle);
            var timeWidth = g.MeasureString("00:00", FlightFont).Width;
            lbTime.Text = DateTime.Now.ToString("HH:mm");
            lbTime.Font = FlightFont;
            lbTime.ForeColor = Color.White;
            lbTime.Width = (int)(timeWidth + 10);

        }

        private void Gate_Load(object sender, EventArgs e)
        {
            
            Init();
            bgwGate.RunWorkerAsync();
        }

        private void Init()
        {
            try
            {
                pictureBoxMark.GetPictureList(global.Variable.IMAGEFolder);
                global.Function.InitLogo();
                global.Function.InitColor();
                InitAD();
                SetCSS();
                GateAdapter.GetData();
                ViewCommentText = GateAdapter.Adapter.SelectCommand.CommandText;
                CreateRollingTimer(RollingTimer, null, lbTime);
            }
            catch
            {
                SetMask(true);
            }
        }

        private DataSetGate.GateDataTable GetGateTable(ref int currentPage, int perPage, int preHour, int afterMin)
        {
            string where = " WHERE ";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("timediff(orderTime,now())<'{0}'", new TimeSpan(0, preHour, 0).ToString());
            where += " AND ";
            where += string.Format("case when atd='' then true else timediff(now(),adatetime)<'{0}' END", new TimeSpan(0, afterMin, 0).ToString());
            where += " AND ";
            where += string.Format("(locate('{0}', gate) > 0)", global.Variable.GATE);
            where += ")";
            #endregion
            where += string.Format(" limit {0},{1}", currentPage * perPage, perPage);
            GateAdapter.Adapter.SelectCommand.CommandText = ViewCommentText + where;
            var table = GateAdapter.GetData();
            //判断page的情况
            if (currentPage != 0)
            {
                if (table.Rows.Count == 0)
                {
                    currentPage = 0;
                    return GetGateTable(ref currentPage, perPage, preHour, afterMin);
                }
            }
            currentPage += 1;
            return table;
        }

        private void SetValueByRow(DataSetGate.GateRow row)
        {
            if (row != null)
            {
                Flight = row.flight;
                var to = row.tovia.Split(' ').ToList();
                var toen = row.en_tovia.Split(' ').ToList();

                List<string> toviaList = new List<string>();
                List<string> toviaenList = new List<string>();

                if (row.tovia.IndexOf('*') < 0)
                {
                    row.tovia.Split(' ').ToList().ForEach((o) =>
                    {
                        toviaList.Add(o);
                    });
                    row.en_tovia.Split(' ').ToList().ForEach((o) =>
                    {
                        toviaenList.Add(o);
                    });
                }
                else
                {
                    var templist = row.tovia.Split('*')[1].Split(' ');

                    templist.ToList().GetRange(1, templist.Length - 1).ForEach((o) =>
                    {
                        toviaList.Add(o);
                    });

                    templist = row.en_tovia.Split('*')[1].Split(' ');

                    templist.ToList().GetRange(1, templist.Length - 1).ForEach((o) =>
                    {
                        toviaenList.Add(o);
                    });
                }

                Tovia = string.Join(" ", toviaList);
                Toviaen = string.Join(" ", toviaenList);

                STDTime = row.std;

                RemarkText = EditRemark(row);
            }
            else
            {
                Tovia = string.Empty;
                Toviaen = string.Empty;
                STDTime = string.Empty;
                RemarkText = string.Empty;
            }
            panelTitle.Refresh();
            panelContent.Refresh();
            panelTips.Refresh();
        }

        private string EditRemark(DataSetGate.GateRow row)
        {

            if (row.gate.IndexOf(">") >= 0)
            {
                if (!(row.gate.Substring(0, 2) == row.gate.Substring(3, 2)))
                {
                    if (row.gate.Substring(0, row.gate.IndexOf(">")) == global.Variable.GATE)
                    {
                        LTimer = new System.Windows.Forms.Timer();
                        LTimer.Tick += new EventHandler((o, e) =>
                        {
                            RemarkText = string.Format("Change to Gate {0}", row.gate.Substring(row.gate.IndexOf(">") + 1));
                            panelTips.Refresh();
                            LTimer.Stop();
                        });
                        LTimer.Interval = UpdateInterval * 1000 / 2;
                        LTimer.Start();
                        RemarkTextColor = Color.Red;
                        return string.Format("现改为{0}号登机口", row.gate.Substring(row.gate.IndexOf(">") + 1));
                    }
                }
            }

            var returnString = row.departstatus + row.en_departstatus;

            if (returnString.IndexOf("延误") >= 0)
            {
                if (string.IsNullOrWhiteSpace(row.etd))
                {
                    returnString = row.departoutward + returnString;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(row.departoutward))
                    {
                        returnString = "预计起飞ETD" + row.etd.Substring(0, 2) + ":" + row.etd.Substring(2, 2);
                    }
                    else
                    {
                        returnString = row.departoutward + "延误至ETD" + row.etd.Substring(0, 2) + ":" + row.etd.Substring(2, 2);
                    }
                }
            }
            else if (returnString.IndexOf("取消") >= 0)
            {
                returnString = row.departoutward + returnString;
            }

            RemarkTextColor = global.Function.GetColor(row.orgdepartstatus);
            return returnString;
        }

        private void SetAD()
        {
            panelAD.Refresh();
        }

        private void bgwGate_DoWork(object sender, DoWorkEventArgs e)
        {
            BackGroundWork();
        }

        private void BackGroundWork()
        {
            try
            {
                while (!this.IsDisposed)
                {
                    try
                    {
                        int preHour, afterMIN;
                        bool showError;
                        GetConfig(out preHour, out afterMIN, out showError);
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            if (GateList.Count == 0)
                            {
                                GetTableList(GetGateTable(ref CurrentPage, 1, preHour, afterMIN)); 
                            }
                            DataSetGate.GateRow row = null;
                            if (GateList.Count > 0)
                            {
                                var tempRow = GateList[0];
                                row = GateTable.NewGateRow();
                                row.flight = tempRow.flight;
                                row.std = tempRow.std;
                                row.etd = tempRow.etd;
                                row.atd = tempRow.atd;
                                row.tovia = tempRow.tovia;
                                row.en_tovia = tempRow.en_tovia;
                                row.gate = tempRow.gate;
                                row.departstatus = tempRow.departstatus;
                                row.en_departstatus = tempRow.en_departstatus;
                                row.departoutward = tempRow.departoutward;
                                row.departoutward_en = tempRow.departoutward_en;
                                row.orgdepartstatus = tempRow.orgdepartstatus;
                                SetValueByRow(row);
                            }

                            global.Function.CountErrorTime();
                            SetMask(GateList.Count == 0 || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit), GateList.Count == 0);
                            if (GateList.Count > 0)
                            {
                                GateList.RemoveAt(0);
                            }
                        });
                        this.Invoke(refresh);
                        Thread.Sleep(UpdateInterval * 1000);
                    }
                    catch (Exception ex)
                    {
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            SetMask(true);
                        });
                        this.Invoke(refresh);
                        Thread.Sleep(3000);
                    }
                }
            }
            catch
            {
            }
        }

        private void SetMask(bool visible, bool black = false)
        {
            pictureBoxMark.Visible = visible;
            pictureBoxMark.SetBlackMask(black);
        }

        private void GetTableList(DataSetGate.GateDataTable gate)
        {
            GateList.Clear();
            if (gate.Count > 0)
            {
                foreach (var flight in gate[0].flight.Split(','))
                {
                    if (!string.IsNullOrWhiteSpace(flight))
                    {
                        var row = gate.NewGateRow();
                        row.flight = flight;
                        row.std = gate[0].std;
                        row.etd = gate[0].etd;
                        row.atd = gate[0].atd;
                        row.tovia = gate[0].tovia;
                        row.en_tovia = gate[0].en_tovia;
                        row.gate = gate[0].gate;
                        row.departstatus = gate[0].departstatus;
                        row.en_departstatus = gate[0].en_departstatus;
                        row.departoutward = gate[0].departoutward;
                        row.departoutward_en = gate[0].departoutward_en;
                        row.orgdepartstatus = gate[0].orgdepartstatus;
                        GateList.Add(row);
                    }
                }
            }
        }

        private void GetConfig(out int preHour, out int afterMin, out bool showError)
        {
            var row = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.gate)).ToArray();
            if (row.Length > 0)
            {
                UpdateInterval = row[0].updateinterval;
                preHour = row[0].advance;
                afterMin = row[0].delay;
            }
            else
            {
                UpdateInterval = 7;
                preHour = 4;
                afterMin = 15;
            }

            showError = bool.Parse(data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.SHOWERRORLINECONFIG).ToArray()[0].value);
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {
            var px = 0;
            Flight.Split(' ').ToList().ForEach((o) =>
            {
                px = DrawAflight(o, px, e);
            });
        }

        private int DrawAflight(string flight,int px, PaintEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(flight))
                {
                    e.Graphics.TextRenderingHint = global.Variable.HINT;
                    var logoString = flight.Substring(0, 2);
                    var logo = global.Function.GetLogo(logoString);
                    int logoHeight = (int)(e.ClipRectangle.Height * 0.8);

                    var ImageRectangle = new Rectangle((e.ClipRectangle.Height - logoHeight) / 2, (e.ClipRectangle.Height - logoHeight) / 2, logoHeight * logo.Width / logo.Height, logoHeight);

                    e.Graphics.DrawImage(logo, ImageRectangle);
                    var font = new Font("黑体", (int)(panelTitle.Height * 0.9), fontStyle, System.Drawing.GraphicsUnit.Pixel);

                    var sizeF = e.Graphics.MeasureString(flight, font);

                    var fontRectangle = new Rectangle(e.ClipRectangle.Width / 2, 0, e.ClipRectangle.Width / 2, e.ClipRectangle.Height);
                    fontRectangle.Offset(-20, 0);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Trimming = StringTrimming.Word;

                    e.Graphics.DrawString(flight,
                        font,
                        new SolidBrush(Color.White),
                        fontRectangle,
                        stringFormat);

                    return fontRectangle.X + fontRectangle.Width;
                }
                else
                {
                    return px;
                }
            }
            catch
            {
                return 0;
            }
        }

        private void panelTips_Paint(object sender, PaintEventArgs e)
        {
            DrawTips(STDTime, RemarkText, e);
        }
        private void DrawTips(string time, string remark, PaintEventArgs e)
        {
            try
            {
                e.Graphics.TextRenderingHint = global.Variable.HINT;
                DateTime dateTime;
                if (DateTime.TryParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dateTime))
                {
                    time = dateTime.ToString("HH:mm");
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.Word;
                    var font = new Font("黑体", (int)(panelTips.Height*0.55), fontStyle, System.Drawing.GraphicsUnit.Pixel);
                    var size = e.Graphics.MeasureString("计划STDXX:XX ", font);
                    var remarkSize = e.Graphics.MeasureString(remark, font);
                    var rect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, (int)(size.Width) + 5, panelTips.Height);

                    e.Graphics.DrawString("计划STD" + time,
                                font,
                                new SolidBrush(Color.White),
                                rect,
                                stringFormat);
                    
                    e.Graphics.DrawString(RemarkText,
                                font,
                                new SolidBrush(RemarkTextColor),
                                e.ClipRectangle,
                                stringFormat);
                }
            }
            catch
            {

            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            DrawContent(Tovia, Toviaen, e);
        }
        private void DrawContent(string to, string toen, PaintEventArgs e)
        {
            try
            {
                e.Graphics.TextRenderingHint = global.Variable.HINT;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;
                stringFormat.Trimming = StringTrimming.Word;
                var toFont = new Font("黑体", (int)(e.ClipRectangle.Height*0.6), fontStyle, System.Drawing.GraphicsUnit.Pixel);
                var toFonten = new Font("黑体", (int)(e.ClipRectangle.Height / 4), fontStyle, System.Drawing.GraphicsUnit.Pixel);
                var toRect = new Rectangle(e.ClipRectangle.X, (int)(e.ClipRectangle.Height * 0.05), e.ClipRectangle.Width, e.ClipRectangle.Height);
                e.Graphics.DrawString(to,
                                    toFont,
                                    new SolidBrush(Color.White),
                                    toRect,
                                    stringFormat);
                var toenFont = new Font("黑体", e.ClipRectangle.Height / 4, fontStyle, System.Drawing.GraphicsUnit.Pixel);
                var toenRect = new Rectangle(e.ClipRectangle.X, -(int)(e.ClipRectangle.Height * 0.05), e.ClipRectangle.Width, e.ClipRectangle.Height);
                stringFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString(toen,
                                    toFonten,
                                    new SolidBrush(Color.White),
                                    toenRect,
                                    stringFormat);
            }
            catch
            {
            }
            
        }

        private void panelAD_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (CurrentADPage >= ADList.Count)
                {
                    CurrentADPage = 0;
                }
                e.Graphics.DrawImage(ADList[CurrentADPage], e.ClipRectangle);
                CurrentADPage += 1;
            }
            catch
            {

            }
        }
    }
}
