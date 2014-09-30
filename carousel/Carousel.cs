using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace data
{
    public partial class Carousel : global.BaseForm
    {
        private int CurrentPage;
        private DataSetCarousel.CarouselDataTable CarouselTable = new DataSetCarousel.CarouselDataTable();
        private DataSetCarouselTableAdapters.CarouselTableAdapter CarouselAdapter = new DataSetCarouselTableAdapters.CarouselTableAdapter();

        public Carousel()
        {
            InitializeComponent();
            filetransfer.FileIO.StartFileListen(this, new filetransfer.FileIO.FinishHandle(() => {
                global.Function.InitIcon();
            }));
            global.Function.CreateAccessTimer(AccessTimer);
        }


        private void Carousel_Load(object sender, EventArgs e)
        {
            Init();
            bgwCarousel.RunWorkerAsync();
        }

        private void Init()
        {
            try
            {
                pictureBoxMark.Size = this.Size;
                global.Function.CreateErrorImage(pictureBoxMark);
                global.Function.InitIcon();
                InitPanel(global.Variable.RowCount);
                CarouselAdapter.GetData();
                ViewCommentText = CarouselAdapter.Adapter.SelectCommand.CommandText;
            }
            catch
            {
                pictureBoxMark.Visible = true;
            }
        }

        private DataSetCarousel.CarouselDataTable GetCarouselTable(ref int currentPage, int perPage, int preHour, int afterMin)
        {
            string where = " AND ";
            #region 提前起飞后显示时间设置
            where += "(";
            where += string.Format("case when ata='' then false else timediff(now(),adatetime)<'{0}' END", new TimeSpan(0, afterMin, 0).ToString());
            where += ")";
            #endregion
            where += string.Format(" limit {0},{1}", currentPage * perPage, perPage);
            CarouselAdapter.Adapter.SelectCommand.CommandText = ViewCommentText + where;
            var table = CarouselAdapter.GetData();
            //判断page的情况
            if (currentPage != 0)
            {
                if (table.Rows.Count == 0)
                {
                    currentPage = 0;
                    return GetCarouselTable(ref currentPage, perPage, preHour, afterMin);
                }
            }
            currentPage += 1;
            return table;
        }

        private void InitPanel(int rowCount)
        {
            for (var i = 0; i < rowCount; i++)
            {
                var panel = new System.Windows.Forms.Panel();
                panel.BackColor = fidsstyle.Style.RowBackColor;
                var rowHeight = (Height - lbTitle.Height) / rowCount - 5;
                panel.Name = "panel" + i.ToString();
                panel.Size = new System.Drawing.Size(Width, rowHeight);
                panel.Location = new System.Drawing.Point(0, lbTitle.Height + 5 + i * (rowHeight + 5));

                Controls.Add(panel);
            }
        }

        private void SetValueByRow(DataSetCarousel.CarouselRow row, System.Windows.Forms.Panel panel)
        {

            #region setvia
            string from, fromen;
            string tovia, toviaen;
            fromen = row.en_from;
            toviaen = row.en_tovia;
            from = row.from;
            tovia = row.tovia;
            var to = tovia.Split(' ');
            var toen = toviaen.Split(' ');

            var fromviaList = new List<string>();
            var fromviaenList = new List<string>();
            fromviaList.Add(from);
            fromviaenList.Add(fromen);

            if (tovia.IndexOf("*") >= 0)
            {
                var tempList = tovia.Split('*');
                if (!string.IsNullOrWhiteSpace(tempList[0]))
                {
                    tempList[0].Trim().Split(' ').ToList().ForEach((o) =>
                    {
                        fromviaList.Add(o);
                    });
                }

                tempList = toviaen.Split('*');
                if (!string.IsNullOrWhiteSpace(tempList[0]))
                {
                    tempList[0].Trim().Split(' ').ToList().ForEach((o) =>
                    {
                        fromviaenList.Add(o);
                    });
                }
            }
            else
            {
                for (var i = 0; i < to.Length - 1; i++)
                {
                    fromviaList.Add(to[i]);
                    fromviaenList.Add(toen[i]);
                }
            }

            var via = string.Join(" ", fromviaList);
            var viaen = string.Join(" ", fromviaenList);
            #endregion

            #region setControl
            panel.Controls.Clear();
            var g = Graphics.FromHwnd(this.Handle);

            int titleSize, contentSize, logoSize, fromViaSize, fromViaenSize, carouselSize, carouseWidth, contentWidth;
            contentSize = (int)(panel.Height * 0.25);
            titleSize = (int)(panel.Height * 0.2);
            logoSize = (int)(titleSize * 0.8125);

            carouseWidth = Width / 5;
            carouselSize = panel.Height;
            contentWidth = Width - carouseWidth;
            fromViaSize = contentSize;
            var viawidth = g.MeasureString(via, new Font("黑体", contentSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Width;
            if (viawidth > contentWidth)
            {
                var newSize = fromViaSize * contentWidth / viawidth;
                fromViaSize = (int)newSize - 2;
            }

            fromViaenSize = contentSize / 3 * 2;
            var viaenwidth = g.MeasureString(via, new Font("黑体", fromViaenSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Width;
            if (viaenwidth > contentWidth)
            {
                var newSize = fromViaenSize * contentWidth / viaenwidth;
                fromViaenSize = (int)newSize - 2;
            }

            var titlePanel = new System.Windows.Forms.Panel()
            {
                Name = panel.Name + "panelTitle",
                Height = titleSize,
                Width = contentWidth,
                BackColor = Color.Transparent,
                Location = new Point(0, 0)
            };



            titlePanel.Paint += new PaintEventHandler((o, e) => {
                var pos = 0;
                var font = new Font("黑体", titleSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                var fordColor = Color.White;
                foreach (var flight in row.flight.Split(','))
                {
                    if(!string.IsNullOrWhiteSpace(flight))
                    {
                        var icon = global.Function.GetIcon(flight.Substring(0,2));
                        e.Graphics.DrawImage(global.Function.GetIcon(flight.Substring(0, 2)),
                            new Point(pos, (int)((e.ClipRectangle.Height - icon.Height) / 2)));
                        pos += icon.Width;
                        var size = e.Graphics.MeasureString(flight, font);
                        e.Graphics.DrawString(flight, font, new SolidBrush(fordColor),
                            new Point(pos, (int)((e.ClipRectangle.Height - size.Height) / 2)));
                        pos += (int)size.Width;
                    }
                }
            });

            
            panel.Controls.Add(titlePanel);
            panel.Controls.Add(new System.Windows.Forms.Label()
            {
                Name = panel.Name + "lbfromvia",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Size = new System.Drawing.Size(contentWidth, fromViaSize),
                Font = new Font("黑体", fromViaSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel),
                Location = new Point(0, contentSize + 20),
                Text = via
            });
            panel.Controls.Add(new System.Windows.Forms.Label()
            {
                Name = panel.Name + "lbfromviaen",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Size = new System.Drawing.Size(contentWidth, fromViaenSize),
                Font = new Font("黑体", fromViaenSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel),
                Location = new Point(0, contentSize + 20 + fromViaSize + 20),
                Text = viaen
            });

            panel.Controls.Add(new System.Windows.Forms.Label()
            {
                Name = panel.Name + "lbcarousel",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Red,
                BackColor = Color.Yellow,
                Size = new System.Drawing.Size(carouseWidth, panel.Height),
                Font = new Font("黑体", carouselSize, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel),
                Location = new Point(contentWidth, 0),
                Text = row.carousel
            });
            #endregion
        }

        private void GetConfig(out int updateInterval, out int preHour, out int afterMin)
        {
            var row = data.FIDSAdapter.SubsystemAdapter.GetData().Where(o => o.code == Enum.GetName(typeof(global.SubsystemType), global.SubsystemType.carousel)).ToArray();
            if (row.Length > 0)
            {
                updateInterval = row[0].updateinterval;
                preHour = row[0].advance;
                afterMin = row[0].delay;
            }
            else
            {
                updateInterval = 7;
                preHour = 4;
                afterMin = 15;
            }
        }

        private void bgwCarousel_DoWork(object sender, DoWorkEventArgs e)
        {
            BackGroundWork();
        }

        private void BackGroundWork()
        {
            try
            {
                while (!this.IsDisposed)
                {
                    try
                    {
                        int preHour, afterMIN, updateInterval;
                        GetConfig(out updateInterval, out preHour, out afterMIN);
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            var table = GetCarouselTable(ref CurrentPage, global.Variable.RowCount, preHour, afterMIN);
                            for (var i = 0; i < table.Count; i++)
                            {
                                SetValueByRow(table[i], (Panel)Controls["panel" + i.ToString()]);
                            }
                            global.Function.CountErrorTime();
                            pictureBoxMark.Visible = (table.Count == 0) || (global.Variable.ERRORTIMECOUNT > global.Const.CountErrorTimeLimit);
                        });
                        this.Invoke(refresh);
                        Thread.Sleep(updateInterval * 1000);
                    }
                    catch (Exception ex)
                    {
                        RefreshHandle refresh = new RefreshHandle(() =>
                        {
                            pictureBoxMark.Visible = true;
                        });
                        this.Invoke(refresh);
                        Thread.Sleep(3000);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
