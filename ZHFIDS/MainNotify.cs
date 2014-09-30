using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using data;
using System.Threading;
using System.Diagnostics;

namespace ZHFIDS
{
    public partial class MainNotify : Form
    {
        public MainNotify()
        {
            InitializeComponent();
        }

        private void MainNotify_Load(object sender, EventArgs e)
        {
            try
            {
                if (!global.Function.CheckMySQLConnection())
                {
                    MessageBox.Show(global.Const.MYSQLCONNECTIONERROR);
                }
                else
                {
                    Init();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
                Application.Exit();
            }
        }

        #region 自定义方法

        private void Init()
        {
            SetPermissions(global.Variable.ADMIN);
            if (global.Variable.IP == null)
            {
                Forms.ChangeForm(global.SubsystemType.FIDS);
            }
            else
            {
                var row = data.FIDSAdapter.IPCStatusAdapter.GetData().Where(o => o.ip == global.Variable.IP.ToString()).ToArray();
                if (row.Length == 0)
                {
                    Forms.ChangeForm(global.SubsystemType.FIDS);
                }
                else if (row[0].autoaccess)
                {
                    var type = (global.SubsystemType)Enum.Parse(typeof(global.SubsystemType), row[0].subsystem);
                    if (type == global.SubsystemType.server)
                    {
                        global.Function.StartGetDynamicThread(GetDynamicToolStripMenuItem);
                    }
                    Forms.ChangeForm((global.SubsystemType)Enum.Parse(typeof(global.SubsystemType), row[0].subsystem));
                }
                else
                {
                    Forms.ChangeForm(global.SubsystemType.FIDS);
                }
            }
        }

        private void SetPermissions(bool admin)
        {
            ChangeSubToolStripMenuItem.Visible = admin;
            ChangePasswordMenuItem.Visible = admin;
        }

        private void ClossAllForms()
        {
            Forms.FIDSForm.Dispose();
        }

        public ToolStripMenuItem GetAutoDynamicMenuItem()
        {
            return GetDynamicToolStripMenuItem;
        }

        public ToolStripMenuItem GetAutoPlanMenuItem()
        {
            return GetPlanMenuItem;
        }

        #endregion


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FIDSNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MainMenu.Show();
            }
        }

        private void AccessFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.FIDS);
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.editor);
        }

        private void arrivalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.arrival);
        }

        private void departureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.departure);
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.guide);
        }

        private void gateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.gate);
        }

        private void carouselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.carousel);
        }


        private void ServerFormStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.server);
        }

        private void GetDynamicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetDynamicToolStripMenuItem.Checked)
            {
                global.Function.StopGetDynamicThread(GetDynamicToolStripMenuItem);
            }
            else
            {
                global.Function.StartGetDynamicThread(GetDynamicToolStripMenuItem);
            }
        }

        private void get7planMenuItem_Click(object sender, EventArgs e)
        {
            getAWeekPlan();
        }

        //获取一周计划
        private void getAWeekPlan()
        {
            var progressForm = new global.ProgressBar(global.Const.SYNCPLAN);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    var service = global.Function.CreateService();
                    obj.ReportProgress(0, "正在连接web服务...");
                    for (var i = 0; i < 7; i++)
                    {
                        var date = (DateTime.Now - global.Variable.TIMESPLIT).AddDays(-i).ToString(global.Const.DATEFORMAT);
                        global.Function.GetFlightPlanByWebService(service, date);
                        obj.ReportProgress((int)((float)(i + 1) / 7F * 100F), "更新" + date + "计划");
                        Thread.Sleep(500);
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

        private void syncDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncDataSource();
        }

        //同步数据源
        public void SyncDataSource()
        {
            var progressForm = new global.ProgressBar(global.Const.SYNCDATASOURCE);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((sender,e)=>
            {
                var obj = (System.ComponentModel.BackgroundWorker)sender;
                try
                {
                    var service = global.Function.CreateService();
                    obj.ReportProgress(0, "正在连接web服务...");
                    global.Function.SyncTimeSplit(service);
                    obj.ReportProgress(25, "更新时间切割点");
                    Thread.Sleep(500);

                    obj.ReportProgress(50, "更新航空公司库");
                    global.Function.SyncAirlines(service);

                    obj.ReportProgress(75, "更新数据字典");
                    global.Function.SyncDictionary(service);

                    obj.ReportProgress(99, "更新机场信息");
                    global.Function.SyncAirport(service);

                    obj.ReportProgress(100, "完成");
                }
                catch (Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                }
            });
            progressForm.Show();
        }

        private void GetPlanMenuItem_Click(object sender, EventArgs e)
        {
            if (GetPlanMenuItem.Checked)
            {
                global.Function.StopGetPlanThread(GetPlanMenuItem);
            }
            else
            {
                global.Function.StartGetPlanThread(GetPlanMenuItem);
            }
        }

        private void FIDSNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.Variable.Subsystem);
        }

        private void checkDynamicMenuItem_Click(object sender, EventArgs e)
        {
            var progressForm = new global.ProgressBar(global.Const.CHECKDYNAMIC);
            progressForm.fidsBackgroundWorker.DoWork += new DoWorkEventHandler((s, eventArgs) =>
            {
                var obj = (System.ComponentModel.BackgroundWorker)s;
                try
                {
                    var service = global.Function.CreateService();
                    obj.ReportProgress(0, "正在连接web服务...");
                    obj.ReportProgress(100, global.Function.CheckDynamicByWebService(service));
                }
                catch (Exception ex)
                {
                    obj.ReportProgress(0, string.Format(global.Const.ERROR, ex.Message));
                }
            });
            progressForm.Show();
        }

        private void AdminMenuItem_Click(object sender, EventArgs e)
        {
            if(global.Variable.ADMIN)
            {
                AdminMenuItem.Text = global.Const.ADMINOFF;
                global.Variable.ADMIN = false;
                SetPermissions(false);
            }
            else
            {
                new AdminLogin().ShowDialog();
                AdminMenuItem.Text = global.Variable.ADMIN ? global.Const.ADMINON : global.Const.ADMINOFF;
                SetPermissions(global.Variable.ADMIN);

                if(global.Variable.ADMIN)
                {
                    Forms.ChangeForm(global.SubsystemType.FIDS);
                }
            }
        }

        private void ChangePasswordMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void carouseldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangeForm(global.SubsystemType.carouseld);
        }

    }
}
