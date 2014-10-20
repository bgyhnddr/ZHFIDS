using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fidsstyle;
using System.IO;
using System.Threading;

namespace data
{
    public partial class Guide : global.BaseForm
    {
        private DataSetGuide.GuideDataTable GuideTable = new DataSetGuide.GuideDataTable();
        private DataSetGuideTableAdapters.GuideTableAdapter GuideAdapter = new DataSetGuideTableAdapters.GuideTableAdapter();
        private BindingList<GuideEntity> GuideList = new BindingList<GuideEntity>();

        public Guide(bool isChild)
        {
            InitializeComponent();
            IsChild = isChild;
            if (!IsChild)
            {
                filetransfer.FileIO.StartFileListen(this, new filetransfer.FileIO.FinishHandle(() =>
                {
                    global.Function.InitIcon();
                    pictureBoxMark.GetPictureList(global.Variable.IMAGEFolder);
                }));
                global.Function.InitColor();
                global.Function.CreateAccessTimer(AccessTimer);
                InitChildrenForm();
            }
        }

        private void Guide_Load(object sender, EventArgs e)
        {
            Init();
            if (!IsChild)
            {
                bgwGuide.RunWorkerAsync();
            }
        }

        private void Init()
        {
            try
            {
                if (!IsChild)
                {
                    global.Function.InitIcon();
                }
                lbTime.Text = DateTime.Now.ToShortTimeString();
                pictureBoxMark.GetPictureList(global.Variable.IMAGEFolder);
                Style.SetGuideGrid(dgvGuide, lbTime, Height, Width, global.Variable.RowCount, Graphics.FromHwnd(this.Handle));
                GuideAdapter.GetData();
                ViewCommentText = GuideAdapter.Adapter.SelectCommand.CommandText;
                CreateRollingTimer(RollingTimer, dgvGuide, lbTime);
                CellFormat(dgvGuide);
                CreateLanguageTimer(timerLanguage, dgvGuide);
            }
            catch
            {
                SetMask(true);
            }
        }

        public void SetMask(bool show)
        {
            pictureBoxMark.Visible = show;
        }

        private void InitChildrenForm()
        {
            if (Screen.AllScreens.Length > 1)
            {
                foreach (var screen in Screen.AllScreens)
                {
                    var form = new Guide(true);
                    form.SetPosition(screen.WorkingArea.Location);
                    ChildrenForm.Add(form);
                    form.Show();
                }
            }
        }


        public void SetPosition(Point pos)
        {
            this.Location = pos;
        }
        private DataSetGuide.GuideDataTable GetGuideTable(int lastRowIndex, int perPage, int preHour, int afterMin, bool showError)
        {
            string where = " WHERE ";
            where += "(";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("timediff(orderTime,now())<'{0}'", new TimeSpan(0, preHour, 0).ToString());
            where += " AND ";
            where += string.Format("case when atd='' then true else timediff(now(),adatetime)<'{0}' END", new TimeSpan(0, afterMin, 0).ToString());
            where += ")";
            #endregion
            where += " OR ";
            where += "(forceshow=1)";
            where += " OR ";
            #region 全天显示延误取消航班
            where += "(";
            where += "true=" + showError.ToString();
            where += " AND ";
            where += "errorline=true";
            where += ")";
            #endregion
            where += ")";
            where += " AND forceshow<>2";
            where += string.Format(" limit {0},{1}", lastRowIndex, perPage * (ChildrenForm.Count + 1));
            GuideAdapter.Adapter.SelectCommand.CommandText = ViewCommentText + where;
            var table = GuideAdapter.GetData();
            return table;
        }

