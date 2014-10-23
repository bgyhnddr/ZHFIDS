using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Text;

namespace VCustomControls
{
    public partial class ScrollDataGridView : DataGridView
    {
        private List<RollingCell> RollingCellList = new List<RollingCell>();
        private int Interval = 20;
        public bool Drawed = false;
        public ScrollDataGridView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
            this.MouseClick += new MouseEventHandler((o, e) => {
                Drawed = false;
            });
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            CellPaint();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (Drawed)
                {
                    Invalidate();
                }
                else
                {
                    RollingCellList.RemoveAll((o) =>
                    {
                        if (this[o.x, o.y].Value == null)
                        {
                            return true;
                        }
                        var has = (this[o.x, o.y].Value.ToString() == o.text);
                        if (has)
                        {
                            return false;
                        }
                        o.thread.Abort();
                        return true;
                    });

                    rollingTimer.Enabled = true;
                    base.OnPaint(e);
                    Drawed = true;
                }
            }
            catch
            {

            }
        }
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                Drawed = false;
                base.DataSource = value;
            }
        }
        private void CellPaint()
        {
            this.CellPainting += new DataGridViewCellPaintingEventHandler((o, e) =>
            {
                try
                {
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    if (e.RowIndex >= 0 && e.Value != null && e.Value.GetType() == typeof(string))
                    {
                        if (RollingCellList.Where(obj => obj.x == e.ColumnIndex && obj.y == e.RowIndex).Count() == 0)
                        {
                            var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                            if (textLength > e.CellBounds.Width)
                            {
                                //RollingCellList.Add(new RollingCell()
                                //{
                                //    x = e.ColumnIndex,
                                //    y = e.RowIndex,
                                //    text = e.Value.ToString(),
                                //    rect = e.CellBounds,
                                //    style = e.CellStyle,
                                //    offset = e.CellBounds.Width,
                                //    textLenght = (int)textLength,
                                //    moveLength = (int)textLength - e.CellBounds.Width
                                //});
                                var rollingCell = new RollingCell()
                                 {
                                     x = e.ColumnIndex,
                                     y = e.RowIndex,
                                     text = e.Value.ToString(),
                                     rect = e.CellBounds,
                                     style = e.CellStyle,
                                     offset = e.CellBounds.Width,
                                     textLenght = (int)textLength,
                                     moveLength = (int)textLength - e.CellBounds.Width
                                 };
                                rollingCell.thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((obj) =>
                                {
                                    try
                                    {
                                        var watch = new Stopwatch();
                                        watch.Start();
                                        while (!this.IsDisposed)
                                        {
                                            if (watch.ElapsedMilliseconds < 30)
                                            {
                                                System.Threading.Thread.Sleep(30 - (int)watch.ElapsedMilliseconds);
                                            }
                                            watch.Restart();
                                            var rc = (RollingCell)obj;
                                            rc.offset -= 3;
                                            var bufferImage = new Bitmap(rc.rect.Width, rc.rect.Height);
                                            var imageGraphics = Graphics.FromImage(bufferImage);
                                            imageGraphics.Clear(rc.style.BackColor);

                                            StringFormat stringFormat = new StringFormat();
                                            stringFormat.Alignment = StringAlignment.Near;
                                            stringFormat.LineAlignment = StringAlignment.Center;
                                            stringFormat.Trimming = StringTrimming.Word;
                                            var renderRect = new Rectangle(0, 5, (int)(rc.textLenght * 1.1), rc.rect.Height);

                                            if (rc.offset < -rc.textLenght)
                                            {
                                                rc.offset = rc.rect.Width;
                                            }

                                            int offset = rc.offset;


                                            renderRect.Offset(offset, 0);
                                            imageGraphics.DrawString(rc.text,
                                                rc.style.Font,
                                                new SolidBrush(rc.style.ForeColor),
                                                renderRect, stringFormat);
                                            this.CreateGraphics().DrawImage((Image)bufferImage, rc.rect);
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }));
                                RollingCellList.Add(rollingCell);
                                rollingCell.thread.IsBackground = true;
                                rollingCell.thread.Start(rollingCell);
                                    //thread = new System.Threading.Thread(new System.Threading.ThreadStart(() => {
                                        
                                    //    System.Threading.Thread.Sleep(Interval);
                                    //}))
                                e.Handled = true;
                            }
                        }
                    }
                }
                catch
                {

                }
            });
        }
    }


    public class RollingCell
    {
        public int x;
        public int y;
        public string text;
        public DataGridViewCellStyle style;
        public Rectangle rect;
        public Graphics graphics;
        public int moveLength;
        public int offset = 0;
        public int textLenght;
        public System.Threading.Thread thread;
    }
}
