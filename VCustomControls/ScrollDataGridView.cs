using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCustomControls
{
    public partial class ScrollDataGridView : DataGridView
    {
        private List<RollingCell> RollingCellList = new List<RollingCell>();
        
        public ScrollDataGridView()
        {
            InitializeComponent();
            CellPaint();
            InitTimer(rollingTimer, 25);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RollingCellList.Clear();
            rollingTimer.Enabled = true;
            base.OnPaint(e);
        }

        private void InitTimer(Timer timer,int interval)
        {
            timer.Interval = interval;
            timer.Tick += new EventHandler((o, e) => {
                try
                {
                    foreach (var rollingCell in RollingCellList)
                    {
                        var bufferImage = new Bitmap(rollingCell.rect.Width, rollingCell.rect.Height);
                        var imageGraphics = Graphics.FromImage(bufferImage);
                        imageGraphics.Clear(rollingCell.style.BackColor);

                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Trimming = StringTrimming.Word;
                        var renderRect = new Rectangle(0, 5, (int)(rollingCell.textLenght * 1.1), rollingCell.rect.Height);
                        rollingCell.offset -= 3;
                        if (rollingCell.offset < -(rollingCell.textLenght - rollingCell.moveLength))
                        {
                            rollingCell.offset = rollingCell.rect.Width / 2;
                        }

                        int offset = 0;
                        if (rollingCell.offset > 0)
                        {
                            offset = 0;
                        }
                        else if (rollingCell.offset <= 0 && rollingCell.offset >= -rollingCell.moveLength)
                        {
                            offset = rollingCell.offset;
                        }
                        else if (rollingCell.offset < -rollingCell.moveLength)
                        {
                            offset = -rollingCell.moveLength;
                        }


                        renderRect.Offset(offset, 0);
                        imageGraphics.DrawString(rollingCell.text,
                            rollingCell.style.Font,
                            new SolidBrush(rollingCell.style.ForeColor),
                            renderRect, stringFormat);
                        this.CreateGraphics().DrawImage((Image)bufferImage, rollingCell.rect);
                    }
                }
                catch
                {

                }
            });
            timer.Start();
        }

        private void CellPaint()
        {
            this.CellPainting += new DataGridViewCellPaintingEventHandler((o, e) =>
            {
                try
                {
                    if (e.RowIndex >= 0 && e.Value != null && e.Value.GetType() == typeof(string))
                    {
                        var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                        if (textLength > e.CellBounds.Width)
                        {
                            RollingCellList.Add(new RollingCell()
                            {
                                text = e.Value.ToString(),
                                rect = e.CellBounds,
                                style = e.CellStyle,
                                offset = e.CellBounds.Width / 2,
                                textLenght = (int)textLength,
                                moveLength = (int)textLength - e.CellBounds.Width
                            });
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
        public string text;
        public DataGridViewCellStyle style;
        public Rectangle rect;
        public Graphics graphics;
        public int moveLength;
        public int offset = 0;
        public int textLenght;
    }
}
