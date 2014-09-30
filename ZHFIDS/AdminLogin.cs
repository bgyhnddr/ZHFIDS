using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ZHFIDS
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                global.Variable.ADMIN = true;
                this.Close();
            }
        }


        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(CheckPassword(tbPassword.Text))
                {
                    epTips.SetError(tbPassword, string.Empty);
                }
                else
                {
                    epTips.SetError(tbPassword, global.Const.PASSWORDERROR);
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                epTips.SetError(tbPassword, string.Format(global.Const.ERROR, ex.Message));
                e.Cancel = true;
            }
        } 

        public static bool CheckPassword(string passwordInput)
        {
            var password = data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.PASSWORDCONFIG).First().value;
            if(!string.IsNullOrWhiteSpace(passwordInput))
            {
                passwordInput = global.Function.GetMD5Hash(passwordInput);
            }
            return password == passwordInput;
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidateChildren())
                {
                    global.Variable.ADMIN = true;
                    this.Close();
                }
            }
        }
    }
}
