namespace data
{
    partial class Guide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guide));
            this.dgvGuide = new VCustomControls.ScrollDataGridView();
            this.AccessTimer = new System.Windows.Forms.Timer(this.components);
            this.bgwGuide = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxMark = new System.Windows.Forms.PictureBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.STD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICON = new System.Windows.Forms.DataGridViewImageColumn();
            this.FLIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOVIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGuide
            // 
            this.dgvGuide.AllowUserToAddRows = false;
            this.dgvGuide.AllowUserToDeleteRows = false;
            this.dgvGuide.AllowUserToResizeColumns = false;
            this.dgvGuide.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("黑体", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvGuide.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGuide.BackgroundColor = System.Drawing.Color.Black;
            this.dgvGuide.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGuide.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(184)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("黑体", 27.32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuide.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGuide.ColumnHeadersHeight = 64;
            this.dgvGuide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGuide.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STD,
            this.ICON,
            this.FLIGHT,
            this.TOVIA,
            this.GATE,
            this.REMARK});
            this.dgvGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGuide.EnableHeadersVisualStyles = false;
            this.dgvGuide.Location = new System.Drawing.Point(0, 0);
            this.dgvGuide.Name = "dgvGuide";
            this.dgvGuide.ReadOnly = true;
            this.dgvGuide.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("黑体", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvGuide.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGuide.RowTemplate.Height = 64;
            this.dgvGuide.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvGuide.Size = new System.Drawing.Size(1366, 768);
            this.dgvGuide.TabIndex = 1;
            // 
            // bgwGuide
            // 
            this.bgwGuide.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuide_DoWork);
            // 
            // pictureBoxMark
            // 
            this.pictureBoxMark.BackColor = System.Drawing.Color.White;
            this.pictureBoxMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMark.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMark.Name = "pictureBoxMark";
            this.pictureBoxMark.Size = new System.Drawing.Size(1366, 768);
            this.pictureBoxMark.TabIndex = 2;
            this.pictureBoxMark.TabStop = false;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(1313, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(41, 12);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "label1";
            this.lbTime.Visible = false;
            // 
            // STD
            // 
            this.STD.DataPropertyName = "std";
            this.STD.FillWeight = 5F;
            this.STD.HeaderText = "计划\nSTD";
            this.STD.Name = "STD";
            this.STD.ReadOnly = true;
            this.STD.Width = 108;
            // 
            // ICON
            // 
            this.ICON.DataPropertyName = "icon";
            this.ICON.FillWeight = 2F;
            this.ICON.HeaderText = "";
            this.ICON.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ICON.Name = "ICON";
            this.ICON.ReadOnly = true;
            this.ICON.Width = 44;
            // 
            // FLIGHT
            // 
            this.FLIGHT.DataPropertyName = "flight";
            this.FLIGHT.FillWeight = 6F;
            this.FLIGHT.HeaderText = "航班号\nFLIGHT";
            this.FLIGHT.Name = "FLIGHT";
            this.FLIGHT.ReadOnly = true;
            this.FLIGHT.Width = 129;
            // 
            // TOVIA
            // 
            this.TOVIA.DataPropertyName = "tovia";
            this.TOVIA.FillWeight = 20F;
            this.TOVIA.HeaderText = "目的地\nTO";
            this.TOVIA.Name = "TOVIA";
            this.TOVIA.ReadOnly = true;
            this.TOVIA.Width = 433;
            // 
            // GATE
            // 
            this.GATE.DataPropertyName = "gate";
            this.GATE.FillWeight = 5F;
            this.GATE.HeaderText = "登机口\nGATE";
            this.GATE.Name = "GATE";
            this.GATE.ReadOnly = true;
            this.GATE.Width = 108;
            // 
            // REMARK
            // 
            this.REMARK.DataPropertyName = "remark";
            this.REMARK.FillWeight = 20F;
            this.REMARK.HeaderText = "备注\nREMARK";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            this.REMARK.Width = 433;
            // 
            // Guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pictureBoxMark);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.dgvGuide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Guide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guide";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Guide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VCustomControls.ScrollDataGridView dgvGuide;
        private System.Windows.Forms.Timer AccessTimer;
        private System.ComponentModel.BackgroundWorker bgwGuide;
        private System.Windows.Forms.PictureBox pictureBoxMark;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn STD;
        private System.Windows.Forms.DataGridViewImageColumn ICON;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOVIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
    }
}