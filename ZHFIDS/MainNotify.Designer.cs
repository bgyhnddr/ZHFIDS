namespace ZHFIDS
{
    partial class MainNotify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FIDSNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AccessFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeSubsystemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrivalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carouselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ServerFormStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetDynamicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.get7planMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDynamicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carouseldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.ChangeSubsystemMenu.SuspendLayout();
            this.ServerMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FIDSNotifyIcon
            // 
            this.FIDSNotifyIcon.ContextMenuStrip = this.MainMenu;
            this.FIDSNotifyIcon.Icon = global::ZHFIDS.Properties.Resources.favicon;
            this.FIDSNotifyIcon.Text = "ZHFIDS";
            this.FIDSNotifyIcon.Visible = true;
            this.FIDSNotifyIcon.DoubleClick += new System.EventHandler(this.FIDSNotifyIcon_DoubleClick);
            this.FIDSNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FIDSNotifyIcon_MouseClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccessFormToolStripMenuItem,
            this.AdminMenuItem,
            this.ChangePasswordMenuItem,
            this.ChangeSubToolStripMenuItem,
            this.get7planMenuItem,
            this.syncDataToolStripMenuItem,
            this.checkDynamicMenuItem,
            this.ExitToolStripMenuItem});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.ShowImageMargin = false;
            this.MainMenu.Size = new System.Drawing.Size(160, 180);
            // 
            // AccessFormToolStripMenuItem
            // 
            this.AccessFormToolStripMenuItem.Name = "AccessFormToolStripMenuItem";
            this.AccessFormToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.AccessFormToolStripMenuItem.Text = "重新登入";
            this.AccessFormToolStripMenuItem.Click += new System.EventHandler(this.AccessFormToolStripMenuItem_Click);
            // 
            // AdminMenuItem
            // 
            this.AdminMenuItem.Name = "AdminMenuItem";
            this.AdminMenuItem.Size = new System.Drawing.Size(159, 22);
            this.AdminMenuItem.Text = "管理员权限：关闭";
            this.AdminMenuItem.Click += new System.EventHandler(this.AdminMenuItem_Click);
            // 
            // ChangePasswordMenuItem
            // 
            this.ChangePasswordMenuItem.Name = "ChangePasswordMenuItem";
            this.ChangePasswordMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ChangePasswordMenuItem.Text = "修改管理员密码";
            this.ChangePasswordMenuItem.Click += new System.EventHandler(this.ChangePasswordMenuItem_Click);
            // 
            // ChangeSubToolStripMenuItem
            // 
            this.ChangeSubToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ChangeSubToolStripMenuItem.DropDown = this.ChangeSubsystemMenu;
            this.ChangeSubToolStripMenuItem.Name = "ChangeSubToolStripMenuItem";
            this.ChangeSubToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ChangeSubToolStripMenuItem.Text = "子系统";
            // 
            // ChangeSubsystemMenu
            // 
            this.ChangeSubsystemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.arrivalToolStripMenuItem,
            this.departureToolStripMenuItem,
            this.guideToolStripMenuItem,
            this.gateToolStripMenuItem,
            this.carouselToolStripMenuItem,
            this.carouseldToolStripMenuItem,
            this.serverToolStripMenuItem});
            this.ChangeSubsystemMenu.Name = "ChangeSubsystemMenu";
            this.ChangeSubsystemMenu.ShowImageMargin = false;
            this.ChangeSubsystemMenu.Size = new System.Drawing.Size(124, 180);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.editorToolStripMenuItem.Text = "航显编辑器";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // arrivalToolStripMenuItem
            // 
            this.arrivalToolStripMenuItem.Name = "arrivalToolStripMenuItem";
            this.arrivalToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.arrivalToolStripMenuItem.Text = "到达航显";
            this.arrivalToolStripMenuItem.Click += new System.EventHandler(this.arrivalToolStripMenuItem_Click);
            // 
            // departureToolStripMenuItem
            // 
            this.departureToolStripMenuItem.Name = "departureToolStripMenuItem";
            this.departureToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.departureToolStripMenuItem.Text = "出发航显";
            this.departureToolStripMenuItem.Click += new System.EventHandler(this.departureToolStripMenuItem_Click);
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.guideToolStripMenuItem.Text = "综合航显";
            this.guideToolStripMenuItem.Click += new System.EventHandler(this.guideToolStripMenuItem_Click);
            // 
            // gateToolStripMenuItem
            // 
            this.gateToolStripMenuItem.Name = "gateToolStripMenuItem";
            this.gateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.gateToolStripMenuItem.Text = "登机口";
            this.gateToolStripMenuItem.Click += new System.EventHandler(this.gateToolStripMenuItem_Click);
            // 
            // carouselToolStripMenuItem
            // 
            this.carouselToolStripMenuItem.Name = "carouselToolStripMenuItem";
            this.carouselToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.carouselToolStripMenuItem.Text = "行李转盘";
            this.carouselToolStripMenuItem.Click += new System.EventHandler(this.carouselToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDown = this.ServerMenuStrip;
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.serverToolStripMenuItem.Text = "航显服务";
            // 
            // ServerMenuStrip
            // 
            this.ServerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerFormStripMenuItem,
            this.GetPlanMenuItem,
            this.GetDynamicToolStripMenuItem});
            this.ServerMenuStrip.Name = "ServerMenuStrip";
            this.ServerMenuStrip.ShowCheckMargin = true;
            this.ServerMenuStrip.ShowImageMargin = false;
            this.ServerMenuStrip.Size = new System.Drawing.Size(173, 70);
            // 
            // ServerFormStripMenuItem
            // 
            this.ServerFormStripMenuItem.Name = "ServerFormStripMenuItem";
            this.ServerFormStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ServerFormStripMenuItem.Text = "服务窗口";
            this.ServerFormStripMenuItem.Click += new System.EventHandler(this.ServerFormStripMenuItem_Click);
            // 
            // GetPlanMenuItem
            // 
            this.GetPlanMenuItem.Name = "GetPlanMenuItem";
            this.GetPlanMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GetPlanMenuItem.Text = "自动获取计划数据";
            this.GetPlanMenuItem.Click += new System.EventHandler(this.GetPlanMenuItem_Click);
            // 
            // GetDynamicToolStripMenuItem
            // 
            this.GetDynamicToolStripMenuItem.Name = "GetDynamicToolStripMenuItem";
            this.GetDynamicToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GetDynamicToolStripMenuItem.Text = "自动获取动态数据";
            this.GetDynamicToolStripMenuItem.Click += new System.EventHandler(this.GetDynamicToolStripMenuItem_Click);
            // 
            // get7planMenuItem
            // 
            this.get7planMenuItem.Name = "get7planMenuItem";
            this.get7planMenuItem.Size = new System.Drawing.Size(159, 22);
            this.get7planMenuItem.Text = "同步最近一周的计划";
            this.get7planMenuItem.Click += new System.EventHandler(this.get7planMenuItem_Click);
            // 
            // syncDataToolStripMenuItem
            // 
            this.syncDataToolStripMenuItem.Name = "syncDataToolStripMenuItem";
            this.syncDataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.syncDataToolStripMenuItem.Text = "同步基础数据";
            this.syncDataToolStripMenuItem.Click += new System.EventHandler(this.syncDataToolStripMenuItem_Click);
            // 
            // checkDynamicMenuItem
            // 
            this.checkDynamicMenuItem.Name = "checkDynamicMenuItem";
            this.checkDynamicMenuItem.Size = new System.Drawing.Size(159, 22);
            this.checkDynamicMenuItem.Text = "测试动态连接";
            this.checkDynamicMenuItem.Click += new System.EventHandler(this.checkDynamicMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // carouseldToolStripMenuItem
            // 
            this.carouseldToolStripMenuItem.Name = "carouseldToolStripMenuItem";
            this.carouseldToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.carouseldToolStripMenuItem.Text = "行李转盘分区";
            this.carouseldToolStripMenuItem.Click += new System.EventHandler(this.carouseldToolStripMenuItem_Click);
            // 
            // MainNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainNotify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MainNotify";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainNotify_Load);
            this.MainMenu.ResumeLayout(false);
            this.ChangeSubsystemMenu.ResumeLayout(false);
            this.ServerMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon FIDSNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccessFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeSubToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ChangeSubsystemMenu;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrivalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carouselToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ServerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ServerFormStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetDynamicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetPlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem get7planMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDynamicMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carouseldToolStripMenuItem;
    }
}