        private int SetSourceList(List<DataSetGuide.GuideRow> sourceRows, int rowCount)
        {
            var returnNum = 0;
            FlightsList.Clear();
            GuideList.Clear();
            ToviaLangList.Clear();
            RemarkList.Clear();
            foreach (DataSetGuide.GuideRow row in sourceRows)
            {
                //此处可能因为珠海的名称改变而发生错误，暂时不处理
                string tovia, roviaen;
                roviaen = row.en_tovia;
                tovia = row.tovia;
                var to = tovia.Split(' ');
                var toen = roviaen.Split(' ');

                List<string> toviaList = new List<string>();
                List<string> toviaenList = new List<string>();
                if (tovia.IndexOf('*') < 0)
                {
                    to.ToList().ForEach((o) =>
                    {
                        toviaList.Add(o);
                    });
                    toen.ToList().ForEach((o) =>
                    {
                        toviaenList.Add(o);
                    });
                }
                else
                {
                    var templist = tovia.Split('*')[1].Split(' ');

                    templist.ToList().GetRange(1, templist.Length - 1).ForEach((o) =>
                    {
                        toviaList.Add(o);
                    });

                    templist = roviaen.Split('*')[1].Split(' ');

                    templist.ToList().GetRange(1, templist.Length - 1).ForEach((o) =>
                    {
                        toviaenList.Add(o);
                    });
                }
                var dytovia = string.Join("", string.Join(" ", toviaList), string.Join(" ", toviaenList));
                var width = DrawGraphics.MeasureString(dytovia, new Font("黑体", Style.FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Width;
                if (width > TOVIA.Width)
                {
                    ToviaLangList.Add(new global.ConDouble()
                    {
                        point = new Point(dgvGuide.Columns[TOVIA.Name].Index, GuideList.Count),
                        showtext = string.Join(" ", toviaList),
                        hidetext = string.Join(" ", toviaenList)
                    });
                    dytovia = string.Join(" ", toviaList);
                }
                var flight = row.flight;
                var flights = row.flight.Split(',');
                if (flights.Length == 2)
                {
                    FlightsList.Add(new global.ConDouble()
                    {
                        point = new Point(dgvGuide.Columns[FLIGHT.Name].Index, GuideList.Count),
                        showtext = flights[0],
                        hidetext = flights[1]
                    });
                    flight = flights[0];
                }
                else if (flights.Length == 3)
                {
                    flight = flights[0];
                }
                var dynamic = new GuideEntity()
                {
                    std = row.std.Length > 0 ? (row.std.Substring(0, 2) + ":" + row.std.Substring(2, 2)) : string.Empty,
                    icon = global.Function.GetIcon(row.airlinecode),
                    flight = flight,
                    tovia = dytovia,
                    etd = row.etd.Length > 0 ? (row.etd.Substring(0, 2) + ":" + row.etd.Substring(2, 2)) : string.Empty,
                    gate = row.gate.IndexOf(">") >= 0 ? row.gate.Substring(row.gate.IndexOf(">") + 1) : row.gate,
                    remark = string.Join("", row.departstatus, row.en_departstatus).Trim()
                };
                EditRemark(dynamic, row);

                if (row.gate.IndexOf(">") >= 0)
                {
                    if (string.IsNullOrWhiteSpace(dynamic.remark))
                    {
                        dynamic.remark = "登机口变更Gate Change";
                    }
                    else
                    {
                        RemarkList.Add(new global.ConDouble()
                        {
                            point = new Point(dgvGuide.Columns[REMARK.Name].Index, GuideList.Count),
                            showtext = dynamic.remark,
                            hidetext = "登机口变更Gate Change"
                        });
                    }
                }
                
                GuideList.Add(dynamic);
                returnNum += 1;

                if (flights.Length == 3)
                {
                    GuideList.Add(new GuideEntity()
                    {
                        std = string.Empty,
                        icon = global.Function.GetIcon(flights[1].Substring(0, 2)),
                        flight = flights[1],
                        tovia = flights[2],
                        gate = string.Empty,
                        remark = string.Empty
                    });
                }
                if (GuideList.Count == rowCount)
                {
                    break;
                }
                else if (GuideList.Count > rowCount)
                {
                    while (GuideList.Last().std == string.Empty)
                    {
                        GuideList.Remove(GuideList.Last());
                    }
                    returnNum -= 1;
                    break;
                }
            }

            for (var i = GuideList.Count; i < rowCount; i++)
            {
                GuideList.Add(new GuideEntity()
                {
                    std = string.Empty,
                    icon = global.Function.GetIcon(string.Empty),
                    flight = string.Empty,
                    tovia = string.Empty,
                    etd = string.Empty,
                    gate = string.Empty,
                    remark = string.Empty
                });
                returnNum += 1;
            }
            return returnNum;
        }

        private void EditRemark(GuideEntity entity, DataSetGuide.GuideRow row)
        {
            if (entity.remark.IndexOf("延误") >= 0)
            {
                if (string.IsNullOrWhiteSpace(entity.etd))
                {
                    entity.remark = row.departoutward + entity.remark;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(row.departoutward))
                    {
                        entity.remark = "预计起飞ETD" + row.etd.Substring(0, 2) + ":" + row.etd.Substring(2, 2);
                    }
                    else
                    {
                        entity.remark = row.departoutward + "延误至ETD" + row.etd.Substring(0, 2) + ":" + row.etd.Substring(2, 2);
                    }
                }
            }
            else if (entity.remark.IndexOf("取消") >= 0)
            {
                entity.remark = row.departoutward + entity.remark;
            }
        }

        private List<DataSetGuide.GuideRow> GetSourceList(int index, int count, List<DataSetGuide.GuideRow> list)
        {
            if (list.Count >= index + count)
            {
                return list.GetRange(index, count).ToList();
            }
            else if (list.Count < index + count && list.Count > index)
            {
                return list.GetRange(index, list.Count - (index)).ToList();
            }
            else
            {
                return new List<DataSetGuide.GuideRow>();
            }
        }

        public int UpdateDataSource(int index, int count, List<DataSetGuide.GuideRow> tableList)
        {
            var list = GetSourceList(index, count, tableList);
            index += SetSourceList(list, count);
            this.dgvGuide.DataSource = GuideList;
            SetColor(list);
            this.Focus();
            dgvGuide.ClearSelection();
            SetMask((GuideList.Count == 0) || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit));
            return index;

        }


