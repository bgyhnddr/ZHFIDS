using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using data.DataSetDynamicViewTableAdapters;
using VCustomControls;

namespace data
{
    public partial class Editor : Form
    {
        private delegate void RefreshHandle();
        private flightdynamicdeparture_viewTableAdapter flightdepartureview = new flightdynamicdeparture_viewTableAdapter();
        private flightdynamicarrival_viewTableAdapter flightarrivalview = new flightdynamicarrival_viewTableAdapter();
        private DataSetDynamicView.flightdynamicdeparture_viewDataTable departureSourceTable = new DataSetDynamicView.flightdynamicdeparture_viewDataTable();
        private DataSetDynamicView.flightdynamicarrival_viewDataTable arrivalSourceTable = new DataSetDynamicView.flightdynamicarrival_viewDataTable();
        private data.FIDSDatasetTableAdapters.remarkinfoTableAdapter remarkinfoAdapter = new FIDSDatasetTableAdapters.remarkinfoTableAdapter();

        public Editor()
        {
            InitializeComponent();
            global.Function.CreateAccessTimer(AccessTimer);
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Init();
            bgwRefresh.RunWorkerAsync();
            filetransfer.FileIO.StartFileListen();
        }

        private void Init()
        {
            RefreshRemarkinfoDatasource();
        }


        private void RefreshDataSource()
        {
            RefreshDeparture();
            RefreshArrival();
        }

        private void RefreshArrival()
        {
            var tempTable = flightarrivalview.GetData();
            var table = tempTable.Clone();
            foreach (DataRow row in tempTable.Where(o => !string.IsNullOrWhiteSpace(o.sta)).OrderBy((o) => {
                var time = DateTime.ParseExact(o.sta, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                time = time - global.Variable.TIMESPLIT;
                return time.ToString("HHmm");
            }).ToArray().ToArray())
            {
                table.ImportRow(row);
            }
            arrivalSourceTable = (DataSetDynamicView.flightdynamicarrival_viewDataTable)InitDataSource(dgvDynamicArrival, arrivalSourceTable, table);
        }
        private void RefreshDeparture()
        {
            var tempTable = flightdepartureview.GetData();
            var table = tempTable.Clone();
            foreach (DataRow row in tempTable.Where(o => !string.IsNullOrWhiteSpace(o.std)).OrderBy((o) =>
            {
                var time = DateTime.ParseExact(o.std, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                time = time - global.Variable.TIMESPLIT;
                return time.ToString("HHmm");
            }).ToArray().ToArray())
            {
                table.ImportRow(row);
            }
            departureSourceTable = (DataSetDynamicView.flightdynamicdeparture_viewDataTable)InitDataSource(dgvDynamicDeparture, departureSourceTable, table);
        }

        private DataTable InitDataSource(VDataGridView dgv, DataTable sourceTable, DataTable table)
        {
            var rowfilter = table.DefaultView.RowFilter;
            var sort = table.DefaultView.Sort;
            if (sourceTable.Rows.Count != table.Rows.Count)
            {
                sourceTable = table;
                dgv.DataSource = sourceTable.DefaultView;
                sourceTable.DefaultView.RowFilter = rowfilter;
                sourceTable.DefaultView.Sort = sort;
            }
            else
            {
                for (var i = 0; i < sourceTable.Rows.Count; i++)
                {
                    if (DateTime.Parse(sourceTable.Rows[i][data.FIDSDataTable.FlightDynamic.lastmodifytimeColumn.ColumnName].ToString())
                        < DateTime.Parse(table.Rows[i][data.FIDSDataTable.FlightDynamic.lastmodifytimeColumn.ColumnName].ToString()))
                    {
                        sourceTable = table;
                        dgv.DataSource = sourceTable.DefaultView;
                        sourceTable.DefaultView.RowFilter = rowfilter;
                        sourceTable.DefaultView.Sort = sort;
                        break;
                    }
                }
            }

            return sourceTable;
        }

        private void GetConfig(out int updateInterval)
        {
            var rows = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.editor)).ToArray();
            if (rows.Length > 0)
            {
                updateInterval = rows[0].updateinterval;
            }
            else
            {
                updateInterval = 7;
            }
        }

