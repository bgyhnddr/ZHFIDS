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
        private List<DataSetGate.GateRow> gateList = new List<DataSetGate.GateRow>();

        public Gate()
        {
            InitializeComponent();
            filetransfer.FileIO.StartFileListen(this, new filetransfer.FileIO.FinishHandle(() =>
            {
                global.Function.InitLogo();
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
        }

        private void SetCSS()
        {
            pictureBoxMark.Width = Width;

            panelContent.Width = panelTips.Width = panelAD.Width = Width;

            panelTitle.BackColor = fidsstyle.Style.RowBackColor;
            panelTitle.Height = (int)(Height * 0.15);
            panelContent.Location = new Point(0, panelTitle.Height);
            panelContent.Height = (int)(Height * 0.45);
            panelTips.BackColor = fidsstyle.Style.RowBackColor;
            panelTips.Location = new Point(0, panelContent.Location.Y + panelContent.Height);
            panelTips.Height = (int)(Height * 0.15);


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
                global.Function.CreateErrorImage(pictureBoxMark);
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
                pictureBoxMark.Visible = true;
            }
        }

        private DataSetGate.GateDataTable GetGateTable(ref int currentPage, int perPage, int preHour, int afterMin)
        {
            string where = " WHERE ";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("timediff(orderTime,now())<'{0:D2}:00:00'", preHour);
            where += " AND ";
            where += string.Format("case when atd='' then true else timediff(now(),adatetime)<'{0}' END", new TimeSpan(0, afterMin, 0).ToString());
            where += " AND ";
            where += string.Format("gate='{0}'", global.Variable.GATE);
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
            if (CurrentADPage >= ADList.Count)
            {
                CurrentADPage = 0;
            }
            panelAD.BackgroundImage = ADList[CurrentADPage];
            CurrentADPage += 1;
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
                        int preHour, afterMIN, updateInterval;
                        bool showError;
                        GetConfig(out updateInterval, out preHour, out afterMIN, out showError);
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            if (gateList.Count == 0)
                            {
                                GetTableList(GetGateTable(ref CurrentPage, 1, preHour, afterMIN)); 
                            }
                            DataSetGate.GateRow row = null;
                            if (gateList.Count > 0)
                            {
                                var tempRow = gateList[0];
                                row = GateTable.NewGateRow();
                                row.flight = tempRow.flight;
                                row.std = tempRow.std;
                                row.etd = tempRow.etd;
                                row.atd = tempRow.atd;
                                row.tovia = tempRow.tovia;
                                row.en_tovia = tempRow.en_tovia;
                                row.departstatus = tempRow.departstatus;
                                row.en_departstatus = tempRow.en_departstatus;
                                row.departoutward = tempRow.departoutward;
                                row.departoutward_en = tempRow.departoutward_en;
                                row.orgdepartstatus = tempRow.orgdepartstatus;
                            }
                            SetValueByRow(row);
                            SetAD();

                            global.Function.CountErrorTime();
                            pictureBoxMark.Visible = (gateList.Count == 0) || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit);
                            gateList.RemoveAt(0);
                        });
                        this.Invoke(refresh);
                        Thread.Sleep(updateInterval * 1000);
                    }
                    catch (Exception ex)
                    {
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            pictureBoxMark.Visible = true;
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

        private void GetTableList(DataSetGate.GateDataTable gate)
        {
            gateList.Clear();
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
                        row.departstatus = gate[0].departstatus;
                        row.en_departstatus = gate[0].en_departstatus;
                        row.departoutward = gate[0].departoutward;
                        row.departoutward_en = gate[0].departoutward_en;
                        row.orgdepartstatus = gate[0].orgdepartstatus;
                        gateList.Add(row);
                    }
                }
            }
        }

        private void GetConfig(out int updateInterval, out int preHour, out int afterMin, out bool showError)
        {
            var row = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.gate)).ToArray();
            if (row.Length > 0)
            {
                updateInterval = row[0].updateinterval;
                preHour = row[0].advance;
                afterMin = row[0].delay;
            }
            else
            {
                updateInterval = 7;
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

                    var logoString = flight.Substring(0, 2);
                    var logo = global.Function.GetLogo(logoString);
                    int logoHeight = (int)(e.ClipRectangle.Height * 0.8);

                    var ImageRectangle = new Rectangle((e.ClipRectangle.Height - logoHeight) / 2, (e.ClipRectangle.Height - logoHeight) / 2, logoHeight * logo.Width / logo.Height, logoHeight);

                    e.Graphics.DrawImage(logo, ImageRectangle);
                    var font = new Font("黑体", (int)(panelTitle.Height * 0.8), fontStyle, System.Drawing.GraphicsUnit.Pixel);

                    var sizeF = e.Graphics.MeasureString(flight, font);

                    var fontRectangle = new Rectangle(ImageRectangle.X + ImageRectangle.Width + 5, 0, (int)sizeF.Width, panelTitle.Height);

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.Word;

                    e.Graphics.DrawString(flight,
                        font,
                        new SolidBrush(Color.White),
                        e.ClipRectangle,
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
                DateTime dateTime;
                if (DateTime.TryParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dateTime))
                {
                    time = dateTime.ToString("HH:mm");

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.Word;
                    var font = new Font("黑体", panelTips.Height / 2, fontStyle, System.Drawing.GraphicsUnit.Pixel);
                    var size = e.Graphics.MeasureString("计划STDXX:XX ", font);
                    var remarkSize = e.Graphics.MeasureString(remark, font);
                    var rect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, (int)(size.Width) + 5, panelTips.Height);
                    e.Graphics.DrawString("计划STD" + time,
                                font,
                                new SolidBrush(Color.White),
                                rect,
                                stringFormat);


                    var remarkRect = new Rectangle(e.ClipRectangle.X + rect.Width, e.ClipRectangle.Y, panelTips.Width - (int)(size.Width * 1.1), panelTips.Height);
                    e.Graphics.DrawString(RemarkText,
                                font,
                                new SolidBrush(RemarkTextColor),
                                remarkRect,
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
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.Trimming = StringTrimming.Word;
                var toFont = new Font("黑体", e.ClipRectangle.Height / 4, fontStyle, System.Drawing.GraphicsUnit.Pixel);
                var toRect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height / 2);
                e.Graphics.DrawString(to,
                                    toFont,
                                    new SolidBrush(Color.White),
                                    toRect,
                                    stringFormat);
                var toenFont = new Font("黑体", e.ClipRectangle.Height / 4, fontStyle, System.Drawing.GraphicsUnit.Pixel);
                var toenRect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + toRect.Height, e.ClipRectangle.Width, e.ClipRectangle.Height / 2);
                stringFormat.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString(toen,
                                    toFont,
                                    new SolidBrush(Color.White),
                                    toenRect,
                                    stringFormat);
            }
            catch
            {
            }
            
        }
    }
}
