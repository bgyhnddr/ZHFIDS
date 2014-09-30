using global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace data
{
    public partial class IPCEditor : Form
    {
        public IPCEditor(string ip)
        {
            InitializeComponent();
            BindComboBoxDataSource();
            InitValue(ip);
        }

        private void IPCEditor_Load(object sender, EventArgs e)
        {
        }

        private void InitValue(string ip)
        {
            var table = data.FIDSAdapter.IPCStatusAdapter.GetData().Where(o=>o.ip == ip).ToArray();
            if (table.Length > 0)
            {
                tbIP.Text = table[0].ip;
                tbPort.Text = table[0].port.ToString();
                tbMAC.Text = table[0].mac;
                cbSubsystem.SelectedValue = table[0].subsystem;
                cbAutoAccess.Checked = table[0].autoaccess;
            }
        }

        private bool SaveVlue(string ip)
        {
            MySql.Data.MySqlClient.MySqlTransaction tran = null;
            var adapter = new data.FIDSDatasetTableAdapters.ipcstatusTableAdapter();
            try
            {
                adapter.Connection.Open();
                tran = adapter.Connection.BeginTransaction();
                var table = adapter.GetData();
                var rows = table.Where(o => o.ip == ip).ToArray();

                if(rows.Length>0)
                {
                    rows[0].ip = tbIP.Text;
                    rows[0].port = int.Parse(tbPort.Text);
                    rows[0].mac = tbMAC.Text;
                    rows[0].subsystem = cbSubsystem.SelectedValue.ToString();
                    rows[0].autoaccess = cbAutoAccess.Checked;
                    adapter.Update(rows[0]);
                }
                else
                {
                    var row = table.NewipcstatusRow();
                    row.ip = tbIP.Text;
                    row.port = int.Parse(tbPort.Text);
                    row.mac = tbMAC.Text;
                    row.subsystem = cbSubsystem.SelectedValue.ToString();
                    row.autoaccess = cbAutoAccess.Checked;
                    table.AddipcstatusRow(row);
                    adapter.Update(table);
                }
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                if (tran != null)
                {
                    tran.Rollback();
                }
                MessageBox.Show(string.Format(global.Const.SAVEDATAERROR, ex.Message));
            }
            finally
            {
                adapter.Connection.Close();
            }
            return false;
        }

        private void BindComboBoxDataSource()
        {
            try
            {
                var subTable = data.FIDSAdapter.SubsystemAdapter.GetData();
                cbSubsystem.ValueMember = subTable.codeColumn.ColumnName;
                cbSubsystem.DisplayMember = subTable.nameColumn.ColumnName;
                cbSubsystem.DataSource = subTable;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(Const.BINDINGSUBSYSTEMCOMBOBOXERROR, ex.Message));
            }
        }

        private void tbIP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                IPAddress.Parse(tbIP.Text);
                epTips.SetError(tbIP, string.Empty);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                epTips.SetError(tbIP, global.Const.IP_VALIDATINGEMESSAGE);
                e.Cancel = true;
            }
        }

        private void tbPort_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ushort.Parse(tbPort.Text);
                epTips.SetError(tbPort, string.Empty);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                epTips.SetError(tbPort, global.Const.PORT_VALIDATINGEMESSAGE);
                e.Cancel = true;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                if (SaveVlue(tbIP.Text))
                {
                    this.Close();
                }
            }
        }
    }
}
