using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using global;
using System.Threading;
using System.Diagnostics;

namespace ZHFIDS
{
    public partial class FIDS : Form
    {
        public FIDS()
        {
            InitializeComponent();
        }


        private void FIDS_Load(object sender, EventArgs e)
        {
            this.Focus();
            cbSubsystem.Enabled = global.Variable.ADMIN;
            if (Function.CheckMySQLConnection())
            {
                BindComboBoxDataSource();
                InitValue();
            }
            else
            {
                MessageBox.Show(Const.MYSQLCONNECTIONERROR);
                Close();
            }
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            if (SaveValue())
            {
                try
                {
                    var type = (global.SubsystemType)Enum.Parse(typeof(global.SubsystemType), cbSubsystem.SelectedValue.ToString());
                    if (type == global.SubsystemType.server)
                    {
                        global.Function.StartGetPlanThread(Forms.NotifyForm.GetAutoPlanMenuItem());
                        global.Function.StartGetDynamicThread(Forms.NotifyForm.GetAutoDynamicMenuItem());
                    }
                    Forms.ChangeForm((global.SubsystemType)Enum.Parse(typeof(global.SubsystemType), cbSubsystem.SelectedValue.ToString()));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
                }
            }
        }

        private void tbIP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                IPAddress.Parse(tbIP.Text);
                FidsErrorProvider.SetError(tbIP, string.Empty);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.StackTrace);
                FidsErrorProvider.SetError(tbIP, global.Const.IP_VALIDATINGEMESSAGE);
                e.Cancel = true;
            }
        }

        private void tbPort_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ushort.Parse(tbPort.Text);
                FidsErrorProvider.SetError(tbPort, string.Empty);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                FidsErrorProvider.SetError(tbPort, global.Const.PORT_VALIDATINGEMESSAGE);
                e.Cancel = true;
            }
        }


        #region 自定义方法
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
        
        private void InitValue()
        {
            try
            {
                tbIP.Text = Variable.IP != null ? Variable.IP.ToString() : string.Empty;
                tbUser.Text = Variable.USER;
                tbPassword.Text = Variable.PASSWORD;
                tbGate.Text = Variable.GATE;
                cbStyle.Text = Variable.CSSSTYLE;
                tbCarouseld.Text = Variable.CAROUSELD;
                numRowCount.Value = Variable.RowCount;
                var rows = data.FIDSAdapter.IPCStatusAdapter.GetData().Where(o => o.ip == tbIP.Text).ToArray();
                if (rows.Length > 0)
                {
                    tbPort.Text = rows[0].port.ToString();
                    tbMAC.Text = rows[0].mac.ToString();
                    cbSubsystem.SelectedValue = rows[0].subsystem;
                    cbAutoAccess.Checked = rows[0].autoaccess;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(Const.BINDDATAERROR, ex.Message));
            }

        }

        private bool SaveValue()
        {
            var returnValue = false;
            if (ValidateChildren())
            {
                global.Variable.USER = tbUser.Text;
                global.Variable.PASSWORD = tbPassword.Text;
                global.Variable.RowCount = int.Parse(numRowCount.Value.ToString());
                global.Variable.GATE = tbGate.Text;
                global.Variable.CSSSTYLE = cbStyle.Text;
                global.Variable.CAROUSELD = tbCarouseld.Text;
                MySql.Data.MySqlClient.MySqlTransaction tran = null;
                var adapter = new data.FIDSDatasetTableAdapters.ipcstatusTableAdapter();
                try
                {
                    global.Variable.IP = IPAddress.Parse(tbIP.Text);
                    global.Variable.Port = ushort.Parse(tbPort.Text);
                    adapter.Connection.Open();
                    tran = adapter.Connection.BeginTransaction();
                    var table = adapter.GetData();
                    data.FIDSDataset.ipcstatusRow row;
                    var rows = table.Where(o => o.ip == global.Variable.IP.ToString()).ToArray();
                    if (rows.Length == 0)
                    {
                        row = table.NewipcstatusRow();
                        row.ip = global.Variable.IP.ToString();
                        row.port = ushort.Parse(tbPort.Text);
                        row.mac = tbMAC.Text;
                        row.subsystem = cbSubsystem.SelectedValue.ToString();
                        row.autoaccess = cbAutoAccess.Checked;
                        table.AddipcstatusRow(row);
                    }
                    else
                    {
                        row = rows[0];
                        row.ip = global.Variable.IP.ToString();
                        row.port = ushort.Parse(tbPort.Text);
                        row.mac = tbMAC.Text;
                        row.subsystem = cbSubsystem.SelectedValue.ToString();
                        row.autoaccess= cbAutoAccess.Checked;
                    }



                    adapter.Update(row);
                    tran.Commit();
                    returnValue = true;
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
                
            }
            return returnValue;
        }
        #endregion

        private void cbSubsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    var selected = (SubsystemType)Enum.Parse(typeof(SubsystemType), cbSubsystem.SelectedValue.ToString());
                    switch (selected)
                    {
                        case SubsystemType.server:
                            gbAccount.Visible = true;
                            gbGate.Visible = gbShowSetting.Visible = false;
                            Height = 342;
                            break;
                        case SubsystemType.gate:
                            gbAccount.Visible = gbShowSetting.Visible = false;
                            gbGate.Visible = true;
                            Height = 342;
                            break;
                        case SubsystemType.departure:
                        case SubsystemType.arrival:
                        case SubsystemType.guide:
                        case SubsystemType.carousel:
                            gbAccount.Visible = gbGate.Visible = false;
                            gbShowSetting.Visible = true;
                            lbCarouseld.Visible = tbCarouseld.Visible = false;
                            Height = 342;
                            break;
                        case SubsystemType.carouseld:
                            gbAccount.Visible = gbGate.Visible = false;
                            gbShowSetting.Visible = true;
                            lbCarouseld.Visible = tbCarouseld.Visible = true;
                            Height = 342;
                            break;
                        default:
                            gbAccount.Visible = gbGate.Visible = gbShowSetting.Visible = false;
                            Height = 262;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

    }
}
