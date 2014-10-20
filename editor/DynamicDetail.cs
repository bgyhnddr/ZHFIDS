using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace data
{
    public partial class DynamicDetail : Form
    {
        private string flightDynamicId;
        private data.FIDSDataset.flightdynamicRow dynamicRow;
        private data.FIDSDataset.flightdynamicDataTable dynamicTable;
        private data.FIDSDatasetTableAdapters.flightdynamicTableAdapter adapterDynamic;
        private data.FIDSDatasetTableAdapters.dictionaryTableAdapter adapterDictionary;
        private data.FIDSDatasetTableAdapters.airlineTableAdapter adapterAirline;
        private data.FIDSDatasetTableAdapters.airportTableAdapter adapterAirport;

        public DynamicDetail(string id, bool departure)
        {
            flightDynamicId = id;
            adapterDynamic = new data.FIDSDatasetTableAdapters.flightdynamicTableAdapter();
            adapterDictionary = new data.FIDSDatasetTableAdapters.dictionaryTableAdapter();
            adapterAirline = new data.FIDSDatasetTableAdapters.airlineTableAdapter();
            adapterAirport = new data.FIDSDatasetTableAdapters.airportTableAdapter();
            InitializeComponent();

            gbDepart.Visible = departure;
            gbArrival.Visible = !departure;
        }

        private void DynamicDetail_Load(object sender, EventArgs e)
        {
            InitValue();
        }

        private void InitDynamicSource()
        {
            dynamicTable = adapterDynamic.GetData();
            dynamicTable.Select((o) => { return o.forceshow; });
            var rows = dynamicTable.Where(o => o.flightdynamicid == flightDynamicId).ToArray();
            if (rows.Length > 0)
            {
                dynamicRow = rows[0];
            }

            var dictTable = adapterDictionary.GetData();
            var row = dictTable.NewdictionaryRow();
            row.index = -1;
            row.code = string.Empty;
            row.name = string.Empty;
            row.en_name = string.Empty;
            row.type = global.Const.Dictionary_FlightStatus;
            dictTable.AdddictionaryRow(row);
            var row2 = dictTable.NewdictionaryRow();
            row2.index = -1;
            row2.code = string.Empty;
            row2.name = string.Empty;
            row2.en_name = string.Empty;
            row2.type = global.Const.Dictionary_AbnormalCause;
            dictTable.AdddictionaryRow(row2); 
            #region dictbing
            cbArravalStatus.DataSource = ((data.FIDSDataset.dictionaryDataTable)dictTable.Copy()).Where(o => o.type == global.Const.Dictionary_FlightStatus).OrderBy(o => o.index).ToList();
            cbArravalStatus.ValueMember = dictTable.en_nameColumn.ColumnName;
            cbArravalStatus.DisplayMember = dictTable.nameColumn.ColumnName;
            cbArravalStatus.Text = string.Empty;

            cbDepartStatus.DataSource = ((data.FIDSDataset.dictionaryDataTable)dictTable.Copy()).Where(o => o.type == global.Const.Dictionary_FlightStatus).OrderBy(o => o.index).ToList();
            cbDepartStatus.ValueMember = dictTable.en_nameColumn.ColumnName;
            cbDepartStatus.DisplayMember = dictTable.nameColumn.ColumnName;
            cbDepartStatus.Text = string.Empty;


            cbDepartError.DataSource = cbDepartErrorEN.DataSource = ((data.FIDSDataset.dictionaryDataTable)dictTable.Copy()).Where(o => o.type == global.Const.Dictionary_AbnormalCause).OrderBy(o => o.index).ToList();
            cbDepartError.DisplayMember = dictTable.nameColumn.ColumnName;
            cbDepartErrorEN.DisplayMember = dictTable.en_nameColumn.ColumnName;
            cbDepartError.Text = cbDepartErrorEN.Text = string.Empty;

            cbArrivalError.DataSource = cbArrivalErrorEN.DataSource = ((data.FIDSDataset.dictionaryDataTable)dictTable.Copy()).Where(o => o.type == global.Const.Dictionary_AbnormalCause).OrderBy(o => o.index).ToList();
            cbArrivalError.DisplayMember = dictTable.nameColumn.ColumnName;
            cbArrivalErrorEN.DisplayMember = dictTable.en_nameColumn.ColumnName;
            cbArrivalError.Text = cbArrivalErrorEN.Text = string.Empty;

            #endregion
        }

        private void SetAuth(bool isManual)
        {
            tbFlight.ReadOnly = !isManual;
            btnAirline.Enabled = isManual;
            btnArrival.Enabled = isManual;
            btnDepart.Enabled = isManual;
            btnVia.Enabled = isManual;
            tbSTD.ReadOnly = !isManual;
            tbSTA.ReadOnly = !isManual;
        }

        private void InitValue()
        {
            InitDynamicSource();

            if (dynamicRow != null)
            {
                tbFlight.Text = dynamicRow.flight;

                #region airline
                var airlineRows = adapterAirline.GetData().Where(o => o.code == dynamicRow.airlinecode).ToArray();
                if (airlineRows.Length > 0)
                {
                    btnAirline.Text = airlineRows[0].name;
                }
                #endregion

                var airportTable = adapterAirport.GetData();

                #region depart
                var departRow = airportTable.Where(o => o.name == dynamicRow.from).ToArray();
                if (departRow.Length > 0)
                {
                    btnDepart.Text = departRow[0].name;
                }
                #endregion

                #region arrival
                var arrivalRow = airportTable.Where(o => o.name == dynamicRow.tovia.Split(' ').Last()).ToArray();
                if (arrivalRow.Length > 0)
                {
                    btnArrival.Text = arrivalRow[0].name;
                }
                #endregion

                #region via
                var viaRow = airportTable.Where(o =>
                    (dynamicRow.tovia.LastIndexOf(' ') >= 0 ?
                    dynamicRow.tovia.Substring(0, dynamicRow.tovia.LastIndexOf(' ')).Replace("*", string.Empty) : string.Empty).IndexOf(o.name) >= 0).ToArray();

                if (viaRow.Length > 0)
                {
                    btnVia.Text = string.Join(" ", viaRow.Select(o => o.name).ToArray());
                }
                #endregion

                #region showmode
                switch (dynamicRow.forceshow)
                {
                    case 0:
                        cbShowMode.Text = "不控制";
                        break;
                    case 1:
                        cbShowMode.Text = "强制显示";
                        break;
                    case 2:
                        cbShowMode.Text = "强制不显示";
                        break;
                }
                #endregion

                #region time
                //sta
                tbSTA.Text = dynamicRow.sta;
                //eta
                tbETA.Text = dynamicRow.eta;
                //ata
                tbATA.Text = dynamicRow.ata;
                //std
                tbSTD.Text = dynamicRow.std;
                //etd
                tbETD.Text = dynamicRow.etd;
                //atd
                tbATD.Text = dynamicRow.atd;
                #endregion


                var dictionaryTable = adapterDictionary.GetData();

                #region status
                var arrivalstatus = dictionaryTable.Where(o=>o.name == dynamicRow.arrivalstatus).ToArray();
                if (arrivalstatus.Length > 0)
                {
                    cbArravalStatus.Text = dynamicRow.arrivalstatus;
                }

                var departstatus = dictionaryTable.Where(o => o.name == dynamicRow.departstatus).ToArray();
                if (departstatus.Length > 0)
                {
                    cbDepartStatus.Text = dynamicRow.departstatus;
                }

                cbDepartError.Text = dynamicRow.departoutward;
                cbDepartErrorEN.Text = dynamicRow.departoutward_en;
                cbArrivalError.Text = dynamicRow.arrivaloutward;
                cbArrivalErrorEN.Text = dynamicRow.arrivaloutward_en;
                #endregion

                #region other
                tbCarousel.Text = dynamicRow.carousel;
                tbCounter.Text = dynamicRow.counter;
                tbGate.Text = dynamicRow.gate;
                #endregion

                cbManual.Checked = dynamicRow.manual;
                btnConfirm.Focus();
            }
            else
            {
                dynamicRow = dynamicTable.NewflightdynamicRow();
                dynamicRow.flightdynamicid = Guid.NewGuid().ToString();
                cbShowMode.Text = "不控制";
                cbManual.Checked = true;
            }

            SetAuth(cbManual.Checked);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveValueAndExit();
        }

        private void SaveValueAndExit()
        {
            if (ValidateChildren())
            {
                if (SaveValue())
                {
                    Close();
                }
            }
        }

        private bool SaveValue()
        {
            var adapter = new data.FIDSDatasetTableAdapters.flightdynamicTableAdapter();
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            try
            {
                adapter.Connection.Open();
                #region from tovia
                string to = string.Empty, toen = string.Empty, via = string.Empty, viaen = string.Empty;
                var airportTable = adapterAirport.GetData();
                var arrivalRows = airportTable.Where(o => btnArrival.Text.IndexOf(o.name) >= 0).ToArray();
                if (arrivalRows.Length > 0)
                {
                    to = arrivalRows[0].name;
                    toen = arrivalRows[0].nameEn;
                }
                var viaRows = airportTable.Where(o => btnVia.Text.IndexOf(o.name) >= 0).ToArray();
                if (viaRows.Length > 0)
                {
                    via = string.Join(" ", viaRows.Select((o) =>
                    {
                        if (o.code == global.Const.ZUH)
                        {
                            o.name = "*" + o.name;
                        }
                        return o.name;
                    }).ToArray()) + " ";

                    viaen = string.Join(" ", viaRows.Select((o) =>
                    {
                        if (o.code == global.Const.ZUH)
                        {
                            o.nameEn = "*" + o.nameEn;
                        }
                        return o.nameEn;
                    }).ToArray()) + " ";
                }
                dynamicRow.tovia = via + to;
                dynamicRow.en_tovia = viaen + toen;
                #endregion

                dynamicRow.date = DateTime.Now.ToString(global.Const.DATEFORMAT);
                dynamicRow.flight = tbFlight.Text;
                dynamicRow.sta = tbSTA.Text;
                dynamicRow.eta = tbETA.Text;
                dynamicRow.ata = tbATA.Text;
                dynamicRow.std = tbSTD.Text;
                dynamicRow.etd = tbETD.Text;
                dynamicRow.atd = tbATD.Text;
                dynamicRow.counter = tbCounter.Text;
                dynamicRow.gate = tbGate.Text;
                dynamicRow.carousel = tbCarousel.Text;
                dynamicRow.forceshow = cbShowMode.Text == "强制显示" ? 1 : (cbShowMode.Text == "强制不显示" ? 1 : 0);
                dynamicRow.manual = cbManual.Checked;

                dynamicRow.departstatus = cbDepartStatus.Text;
                dynamicRow.en_departstatus = cbDepartStatus.SelectedValue.ToString();
                dynamicRow.departoutward = cbDepartError.Text;
                dynamicRow.departoutward_en = cbDepartErrorEN.Text;
                dynamicRow.arrivalstatus = cbArravalStatus.Text;
                dynamicRow.en_arrivalstatus = cbArravalStatus.SelectedValue.ToString();
                dynamicRow.arrivaloutward = cbArrivalError.Text;
                dynamicRow.arrivaloutward_en = cbArrivalErrorEN.Text;



                tran = adapter.Connection.BeginTransaction();
                var table = adapter.GetData();
                data.FIDSDataset.flightdynamicRow updateRow;
                var selectRow = table.Where(o => o.flightdynamicid == dynamicRow.flightdynamicid).ToArray();
                if (selectRow.Length > 0)
                {
                    updateRow = selectRow[0];
                }
                else
                {
                    updateRow = table.NewflightdynamicRow();
                }

                foreach (DataColumn col in table.Columns)
                {
                    updateRow[col] = dynamicRow[col.ColumnName];
                }

                updateRow.lastmodifytime = DateTime.Now;

                if (selectRow.Length == 0)
                {
                    table.AddflightdynamicRow(updateRow);
                }

                adapter.Update(updateRow);

                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                MessageBox.Show(string.Format(global.Const.SAVEDATAERROR, ex.Message));
                return false;
            }
            finally
            {
                adapter.Connection.Close();
            }

        }

        private bool ValidateNotNull(Control sender)
        {
            if (sender.Text == string.Empty)
            {
                errorProviderDetail.SetError(sender, global.Const.NOTNULL);
                return false;
            }
            else
            {
                errorProviderDetail.SetError(sender, string.Empty);
                return true;
            }
        }

        private void btnAirline_Click(object sender, EventArgs e)
        {
            try
            {
                var table = adapterAirline.GetData();
                var selectrows = table.Where(o => btnAirline.Text.IndexOf(o.name) >= 0).ToArray();
                var selectedIndex = new List<DataRow>();
                if (selectrows.Length > 0)
                {
                    selectedIndex.Add(selectrows[0]);
                }
                new GridSelector(table, selectedIndex, "航空公司", table.nameColumn.ColumnName, false).ShowDialog();
                var selectArray = selectedIndex.Select((o) => { return o[table.nameColumn.ColumnName].ToString(); }).ToArray();
                btnAirline.Text = string.Join(" ", selectArray);

                selectrows = table.Where(o => btnAirline.Text.IndexOf(o.name) >= 0).ToArray();
                if(selectrows.Length>0)
                {
                    dynamicRow.airlinecode = selectrows[0].code;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnDepart_Click(object sender, EventArgs e)
        {
            try
            {
                var table = adapterAirport.GetData();
                var selectrows = table.Where(o => btnDepart.Text.IndexOf(o.name) >= 0).ToArray();
                var selectedIndex = new List<DataRow>();
                if (selectrows.Length > 0)
                {
                    selectedIndex.Add(selectrows[0]);
                }
                new GridSelector(table, selectedIndex, "机场", table.nameColumn.ColumnName, false).ShowDialog();
                var selectArray = selectedIndex.Select((o) => { return o[table.nameColumn.ColumnName].ToString(); }).ToArray();
                btnDepart.Text = string.Join(" ", selectArray);

                selectrows = table.Where(o => btnDepart.Text.IndexOf(o.name) >= 0).ToArray();
                if (selectrows.Length > 0)
                {
                    dynamicRow.from = selectrows[0].name;
                    dynamicRow.en_from = selectrows[0].nameEn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnArrival_Click(object sender, EventArgs e)
        {
            try
            {
                var table = adapterAirport.GetData();
                var selectrows = table.Where(o => btnArrival.Text.IndexOf(o.name) >= 0).ToArray();
                var selectedIndex = new List<DataRow>();
                if (selectrows.Length > 0)
                {
                    selectedIndex.Add(selectrows[0]);
                }
                new GridSelector(table, selectedIndex, "机场", table.nameColumn.ColumnName, false).ShowDialog();
                var selectArray = selectedIndex.Select((o) => { return o[table.nameColumn.ColumnName].ToString(); }).ToArray();
                btnArrival.Text = string.Join(" ", selectArray);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnVia_Click(object sender, EventArgs e)
        {
            try
            {
                var table = adapterAirport.GetData();
                var selectrows = table.Where(o => btnVia.Text.IndexOf(o.name) >= 0).ToArray();
                var selectedIndex = new List<DataRow>();
                foreach (var row in selectrows)
                {
                    selectedIndex.Add(row);
                }
                new GridSelector(table, selectedIndex, "机场", table.nameColumn.ColumnName, true).ShowDialog();
                var selectArray = selectedIndex.Select((o) => { return o[table.nameColumn.ColumnName].ToString(); }).ToArray();
                btnVia.Text = string.Join(" ", selectArray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void Time_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((TextBox)sender).Text.Length > 0)
                {
                    DateTime.ParseExact(((TextBox)sender).Text, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                    errorProviderDetail.SetError(((TextBox)sender), string.Empty);
                }
            }
            catch
            {
                errorProviderDetail.SetError(((TextBox)sender), global.Const.FORMATERROR);
                e.Cancel = true;
            }
        }

        private void NOTNULL_Validating(object sender, CancelEventArgs e)
        {
            ValidateNotNull((Control)sender);
        }

        private void cbManual_CheckedChanged(object sender, EventArgs e)
        {
            SetAuth(cbManual.Checked);
        }
    }
}
