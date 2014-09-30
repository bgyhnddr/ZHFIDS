using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace global
{
    public partial class BaseForm : Form
    {

        protected int LastRowIndex;
        protected string ViewCommentText;
        protected List<Object> ChildrenForm = new List<Object>();
        protected bool IsChild = false;
        protected List<ConDouble> FlightsList = new List<ConDouble>();
        protected Graphics DrawGraphics;
        protected delegate void RefreshHandle();

        public static bool En = true;

        public static List<ConDouble> ToviaLangList = new List<ConDouble>();
        public static List<ConDouble> RemarkList = new List<ConDouble>();

        public BaseForm()
        {
            InitializeComponent();
            BindingKeyPress();
            DrawGraphics = Graphics.FromHwnd(this.Handle);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void BindingKeyPress()
        {
            this.Load += new EventHandler((o, eg) =>
            {
                if (global.Variable.APPLICATIONRUN)
                {
                    Cursor.Position = new Point(0, 0);
                    global.Function.ShowCursor(false);
                }
                this.KeyPress += new KeyPressEventHandler((sender, e) =>
                {
                    if (e.KeyChar == (char)Keys.Escape)
                    {
                        this.Close();
                    }
                });
                foreach (Control control in Controls)
                {
                    control.KeyPress += new KeyPressEventHandler((sender, e) =>
                    {
                        if (e.KeyChar == (char)Keys.Escape)
                        {
                            this.Close();
                        }
                    });
                }
            });

            this.FormClosed += new FormClosedEventHandler((sender, e) => {
                global.Function.ShowCursor(true);
            });
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChildrenForm.ForEach(o =>
            {
                var form = (Form)o;
                if (!form.IsDisposed)
                {
                    form.Close();
                }
            });
        }

        protected void CellFormat(DataGridView grid)
        {
            
        }

        protected void CreateRollingTimer(Timer timer, DataGridView grid, Label lbTime = null)
        {
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler((sender, e) =>
            {
                try
                {
                    if (lbTime != null)
                    {
                        lbTime.Text = DateTime.Now.ToShortTimeString();
                    }
                }
                catch
                {

                }
            });
            timer.Enabled = true;
        }

        protected void CreateLanguageTimer(Timer timer, DataGridView grid)
        {
            timer.Tick += new System.EventHandler((sender, e) =>
            {
                try
                {
                    if (grid != null)
                    {
                        if (ToviaLangList.Count > 0)
                        {
                            ToviaLangList.ForEach((o) =>
                            {
                                if (grid[o.point.X, o.point.Y].Value != null)
                                {
                                    grid[o.point.X, o.point.Y].Value = o.hidetext;
                                }
                            });
                        }

                        if (RemarkList.Count > 0)
                        {
                            RemarkList.ForEach((o) =>
                            {
                                if (grid[o.point.X, o.point.Y].Value != null)
                                {
                                    grid[o.point.X, o.point.Y].Value = o.hidetext;
                                }
                            });
                        }

                        if (FlightsList.Count > 0)
                        {
                            FlightsList.ForEach((o) =>
                            {
                                if (grid["FLIGHT", o.point.Y].Value != null)
                                {
                                    grid["FLIGHT", o.point.Y].Value = o.hidetext;
                                    grid["ICON", o.point.Y].Value = global.Function.GetIcon(o.hidetext.Substring(0,2));
                                }
                            });
                        }
                        grid.Refresh();
                    }
                }
                catch
                {

                }
            });
        }
    }


    public class ConDouble
    {
        public Point point;
        public string hidetext;
        public string showtext;
    }
}
