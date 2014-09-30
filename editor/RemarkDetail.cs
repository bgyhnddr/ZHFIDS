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
    public partial class RemarkDetail : Form
    {
        private string _code;

        public RemarkDetail(string code)
        {
            InitializeComponent();
            _code = code;
        }

        private void Init()
        {
            var dictAdatper = new data.FIDSDatasetTableAdapters.dictionaryTableAdapter();
            var dictTable = dictAdatper.GetData().Where(o => o.type == global.Const.Dictionary_FlightStatus).OrderBy(o=>o.index).ToList();
            cbCode.DataSource = dictTable;
            cbCode.ValueMember = data.FIDSDataTable.Dictionary.codeColumn.ColumnName;
            cbCode.DisplayMember = data.FIDSDataTable.Dictionary.nameColumn.ColumnName;

            InitValue(_code);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save()
        {
            var adapter = new data.FIDSDatasetTableAdapters.remarkinfoTableAdapter();
            var table = adapter.GetData();
            var row = table.Where(o => o.code == cbCode.SelectedValue.ToString()).ToList();
            if (row.Count > 0)
            {
                row[0].code = cbCode.SelectedValue.ToString();
                row[0].color = btnColor.BackColor.ToArgb();
                row[0].departure_cn = tbDeparture.Text;
                row[0].departure_en = tbDepartureEn.Text;
                row[0].arrival_cn = tbArrival.Text;
                row[0].arrival_en = tbArrivalEn.Text;
                row[0].guide_cn = tbGuide.Text;
                row[0].guide_en = tbGuideEn.Text;
                row[0].gate_cn = tbGate.Text;
                row[0].gate_en = tbGateEn.Text;
                row[0].errorline = cbError.Checked;
                adapter.Update(row[0]);
            }
            else
            {
                var newrow = table.NewremarkinfoRow();
                newrow.code = cbCode.SelectedValue.ToString();
                newrow.color = btnColor.BackColor.ToArgb();
                newrow.departure_cn = tbDeparture.Text;
                newrow.departure_en = tbDepartureEn.Text;
                newrow.arrival_cn = tbArrival.Text;
                newrow.arrival_en = tbArrivalEn.Text;
                newrow.guide_cn = tbGuide.Text;
                newrow.guide_en = tbGuideEn.Text;
                newrow.gate_cn = tbGate.Text;
                newrow.gate_en = tbGateEn.Text;
                newrow.errorline = cbError.Checked;
                table.AddremarkinfoRow(newrow);
                adapter.Update(newrow);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void RemarkDetail_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void InitValue(string code)
        {
            var adapter = new data.FIDSDatasetTableAdapters.remarkinfoTableAdapter();
            var row = adapter.GetData().Where(o => o.code == code).ToList();
            if (row.Count > 0)
            {
                cbCode.SelectedValue = row[0].code;
                btnColor.BackColor = Color.FromArgb(row[0].color);
                colorSelector.Color = Color.FromArgb(row[0].color);
                tbDeparture.Text = row[0].departure_cn;
                tbDepartureEn.Text = row[0].departure_en;
                tbArrival.Text = row[0].arrival_cn;
                tbArrivalEn.Text = row[0].arrival_en;
                tbGuide.Text = row[0].guide_cn;
                tbGuideEn.Text = row[0].guide_en;
                tbGate.Text = row[0].gate_cn;
                tbGateEn.Text = row[0].gate_en;
                cbError.Checked = row[0].errorline;
            }
            else
            {
                btnColor.BackColor = Color.White;
                colorSelector.Color = Color.White;
                tbDeparture.Text = string.Empty;
                tbDepartureEn.Text = string.Empty;
                tbArrival.Text = string.Empty;
                tbArrivalEn.Text = string.Empty;
                tbGuide.Text = string.Empty;
                tbGuideEn.Text = string.Empty;
                tbGate.Text = string.Empty;
                tbGateEn.Text = string.Empty;
                cbError.Checked = false;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorSelector.ShowDialog();
            btnColor.BackColor = colorSelector.Color;
        }

        private void cbCode_SelectedValueChanged(object sender, EventArgs e)
        {
            InitValue(cbCode.SelectedValue.ToString());
        }
    }
}
