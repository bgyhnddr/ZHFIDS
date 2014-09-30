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
    public partial class SubsystemDetail : Form
    {
        private string subSystem;
        private data.FIDSDataset.subsystemRow subRow;
        private data.FIDSDatasetTableAdapters.subsystemTableAdapter adapter = new data.FIDSDatasetTableAdapters.subsystemTableAdapter();

        public SubsystemDetail(string sub)
        {
            subSystem = sub;
            InitializeComponent();
        }

        private void SubsystemDetail_Load(object sender, EventArgs e)
        {
            InitValue();
        }

        private void InitValue()
        {
            try
            {
                subRow = adapter.GetData().Where(o => o.code == subSystem).ToArray()[0];
                lbSubsystem.Text = subRow.name;
                numAdvance.Value = subRow.advance;
                numDelay.Value = subRow.delay;
                numInterval.Value = subRow.updateinterval;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UpdateValue();
            Close();
        }

        private void UpdateValue()
        {
            try
            {
                subRow.advance = (int)numAdvance.Value;
                subRow.delay = (int)numDelay.Value;
                subRow.updateinterval = (int)numInterval.Value;

                adapter.Update(subRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }
    }
}