        private void bgwRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.IsDisposed)
            {
                try
                {
                    int updateInterval;
                    GetConfig(out updateInterval);

                    global.Variable.TIMESPLIT = global.Function.GetTimeSplit();
                    this.Invoke(new RefreshHandle(() =>
                    {
                        RefreshDataSource();
                        RefreshConfig();
                    }));



                    Thread.Sleep(updateInterval * 1000);
                }
                catch
                {
                    Thread.Sleep(3000);
                }
            }
        }

        private void btnAddDepartureDynamic_Click(object sender, EventArgs e)
        {
            OpenDynamicDetail(string.Empty, true);
        }

        private void btnEditDepartureDynaimc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDynamicDeparture.CurrentRow.Index >= 0)
                {
                    OpenDynamicDetail(dgvDynamicDeparture.CurrentRow.Cells[data.FIDSDataTable.FlightDynamic.flightdynamicidColumn.ColumnName].Value.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void OpenDynamicDetail(string id, bool departure)
        {
            new DynamicDetail(id, departure).ShowDialog();
            if (departure)
            {
                RefreshDeparture();
            }
            else
            {
                RefreshArrival();
            }
        }


        private void btnDepartureFlightFilterClear_Click(object sender, EventArgs e)
        {
            departureSourceTable.DefaultView.RowFilter = tbDepartureFlightFilter.Text = string.Empty;
        }

        private void tbFlightFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FlightDepartureDynamicFliter(tbDepartureFlightFilter.Text);
            }
        }
        private void FlightDepartureDynamicFliter(string filter)
        {
            departureSourceTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", departureSourceTable.flightColumn.ColumnName, filter);
        }

        private void btnDepartureFlightFilter_Click(object sender, EventArgs e)
        {
            FlightDepartureDynamicFliter(tbDepartureFlightFilter.Text);
        }

        private void btnDeleteDepartureDynamic_Click(object sender, EventArgs e)
        {
            if (dgvDynamicDeparture.CurrentRow.Index >= 0)
            {
                if (MessageBox.Show(
                    string.Format(global.Const.DELETEWARN,
                    dgvDynamicDeparture.CurrentRow.Cells[departureSourceTable.flightColumn.ColumnName].Value),
                    global.Const.TIPS, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteDynamic(dgvDynamicDeparture.CurrentRow.Cells[departureSourceTable.flightdynamicidColumn.ColumnName].Value.ToString()))
                    {
                        RefreshDataSource();
                    }
                }
            }

        }

        private bool DeleteDynamic(string id)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var adapter = new data.FIDSDatasetTableAdapters.flightdynamicTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var table = adapter.GetData();
                var rows = table.Where(o => o.flightdynamicid == id).ToArray();
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                }
                adapter.Update(rows[0]);
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
                return false;
            }
            finally
            {
                adapter.Connection.Close();
            }
        }

        private void RefreshConfig()
        {
            try
            {
                var configTable = data.FIDSAdapter.ConfigAdapter.GetData();
                var connected = bool.Parse(configTable.Where(o => o.code == global.Const.CONNECTEDCONFIG).ToArray()[0].value);

                if (connected)
                {
                    lbDynamicStatus.Text = global.Const.NORMAL;
                    epEditor.SetError(lbDynamicStatus, string.Empty);
                }
                else
                {
                    lbDynamicStatus.Text = global.Const.UNNORMAL;
                    epEditor.SetError(lbDynamicStatus, global.Variable.WEBSERVICEERROR);
                }

                lbDynamicInterval.Text = configTable.Where(o => o.code == global.Const.UPDATEINTERVALCONFIG).ToArray()[0].value;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                //
            }
        }

        private void btnDynamicInterval_Click(object sender, EventArgs e)
        {
            global.Function.SetDynamicInterval();
            RefreshConfig();
        }

        private void btnGetDynamicByPlan_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(global.Const.GETDYNAMICBYPLANWARN, global.Const.TIPS, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var progressForm = new global.ProgressBar(global.Const.PLANTODYNAMIC);
                progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((s, eventArgs) =>
                {
                    var obj = (System.ComponentModel.BackgroundWorker)s;
                    try
                    {
                        global.Function.SetDynamicIntervalTime(0);
                        RefreshConfig();
                        obj.ReportProgress(0, "正在准备...");
                        for (var i = 0; i < 20; i++)
                        {
                            obj.ReportProgress(i, string.Empty);
                            Thread.Sleep(500);
                        }
                        if (global.Function.GetDynamicByPlan())
                        {
                            obj.ReportProgress(100, "完成");
                            this.Invoke(new RefreshHandle(() =>
                            {
                                RefreshDataSource();
                            }));
                        }
                        else
                        {
                            obj.ReportProgress(0, "失败");
                        }

                    }
                    catch (Exception ex)
                    {
                        obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                    }

                });
                progressForm.Show();

            }
        }

        private void RefreshRemarkinfoDatasource()
        {
            var table = remarkinfoAdapter.GetData();
            var view = table.AsDataView();
            var source = view.ToTable(true, table.codeColumn.ColumnName,
                table.colorColumn.ColumnName,
                table.errorlineColumn.ColumnName,
                table.departure_cnColumn.ColumnName,
                table.departure_enColumn.ColumnName,
                table.guide_cnColumn.ColumnName,
                table.guide_enColumn.ColumnName,
                table.arrival_cnColumn.ColumnName,
                table.arrival_enColumn.ColumnName,
                table.gate_cnColumn.ColumnName,
                table.gate_enColumn.ColumnName
                );
            dgvRemarkinfo.DataSource = source;
        }

        private void btnArrivalFlightFilter_Click(object sender, EventArgs e)
        {
            FlightArrivalDynamicFliter(tbArrivalFlightFilter.Text);
        }

        private void FlightArrivalDynamicFliter(string filter)
        {
            arrivalSourceTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", arrivalSourceTable.flightColumn.ColumnName, filter);
        }

        private void btnArrivalFlightFilterClear_Click(object sender, EventArgs e)
        {
            arrivalSourceTable.DefaultView.RowFilter = tbArrivalFlightFilter.Text = string.Empty;
        }

        private void btnAddArrivalDynamic_Click(object sender, EventArgs e)
        {
            OpenDynamicDetail(string.Empty, false);
        }

        private void btnEditArrivalDynaimc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDynamicArrival.CurrentRow.Index >= 0)
                {
                    OpenDynamicDetail(dgvDynamicArrival.CurrentRow.Cells[0].Value.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnDeleteArrivalDynamic_Click(object sender, EventArgs e)
        {
            if (dgvDynamicArrival.CurrentRow.Index >= 0)
            {
                if (MessageBox.Show(
                    string.Format(global.Const.DELETEWARN,
                    dgvDynamicArrival.CurrentRow.Cells[1].Value),
                    global.Const.TIPS, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteDynamic(dgvDynamicArrival.CurrentRow.Cells[0].Value.ToString()))
                    {
                        RefreshDataSource();
                    }
                }
            }
        }

        private void dgvDynamicDeparture_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvDynamicDeparture.CurrentRow.Index >= 0)
                    {
                        OpenDynamicDetail(dgvDynamicDeparture.CurrentRow.Cells[data.FIDSDataTable.FlightDynamic.flightdynamicidColumn.ColumnName].Value.ToString(), true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }

            e.Handled = true;
        }

        private void dgvDynamicArrival_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDynamicArrival.CurrentRow.Index >= 0)
                {
                    OpenDynamicDetail(dgvDynamicArrival.CurrentRow.Cells[0].Value.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void dgvDynamicArrival_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvDynamicArrival.CurrentRow.Index >= 0)
                    {
                        OpenDynamicDetail(dgvDynamicArrival.CurrentRow.Cells[0].Value.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }

            e.Handled = true;
        }

        private void dgvDynamicDeparture_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDynamicDeparture.Rows.Cast<DataGridViewRow>().ToList().ForEach((o) =>
            {
                switch (o.Cells[en_departstatus.Name].Value.ToString())
                {
                    case global.Const.DELAYED:
                        o.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case global.Const.CANCELLED:
                        o.DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            });
        }

        private void dgvDynamicArrival_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDynamicArrival.Rows.Cast<DataGridViewRow>().ToList().ForEach((o) => {
                switch (o.Cells[en_arrivalstatus.Name].Value.ToString())
                {
                    case global.Const.DELAYED:
                        o.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case global.Const.CANCELLED:
                        o.DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            });
        }

        private void dgvRemarkinfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRemarkinfo.Columns[e.ColumnIndex].Name == color.Name && e.RowIndex >= 0 && e.Value != null)
            {
                var colorargb = -1;
                int.TryParse(e.Value.ToString(), out colorargb);
                e.CellStyle.BackColor = Color.FromArgb(colorargb);
                e.Value = string.Empty;
            }
        }

        private void btnremarkadd_Click(object sender, EventArgs e)
        {
            new RemarkDetail(string.Empty).ShowDialog();
            RefreshRemarkinfoDatasource();
            
        }

        private void btneditremark_Click(object sender, EventArgs e)
        {
            if (dgvRemarkinfo.CurrentRow.Index >= 0)
            {
                var detail = new RemarkDetail(dgvRemarkinfo.CurrentRow.Cells[remark_code.Name].Value.ToString());
                detail.ShowDialog();
                RefreshRemarkinfoDatasource();
            }
        }

        private void btndeleteremarkinfo_Click(object sender, EventArgs e)
        {
            if (dgvRemarkinfo.CurrentRow.Index >= 0)
            {
                DeleteRemarkInfo(dgvRemarkinfo.CurrentRow.Cells[remark_code.Name].Value.ToString());
            }
        }

        private void DeleteRemarkInfo(string code)
        {
            var adatper = new data.FIDSDatasetTableAdapters.remarkinfoTableAdapter();
            var table = adatper.GetData();
            var deleteRow = table.Where(o => o.code == code).ToList();
            if(deleteRow.Count>0)
            {
                deleteRow[0].Delete();
                adatper.Update(table);
                RefreshRemarkinfoDatasource();
            }

        }

        private void dgvRemarkinfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvRemarkinfo.CurrentRow.Index >= 0)
            {
                var detail = new RemarkDetail(dgvRemarkinfo.CurrentRow.Cells[remark_code.Name].Value.ToString());
                detail.ShowDialog();
                RefreshRemarkinfoDatasource();
            }
        }

        private void tbDepartureFlightFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FlightDepartureDynamicFliter(tbDepartureFlightFilter.Text);
            }
        }

        private void tbArrivalFlightFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FlightArrivalDynamicFliter(tbArrivalFlightFilter.Text);
            }
        }

        private void dgvDynamicDeparture_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (dgvDynamicDeparture.CurrentRow.Index >= 0)
                {
                    OpenDynamicDetail(dgvDynamicDeparture.CurrentRow.Cells[data.FIDSDataTable.FlightDynamic.flightdynamicidColumn.ColumnName].Value.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }
    }
}
