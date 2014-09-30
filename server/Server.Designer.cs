namespace data
{
    partial class Server
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDynamicInterval = new System.Windows.Forms.Button();
            this.lbDynamicInterval = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnADFolder = new System.Windows.Forms.Button();
            this.lbDynamicStatus = new System.Windows.Forms.Label();
            this.btnLogoFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dglIPCStatus = new VCustomControls.VDataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subsystem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LogoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastAccessTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnAddIPC = new System.Windows.Forms.Button();
            this.btnEditIPC = new System.Windows.Forms.Button();
            this.btnSyncLogo = new System.Windows.Forms.Button();
            this.btnSyncAD = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.AccessTimer = new System.Windows.Forms.Timer(this.components);
            this.bgwIPCStatus = new System.ComponentModel.BackgroundWorker();
            this.epServer = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvSubsystem = new VCustomControls.VDataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSubsystemEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglIPCStatus)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epServer)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubsystem)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDynamicInterval);
            this.panel1.Controls.Add(this.lbDynamicInterval);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnADFolder);
            this.panel1.Controls.Add(this.lbDynamicStatus);
            this.panel1.Controls.Add(this.btnLogoFolder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 31);
            this.panel1.TabIndex = 0;
            // 
            // btnDynamicInterval
            // 
            this.btnDynamicInterval.AutoSize = true;
            this.btnDynamicInterval.Location = new System.Drawing.Point(324, 4);
            this.btnDynamicInterval.Name = "btnDynamicInterval";
            this.btnDynamicInterval.Size = new System.Drawing.Size(135, 23);
            this.btnDynamicInterval.TabIndex = 8;
            this.btnDynamicInterval.Text = "设置动态数据获取间隔";
            this.btnDynamicInterval.UseVisualStyleBackColor = true;
            this.btnDynamicInterval.Click += new System.EventHandler(this.btnDynamicInterval_Click);
            // 
            // lbDynamicInterval
            // 
            this.lbDynamicInterval.AutoSize = true;
            this.lbDynamicInterval.Location = new System.Drawing.Point(301, 9);
            this.lbDynamicInterval.Name = "lbDynamicInterval";
            this.lbDynamicInterval.Size = new System.Drawing.Size(11, 12);
            this.lbDynamicInterval.TabIndex = 3;
            this.lbDynamicInterval.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "动态数据获取间隔（秒）：";
            // 
            // btnADFolder
            // 
            this.btnADFolder.AutoSize = true;
            this.btnADFolder.Location = new System.Drawing.Point(570, 4);
            this.btnADFolder.Name = "btnADFolder";
            this.btnADFolder.Size = new System.Drawing.Size(99, 23);
            this.btnADFolder.TabIndex = 7;
            this.btnADFolder.Text = "打开广告文件夹";
            this.btnADFolder.UseVisualStyleBackColor = true;
            this.btnADFolder.Click += new System.EventHandler(this.btnADFolder_Click);
            // 
            // lbDynamicStatus
            // 
            this.lbDynamicStatus.AutoSize = true;
            this.lbDynamicStatus.Location = new System.Drawing.Point(95, 9);
            this.lbDynamicStatus.Name = "lbDynamicStatus";
            this.lbDynamicStatus.Size = new System.Drawing.Size(29, 12);
            this.lbDynamicStatus.TabIndex = 1;
            this.lbDynamicStatus.Text = "正常";
            // 
            // btnLogoFolder
            // 
            this.btnLogoFolder.AutoSize = true;
            this.btnLogoFolder.Location = new System.Drawing.Point(465, 4);
            this.btnLogoFolder.Name = "btnLogoFolder";
            this.btnLogoFolder.Size = new System.Drawing.Size(99, 23);
            this.btnLogoFolder.TabIndex = 1;
            this.btnLogoFolder.Text = "打开LOGO文件夹";
            this.btnLogoFolder.UseVisualStyleBackColor = true;
            this.btnLogoFolder.Click += new System.EventHandler(this.btnLogoFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "运营系统状态：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dglIPCStatus);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 434);
            this.panel2.TabIndex = 1;
            // 
            // dglIPCStatus
            // 
            this.dglIPCStatus.AllowUserToAddRows = false;
            this.dglIPCStatus.AllowUserToDeleteRows = false;
            this.dglIPCStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dglIPCStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglIPCStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Port,
            this.mac,
            this.Subsystem,
            this.LogoDate,
            this.ADDate,
            this.LastAccessTime,
            this.AutoAccess});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglIPCStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dglIPCStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglIPCStatus.Location = new System.Drawing.Point(0, 33);
            this.dglIPCStatus.Name = "dglIPCStatus";
            this.dglIPCStatus.ReadOnly = true;
            this.dglIPCStatus.RowHeadersWidth = 20;
            this.dglIPCStatus.RowTemplate.Height = 23;
            this.dglIPCStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglIPCStatus.Size = new System.Drawing.Size(826, 401);
            this.dglIPCStatus.TabIndex = 0;
            this.dglIPCStatus.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglIPCStatus_CellDoubleClick);
            // 
            // IP
            // 
            this.IP.DataPropertyName = "ip";
            this.IP.FillWeight = 2F;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "port";
            this.Port.FillWeight = 1F;
            this.Port.HeaderText = "端口";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // mac
            // 
            this.mac.DataPropertyName = "mac";
            this.mac.FillWeight = 1F;
            this.mac.HeaderText = "MAC";
            this.mac.Name = "mac";
            this.mac.ReadOnly = true;
            // 
            // Subsystem
            // 
            this.Subsystem.DataPropertyName = "subsystem";
            this.Subsystem.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Subsystem.FillWeight = 2F;
            this.Subsystem.HeaderText = "子系统";
            this.Subsystem.Name = "Subsystem";
            this.Subsystem.ReadOnly = true;
            this.Subsystem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Subsystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LogoDate
            // 
            this.LogoDate.DataPropertyName = "logodate";
            this.LogoDate.FillWeight = 2F;
            this.LogoDate.HeaderText = "Logo日期";
            this.LogoDate.Name = "LogoDate";
            this.LogoDate.ReadOnly = true;
            // 
            // ADDate
            // 
            this.ADDate.DataPropertyName = "addate";
            this.ADDate.FillWeight = 2F;
            this.ADDate.HeaderText = "广告日期";
            this.ADDate.Name = "ADDate";
            this.ADDate.ReadOnly = true;
            // 
            // LastAccessTime
            // 
            this.LastAccessTime.DataPropertyName = "lastaccesstime";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.LastAccessTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastAccessTime.FillWeight = 2F;
            this.LastAccessTime.HeaderText = "最后通讯时间";
            this.LastAccessTime.Name = "LastAccessTime";
            this.LastAccessTime.ReadOnly = true;
            // 
            // AutoAccess
            // 
            this.AutoAccess.DataPropertyName = "autoaccess";
            this.AutoAccess.FalseValue = "0";
            this.AutoAccess.FillWeight = 1F;
            this.AutoAccess.HeaderText = "自动登入";
            this.AutoAccess.Name = "AutoAccess";
            this.AutoAccess.ReadOnly = true;
            this.AutoAccess.TrueValue = "1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnShutdown);
            this.panel3.Controls.Add(this.btnAddIPC);
            this.panel3.Controls.Add(this.btnEditIPC);
            this.panel3.Controls.Add(this.btnSyncLogo);
            this.panel3.Controls.Add(this.btnSyncAD);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 33);
            this.panel3.TabIndex = 8;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShutdown.AutoSize = true;
            this.btnShutdown.Location = new System.Drawing.Point(710, 4);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(111, 23);
            this.btnShutdown.TabIndex = 10;
            this.btnShutdown.Text = "关闭所有工控机";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Visible = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnAddIPC
            // 
            this.btnAddIPC.AutoSize = true;
            this.btnAddIPC.Location = new System.Drawing.Point(7, 4);
            this.btnAddIPC.Name = "btnAddIPC";
            this.btnAddIPC.Size = new System.Drawing.Size(75, 23);
            this.btnAddIPC.TabIndex = 9;
            this.btnAddIPC.Text = "添加配置";
            this.btnAddIPC.UseVisualStyleBackColor = true;
            this.btnAddIPC.Click += new System.EventHandler(this.btnAddIPC_Click);
            // 
            // btnEditIPC
            // 
            this.btnEditIPC.AutoSize = true;
            this.btnEditIPC.Location = new System.Drawing.Point(88, 4);
            this.btnEditIPC.Name = "btnEditIPC";
            this.btnEditIPC.Size = new System.Drawing.Size(75, 23);
            this.btnEditIPC.TabIndex = 8;
            this.btnEditIPC.Text = "编辑配置";
            this.btnEditIPC.UseVisualStyleBackColor = true;
            this.btnEditIPC.Click += new System.EventHandler(this.btnEditIPC_Click);
            // 
            // btnSyncLogo
            // 
            this.btnSyncLogo.AutoSize = true;
            this.btnSyncLogo.Location = new System.Drawing.Point(250, 4);
            this.btnSyncLogo.Name = "btnSyncLogo";
            this.btnSyncLogo.Size = new System.Drawing.Size(129, 23);
            this.btnSyncLogo.TabIndex = 5;
            this.btnSyncLogo.Text = "同步logo到工控机";
            this.btnSyncLogo.UseVisualStyleBackColor = true;
            this.btnSyncLogo.Click += new System.EventHandler(this.btnSyncLogo_Click);
            // 
            // btnSyncAD
            // 
            this.btnSyncAD.AutoSize = true;
            this.btnSyncAD.Location = new System.Drawing.Point(385, 4);
            this.btnSyncAD.Name = "btnSyncAD";
            this.btnSyncAD.Size = new System.Drawing.Size(111, 23);
            this.btnSyncAD.TabIndex = 6;
            this.btnSyncAD.Text = "同步广告到工控机";
            this.btnSyncAD.UseVisualStyleBackColor = true;
            this.btnSyncAD.Click += new System.EventHandler(this.btnSyncAD_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(169, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除配置";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bgwIPCStatus
            // 
            this.bgwIPCStatus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwIPCStatus_DoWork);
            // 
            // epServer
            // 
            this.epServer.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epServer.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 466);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工控机";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvSubsystem);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "子系统";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSubsystem
            // 
            this.dgvSubsystem.AllowUserToAddRows = false;
            this.dgvSubsystem.AllowUserToDeleteRows = false;
            this.dgvSubsystem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSubsystem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubsystem.ColumnHeadersHeight = 26;
            this.dgvSubsystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSubsystem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.advance,
            this.delay,
            this.interval});
            this.dgvSubsystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubsystem.Location = new System.Drawing.Point(3, 34);
            this.dgvSubsystem.MultiSelect = false;
            this.dgvSubsystem.Name = "dgvSubsystem";
            this.dgvSubsystem.ReadOnly = true;
            this.dgvSubsystem.RowHeadersVisible = false;
            this.dgvSubsystem.RowHeadersWidth = 25;
            this.dgvSubsystem.RowTemplate.Height = 23;
            this.dgvSubsystem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubsystem.Size = new System.Drawing.Size(826, 403);
            this.dgvSubsystem.TabIndex = 4;
            this.dgvSubsystem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubsystem_CellDoubleClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Visible = false;
            this.code.Width = 54;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 54;
            // 
            // advance
            // 
            this.advance.DataPropertyName = "advance";
            this.advance.HeaderText = "提前显示时间（小时）";
            this.advance.Name = "advance";
            this.advance.ReadOnly = true;
            this.advance.Width = 150;
            // 
            // delay
            // 
            this.delay.DataPropertyName = "delay";
            this.delay.HeaderText = "消失延迟时间（分钟）";
            this.delay.Name = "delay";
            this.delay.ReadOnly = true;
            this.delay.Width = 150;
            // 
            // interval
            // 
            this.interval.DataPropertyName = "updateinterval";
            this.interval.HeaderText = "更新频率（秒）";
            this.interval.Name = "interval";
            this.interval.ReadOnly = true;
            this.interval.Width = 114;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSubsystemEdit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(826, 31);
            this.panel4.TabIndex = 3;
            // 
            // btnSubsystemEdit
            // 
            this.btnSubsystemEdit.AutoSize = true;
            this.btnSubsystemEdit.Location = new System.Drawing.Point(5, 3);
            this.btnSubsystemEdit.Name = "btnSubsystemEdit";
            this.btnSubsystemEdit.Size = new System.Drawing.Size(63, 23);
            this.btnSubsystemEdit.TabIndex = 2;
            this.btnSubsystemEdit.Text = "编辑";
            this.btnSubsystemEdit.UseVisualStyleBackColor = true;
            this.btnSubsystemEdit.Click += new System.EventHandler(this.btnSubsystemEdit_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "航显服务";
            this.Load += new System.EventHandler(this.Server_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dglIPCStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epServer)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubsystem)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDynamicStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnADFolder;
        private System.Windows.Forms.Button btnSyncAD;
        private System.Windows.Forms.Button btnSyncLogo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLogoFolder;
        private VCustomControls.VDataGridView dglIPCStatus;
        private System.Windows.Forms.Button btnDynamicInterval;
        private System.Windows.Forms.Label lbDynamicInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer AccessTimer;
        private System.ComponentModel.BackgroundWorker bgwIPCStatus;
        private System.Windows.Forms.ErrorProvider epServer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private VCustomControls.VDataGridView dgvSubsystem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSubsystemEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn advance;
        private System.Windows.Forms.DataGridViewTextBoxColumn delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn interval;
        private System.Windows.Forms.Button btnAddIPC;
        private System.Windows.Forms.Button btnEditIPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn mac;
        private System.Windows.Forms.DataGridViewComboBoxColumn Subsystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastAccessTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AutoAccess;
        private System.Windows.Forms.Button btnShutdown;

    }
}