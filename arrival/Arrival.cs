using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fidsstyle;
using System.Threading;

namespace data
{
    public partial class Arrival : global.BaseForm
    {
        private DataSetArrival.ArrivalDataTable ArrivalTable = new DataSetArrival.ArrivalDataTable();
        private DataSetArrivalTableAdapters.ArrivalTableAdapter ArrivalAdapter = new DataSetArrivalTableAdapters.ArrivalTableAdapter();
        private BindingList<ArrivalEntity> ArrivalList = new BindingList<ArrivalEntity>();

        public Arrival(bool isChild)
        {
            InitializeComponent();
            IsChild = isChild;
            if (!IsChild)
            {
                filetransfer.FileIO.StartFileListen(this, new filetransfer.FileIO.FinishHandle(() =>
                {
                    global.Function.InitIcon();
                }));
                global.Function.InitColor();
                global.Function.CreateAccessTimer(AccessTimer);
                InitChildrenForm();
            }
        }

        private void Arrival_Load(object sender, EventArgs e)
        {
            Init();
            if (!IsChild)
            {
                bgwArrival.RunWorkerAsync();
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
                global.Function.CreateErrorImage(pictureBoxMark);
                Style.SetArrivalGrid(dgvArrival, lbTime, Height, Width, global.Variable.RowCount, Graphics.FromHwnd(this.Handle));
                ArrivalAdapter.GetData();
                ViewCommentText = ArrivalAdapter.Adapter.SelectCommand.CommandText;
                CreateRollingTimer(RollingTimer, dgvArrival, lbTime);
                CellFormat(dgvArrival);
                CreateLanguageTimer(timerLanguage, dgvArrival);
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
                    var form = new Arrival(true);
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

        public int UpdateDataSource(int index, int count, List<DataSetArrival.ArrivalRow> tableList)
        {
            var list = GetSourceList(index, count, tableList);
            index += SetSourceList(list, count);
            this.dgvArrival.DataSource = this.ArrivalList;
            SetColor(list);
            this.Focus();
            dgvArrival.ClearSelection();
            SetMask((ArrivalList.Count == 0) || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit));
            return index;
        }

        private List<DataSetArrival.ArrivalRow> GetSourceList(int index, int count, List<DataSetArrival.ArrivalRow> list)
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
                return new List<DataSetArrival.ArrivalRow>();
            }
        }

        private DataSetArrival.ArrivalDataTable GetArrivalTable(int lastRowIndex, int perPage, int preHour, int afterMin, bool showError)
        {
            string where = " WHERE ";
            where += "(";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("timediff(orderTime,now())<'{0:D2}:00:00'", preHour);
            where += " AND ";
            where += string.Format("case when ata='' then true else timediff(now(),adatetime)<'{0}' END", new TimeSpan(0, afterMin, 0).ToString());
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
            ArrivalAdapter.Adapter.SelectCommand.CommandText = ViewCommentText + where;
            var table = ArrivalAdapter.GetData();
            return table;
        }


