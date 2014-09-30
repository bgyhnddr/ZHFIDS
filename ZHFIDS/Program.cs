using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZHFIDS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool isRuned;
                System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRunOneInstance", out isRuned);
                if (isRuned)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Forms.NotifyForm = new MainNotify();
                    global.Variable.APPLICATIONRUN = true;
                    Application.Run(Forms.NotifyForm);
                    mutex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("程序已启动!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(global.Const.ERROR, ex.Message));
            }
        }
    }
}
