using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fidsstyle;
using data.DataSetDepartureTableAdapters;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace data
{
    public partial class Departure : global.BaseForm
    {
        private DataSetDeparture.DepartureDataTable DepartureTable = new DataSetDeparture.DepartureDataTable();
        private DataSetDepartureTableAdapters.DepartureTableAdapter DepartureAdapter = new DataSetDepartureTableAdapters.DepartureTableAdapter();
        private BindingList<DepartureEntity> DepartureList = new BindingList<DepartureEntity>();

        public Departure(bool isChild)
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
        private void InitChildrenForm()
        {
            if (Screen.AllScreens.Length > 1)
            {
                foreach (var screen in Screen.AllScreens)
                {
                    var form = new Departure(true);
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
        private void Departure_Load(object sender, EventArgs e)
        {
            Init();
            if (!IsChild)
            {
                bgwDeparture.RunWorkerAsync();
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
                Style.SetDepartureGrid(dgvDeparture, lbTime, Height, Width, global.Variable.RowCount, Graphics.FromHwnd(this.Handle));
                DepartureAdapter.GetData();
                ViewCommentText = DepartureAdapter.Adapter.SelectCommand.CommandText;
                CreateRollingTimer(RollingTimer, dgvDeparture, lbTime);
                CellFormat(dgvDeparture);
                CreateLanguageTimer(timerLanguage, dgvDeparture);
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
        private DataSetDeparture.DepartureDataTable GetDepartureTable(int lastRowIndex, int perPage, int preHour, int afterMin, bool showError)
        {
            string where = " WHERE ";
            where += "(";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("timediff(orderTime,now())<'{0:D2}:00:00'", preHour);
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
            DepartureAdapter.Adapter.SelectCommand.CommandText = ViewCommentText + where;
            var table = DepartureAdapter.GetData();
            return table;
        }
        public int UpdateDataSource(int index, int count, List<DataSetDeparture.DepartureRow> tableList)
        {
            var list = GetSourceList(index, count, tableList);
            index += SetSourceList(list, count);
            this.dgvDeparture.DataSource = DepartureList;
            SetColor(list);
            this.Focus();
            dgvDeparture.ClearSelection();
            SetMask((DepartureList.Count == 0) || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit));
            return index;
        }

        private void SetColor(List<DataSetDeparture.DepartureRow> list)
        {
            //设定颜色
            foreach (DataGridViewRow row in dgvDeparture.Rows)
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
        private int SetSourceList(List<DataSetDeparture.DepartureRow> sourceRows, int rowCount)
        {
            var returnNum = 0;
            FlightsList.Clear();
            DepartureList.Clear();
            ToviaLangList.Clear();
            RemarkList.Clear();
            foreach (DataSetDeparture.DepartureRow row in sourceRows)
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
                        point = new Point(dgvDeparture.Columns[TOVIA.Name].Index, DepartureList.Count),
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
                        point = new Point(dgvDeparture.Columns[FLIGHT.Name].Index, DepartureList.Count),
                        showtext = flights[0],
                        hidetext = flights[1]
                    });
                    flight = flights[0];
                }
                else if (flights.Length == 3)
                {
                    flight = flights[0];
                }

                var dynamic = new DepartureEntity()
                {
                    std = row.std.Length > 0 ? (row.std.Substring(0, 2) + ":" + row.std.Substring(2, 2)) : string.Empty,
                    icon = global.Function.GetIcon(row.airlinecode),
                    flight = flight,
                    tovia = dytovia,
                    counter = row.counter,
                    gate = row.gate,
                    remark = string.Join("", row.departstatus, row.en_departstatus).Trim()
                };
                EditRemark(dynamic, row, returnNum);

                DepartureList.Add(dynamic);
                returnNum += 1;

                if (flights.Length == 3)
                {
                    DepartureList.Add(new DepartureEntity()
                    {
                        std = string.Empty,
                        icon = global.Function.GetIcon(flights[1].Substring(0,2)),
                        flight = flights[1],
                        tovia = flights[2],
                        counter = string.Empty,
                        gate = string.Empty,
                        remark = string.Empty
                    });
                }

                if (DepartureList.Count == rowCount)
                {
                    break;
                }
                else if (DepartureList.Count > rowCount)
                {
                    while (DepartureList.Last().std == string.Empty)
                    {
                        DepartureList.Remove(DepartureList.Last());
                    }
                    returnNum -= 1;
                    break;
                }
            }

            for (var i = DepartureList.Count; i < rowCount; i++)
            {
                DepartureList.Add(new DepartureEntity()
                {
                    std = string.Empty,
                    icon = global.Function.GetIcon(string.Empty),
                    flight = string.Empty,
                    tovia = string.Empty,
                    counter = string.Empty,
                    gate = string.Empty,
                    remark = string.Empty
                });
            }

            return returnNum;
        }
        private void EditRemark(DepartureEntity entity, DataSetDeparture.DepartureRow row,int num)
        {
            if (entity.remark.IndexOf("延误") >= 0)
            {
                if (string.IsNullOrWhiteSpace(row.etd))
                {
                    entity.remark = row.departoutward + entity.remark;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(row.departoutward))
                    {
                        entity.remark = "预计起飞ETD" + row.etd;
                    }
                    else
                    {
                        entity.remark = row.departoutward + "延误至ETD" + row.etd;
                    }
                }
            }
            else if (entity.remark.IndexOf("取消") >= 0)
            {
                entity.remark = row.departoutward + entity.remark;
            }
        }

        private List<DataSetDeparture.DepartureRow> GetSourceList(int index, int count, List<DataSetDeparture.DepartureRow> list)
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
                return new List<DataSetDeparture.DepartureRow>();
            }
        }
        private void bgwDeparture_DoWork(object sender, DoWorkEventArgs e)
        {
            BackGroundWork();
        }
        private List<DataSetDeparture.DepartureRow> SortTable(DataSetDeparture.DepartureDataTable table)
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
                        DepartureTable = GetDepartureTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);

                        if (LastRowIndex != 0 && DepartureTable.Count == 0)
                        {
                            LastRowIndex = 0;
                            DepartureTable = GetDepartureTable(LastRowIndex, global.Variable.RowCount, preHour, afterMin, showError);
                        }

                        int lastTableCount = 0;

                        this.Invoke(new RefreshHandle(() =>
                        {
                            var count = UpdateDataSource(0, global.Variable.RowCount, DepartureTable.ToList());
                            lastTableCount += count;
                            LastRowIndex += count;
                        }));
                        for (var i = 1; i <= ChildrenForm.Count; i++)
                        {
                            ((Departure)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                var count = ((Departure)ChildrenForm[i]).UpdateDataSource(lastTableCount, global.Variable.RowCount, DepartureTable.ToList());
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
                            ((Departure)ChildrenForm[i]).Invoke(new RefreshHandle(() =>
                            {
                                ((Departure)ChildrenForm[i]).SetMask(true);
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
            var row = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.departure)).ToArray();
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
