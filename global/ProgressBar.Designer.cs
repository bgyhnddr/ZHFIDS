namespace global
{
    partial class ProgressBar
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
            this.fidsProgress = new System.Windows.Forms.ProgressBar();
            this.fidsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fidsProgress
            // 
            this.fidsProgress.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fidsProgress.Location = new System.Drawing.Point(12, 12);
            this.fidsProgress.Name = "fidsProgress";
            this.fidsProgress.Size = new System.Drawing.Size(260, 23);
            this.fidsProgress.TabIndex = 0;
            // 
            // fidsBackgroundWorker
            // 
            this.fidsBackgroundWorker.WorkerReportsProgress = true;
            this.fidsBackgroundWorker.WorkerSupportsCancellation = true;
            this.fidsBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fidsBackgroundWorker_ProgressChanged);
            this.fidsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fidsBackgroundWorker_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(108, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(14, 41);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(258, 56);
            this.tbStatus.TabIndex = 3;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 131);
            this.ControlBox = false;
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.fidsProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进图条";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProgressBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.ComponentModel.BackgroundWorker fidsBackgroundWorker;
        public System.Windows.Forms.ProgressBar fidsProgress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbStatus;
    }
}