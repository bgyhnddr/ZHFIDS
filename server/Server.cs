using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using global.EOSFIDSReference;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Management;

namespace data
{
    public partial class Server : Form
    {
        private delegate void RefreshHandle();
        private int updateinterval;

        public Server()
        {
            InitializeComponent();
            global.Function.CreateAccessTimer(AccessTimer);
            filetransfer.FileIO.StartFileListen();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            BindingIPCStatusSubsystemDataSource();
            BindingIPCStatus();
            RefreshConfig();
            RefreshSubsystem();
            global.Variable.TIMESPLIT = global.Function.GetTimeSplit();
            bgwIPCStatus.RunWorkerAsync();
        }
        
        private void btnLogoFolder_Click(object sender, EventArgs e)
        {
            filetransfer.FileIO.OpenLogoFolder();
        }

        private void btnADFolder_Click(object sender, EventArgs e)
        {
            filetransfer.FileIO.OpenADFolder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteIPCStatus();
        }

        private void btnDynamicInterval_Click(object sender, EventArgs e)
        {
            global.Function.SetDynamicInterval();
            RefreshConfig();
        }


        #region 自定义方法
        private void BindingIPCStatus()
        {
            try
            {
                dglIPCStatus.DataSource = data.FIDSAdapter.IPCStatusAdapter.GetData();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.BINDDATAERROR, ex.Message));
            }
        }

        private void BindingIPCStatusSubsystemDataSource()
        {
            try
            {
                var table = data.FIDSAdapter.SubsystemAdapter.GetData();
                DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)(dglIPCStatus.Columns[data.FIDSDataTable.IPCStatus.subsystemColumn.ColumnName]);
                column.DataSource = table;
                column.ValueMember = table.codeColumn.ColumnName;
                column.DisplayMember = table.nameColumn.ColumnName;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.BINDINGSUBSYSTEMCOMBOBOXERROR, ex.Message));
            }
        }
        
        private void OpenSubsystemDetail(string code)
        {
            new SubsystemDetail(code).ShowDialog();
            RefreshSubsystem();
        }

        private void RefreshSubsystem()
        {
            dgvSubsystem.DataSource = data.FIDSAdapter.SubsystemAdapter.GetData();
        }

        private void RefreshIPCStatus()
        {
            try
            {
                dglIPCStatus.DataSource = data.FIDSAdapter.IPCStatusAdapter.GetData();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.BINDDATAERROR, ex.Message));
            }
        }



        private void DeleteIPCStatus()
        {
            try
            {
                var deleterow = dglIPCStatus.SelectedRows;
                if (deleterow.Count > 0)
                {
                    var deleteips = string.Empty;
                    foreach (DataGridViewRow row in deleterow)
                    {
                        deleteips += row.Cells[data.FIDSDataTable.IPCStatus.ipColumn.ColumnName].Value + ",";
                    }
                    deleteips = deleteips.TrimEnd(',');
                    if (MessageBox.Show(string.Format(global.Const.DELETEWARN, deleteips), global.Const.TIPS, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MySql.Data.MySqlClient.MySqlTransaction tran = null;
                        var adapter = new data.FIDSDatasetTableAdapters.ipcstatusTableAdapter();
                        try
                        {
                            adapter.Connection.Open();
                            tran = adapter.Connection.BeginTransaction();
                            var table = adapter.GetData();
                            foreach (var ip in deleteips.Split(','))
                            {
                                var rows = table.Where(o => o.ip == ip).ToArray();
                                if (rows.Length > 0)
                                {
                                    rows.First().Delete();
                                }
                            }


                            adapter.Update(table);
                            tran.Commit();

                            RefreshIPCStatus();
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
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.DELETEDATAERROR, ex.Message));
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
                    epServer.SetError(lbDynamicStatus, string.Empty);
                }
                else
                {
                    lbDynamicStatus.Text = global.Const.UNNORMAL;
                    epServer.SetError(lbDynamicStatus, global.Variable.WEBSERVICEERROR);
                }
                lbDynamicInterval.Text = configTable.Where(o => o.code == global.Const.UPDATEINTERVALCONFIG).ToArray()[0].value;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                //
            }
        }
        #endregion

        private void bgwIPCStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.IsDisposed)
            {
                try
                {
                    var rows = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.Variable.Subsystem)).ToArray();
                    if (rows.Length > 0)
                    {
                        updateinterval = rows[0].updateinterval;
                    }
                    var handle = new RefreshHandle(() =>
                    {
                        RefreshIPCStatus();
                        RefreshConfig();
                    });
                    this.Invoke(handle);
                    Thread.Sleep(updateinterval * 1000);
                }
                catch
                {
                    Thread.Sleep(3000);
                }
            }
        }

        private void btnSyncLogo_Click(object sender, EventArgs e)
        {
            SendLogoFile();
        }

        private void SendLogoFile()
        {
            try
            {
                foreach (DataGridViewRow row in dglIPCStatus.SelectedRows)
                {
                    filetransfer.FileIO.SendLogoFileToIPC(row.Cells[data.FIDSDataTable.IPCStatus.ipColumn.ColumnName].Value.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(global.Const.ERROR,ex.Message);
            }
        }

        private void btnSyncAD_Click(object sender, EventArgs e)
        {
            SendADFile();
        }

        private void SendADFile()
        {
            try
            {
                foreach (DataGridViewRow row in dglIPCStatus.SelectedRows)
                {
                    filetransfer.FileIO.SendADFileToIPC(row.Cells[data.FIDSDataTable.IPCStatus.ipColumn.ColumnName].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(global.Const.ERROR, ex.Message);
            }
        }

        private void dgvSubsystem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    OpenSubsystemDetail(dgvSubsystem[data.FIDSDataTable.Subsystem.codeColumn.ColumnName, e.RowIndex].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnSubsystemEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubsystem.CurrentRow.Index >= 0)
                {
                    OpenSubsystemDetail(dgvSubsystem.CurrentRow.Cells[data.FIDSDataTable.Subsystem.codeColumn.ColumnName].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }

        private void btnAddIPC_Click(object sender, EventArgs e)
        {
            new IPCEditor(string.Empty).ShowDialog();
            RefreshIPCStatus();
        }

        private void btnEditIPC_Click(object sender, EventArgs e)
        {
            if (dglIPCStatus.SelectedRows.Count == 1)
            {
                new IPCEditor(dglIPCStatus.SelectedRows[0].Cells[IP.Name].Value.ToString()).ShowDialog();
                RefreshIPCStatus();
            }
        }

        private void dglIPCStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dglIPCStatus.SelectedRows.Count == 1 && e.RowIndex >= 0)
            {
                new IPCEditor(dglIPCStatus.SelectedRows[0].Cells[IP.Name].Value.ToString()).ShowDialog();
                RefreshIPCStatus();
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format(global.Const.IFSHUTDOWNIPC), global.Const.TIPS, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ShutdownALLIPC();
            }
        }

        private void ShutdownALLIPC()
        {
            var progressForm = new global.ProgressBar(global.Const.SHUTDOWN);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    var rows = FIDSAdapter.IPCStatusAdapter.GetData().Where((o) => {
                        return o.ip != global.Variable.IP.ToString() &&
                            o.subsystem != global.SubsystemType.server.ToString() &&
                            o.subsystem != global.SubsystemType.editor.ToString();
                    }).ToArray();

                    for (var i = 0; i < rows.Length; i++)
                    {
                        obj.ReportProgress((int)((float)(i + 1) / (float)rows.Length * 100), "关闭" + rows[i].ip);
                        filetransfer.FileIO.ControlIP(rows[i].ip, global.Const.Shutdown);
                    }

                    obj.ReportProgress(100, "完成");
                }
                catch (Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                }
            });
            progressForm.Show();
        }

        private void WMIIpc(string ip, string action)
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Username = "administrator";
            options.Password = "";
            ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);
            scope.Connect();
            System.Management.ObjectQuery oq = new System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher query1 = new ManagementObjectSearcher(scope, oq);
            //得到WMI控制
            ManagementObjectCollection queryCollection1 = query1.Get();

            foreach (ManagementObject mo in queryCollection1)
            {
                string[] ss = { "" };
                //重启远程计算机
                mo.InvokeMethod(action, ss);
            }
        }
    }
}
