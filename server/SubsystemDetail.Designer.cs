namespace data
{
    partial class SubsystemDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubsystemDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.lbSubsystem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numAdvance = new System.Windows.Forms.NumericUpDown();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAdvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "子系统";
            // 
            // lbSubsystem
            // 
            this.lbSubsystem.AutoSize = true;
            this.lbSubsystem.Location = new System.Drawing.Point(60, 13);
            this.lbSubsystem.Name = "lbSubsystem";
            this.lbSubsystem.Size = new System.Drawing.Size(41, 12);
            this.lbSubsystem.TabIndex = 1;
            this.lbSubsystem.Text = "子系统";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "提前显示时间（分钟）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "消失延迟时间（分钟）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "更新频率（秒）";
            // 
            // numAdvance
            // 
            this.numAdvance.Location = new System.Drawing.Point(144, 57);
            this.numAdvance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numAdvance.Name = "numAdvance";
            this.numAdvance.Size = new System.Drawing.Size(72, 21);
            this.numAdvance.TabIndex = 6;
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(144, 111);
            this.numInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(72, 21);
            this.numInterval.TabIndex = 7;
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(144, 84);
            this.numDelay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(72, 21);
            this.numDelay.TabIndex = 8;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(141, 142);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // SubsystemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 177);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.numAdvance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSubsystem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SubsystemDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "子系统编辑";
            this.Load += new System.EventHandler(this.SubsystemDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAdvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSubsystem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAdvance;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Button btnConfirm;
    }
}