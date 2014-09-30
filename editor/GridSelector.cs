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
    public partial class GridSelector : Form
    {
        private List<DataRow> selectedRows;
        private DataTable tableSelector;
        private string showColumn;
        private bool multiple;
        public GridSelector(DataTable table, List<DataRow> selected, string title, string showcolumn, bool multi)
        {
            selectedRows = selected;
            tableSelector = table;
            InitializeComponent();
            this.Text = title;
            showColumn = showcolumn;
            multiple = multi;
        }

        private void GridSelector_Load(object sender, EventArgs e)
        {
            dgvSelect.DataSource = tableSelector.DefaultView;

            var selectArray = selectedRows.Select((o) => { return o[showColumn].ToString(); }).ToArray();
            if (selectArray.Length > 0)
            {
                tbValue.Text = string.Join(" ", selectArray);
            }
            cbFilter.Items.Clear();
            foreach (DataColumn column in tableSelector.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);
            }
            if (cbFilter.Items.Count > 0)
            {
                cbFilter.SelectedIndex = 0;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedRows.Clear();
            tbValue.Text = string.Empty;
        }

        private void btnFlilterNot_Click(object sender, EventArgs e)
        {
            tableSelector.DefaultView.RowFilter = string.Empty;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvSelect.CurrentRow.Index >= 0)
            {
                if (!multiple)
                {
                    selectedRows.Clear();
                }
                selectedRows.Add(tableSelector.Select(string.Format("{0}='{1}'", showColumn, dgvSelect.CurrentRow.Cells[showColumn].Value)).First());
                var selectArray = selectedRows.Select((o) => { return o[showColumn].ToString(); }).ToArray();
                if (selectArray.Length > 0)
                {
                    tbValue.Text = string.Join(" ", selectArray);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            tableSelector.DefaultView.RowFilter = string.Format("{0} like '%{1}%'", cbFilter.Text, tbFilter.Text);
        }
    }
}
