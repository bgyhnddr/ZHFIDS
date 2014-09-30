using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZHFIDS
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void tbPasswordnew2_Validating(object sender, CancelEventArgs e)
        {
            if (CheckPasswordSame(tbPasswordnew.Text, tbPasswordnew2.Text))
            {
                epTips.SetError(tbPasswordnew2, string.Empty);
            }
            else
            {
                epTips.SetError(tbPasswordnew2, global.Const.PASSWORDNOTTHESAME);
                e.Cancel = true;
            }
        }
        private bool CheckPasswordSame(string password,string password2)
        {
            return password == password2;
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (AdminLogin.CheckPassword(tbPassword.Text))
                {
                    epTips.SetError(tbPassword, string.Empty);
                }
                else
                {
                    epTips.SetError(tbPassword, global.Const.PASSWORDERROR);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                epTips.SetError(tbPassword, string.Format(global.Const.ERROR, ex.Message));
                e.Cancel = true;
            }
        }

        private void SavePassword(string password)
        {
            var passwordrow = data.FIDSAdapter.ConfigAdapter.GetData().Where(o => o.code == global.Const.PASSWORDCONFIG).First();
            if (!string.IsNullOrWhiteSpace(password))
            {
                passwordrow.value = global.Function.GetMD5Hash(password);
            }
            else
            {
                passwordrow.value = string.Empty;
            }

            data.FIDSAdapter.ConfigAdapter.Update(passwordrow);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    SavePassword(tbPasswordnew.Text);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }
    }
}