        private void SetColor(List<DataSetGuide.GuideRow> list)
        {
            //设定颜色
            foreach (DataGridViewRow row in dgvGuide.Rows)
            {
                var dataRow = list.Where(o => o.flight.IndexOf(row.Cells[FLIGHT.Name].Value.ToString()) >= 0).ToList();
                if (dataRow.Count > 0)
                {
                    row.DefaultCellStyle.ForeColor = global.Function.GetColor(dataRow[0].orgdepartstatus);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void bgwGuide_DoWork(object sender, DoWorkEventArgs e)
        {
            BackGroundWork();
        }
        private List<DataSetGuide.GuideRow> SortTable(DataSetGuide.GuideDataTable table)
        {
            return table.OrderBy((o) =>
            {
                var time = DateTime.ParseExact(o.std, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                time = time - global.Variable.TIMESPLIT;
                return time.ToString("HHmm");
            }).ToList();
        }
        private void BackGroundWork()
        {
            try
            {
                while (!this.IsDisposed)
                {
                    try
                    {
                        int preHour, afterMin, updateInterval;
                        bool showError;
                        GetConfig(out updateInterval, out preHour, out afterMin, out showError);
                        global.Variable.TIMESPLIT = global.Function.GetTimeSplit();
                        GuideTable = GetGuideTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);
                        if (LastRowIndex != 0 && GuideTable.Count == 0)
                        {
                            LastRowIndex = 0;
                            GuideTable = GetGuideTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);
                        }

                        int lastTableCount = 0;
                        this.Invoke(new RefreshHandle(() =>
                        {
                            var count = UpdateDataSource(0, global.Variable.RowCount, GuideTable.ToList());
                            lastTableCount += count;
                            LastRowIndex += count;
                        }));
                        for (var i = 1; i <= ChildrenForm.Count; i++)
                        {
                            ((Guide)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                var count = ((Guide)ChildrenForm[i]).UpdateDataSource(lastTableCount, global.Variable.RowCount, GuideTable.ToList());
                                lastTableCount += count;
                                LastRowIndex += count;
                            }));
                        }

                        global.Function.CountErrorTime();
                        Thread.Sleep(updateInterval * 1000);
                    }
                    catch (Exception ex)
                    {
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            SetMask(true);
                        });
                        this.Invoke(refresh);
                        for (var i = 1; i <= ChildrenForm.Count; i++)
                        {
                            ((Guide)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                ((Guide)ChildrenForm[i]).SetMask(true);
                            }));
                        }
                        Thread.Sleep(3000);
                    }
                }
            }
            catch
            {
            }
        }

        private void GetConfig(out int updateInterval, out int preHour, out int afterMin, out bool showError)
        {
            var row = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.guide)).ToArray();
            if (row.Length > 0)
            {
                updateInterval = row[0].updateinterval;
                preHour = row[0].advance;
                afterMin = row[0].delay;
            }
            else
            {
                updateInterval = 14;
                preHour = 4;
                afterMin = 15;
            }
            var interval = updateInterval;
            this.Invoke(new RefreshHandle(() =>
            {
                timerLanguage.Interval = interval * 1000 / 2;
                timerLanguage.Stop();
                timerLanguage.Start();
            }));
            showError = bool.Parse(data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.SHOWERRORLINECONFIG).ToArray()[0].value);
        }
    }
}