        private int SetSourceList(List<DataSetArrival.ArrivalRow> sourceRows, int rowCount)
        {
            var returnNum = 0;
            FlightsList.Clear();
            this.ArrivalList.Clear();
            ToviaLangList.Clear();
            RemarkList.Clear();
            foreach (DataSetArrival.ArrivalRow row in sourceRows)
            {
                //此处可能因为珠海的名称改变而发生错误，暂时不处理
                string from, fromen;
                string tovia, toviaen;
                fromen = row.en_from;
                toviaen = row.en_tovia;
                from = row.from;
                tovia = row.tovia;
                var to = tovia.Split(' ');
                var toen = toviaen.Split(' ');

                var fromviaList = new List<string>();
                var fromviaenList = new List<string>();
                fromviaList.Add(from);
                fromviaenList.Add(fromen);

                if (tovia.IndexOf("*") >= 0)
                {
                    var tempList = tovia.Split('*');
                    if (!string.IsNullOrWhiteSpace(tempList[0]))
                    {
                        tempList[0].Trim().Split(' ').ToList().ForEach((o) =>
                        {
                            fromviaList.Add(o);
                        });
                    }
                    tempList = toviaen.Split('*');
                    if (!string.IsNullOrWhiteSpace(tempList[0]))
                    {
                        tempList[0].Trim().Split(' ').ToList().ForEach((o) =>
                        {
                            fromviaenList.Add(o);
                        });
                    }
                }
                else
                {
                    for (var i = 0; i < to.Length - 1; i++)
                    {
                        fromviaList.Add(to[i]);
                        fromviaenList.Add(toen[i]);
                    }
                }
                var dyfromvia = string.Join("", string.Join(" ", fromviaList), string.Join(" ", fromviaenList));
                var width = DrawGraphics.MeasureString(dyfromvia, new Font("黑体", Style.FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Width;
                if (width > FROMVIA.Width)
                {
                    ToviaLangList.Add(new global.ConDouble()
                    {
                        point = new Point(dgvArrival.Columns[FROMVIA.Name].Index, ArrivalList.Count),
                        showtext = string.Join(" ", fromviaList),
                        hidetext = string.Join(" ", fromviaenList)
                    });
                    dyfromvia = string.Join(" ", fromviaList);
                }

                var flight = row.flight;
                var flights = row.flight.Split(',');
                if (flights.Length == 2)
                {
                    FlightsList.Add(new global.ConDouble()
                    {
                        point = new Point(dgvArrival.Columns[FLIGHT.Name].Index, ArrivalList.Count),
                        showtext = flights[0],
                        hidetext = flights[1]
                    });
                    flight = flights[0];
                }
                else if (flights.Length == 3)
                {
                    flight = flights[0];
                }

                var dynamic = new ArrivalEntity()
                {
                    sta = row.sta.Length > 0 ? (row.sta.Substring(0, 2) + ":" + row.sta.Substring(2, 2)) : string.Empty,
                    icon = global.Function.GetIcon(row.airlinecode),
                    flight = flight,
                    fromvia = dyfromvia,
                    eta = row.eta.Length > 0 ? (row.eta.Substring(0, 2) + ":" + row.eta.Substring(2, 2)) : string.Empty,
                    remark = string.Join("", row.arrivalstatus, row.en_arrivalstatus).Trim()
                };
                EditRemark(dynamic, row, returnNum);

                this.ArrivalList.Add(dynamic);
                returnNum += 1;

                if (flights.Length == 3)
                {
                    ArrivalList.Add(new ArrivalEntity()
                    {
                        sta = string.Empty,
                        icon = global.Function.GetIcon(flights[1].Substring(0, 2)),
                        flight = flights[1],
                        fromvia = flights[2],
                        remark = string.Empty
                    });
                }

                if (ArrivalList.Count == rowCount)
                {
                    break;
                }
                else if (ArrivalList.Count > rowCount)
                {
                    while (ArrivalList.Last().sta == string.Empty)
                    {
                        ArrivalList.Remove(ArrivalList.Last());
                    }
                    returnNum -= 1;
                    break;
                }
            }

            for (var i = this.ArrivalList.Count; i < rowCount; i++)
            {
                this.ArrivalList.Add(new ArrivalEntity()
                {
                    sta = string.Empty,
                    icon = global.Function.GetIcon(string.Empty),
                    flight = string.Empty,
                    fromvia = string.Empty,
                    eta = string.Empty,
                    remark = string.Empty
                });
            }
            return returnNum;
        }
        private void SetColor(List<DataSetArrival.ArrivalRow> list)
        {
            //设定颜色
            foreach (DataGridViewRow row in dgvArrival.Rows)
            {
                var dataRow = list.Where(o => o.flight.IndexOf(row.Cells[FLIGHT.Name].Value.ToString()) >= 0).ToList();
                if (dataRow.Count > 0)
                {
                    row.DefaultCellStyle.ForeColor = global.Function.GetColor(dataRow[0].orgarrivalstatus);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void EditRemark(ArrivalEntity entity, DataSetArrival.ArrivalRow row, int num)
        {
            if (entity.remark.IndexOf("延误") >= 0)
            {
                if (string.IsNullOrWhiteSpace(entity.eta))
                {
                    entity.remark = row.departoutward + entity.remark;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(row.departoutward))
                    {
                        entity.remark = string.Empty;
                    }
                    else
                    {
                        entity.remark = row.departoutward + entity.remark;
                    }
                }
            }
            else if (entity.remark.IndexOf("取消") >= 0)
            {
                entity.remark = row.arrivaloutward + entity.remark;
            }
        }

        private List<DataSetArrival.ArrivalRow> SortTable(DataSetArrival.ArrivalDataTable table)
        {
            return table.OrderBy((o) =>
            {
                var time = DateTime.ParseExact(o.sta, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                time = time - global.Variable.TIMESPLIT;
                return time.ToString("HHmm");
            }).ToList();
        }

        private void bgwArrival_DoWork(object sender, DoWorkEventArgs e)
        {
            BackGroundWork();
        }

        private void GetConfig(out int updateInterval, out int preHour, out int afterMin, out bool showError)
        {
            var rows = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.arrival)).ToArray();
            if (rows.Length > 0)
            {
                updateInterval = rows[0].updateinterval;
                preHour = rows[0].advance;
                afterMin = rows[0].delay;
            }
            else
            {
                updateInterval = 7;
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
                        ArrivalTable = GetArrivalTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);

                        if (LastRowIndex != 0 && ArrivalTable.Count == 0)
                        {
                            LastRowIndex = 0;
                            ArrivalTable = GetArrivalTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);
                        }
                        int lastTableCount = 0;

                        this.Invoke(new RefreshHandle(() =>
                        {
                            var count = UpdateDataSource(0, global.Variable.RowCount, ArrivalTable.ToList());
                            lastTableCount += count;
                            LastRowIndex += count;
                        }));

                        for (var i = 1; i <= ChildrenForm.Count; i++)
                        {
                            ((Arrival)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                var count = ((Arrival)ChildrenForm[i]).UpdateDataSource(lastTableCount, global.Variable.RowCount, ArrivalTable.ToList());
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
                            ((Arrival)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                ((Arrival)ChildrenForm[i]).SetMask(true);
                            }));
                        }
                        Thread.Sleep(3000);
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

    }
}
