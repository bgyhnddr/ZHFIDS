namespace ZHFIDS
{
    partial class FIDS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubsystem = new System.Windows.Forms.ComboBox();
            this.btnAccess = new System.Windows.Forms.Button();
            this.cbAutoAccess = new System.Windows.Forms.CheckBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.FidsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.gbGate = new System.Windows.Forms.GroupBox();
            this.nbAD = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tbGate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.tbMAC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numRowCount = new System.Windows.Forms.NumericUpDown();
            this.gbShowSetting = new System.Windows.Forms.GroupBox();
            this.tbCarouseld = new System.Windows.Forms.TextBox();
            this.lbCarouseld = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FidsErrorProvider)).BeginInit();
            this.gbAccount.SuspendLayout();
            this.gbGate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowCount)).BeginInit();
            this.gbShowSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口";
            // 
            // cbSubsystem
            // 
            this.cbSubsystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubsystem.FormattingEnabled = true;
            this.cbSubsystem.Location = new System.Drawing.Point(59, 92);
            this.cbSubsystem.Name = "cbSubsystem";
            this.cbSubsystem.Size = new System.Drawing.Size(121, 20);
            this.cbSubsystem.TabIndex = 2;
            this.cbSubsystem.SelectedIndexChanged += new System.EventHandler(this.cbSubsystem_SelectedIndexChanged);
            // 
            // btnAccess
            // 
            this.btnAccess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAccess.Location = new System.Drawing.Point(55, 332);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(75, 23);
            this.btnAccess.TabIndex = 3;
            this.btnAccess.Text = "进入";
            this.btnAccess.UseVisualStyleBackColor = true;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // cbAutoAccess
            // 
            this.cbAutoAccess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAutoAccess.AutoSize = true;
            this.cbAutoAccess.Location = new System.Drawing.Point(55, 310);
            this.cbAutoAccess.Name = "cbAutoAccess";
            this.cbAutoAccess.Size = new System.Drawing.Size(72, 16);
            this.cbAutoAccess.TabIndex = 4;
            this.cbAutoAccess.Text = "自动进入";
            this.cbAutoAccess.UseVisualStyleBackColor = true;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(59, 6);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 21);
            this.tbIP.TabIndex = 5;
            this.tbIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbIP_Validating);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(59, 33);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(51, 21);
            this.tbPort.TabIndex = 6;
            this.tbPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbPort_Validating);
            // 
            // FidsErrorProvider
            // 
            this.FidsErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.FidsErrorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "子系统";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(53, 49);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 11;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(53, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 21);
            this.tbUser.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "用户名";
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.label5);
            this.gbAccount.Controls.Add(this.tbPassword);
            this.gbAccount.Controls.Add(this.label4);
            this.gbAccount.Controls.Add(this.tbUser);
            this.gbAccount.Location = new System.Drawing.Point(14, 144);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(168, 81);
            this.gbAccount.TabIndex = 12;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "运行系统帐号信息";
            this.gbAccount.Visible = false;
            // 
            // gbGate
            // 
            this.gbGate.Controls.Add(this.nbAD);
            this.gbGate.Controls.Add(this.label10);
            this.gbGate.Controls.Add(this.tbGate);
            this.gbGate.Controls.Add(this.label6);
            this.gbGate.Location = new System.Drawing.Point(14, 144);
            this.gbGate.Name = "gbGate";
            this.gbGate.Size = new System.Drawing.Size(168, 81);
            this.gbGate.TabIndex = 14;
            this.gbGate.TabStop = false;
            this.gbGate.Text = "登机口";
            this.gbGate.Visible = false;
            // 
            // nbAD
            // 
            this.nbAD.Location = new System.Drawing.Point(102, 49);
            this.nbAD.Name = "nbAD";
            this.nbAD.Size = new System.Drawing.Size(43, 21);
            this.nbAD.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "广告频率（秒）";
            // 
            // tbGate
            // 
            this.tbGate.Location = new System.Drawing.Point(55, 20);
            this.tbGate.Name = "tbGate";
            this.tbGate.Size = new System.Drawing.Size(100, 21);
            this.tbGate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "样式";
            // 
            // cbStyle
            // 
            this.cbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Items.AddRange(new object[] {
            "SZ",
            "HK",
            "GZ"});
            this.cbStyle.Location = new System.Drawing.Point(59, 118);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(121, 20);
            this.cbStyle.TabIndex = 16;
            // 
            // tbMAC
            // 
            this.tbMAC.Location = new System.Drawing.Point(59, 60);
            this.tbMAC.Name = "tbMAC";
            this.tbMAC.Size = new System.Drawing.Size(100, 21);
            this.tbMAC.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "MAC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "显示行数";
            // 
            // numRowCount
            // 
            this.numRowCount.Location = new System.Drawing.Point(67, 30);
            this.numRowCount.Name = "numRowCount";
            this.numRowCount.Size = new System.Drawing.Size(49, 21);
            this.numRowCount.TabIndex = 2;
            // 
            // gbShowSetting
            // 
            this.gbShowSetting.Controls.Add(this.tbCarouseld);
            this.gbShowSetting.Controls.Add(this.lbCarouseld);
            this.gbShowSetting.Controls.Add(this.numRowCount);
            this.gbShowSetting.Controls.Add(this.label7);
            this.gbShowSetting.Location = new System.Drawing.Point(14, 144);
            this.gbShowSetting.Name = "gbShowSetting";
            this.gbShowSetting.Size = new System.Drawing.Size(168, 81);
            this.gbShowSetting.TabIndex = 15;
            this.gbShowSetting.TabStop = false;
            this.gbShowSetting.Text = "显示设置";
            this.gbShowSetting.Visible = false;
            // 
            // tbCarouseld
            // 
            this.tbCarouseld.Location = new System.Drawing.Point(67, 55);
            this.tbCarouseld.Name = "tbCarouseld";
            this.tbCarouseld.Size = new System.Drawing.Size(49, 21);
            this.tbCarouseld.TabIndex = 4;
            this.tbCarouseld.Visible = false;
            // 
            // lbCarouseld
            // 
            this.lbCarouseld.AutoSize = true;
            this.lbCarouseld.Location = new System.Drawing.Point(8, 58);
            this.lbCarouseld.Name = "lbCarouseld";
            this.lbCarouseld.Size = new System.Drawing.Size(41, 12);
            this.lbCarouseld.TabIndex = 3;
            this.lbCarouseld.Text = "转盘号";
            // 
            // tbComments
            // 
            this.tbComments.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbComments.Location = new System.Drawing.Point(12, 251);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(167, 49);
            this.tbComments.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "备注";
            // 
            // FIDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(191, 367);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbMAC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.cbAutoAccess);
            this.Controls.Add(this.btnAccess);
            this.Controls.Add(this.cbSubsystem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbGate);
            this.Controls.Add(this.gbAccount);
            this.Controls.Add(this.gbShowSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::ZHFIDS.Properties.Resources.favicon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FIDS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIDS";
            this.Load += new System.EventHandler(this.FIDS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FidsErrorProvider)).EndInit();
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.gbGate.ResumeLayout(false);
            this.gbGate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowCount)).EndInit();
            this.gbShowSetting.ResumeLayout(false);
            this.gbShowSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubsystem;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.CheckBox cbAutoAccess;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.ErrorProvider FidsErrorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.GroupBox gbGate;
        private System.Windows.Forms.TextBox tbGate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.TextBox tbMAC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbShowSetting;
        private System.Windows.Forms.NumericUpDown numRowCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCarouseld;
        private System.Windows.Forms.Label lbCarouseld;
        private System.Windows.Forms.NumericUpDown nbAD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label11;
    }
}