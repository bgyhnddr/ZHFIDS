namespace data
{
    partial class Arrival
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arrival));
            this.dgvArrival = new VCustomControls.ScrollDataGridView();
            this.AccessTimer = new System.Windows.Forms.Timer(this.components);
            this.bgwArrival = new System.ComponentModel.BackgroundWorker();
            this.lbTime = new System.Windows.Forms.Label();
            this.pictureBoxMark = new VCustomControls.CPictureBox();
            this.STA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICON = new System.Windows.Forms.DataGridViewImageColumn();
            this.FLIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FROMVIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArrival
            // 
            this.dgvArrival.AllowUserToAddRows = false;
            this.dgvArrival.AllowUserToDeleteRows = false;
            this.dgvArrival.AllowUserToResizeColumns = false;
            this.dgvArrival.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("黑体", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvArrival.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArrival.BackgroundColor = System.Drawing.Color.Black;
            this.dgvArrival.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvArrival.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(184)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("黑体", 27.32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArrival.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArrival.ColumnHeadersHeight = 64;
            this.dgvArrival.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArrival.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STA,
            this.ICON,
            this.FLIGHT,
            this.FROMVIA,
            this.ETA,
            this.REMARK});
            this.dgvArrival.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArrival.EnableHeadersVisualStyles = false;
            this.dgvArrival.Location = new System.Drawing.Point(0, 0);
            this.dgvArrival.Name = "dgvArrival";
            this.dgvArrival.ReadOnly = true;
            this.dgvArrival.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("黑体", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvArrival.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArrival.RowTemplate.Height = 64;
            this.dgvArrival.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvArrival.Size = new System.Drawing.Size(1366, 768);
            this.dgvArrival.TabIndex = 2;
            // 
            // bgwArrival
            // 
            this.bgwArrival.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwArrival_DoWork);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(1313, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(41, 12);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "label1";
            this.lbTime.Visible = false;
            // 
            // pictureBoxMark
            // 
            this.pictureBoxMark.BackColor = System.Drawing.Color.White;
            this.pictureBoxMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMark.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMark.Name = "pictureBoxMark";
            this.pictureBoxMark.Size = new System.Drawing.Size(1366, 768);
            this.pictureBoxMark.TabIndex = 3;
            this.pictureBoxMark.TabStop = false;
            // 
            // STA
            // 
            this.STA.DataPropertyName = "sta";
            this.STA.FillWeight = 5F;
            this.STA.HeaderText = "计划\nSTA";
            this.STA.Name = "STA";
            this.STA.ReadOnly = true;
            this.STA.Width = 108;
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
            // FROMVIA
            // 
            this.FROMVIA.DataPropertyName = "fromvia";
            this.FROMVIA.FillWeight = 20F;
            this.FROMVIA.HeaderText = "始发地/经停\nFROM/VIA";
            this.FROMVIA.Name = "FROMVIA";
            this.FROMVIA.ReadOnly = true;
            this.FROMVIA.Width = 433;
            // 
            // ETA
            // 
            this.ETA.DataPropertyName = "eta";
            this.ETA.HeaderText = "预计\nETA";
            this.ETA.Name = "ETA";
            this.ETA.ReadOnly = true;
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
            // Arrival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pictureBoxMark);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.dgvArrival);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Arrival";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arrival";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Arrival_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VCustomControls.ScrollDataGridView dgvArrival;
        private System.Windows.Forms.Timer AccessTimer;
        private System.ComponentModel.BackgroundWorker bgwArrival;
        private System.Windows.Forms.Label lbTime;
        private VCustomControls.CPictureBox pictureBoxMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn STA;
        private System.Windows.Forms.DataGridViewImageColumn ICON;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FROMVIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETA;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
    }
}