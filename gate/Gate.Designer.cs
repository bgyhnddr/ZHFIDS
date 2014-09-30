namespace data
{
    partial class Gate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gate));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTips = new System.Windows.Forms.Panel();
            this.panelAD = new System.Windows.Forms.Panel();
            this.AccessTimer = new System.Windows.Forms.Timer(this.components);
            this.bgwGate = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxMark = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelTitle.Controls.Add(this.lbTime);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1366, 127);
            this.panelTitle.TabIndex = 3;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            // 
            // lbTime
            // 
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTime.Location = new System.Drawing.Point(1161, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(205, 127);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "label1";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTime.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Black;
            this.panelContent.Location = new System.Drawing.Point(0, 133);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1366, 300);
            this.panelContent.TabIndex = 4;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelTips
            // 
            this.panelTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelTips.Location = new System.Drawing.Point(0, 440);
            this.panelTips.Name = "panelTips";
            this.panelTips.Size = new System.Drawing.Size(1366, 76);
            this.panelTips.TabIndex = 5;
            this.panelTips.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTips_Paint);
            // 
            // panelAD
            // 
            this.panelAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAD.Location = new System.Drawing.Point(0, 522);
            this.panelAD.Name = "panelAD";
            this.panelAD.Size = new System.Drawing.Size(1366, 246);
            this.panelAD.TabIndex = 6;
            // 
            // bgwGate
            // 
            this.bgwGate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGate_DoWork);
            // 
            // pictureBoxMark
            // 
            this.pictureBoxMark.BackColor = System.Drawing.Color.White;
            this.pictureBoxMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMark.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMark.Name = "pictureBoxMark";
            this.pictureBoxMark.Size = new System.Drawing.Size(1366, 768);
            this.pictureBoxMark.TabIndex = 7;
            this.pictureBoxMark.TabStop = false;
            // 
            // Gate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pictureBoxMark);
            this.Controls.Add(this.panelAD);
            this.Controls.Add(this.panelTips);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Gate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Gate_Load);
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelTips;
        private System.Windows.Forms.Panel panelAD;
        private System.Windows.Forms.Timer AccessTimer;
        private System.ComponentModel.BackgroundWorker bgwGate;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.PictureBox pictureBoxMark;
    }
}