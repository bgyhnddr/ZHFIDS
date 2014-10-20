namespace data
{
    partial class Editor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.panelStatus = new System.Windows.Forms.Panel();
            this.btnGetDynamicByPlan = new System.Windows.Forms.Button();
            this.btnDynamicInterval = new System.Windows.Forms.Button();
            this.lbDynamicInterval = new System.Windows.Forms.Label();
            this.lbDynamicStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bgwRefresh = new System.ComponentModel.BackgroundWorker();
            this.AccessTimer = new System.Windows.Forms.Timer(this.components);
            this.epEditor = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPageDynamic = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDynamicDeparture = new VCustomControls.VDataGridView();
            this.flightdynamicid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastmodifytime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forceshow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airlinecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tovia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.std = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.en_departstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departoutward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departoutward_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.departuredate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteDepartureDynamic = new System.Windows.Forms.Button();
            this.btnDepartureFlightFilterClear = new System.Windows.Forms.Button();
            this.btnDepartureFlightFilter = new System.Windows.Forms.Button();
            this.tbDepartureFlightFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditDepartureDynaimc = new System.Windows.Forms.Button();
            this.btnAddDepartureDynamic = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDynamicArrival = new VCustomControls.VDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.en_arrivalstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivaloutward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivaloutward_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.arrivaldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeleteArrivalDynamic = new System.Windows.Forms.Button();
            this.btnArrivalFlightFilterClear = new System.Windows.Forms.Button();
            this.btnArrivalFlightFilter = new System.Windows.Forms.Button();
            this.tbArrivalFlightFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditArrivalDynaimc = new System.Windows.Forms.Button();
            this.btnAddArrivalDynamic = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageRemarkinfo = new System.Windows.Forms.TabPage();
            this.dgvRemarkinfo = new VCustomControls.VDataGridView();
            this.remark_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorline = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.departure_cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departure_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guide_cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guide_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrival_cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrival_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gate_cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gate_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btndeleteremarkinfo = new System.Windows.Forms.Button();
            this.btneditremark = new System.Windows.Forms.Button();
            this.btnremarkadd = new System.Windows.Forms.Button();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epEditor)).BeginInit();
            this.tabPageDynamic.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDynamicDeparture)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDynamicArrival)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageRemarkinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarkinfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.btnGetDynamicByPlan);
            this.panelStatus.Controls.Add(this.btnDynamicInterval);
            this.panelStatus.Controls.Add(this.lbDynamicInterval);
            this.panelStatus.Controls.Add(this.lbDynamicStatus);
            this.panelStatus.Controls.Add(this.label3);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(775, 31);
            this.panelStatus.TabIndex = 0;
            // 
            // btnGetDynamicByPlan
            // 
            this.btnGetDynamicByPlan.AutoSize = true;
            this.btnGetDynamicByPlan.Location = new System.Drawing.Point(476, 4);
            this.btnGetDynamicByPlan.Name = "btnGetDynamicByPlan";
            this.btnGetDynamicByPlan.Size = new System.Drawing.Size(135, 23);
            this.btnGetDynamicByPlan.TabIndex = 8;
            this.btnGetDynamicByPlan.TabStop = false;
            this.btnGetDynamicByPlan.Text = "根据计划生成动态数据";
            this.btnGetDynamicByPlan.UseVisualStyleBackColor = true;
            this.btnGetDynamicByPlan.Click += new System.EventHandler(this.btnGetDynamicByPlan_Click);
            // 
            // btnDynamicInterval
            // 
            this.btnDynamicInterval.AutoSize = true;
            this.btnDynamicInterval.Location = new System.Drawing.Point(335, 4);
            this.btnDynamicInterval.Name = "btnDynamicInterval";
            this.btnDynamicInterval.Size = new System.Drawing.Size(135, 23);
            this.btnDynamicInterval.TabIndex = 9;
            this.btnDynamicInterval.TabStop = false;
            this.btnDynamicInterval.Text = "设置动态数据获取间隔";
            this.btnDynamicInterval.UseVisualStyleBackColor = true;
            this.btnDynamicInterval.Click += new System.EventHandler(this.btnDynamicInterval_Click);
            // 
            // lbDynamicInterval
            // 
            this.lbDynamicInterval.AutoSize = true;
            this.lbDynamicInterval.Location = new System.Drawing.Point(293, 9);
            this.lbDynamicInterval.Name = "lbDynamicInterval";
            this.lbDynamicInterval.Size = new System.Drawing.Size(11, 12);
            this.lbDynamicInterval.TabIndex = 5;
            this.lbDynamicInterval.Text = "5";
            // 
            // lbDynamicStatus
            // 
            this.lbDynamicStatus.AutoSize = true;
            this.lbDynamicStatus.Location = new System.Drawing.Point(95, 9);
            this.lbDynamicStatus.Name = "lbDynamicStatus";
            this.lbDynamicStatus.Size = new System.Drawing.Size(29, 12);
            this.lbDynamicStatus.TabIndex = 3;
            this.lbDynamicStatus.Text = "正常";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "动态数据获取间隔（秒）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "运营系统状态：";
            // 
            // bgwRefresh
            // 
            this.bgwRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRefresh_DoWork);
            // 
            // epEditor
            // 
            this.epEditor.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epEditor.ContainerControl = this;
            // 
            // tabPageDynamic
            // 
            this.tabPageDynamic.Controls.Add(this.tabControl1);
            this.tabPageDynamic.Location = new System.Drawing.Point(4, 22);
            this.tabPageDynamic.Name = "tabPageDynamic";
            this.tabPageDynamic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDynamic.Size = new System.Drawing.Size(767, 408);
            this.tabPageDynamic.TabIndex = 0;
            this.tabPageDynamic.Text = "航显动态";
            this.tabPageDynamic.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 402);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDynamicDeparture);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(753, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "离港";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDynamicDeparture
            // 
            this.dgvDynamicDeparture.AllowUserToAddRows = false;
            this.dgvDynamicDeparture.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDynamicDeparture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDynamicDeparture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDynamicDeparture.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDynamicDeparture.ColumnHeadersHeight = 26;
            this.dgvDynamicDeparture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDynamicDeparture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flightdynamicid,
            this.flight,
            this.lastmodifytime,
            this.forceshow,
            this.airlinecode,
            this.from,
            this.tovia,
            this.std,
            this.etd,
            this.atd,
            this.counter,
            this.gate,
            this.departstatus,
            this.en_departstatus,
            this.departoutward,
            this.departoutward_en,
            this.manual,
            this.departuredate});
            this.dgvDynamicDeparture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDynamicDeparture.Location = new System.Drawing.Point(3, 34);
            this.dgvDynamicDeparture.MultiSelect = false;
            this.dgvDynamicDeparture.Name = "dgvDynamicDeparture";
            this.dgvDynamicDeparture.ReadOnly = true;
            this.dgvDynamicDeparture.RowHeadersVisible = false;
            this.dgvDynamicDeparture.RowHeadersWidth = 25;
            this.dgvDynamicDeparture.RowTemplate.Height = 23;
            this.dgvDynamicDeparture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDynamicDeparture.Size = new System.Drawing.Size(747, 339);
            this.dgvDynamicDeparture.TabIndex = 2;
            this.dgvDynamicDeparture.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDynamicDeparture_CellMouseDoubleClick);
            this.dgvDynamicDeparture.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDynamicDeparture_DataBindingComplete);
            this.dgvDynamicDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDynamicDeparture_KeyDown);
            // 
            // flightdynamicid
            // 
            this.flightdynamicid.DataPropertyName = "flightdynamicid";
            this.flightdynamicid.HeaderText = "航班动态编号";
            this.flightdynamicid.Name = "flightdynamicid";
            this.flightdynamicid.ReadOnly = true;
            this.flightdynamicid.Visible = false;
            this.flightdynamicid.Width = 102;
            // 
            // flight
            // 
            this.flight.DataPropertyName = "flight";
            this.flight.HeaderText = "航班号";
            this.flight.Name = "flight";
            this.flight.ReadOnly = true;
            this.flight.Width = 66;
            // 
            // lastmodifytime
            // 
            this.lastmodifytime.DataPropertyName = "lastmodifytime";
            this.lastmodifytime.HeaderText = "最后编辑时间";
            this.lastmodifytime.Name = "lastmodifytime";
            this.lastmodifytime.ReadOnly = true;
            this.lastmodifytime.Visible = false;
            this.lastmodifytime.Width = 102;
            // 
            // forceshow
            // 
            this.forceshow.DataPropertyName = "forceshow";
            this.forceshow.HeaderText = "强制显示模式";
            this.forceshow.Name = "forceshow";
            this.forceshow.ReadOnly = true;
            this.forceshow.Visible = false;
            this.forceshow.Width = 102;
            // 
            // airlinecode
            // 
            this.airlinecode.DataPropertyName = "airlinecode";
            this.airlinecode.HeaderText = "航空公司";
            this.airlinecode.Name = "airlinecode";
            this.airlinecode.ReadOnly = true;
            this.airlinecode.Visible = false;
            this.airlinecode.Width = 78;
            // 
            // from
            // 
            this.from.DataPropertyName = "from";
            this.from.HeaderText = "出发地";
            this.from.Name = "from";
            this.from.ReadOnly = true;
            this.from.Width = 66;
            // 
            // tovia
            // 
            this.tovia.DataPropertyName = "tovia";
            this.tovia.HeaderText = "到达/经停";
            this.tovia.Name = "tovia";
            this.tovia.ReadOnly = true;
            this.tovia.Width = 84;
            // 
            // std
            // 
            this.std.DataPropertyName = "std";
            this.std.HeaderText = "计划";
            this.std.Name = "std";
            this.std.ReadOnly = true;
            this.std.Width = 54;
            // 
            // etd
            // 
            this.etd.DataPropertyName = "etd";
            this.etd.HeaderText = "预计";
            this.etd.Name = "etd";
            this.etd.ReadOnly = true;
            this.etd.Width = 54;
            // 
            // atd
            // 
            this.atd.DataPropertyName = "atd";
            this.atd.HeaderText = "实际";
            this.atd.Name = "atd";
            this.atd.ReadOnly = true;
            this.atd.Width = 54;
            // 
            // counter
            // 
            this.counter.DataPropertyName = "counter";
            this.counter.HeaderText = "值机区域";
            this.counter.Name = "counter";
            this.counter.ReadOnly = true;
            this.counter.Width = 78;
            // 
            // gate
            // 
            this.gate.DataPropertyName = "gate";
            this.gate.HeaderText = "登机口";
            this.gate.Name = "gate";
            this.gate.ReadOnly = true;
            this.gate.Width = 66;
            // 
            // departstatus
            // 
            this.departstatus.DataPropertyName = "departstatus";
            this.departstatus.HeaderText = "离港状态";
            this.departstatus.Name = "departstatus";
            this.departstatus.ReadOnly = true;
            this.departstatus.Width = 78;
            // 
            // en_departstatus
            // 
            this.en_departstatus.DataPropertyName = "en_departstatus";
            this.en_departstatus.HeaderText = "离港状态英文对照";
            this.en_departstatus.Name = "en_departstatus";
            this.en_departstatus.ReadOnly = true;
            this.en_departstatus.Width = 126;
            // 
            // departoutward
            // 
            this.departoutward.DataPropertyName = "departoutward";
            this.departoutward.HeaderText = "异常原因";
            this.departoutward.Name = "departoutward";
            this.departoutward.ReadOnly = true;
            this.departoutward.Width = 78;
            // 
            // departoutward_en
            // 
            this.departoutward_en.DataPropertyName = "departoutward_en";
            this.departoutward_en.HeaderText = "异常原因英文";
            this.departoutward_en.Name = "departoutward_en";
            this.departoutward_en.ReadOnly = true;
            this.departoutward_en.Width = 102;
            // 
            // manual
            // 
            this.manual.DataPropertyName = "manual";
            this.manual.HeaderText = "冻结数据";
            this.manual.Name = "manual";
            this.manual.ReadOnly = true;
            this.manual.Width = 59;
            // 
            // departuredate
            // 
            this.departuredate.DataPropertyName = "date";
            this.departuredate.HeaderText = "数据日期";
            this.departuredate.Name = "departuredate";
            this.departuredate.ReadOnly = true;
            this.departuredate.Width = 78;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteDepartureDynamic);
            this.panel1.Controls.Add(this.btnDepartureFlightFilterClear);
            this.panel1.Controls.Add(this.btnDepartureFlightFilter);
            this.panel1.Controls.Add(this.tbDepartureFlightFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEditDepartureDynaimc);
            this.panel1.Controls.Add(this.btnAddDepartureDynamic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 31);
            this.panel1.TabIndex = 3;
            // 
            // btnDeleteDepartureDynamic
            // 
            this.btnDeleteDepartureDynamic.AutoSize = true;
            this.btnDeleteDepartureDynamic.Location = new System.Drawing.Point(386, 4);
            this.btnDeleteDepartureDynamic.Name = "btnDeleteDepartureDynamic";
            this.btnDeleteDepartureDynamic.Size = new System.Drawing.Size(63, 23);
            this.btnDeleteDepartureDynamic.TabIndex = 7;
            this.btnDeleteDepartureDynamic.TabStop = false;
            this.btnDeleteDepartureDynamic.Text = "删除记录";
            this.btnDeleteDepartureDynamic.UseVisualStyleBackColor = true;
            this.btnDeleteDepartureDynamic.Click += new System.EventHandler(this.btnDeleteDepartureDynamic_Click);
            // 
            // btnDepartureFlightFilterClear
            // 
            this.btnDepartureFlightFilterClear.AutoSize = true;
            this.btnDepartureFlightFilterClear.Location = new System.Drawing.Point(203, 4);
            this.btnDepartureFlightFilterClear.Name = "btnDepartureFlightFilterClear";
            this.btnDepartureFlightFilterClear.Size = new System.Drawing.Size(39, 23);
            this.btnDepartureFlightFilterClear.TabIndex = 6;
            this.btnDepartureFlightFilterClear.TabStop = false;
            this.btnDepartureFlightFilterClear.Text = "全部";
            this.btnDepartureFlightFilterClear.UseVisualStyleBackColor = true;
            this.btnDepartureFlightFilterClear.Click += new System.EventHandler(this.btnDepartureFlightFilterClear_Click);
            // 
            // btnDepartureFlightFilter
            // 
            this.btnDepartureFlightFilter.AutoSize = true;
            this.btnDepartureFlightFilter.Location = new System.Drawing.Point(158, 4);
            this.btnDepartureFlightFilter.Name = "btnDepartureFlightFilter";
            this.btnDepartureFlightFilter.Size = new System.Drawing.Size(39, 23);
            this.btnDepartureFlightFilter.TabIndex = 5;
            this.btnDepartureFlightFilter.TabStop = false;
            this.btnDepartureFlightFilter.Text = "筛选";
            this.btnDepartureFlightFilter.UseVisualStyleBackColor = true;
            this.btnDepartureFlightFilter.Click += new System.EventHandler(this.btnDepartureFlightFilter_Click);
            // 
            // tbDepartureFlightFilter
            // 
            this.tbDepartureFlightFilter.Location = new System.Drawing.Point(52, 4);
            this.tbDepartureFlightFilter.Name = "tbDepartureFlightFilter";
            this.tbDepartureFlightFilter.Size = new System.Drawing.Size(100, 21);
            this.tbDepartureFlightFilter.TabIndex = 0;
            this.tbDepartureFlightFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartureFlightFilter_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "航班号";
            // 
            // btnEditDepartureDynaimc
            // 
            this.btnEditDepartureDynaimc.AutoSize = true;
            this.btnEditDepartureDynaimc.Location = new System.Drawing.Point(317, 4);
            this.btnEditDepartureDynaimc.Name = "btnEditDepartureDynaimc";
            this.btnEditDepartureDynaimc.Size = new System.Drawing.Size(63, 23);
            this.btnEditDepartureDynaimc.TabIndex = 2;
            this.btnEditDepartureDynaimc.TabStop = false;
            this.btnEditDepartureDynaimc.Text = "编辑记录";
            this.btnEditDepartureDynaimc.UseVisualStyleBackColor = true;
            this.btnEditDepartureDynaimc.Click += new System.EventHandler(this.btnEditDepartureDynaimc_Click);
            // 
            // btnAddDepartureDynamic
            // 
            this.btnAddDepartureDynamic.AutoSize = true;
            this.btnAddDepartureDynamic.Location = new System.Drawing.Point(248, 4);
            this.btnAddDepartureDynamic.Name = "btnAddDepartureDynamic";
            this.btnAddDepartureDynamic.Size = new System.Drawing.Size(63, 23);
            this.btnAddDepartureDynamic.TabIndex = 0;
            this.btnAddDepartureDynamic.TabStop = false;
            this.btnAddDepartureDynamic.Text = "新增记录";
            this.btnAddDepartureDynamic.UseVisualStyleBackColor = true;
            this.btnAddDepartureDynamic.Click += new System.EventHandler(this.btnAddDepartureDynamic_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDynamicArrival);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(753, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "到港";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDynamicArrival
            // 
            this.dgvDynamicArrival.AllowUserToAddRows = false;
            this.dgvDynamicArrival.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDynamicArrival.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDynamicArrival.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDynamicArrival.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDynamicArrival.ColumnHeadersHeight = 26;
            this.dgvDynamicArrival.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDynamicArrival.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn16,
            this.arrivalstatus,
            this.en_arrivalstatus,
            this.arrivaloutward,
            this.arrivaloutward_en,
            this.dataGridViewCheckBoxColumn1,
            this.arrivaldate});
            this.dgvDynamicArrival.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDynamicArrival.Location = new System.Drawing.Point(3, 34);
            this.dgvDynamicArrival.MultiSelect = false;
            this.dgvDynamicArrival.Name = "dgvDynamicArrival";
            this.dgvDynamicArrival.ReadOnly = true;
            this.dgvDynamicArrival.RowHeadersVisible = false;
            this.dgvDynamicArrival.RowHeadersWidth = 25;
            this.dgvDynamicArrival.RowTemplate.Height = 23;
            this.dgvDynamicArrival.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDynamicArrival.Size = new System.Drawing.Size(747, 339);
            this.dgvDynamicArrival.TabIndex = 2;
            this.dgvDynamicArrival.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDynamicArrival_CellDoubleClick);
            this.dgvDynamicArrival.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDynamicArrival_DataBindingComplete);
            this.dgvDynamicArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDynamicArrival_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "flightdynamicid";
            this.dataGridViewTextBoxColumn1.HeaderText = "航班动态编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 102;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "flight";
            this.dataGridViewTextBoxColumn2.HeaderText = "航班号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 66;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "lastmodifytime";
            this.dataGridViewTextBoxColumn3.HeaderText = "最后编辑时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 102;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "forceshow";
            this.dataGridViewTextBoxColumn4.HeaderText = "强制显示模式";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 102;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "airlinecode";
            this.dataGridViewTextBoxColumn5.HeaderText = "航空公司";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "from";
            this.dataGridViewTextBoxColumn6.HeaderText = "出发地";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 66;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "tovia";
            this.dataGridViewTextBoxColumn7.HeaderText = "到达/经停";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 84;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "sta";
            this.dataGridViewTextBoxColumn11.HeaderText = "计划";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 54;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "eta";
            this.dataGridViewTextBoxColumn12.HeaderText = "预计";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 54;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ata";
            this.dataGridViewTextBoxColumn13.HeaderText = "实际";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 54;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "carousel";
            this.dataGridViewTextBoxColumn16.HeaderText = "行李转盘";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 78;
            // 
            // arrivalstatus
            // 
            this.arrivalstatus.DataPropertyName = "arrivalstatus";
            this.arrivalstatus.HeaderText = "到港状态";
            this.arrivalstatus.Name = "arrivalstatus";
            this.arrivalstatus.ReadOnly = true;
            this.arrivalstatus.Width = 78;
            // 
            // en_arrivalstatus
            // 
            this.en_arrivalstatus.DataPropertyName = "en_arrivalstatus";
            this.en_arrivalstatus.HeaderText = "到港状态英文对照";
            this.en_arrivalstatus.Name = "en_arrivalstatus";
            this.en_arrivalstatus.ReadOnly = true;
            this.en_arrivalstatus.Width = 126;
            // 
            // arrivaloutward
            // 
            this.arrivaloutward.DataPropertyName = "arrivaloutward";
            this.arrivaloutward.HeaderText = "异常原因";
            this.arrivaloutward.Name = "arrivaloutward";
            this.arrivaloutward.ReadOnly = true;
            this.arrivaloutward.Width = 78;
            // 
            // arrivaloutward_en
            // 
            this.arrivaloutward_en.DataPropertyName = "arrivaloutward_en";
            this.arrivaloutward_en.HeaderText = "异常原因英文";
            this.arrivaloutward_en.Name = "arrivaloutward_en";
            this.arrivaloutward_en.ReadOnly = true;
            this.arrivaloutward_en.Width = 102;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "manual";
            this.dataGridViewCheckBoxColumn1.HeaderText = "冻结数据";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 59;
            // 
            // arrivaldate
            // 
            this.arrivaldate.DataPropertyName = "date";
            this.arrivaldate.HeaderText = "数据日期";
            this.arrivaldate.Name = "arrivaldate";
            this.arrivaldate.ReadOnly = true;
            this.arrivaldate.Width = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeleteArrivalDynamic);
            this.panel3.Controls.Add(this.btnArrivalFlightFilterClear);
            this.panel3.Controls.Add(this.btnArrivalFlightFilter);
            this.panel3.Controls.Add(this.tbArrivalFlightFilter);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnEditArrivalDynaimc);
            this.panel3.Controls.Add(this.btnAddArrivalDynamic);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(747, 31);
            this.panel3.TabIndex = 4;
            // 
            // btnDeleteArrivalDynamic
            // 
            this.btnDeleteArrivalDynamic.AutoSize = true;
            this.btnDeleteArrivalDynamic.Location = new System.Drawing.Point(386, 4);
            this.btnDeleteArrivalDynamic.Name = "btnDeleteArrivalDynamic";
            this.btnDeleteArrivalDynamic.Size = new System.Drawing.Size(63, 23);
            this.btnDeleteArrivalDynamic.TabIndex = 7;
            this.btnDeleteArrivalDynamic.TabStop = false;
            this.btnDeleteArrivalDynamic.Text = "删除记录";
            this.btnDeleteArrivalDynamic.UseVisualStyleBackColor = true;
            this.btnDeleteArrivalDynamic.Click += new System.EventHandler(this.btnDeleteArrivalDynamic_Click);
            // 
            // btnArrivalFlightFilterClear
            // 
            this.btnArrivalFlightFilterClear.AutoSize = true;
            this.btnArrivalFlightFilterClear.Location = new System.Drawing.Point(203, 4);
            this.btnArrivalFlightFilterClear.Name = "btnArrivalFlightFilterClear";
            this.btnArrivalFlightFilterClear.Size = new System.Drawing.Size(39, 23);
            this.btnArrivalFlightFilterClear.TabIndex = 6;
            this.btnArrivalFlightFilterClear.TabStop = false;
            this.btnArrivalFlightFilterClear.Text = "全部";
            this.btnArrivalFlightFilterClear.UseVisualStyleBackColor = true;
            this.btnArrivalFlightFilterClear.Click += new System.EventHandler(this.btnArrivalFlightFilterClear_Click);
            // 
            // btnArrivalFlightFilter
            // 
            this.btnArrivalFlightFilter.AutoSize = true;
            this.btnArrivalFlightFilter.Location = new System.Drawing.Point(158, 4);
            this.btnArrivalFlightFilter.Name = "btnArrivalFlightFilter";
            this.btnArrivalFlightFilter.Size = new System.Drawing.Size(39, 23);
            this.btnArrivalFlightFilter.TabIndex = 5;
            this.btnArrivalFlightFilter.TabStop = false;
            this.btnArrivalFlightFilter.Text = "筛选";
            this.btnArrivalFlightFilter.UseVisualStyleBackColor = true;
            this.btnArrivalFlightFilter.Click += new System.EventHandler(this.btnArrivalFlightFilter_Click);
            // 
            // tbArrivalFlightFilter
            // 
            this.tbArrivalFlightFilter.Location = new System.Drawing.Point(52, 4);
            this.tbArrivalFlightFilter.Name = "tbArrivalFlightFilter";
            this.tbArrivalFlightFilter.Size = new System.Drawing.Size(100, 21);
            this.tbArrivalFlightFilter.TabIndex = 0;
            this.tbArrivalFlightFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbArrivalFlightFilter_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "航班号";
            // 
            // btnEditArrivalDynaimc
            // 
            this.btnEditArrivalDynaimc.AutoSize = true;
            this.btnEditArrivalDynaimc.Location = new System.Drawing.Point(317, 4);
            this.btnEditArrivalDynaimc.Name = "btnEditArrivalDynaimc";
            this.btnEditArrivalDynaimc.Size = new System.Drawing.Size(63, 23);
            this.btnEditArrivalDynaimc.TabIndex = 2;
            this.btnEditArrivalDynaimc.TabStop = false;
            this.btnEditArrivalDynaimc.Text = "编辑记录";
            this.btnEditArrivalDynaimc.UseVisualStyleBackColor = true;
            this.btnEditArrivalDynaimc.Click += new System.EventHandler(this.btnEditArrivalDynaimc_Click);
            // 
            // btnAddArrivalDynamic
            // 
            this.btnAddArrivalDynamic.AutoSize = true;
            this.btnAddArrivalDynamic.Location = new System.Drawing.Point(248, 4);
            this.btnAddArrivalDynamic.Name = "btnAddArrivalDynamic";
            this.btnAddArrivalDynamic.Size = new System.Drawing.Size(63, 23);
            this.btnAddArrivalDynamic.TabIndex = 0;
            this.btnAddArrivalDynamic.TabStop = false;
            this.btnAddArrivalDynamic.Text = "新增记录";
            this.btnAddArrivalDynamic.UseVisualStyleBackColor = true;
            this.btnAddArrivalDynamic.Click += new System.EventHandler(this.btnAddArrivalDynamic_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageDynamic);
            this.tabControlMain.Controls.Add(this.tabPageRemarkinfo);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 31);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(775, 434);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageRemarkinfo
            // 
            this.tabPageRemarkinfo.Controls.Add(this.dgvRemarkinfo);
            this.tabPageRemarkinfo.Controls.Add(this.panel2);
            this.tabPageRemarkinfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageRemarkinfo.Name = "tabPageRemarkinfo";
            this.tabPageRemarkinfo.Size = new System.Drawing.Size(767, 408);
            this.tabPageRemarkinfo.TabIndex = 1;
            this.tabPageRemarkinfo.Text = "备注编辑";
            this.tabPageRemarkinfo.UseVisualStyleBackColor = true;
            // 
            // dgvRemarkinfo
            // 
            this.dgvRemarkinfo.AllowUserToAddRows = false;
            this.dgvRemarkinfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvRemarkinfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRemarkinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRemarkinfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRemarkinfo.ColumnHeadersHeight = 26;
            this.dgvRemarkinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRemarkinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remark_code,
            this.color,
            this.errorline,
            this.departure_cn,
            this.departure_en,
            this.guide_cn,
            this.guide_en,
            this.arrival_cn,
            this.arrival_en,
            this.gate_cn,
            this.gate_en});
            this.dgvRemarkinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemarkinfo.Location = new System.Drawing.Point(0, 30);
            this.dgvRemarkinfo.MultiSelect = false;
            this.dgvRemarkinfo.Name = "dgvRemarkinfo";
            this.dgvRemarkinfo.ReadOnly = true;
            this.dgvRemarkinfo.RowHeadersVisible = false;
            this.dgvRemarkinfo.RowHeadersWidth = 25;
            this.dgvRemarkinfo.RowTemplate.Height = 23;
            this.dgvRemarkinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemarkinfo.Size = new System.Drawing.Size(767, 378);
            this.dgvRemarkinfo.TabIndex = 3;
            this.dgvRemarkinfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRemarkinfo_CellFormatting);
            this.dgvRemarkinfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRemarkinfo_CellMouseDoubleClick);
            // 
            // remark_code
            // 
            this.remark_code.DataPropertyName = "code";
            this.remark_code.HeaderText = "编码";
            this.remark_code.Name = "remark_code";
            this.remark_code.ReadOnly = true;
            this.remark_code.Width = 54;
            // 
            // color
            // 
            this.color.DataPropertyName = "color";
            this.color.HeaderText = "颜色";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 54;
            // 
            // errorline
            // 
            this.errorline.DataPropertyName = "errorline";
            this.errorline.FalseValue = "0";
            this.errorline.HeaderText = "是否属于异常全天显示状态";
            this.errorline.Name = "errorline";
            this.errorline.ReadOnly = true;
            this.errorline.TrueValue = "1";
            this.errorline.Width = 155;
            // 
            // departure_cn
            // 
            this.departure_cn.DataPropertyName = "departure_cn";
            this.departure_cn.HeaderText = "离港";
            this.departure_cn.Name = "departure_cn";
            this.departure_cn.ReadOnly = true;
            this.departure_cn.Width = 54;
            // 
            // departure_en
            // 
            this.departure_en.DataPropertyName = "departure_en";
            this.departure_en.HeaderText = "离港英文";
            this.departure_en.Name = "departure_en";
            this.departure_en.ReadOnly = true;
            this.departure_en.Width = 78;
            // 
            // guide_cn
            // 
            this.guide_cn.DataPropertyName = "guide_cn";
            this.guide_cn.HeaderText = "综合引导";
            this.guide_cn.Name = "guide_cn";
            this.guide_cn.ReadOnly = true;
            this.guide_cn.Width = 78;
            // 
            // guide_en
            // 
            this.guide_en.DataPropertyName = "guide_en";
            this.guide_en.HeaderText = "综合引导英文";
            this.guide_en.Name = "guide_en";
            this.guide_en.ReadOnly = true;
            this.guide_en.Width = 102;
            // 
            // arrival_cn
            // 
            this.arrival_cn.DataPropertyName = "arrival_cn";
            this.arrival_cn.HeaderText = "到达";
            this.arrival_cn.Name = "arrival_cn";
            this.arrival_cn.ReadOnly = true;
            this.arrival_cn.Width = 54;
            // 
            // arrival_en
            // 
            this.arrival_en.DataPropertyName = "arrival_en";
            this.arrival_en.HeaderText = "到达英文";
            this.arrival_en.Name = "arrival_en";
            this.arrival_en.ReadOnly = true;
            this.arrival_en.Width = 78;
            // 
            // gate_cn
            // 
            this.gate_cn.DataPropertyName = "gate_cn";
            this.gate_cn.HeaderText = "登机口";
            this.gate_cn.Name = "gate_cn";
            this.gate_cn.ReadOnly = true;
            this.gate_cn.Width = 66;
            // 
            // gate_en
            // 
            this.gate_en.DataPropertyName = "gate_en";
            this.gate_en.HeaderText = "登机口英文";
            this.gate_en.Name = "gate_en";
            this.gate_en.ReadOnly = true;
            this.gate_en.Width = 90;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btndeleteremarkinfo);
            this.panel2.Controls.Add(this.btneditremark);
            this.panel2.Controls.Add(this.btnremarkadd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 30);
            this.panel2.TabIndex = 4;
            // 
            // btndeleteremarkinfo
            // 
            this.btndeleteremarkinfo.AutoSize = true;
            this.btndeleteremarkinfo.Location = new System.Drawing.Point(146, 3);
            this.btndeleteremarkinfo.Name = "btndeleteremarkinfo";
            this.btndeleteremarkinfo.Size = new System.Drawing.Size(63, 23);
            this.btndeleteremarkinfo.TabIndex = 10;
            this.btndeleteremarkinfo.TabStop = false;
            this.btndeleteremarkinfo.Text = "删除记录";
            this.btndeleteremarkinfo.UseVisualStyleBackColor = true;
            this.btndeleteremarkinfo.Click += new System.EventHandler(this.btndeleteremarkinfo_Click);
            // 
            // btneditremark
            // 
            this.btneditremark.AutoSize = true;
            this.btneditremark.Location = new System.Drawing.Point(77, 3);
            this.btneditremark.Name = "btneditremark";
            this.btneditremark.Size = new System.Drawing.Size(63, 23);
            this.btneditremark.TabIndex = 9;
            this.btneditremark.TabStop = false;
            this.btneditremark.Text = "编辑记录";
            this.btneditremark.UseVisualStyleBackColor = true;
            this.btneditremark.Click += new System.EventHandler(this.btneditremark_Click);
            // 
            // btnremarkadd
            // 
            this.btnremarkadd.AutoSize = true;
            this.btnremarkadd.Location = new System.Drawing.Point(8, 3);
            this.btnremarkadd.Name = "btnremarkadd";
            this.btnremarkadd.Size = new System.Drawing.Size(63, 23);
            this.btnremarkadd.TabIndex = 8;
            this.btnremarkadd.TabStop = false;
            this.btnremarkadd.Text = "新增记录";
            this.btnremarkadd.UseVisualStyleBackColor = true;
            this.btnremarkadd.Click += new System.EventHandler(this.btnremarkadd_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 465);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editor";
            this.Text = "航显编辑器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Editor_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epEditor)).EndInit();
            this.tabPageDynamic.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDynamicDeparture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDynamicArrival)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageRemarkinfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarkinfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatus;
        private System.ComponentModel.BackgroundWorker bgwRefresh;
        private System.Windows.Forms.Timer AccessTimer;
        private System.Windows.Forms.Label lbDynamicStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider epEditor;
        private System.Windows.Forms.Label lbDynamicInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDynamicInterval;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDynamic;
        private VCustomControls.VDataGridView dgvDynamicDeparture;
        private System.Windows.Forms.Button btnGetDynamicByPlan;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private VCustomControls.VDataGridView dgvDynamicArrival;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteDepartureDynamic;
        private System.Windows.Forms.Button btnDepartureFlightFilterClear;
        private System.Windows.Forms.Button btnDepartureFlightFilter;
        private System.Windows.Forms.TextBox tbDepartureFlightFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditDepartureDynaimc;
        private System.Windows.Forms.Button btnAddDepartureDynamic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeleteArrivalDynamic;
        private System.Windows.Forms.Button btnArrivalFlightFilterClear;
        private System.Windows.Forms.Button btnArrivalFlightFilter;
        private System.Windows.Forms.TextBox tbArrivalFlightFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditArrivalDynaimc;
        private System.Windows.Forms.Button btnAddArrivalDynamic;
        private System.Windows.Forms.TabPage tabPageRemarkinfo;
        private VCustomControls.VDataGridView dgvRemarkinfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btndeleteremarkinfo;
        private System.Windows.Forms.Button btneditremark;
        private System.Windows.Forms.Button btnremarkadd;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewCheckBoxColumn errorline;
        private System.Windows.Forms.DataGridViewTextBoxColumn departure_cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departure_en;
        private System.Windows.Forms.DataGridViewTextBoxColumn guide_cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guide_en;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrival_cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrival_en;
        private System.Windows.Forms.DataGridViewTextBoxColumn gate_cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gate_en;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightdynamicid;
        private System.Windows.Forms.DataGridViewTextBoxColumn flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastmodifytime;
        private System.Windows.Forms.DataGridViewTextBoxColumn forceshow;
        private System.Windows.Forms.DataGridViewTextBoxColumn airlinecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn tovia;
        private System.Windows.Forms.DataGridViewTextBoxColumn std;
        private System.Windows.Forms.DataGridViewTextBoxColumn etd;
        private System.Windows.Forms.DataGridViewTextBoxColumn atd;
        private System.Windows.Forms.DataGridViewTextBoxColumn counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gate;
        private System.Windows.Forms.DataGridViewTextBoxColumn departstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn en_departstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn departoutward;
        private System.Windows.Forms.DataGridViewTextBoxColumn departoutward_en;
        private System.Windows.Forms.DataGridViewCheckBoxColumn manual;
        private System.Windows.Forms.DataGridViewTextBoxColumn departuredate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn en_arrivalstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivaloutward;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivaloutward_en;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivaldate;
    }
}