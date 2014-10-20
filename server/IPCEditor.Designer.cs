namespace data
{
    partial class IPCEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPCEditor));
            this.epTips = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.cbSubsystem = new System.Windows.Forms.ComboBox();
            this.cbAutoAccess = new System.Windows.Forms.CheckBox();
            this.lbDynamicStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMAC = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epTips)).BeginInit();
            this.SuspendLayout();
            // 
            // epTips
            // 
            this.epTips.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epTips.ContainerControl = this;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(59, 13);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(121, 21);
            this.tbIP.TabIndex = 0;
            this.tbIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbIP_Validating);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(59, 40);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(121, 21);
            this.tbPort.TabIndex = 1;
            this.tbPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbPort_Validating);
            // 
            // cbSubsystem
            // 
            this.cbSubsystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubsystem.FormattingEnabled = true;
            this.cbSubsystem.Location = new System.Drawing.Point(59, 94);
            this.cbSubsystem.Name = "cbSubsystem";
            this.cbSubsystem.Size = new System.Drawing.Size(121, 20);
            this.cbSubsystem.TabIndex = 2;
            // 
            // cbAutoAccess
            // 
            this.cbAutoAccess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAutoAccess.AutoSize = true;
            this.cbAutoAccess.Location = new System.Drawing.Point(59, 184);
            this.cbAutoAccess.Name = "cbAutoAccess";
            this.cbAutoAccess.Size = new System.Drawing.Size(72, 16);
            this.cbAutoAccess.TabIndex = 3;
            this.cbAutoAccess.Text = "自动登录";
            this.cbAutoAccess.UseVisualStyleBackColor = true;
            // 
            // lbDynamicStatus
            // 
            this.lbDynamicStatus.AutoSize = true;
            this.lbDynamicStatus.Location = new System.Drawing.Point(12, 16);
            this.lbDynamicStatus.Name = "lbDynamicStatus";
            this.lbDynamicStatus.Size = new System.Drawing.Size(17, 12);
            this.lbDynamicStatus.TabIndex = 4;
            this.lbDynamicStatus.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "子系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "MAC";
            // 
            // tbMAC
            // 
            this.tbMAC.Location = new System.Drawing.Point(59, 67);
            this.tbMAC.Name = "tbMAC";
            this.tbMAC.Size = new System.Drawing.Size(121, 21);
            this.tbMAC.TabIndex = 7;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(59, 206);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(78, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = " 确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "备注";
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(59, 120);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(121, 52);
            this.tbComments.TabIndex = 10;
            // 
            // IPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(197, 238);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMAC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDynamicStatus);
            this.Controls.Add(this.cbAutoAccess);
            this.Controls.Add(this.cbSubsystem);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPCEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工控机";
            this.Load += new System.EventHandler(this.IPCEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epTips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider epTips;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.ComboBox cbSubsystem;
        private System.Windows.Forms.CheckBox cbAutoAccess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDynamicStatus;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbComments;

    }
}