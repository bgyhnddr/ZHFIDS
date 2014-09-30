using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace global
{
    public partial class ProgressBar : Form
    {
        public ProgressBar(string title)
        {
            InitializeComponent();

            this.Text = title;
        }



        private void ProgressBar_Load(object sender, EventArgs e)
        {
            this.fidsBackgroundWorker.RunWorkerAsync();
        }

        private void fidsBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.fidsProgress.Value = e.ProgressPercentage;

            var content = string.Join("\r\n", e.UserState.ToString(), tbStatus.Text);
            this.tbStatus.Text = content.Trim();
        }

        private void fidsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Text = "确定";
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "确定")
            {
                Close();
            }
            else
            {
                btnCancel.Enabled = false;
                this.fidsBackgroundWorker.CancelAsync();
            }
        }
    }
}
