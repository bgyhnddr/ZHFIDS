using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using global;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Text;

namespace fidsstyle
{
    public partial class Style
    {
        public const string Departure_std = "STD";
        public const string Departure_icon = "ICON";
        public const string Departure_flight = "FLIGHT";
        public const string Departure_tovia = "TOVIA";
        public const string Departure_etd = "ETD";
        public const string Departure_counter = "COUNTER";
        public const string Departure_gate = "GATE";
        public const string Departure_remark = "REMARK";

        public const string Arrival_sta = "STA";
        public const string Arrival_icon = "ICON";
        public const string Arrival_flight = "FLIGHT";
        public const string Arrival_fromvia = "FROMVIA";
        public const string Arrival_eta = "ETA";
        public const string Arrival_remark = "REMARK";
        public const int STRINGCOUNTMAX = 100;

        public const float zoomsize = 0.7f;
        public static int FONTSIZE;

        public static int StringCount = 0;
        public static Graphics GridGraphics;

        public static Dictionary<string, Color> FontColor;
        public static Dictionary<string, Color> BackColor;

        public static Color RowBackColor = ColorTranslator.FromHtml("#171451");
        public static Color HeaderForeColor = ColorTranslator.FromHtml("#f5943e");

        public static Color GetFontColorByStatus(string status)
        {
            if (status.IndexOf("Delayed") >= 0 || status.IndexOf("延误") >= 0)
            {
                return Color.Yellow;
            }
            else if (status.IndexOf("Cancelled") >= 0 || status.IndexOf("取消") >= 0)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.YellowGreen;
            }
        }

        public static bool SetDepartureGrid(DataGridView grid, Label lbTime, int formHeight, int formWidth, int rowCount, Graphics g)
        {
            Style.GridGraphics = g;
            var type = (CSSStyle)Enum.Parse(typeof(CSSStyle), global.Variable.CSSSTYLE);

            var fontStyle = rowCount <= 13 ? FontStyle.Regular : FontStyle.Bold;

            SizeF sf;
            var rowHeight = (int)(formHeight / (float)(rowCount + 1.2));
            FONTSIZE = (int)(rowHeight * zoomsize);
            sf = g.MeasureString("XX:XX", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            var stdSize = (int)(sf.Width * 1.1);
            var imageSize = (int)(rowHeight * 0.8125);

            sf = g.MeasureString("航班号", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            var flightSize = (int)(sf.Width * 1.1);

            sf = g.MeasureString("X,X", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            var counterSize = (int)(sf.Width * 1.1);
            sf = g.MeasureString("X,X", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            var gateSize = (int)(sf.Width * 1.1);
            if (rowCount < 13)
            {
                sf = g.MeasureString("口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
            else
            {
                sf = g.MeasureString("口口口口口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
            
            var remarkSize = (int)(sf.Width * 1.1);
            var leftSize = formWidth - stdSize - imageSize - flightSize - counterSize - gateSize - remarkSize;
            var toviaSize = leftSize;

            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            grid.Columns[Departure_std].Width = stdSize;
            grid.Columns[Departure_icon].Width = imageSize;
            grid.Columns[Departure_flight].Width = flightSize;
            grid.Columns[Departure_tovia].Width = toviaSize;
            grid.Columns[Departure_counter].Width = counterSize;
            grid.Columns[Departure_gate].Width = gateSize;
            grid.Columns[Departure_remark].Width = remarkSize;

            sf = g.MeasureString(DateTime.Now.ToShortTimeString(), new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            var timeSize = (int)(sf.Width * 1.1);
            lbTime.Location = new Point(grid.Width - timeSize, grid.Location.Y + ((int)rowHeight - (int)sf.Height) / 2);
            lbTime.Font = new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            switch (type)
            {
                case CSSStyle.SZ:
                    return SetDepartureGridSZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.HK:
                    return SetDepartureGridHK(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.GZ:
                    return SetDepartureGridGZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
            }
            return false;
        }
        private static bool SetDepartureGridSZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "REMARK":
                                    if (e.Value.ToString().Length > 0)
                                    {
                                        if (e.Value.ToString().IndexOf("Delayed") >= 0 || e.Value.ToString().IndexOf("延误") >= 0)
                                        {
                                            e.CellStyle.BackColor = Color.Red;
                                            e.CellStyle.ForeColor = Color.Yellow;
                                        }
                                        else if (e.Value.ToString().IndexOf("Cancelled") >= 0 || e.Value.ToString().IndexOf("取消") >= 0)
                                        {
                                            e.CellStyle.BackColor = Color.YellowGreen;
                                        }
                                        else
                                        {
                                            e.CellStyle.BackColor = Color.Blue;
                                            e.CellStyle.ForeColor = Color.YellowGreen;
                                        }
                                    }
                                    break;
                            }

                            CellDrawStingDefalut(sender, e);
                        }
                    }
                    catch
                    {
                    }
                }));

                SetStyleSZ(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        private static bool SetDepartureGridHK(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                #region paint
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        e.Graphics.TextRenderingHint = global.Variable.HINT;
                        if (sender != null && e.RowIndex == -1)
                        {
                            var currentgrid = (DataGridView)sender;
                            StringFormat stringFormat = new StringFormat();
                            Rectangle newRect;
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "COUNTER":
                                    e.Graphics.FillRectangle(new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Far;
                                    stringFormat.LineAlignment = StringAlignment.Center;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        newRect = new Rectangle(e.CellBounds.X - 20, e.CellBounds.Y, e.CellBounds.Width + 20, e.CellBounds.Height);
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), newRect, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;
                                case "GATE":
                                    var width = GridGraphics.MeasureString(e.Value.ToString(), currentgrid.ColumnHeadersDefaultCellStyle.Font).Width;
                                    newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, (int)width + 30, currentgrid.ColumnHeadersHeight);
                                    Brush backColorBrush = new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.BackColor);//非选中的背景色
                                    e.Graphics.FillRectangle(backColorBrush, newRect);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Center;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), newRect, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;
                                case "REMARK":
                                    Rectangle newREMARKRect = new Rectangle(e.CellBounds.X + 30, e.CellBounds.Y, e.CellBounds.Width, currentgrid.ColumnHeadersHeight);
                                    e.Graphics.FillRectangle(new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.BackColor), newREMARKRect);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Center;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), newREMARKRect, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;
                                default:
                                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Far;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), e.CellBounds, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;

                            }
                        }

                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            if (e.Value != null && e.Value.GetType() == typeof(string))
                            {
                                var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                                if (textLength > e.CellBounds.Width)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }

                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "ICON":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STD", e.RowIndex].Value.ToString()) &&
                                        !string.IsNullOrWhiteSpace(currentgrid["FLIGHT", e.RowIndex].Value.ToString()))
                                    {
                                        e.Graphics.DrawLine(new Pen(Color.White, 1),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y + e.CellBounds.Height * 0.9)),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y - e.CellBounds.Height * 0.9)));

                                    }
                                    break;
                                case "GATE":
                                case "COUNTER":
                                    if (currentgrid["FLIGHT", e.RowIndex].Value != null && currentgrid["FLIGHT", e.RowIndex].Value.ToString().Length > 0)
                                    {
                                        var backColor = e.CellStyle.BackColor;
                                        Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                                        e.CellStyle.BackColor = Color.GreenYellow;
                                        e.CellStyle.ForeColor = Color.Black;
                                        CellDrawStingDefalut(sender, e, false, StringAlignment.Center);
                                        ControlPaint.DrawBorder(e.Graphics, newRect,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid);
                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e);
                                    }
                                    break;
                                case "TOVIA":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STD", e.RowIndex].Value.ToString()) &&
                                        !string.IsNullOrWhiteSpace(e.Value.ToString()))
                                    {//处理3个共享航班
                                        StringFormat stringFormat = new StringFormat();
                                        stringFormat.Alignment = StringAlignment.Near;
                                        stringFormat.LineAlignment = StringAlignment.Center;
                                        stringFormat.Trimming = StringTrimming.Word;
                                        e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                                        var icon = global.Function.GetIcon(e.Value.ToString().Substring(0, 2));
                                        var iconSize = (int)(e.CellBounds.Height * 0.8125);
                                        var newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2, iconSize, iconSize);
                                        e.Graphics.DrawImage(global.Function.GetIcon(e.Value.ToString().Substring(0, 2)), newRect);
                                        var stringRect = new Rectangle(e.CellBounds.X + iconSize, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), stringRect, stringFormat);


                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e, false);
                                        e.Handled = true;
                                    }
                                    break;
                                default:
                                    CellDrawStingDefalut(sender, e);
                                    break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }));
                #endregion
                SetStyleHK(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        private static bool SetDepartureGridGZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            var value = currentgrid.Rows[e.RowIndex].Cells["REMARK"].Value.ToString();
                            if (value.IndexOf("Delayed") >= 0 || value.ToString().IndexOf("延误") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.IndexOf("Cancelled") >= 0 || value.IndexOf("取消") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.Length > 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.Yellow;
                                }
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.White;
                            }

                            CellDrawStingDefalut(sender, e);
                        }
                    }
                    catch
                    {
                    }
                }));
                SetStyleGZ(grid, fontSize, rowHeight, lbTime);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }

        public static bool SetGuideGrid(DataGridView grid, Label lbTime, int formHeight, int formWidth, int rowCount, Graphics g)
        {
            Style.GridGraphics = g;
            var type = (CSSStyle)Enum.Parse(typeof(CSSStyle), global.Variable.CSSSTYLE);
            var fontStyle = rowCount <= 13 ? FontStyle.Regular : FontStyle.Bold;

            SizeF sf;
            var rowHeight = (int)(formHeight / (float)(rowCount + 1.2));
            FONTSIZE = (int)(rowHeight * zoomsize);
            sf = g.MeasureString("XX:XX", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var stdSize = (int)(sf.Width * 1.1);
            var imageSize = (int)(rowHeight * 0.8125);

            sf = g.MeasureString("航班号", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var flightSize = (int)(sf.Width * 1.1);

            sf = g.MeasureString("X,X", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var gateSize = (int)(sf.Width * 1.1);

            if (rowCount < 13)
            {
                sf = g.MeasureString("口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
            else
            {
                sf = g.MeasureString("口口口口口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
           
            var remarkSize = (int)(sf.Width * 1.1);
            var leftSize = formWidth - stdSize - imageSize - flightSize - gateSize - remarkSize;
            var toviaSize = leftSize;

            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            grid.Columns[Departure_std].Width = stdSize;
            grid.Columns[Departure_icon].Width = imageSize;
            grid.Columns[Departure_flight].Width = flightSize;
            grid.Columns[Departure_tovia].Width = toviaSize;
            grid.Columns[Departure_gate].Width = gateSize;
            grid.Columns[Departure_remark].Width = remarkSize;

            sf = g.MeasureString(DateTime.Now.ToShortTimeString(), new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var timeSize = (int)(sf.Width * 1.1);
            lbTime.Location = new Point(grid.Width - timeSize, grid.Location.Y + ((int)rowHeight - (int)sf.Height) / 2);
            lbTime.Font = new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            switch (type)
            {
                case CSSStyle.SZ:
                    return SetGuideGridSZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.HK:
                    return SetGuideGridHK(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.GZ:
                    return SetGuideGridGZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
            }
            return false;
        }
        public static bool SetGuideGridSZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "REMARK":
                                    if (e.Value.ToString().Length > 0 && e.RowIndex >= 0)
                                    {
                                        if (e.Value.ToString().IndexOf("Delayed") >= 0 || e.Value.ToString().IndexOf("延误") >= 0)
                                        {
                                            e.CellStyle.BackColor = Color.Red;
                                            e.CellStyle.ForeColor = Color.Yellow;
                                        }
                                        else if (e.Value.ToString().IndexOf("Cancelled") >= 0 || e.Value.ToString().IndexOf("取消") >= 0)
                                        {
                                            e.CellStyle.BackColor = Color.YellowGreen;
                                        }
                                        else
                                        {
                                            e.CellStyle.BackColor = Color.Blue;
                                            e.CellStyle.ForeColor = Color.YellowGreen;
                                        }
                                    }

                                    break;
                            }
                            CellDrawStingDefalut(sender, e);
                        }
                    }
                    catch
                    {
                    }
                }));

                SetStyleSZ(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        public static bool SetGuideGridHK(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        e.Graphics.TextRenderingHint = global.Variable.HINT;
                        if (sender != null && e.RowIndex == -1)
                        {
                            var currentgrid = (DataGridView)sender;
                            StringFormat stringFormat = new StringFormat();
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "GATE":
                                    var width = GridGraphics.MeasureString(e.Value.ToString(), currentgrid.ColumnHeadersDefaultCellStyle.Font).Width;
                                    Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, (int)width + 30, currentgrid.ColumnHeadersHeight);
                                    Brush backColorBrush = new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.BackColor);//非选中的背景色
                                    e.Graphics.FillRectangle(backColorBrush, newRect);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Center;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), newRect, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;
                                case "REMARK":
                                    Rectangle newREMARKRect = new Rectangle(e.CellBounds.X + 30, e.CellBounds.Y, e.CellBounds.Width, currentgrid.ColumnHeadersHeight);
                                    e.Graphics.FillRectangle(new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.BackColor), newREMARKRect);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Center;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), newREMARKRect, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;
                                default:
                                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);//用背景色填充单元格
                                    stringFormat.Alignment = StringAlignment.Near;
                                    stringFormat.LineAlignment = StringAlignment.Far;
                                    stringFormat.Trimming = StringTrimming.Word;
                                    if (e.Value != null)
                                    {
                                        e.Graphics.DrawString((String)e.Value, currentgrid.ColumnHeadersDefaultCellStyle.Font,
                                                   new SolidBrush(currentgrid.ColumnHeadersDefaultCellStyle.ForeColor), e.CellBounds, stringFormat);
                                    }
                                    e.Handled = true;
                                    break;

                            }
                        }
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            if (e.Value != null && e.Value.GetType() == typeof(string))
                            {
                                var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                                if (textLength > e.CellBounds.Width)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "ICON":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STD", e.RowIndex].Value.ToString()) &&
                                        !string.IsNullOrWhiteSpace(currentgrid["FLIGHT", e.RowIndex].Value.ToString()))
                                    {
                                        e.Graphics.DrawLine(new Pen(Color.White, 1),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y + e.CellBounds.Height * 0.9)),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y - e.CellBounds.Height * 0.9)));

                                    }
                                    break;
                                case "GATE":
                                    if (currentgrid["FLIGHT", e.RowIndex].Value != null && currentgrid["FLIGHT", e.RowIndex].Value.ToString().Length > 0)
                                    {
                                        var backColor = e.CellStyle.BackColor;
                                        Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                                        e.CellStyle.BackColor = Color.GreenYellow;
                                        e.CellStyle.ForeColor = Color.Black;
                                        CellDrawStingDefalut(sender, e, false, StringAlignment.Center);
                                        ControlPaint.DrawBorder(e.Graphics, newRect,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid,
                                            backColor, 5, ButtonBorderStyle.Solid);
                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e);
                                    }
                                    break;
                                case "TOVIA":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STD", e.RowIndex].Value.ToString()) &&
                                        !string.IsNullOrWhiteSpace(e.Value.ToString()))
                                    {//处理3个共享航班
                                        StringFormat stringFormat = new StringFormat();
                                        stringFormat.Alignment = StringAlignment.Near;
                                        stringFormat.LineAlignment = StringAlignment.Center;
                                        stringFormat.Trimming = StringTrimming.Word;
                                        e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                                        var icon = global.Function.GetIcon(e.Value.ToString().Substring(0, 2));
                                        var iconSize = (int)(e.CellBounds.Height * 0.8125);
                                        var newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2, iconSize, iconSize);
                                        e.Graphics.DrawImage(global.Function.GetIcon(e.Value.ToString().Substring(0, 2)), newRect);
                                        var stringRect = new Rectangle(e.CellBounds.X + iconSize, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), stringRect, stringFormat);
                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e, false);
                                        e.Handled = true;
                                    }
                                    break;
                                default:
                                    var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                                    if (textLength > e.CellBounds.Width)
                                    {
                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e);
                                    }
                                    break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }));


                SetStyleHK(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        public static bool SetGuideGridGZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            var value = currentgrid.Rows[e.RowIndex].Cells["REMARK"].Value.ToString();
                            if (value.IndexOf("Delayed") >= 0 || value.ToString().IndexOf("延误") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.IndexOf("Cancelled") >= 0 || value.IndexOf("取消") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.Length > 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.Yellow;
                                }
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.White;
                            }
                            CellDrawStingDefalut(sender, e);
                        }
                    }
                    catch
                    {
                    }
                }));

                SetStyleGZ(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }


        public static bool SetArrivalGrid(DataGridView grid, Label lbTime, int formHeight, int formWidth, int rowCount, Graphics g)
        {
            Style.GridGraphics = g;
            var type = (CSSStyle)Enum.Parse(typeof(CSSStyle), global.Variable.CSSSTYLE);

            var fontStyle = rowCount <= 13 ? FontStyle.Regular : FontStyle.Bold;
            SizeF sf;
            var rowHeight = (int)(formHeight / (float)(rowCount + 1.2));
            FONTSIZE = (int)(rowHeight * zoomsize);
            sf = g.MeasureString("XX:XX", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var staSize = (int)(sf.Width * 1.1);
            var imageSize = (int)(rowHeight * 0.8125);

            sf = g.MeasureString("航班号", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var flightSize = (int)(sf.Width * 1.1);

            sf = g.MeasureString("XX:XX", new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var etaSize = (int)(sf.Width * 1.1);

            if (rowCount < 13)
            {
                sf = g.MeasureString("口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
            else
            {
                sf = g.MeasureString("口口口口口口口口口口", new Font("黑体", FONTSIZE, fontStyle, System.Drawing.GraphicsUnit.Pixel));
            }
            var remarkSize = (int)(sf.Width * 1.1);

            var leftSize = formWidth - staSize - imageSize - flightSize - etaSize - remarkSize;
            var fromviaSize = leftSize;

            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            grid.Columns[Arrival_sta].Width = staSize;
            grid.Columns[Arrival_icon].Width = imageSize;
            grid.Columns[Arrival_flight].Width = flightSize;
            grid.Columns[Arrival_fromvia].Width = fromviaSize;
            grid.Columns[Arrival_eta].Width = etaSize;
            grid.Columns[Arrival_remark].Width = remarkSize;

            sf = g.MeasureString(DateTime.Now.ToShortTimeString(), new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel));
            var timeSize = (int)(sf.Width * 1.1);
            lbTime.Location = new Point(grid.Width - timeSize, grid.Location.Y + ((int)rowHeight - (int)sf.Height) / 2);
            lbTime.Font = new Font("黑体", FONTSIZE, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            switch (type)
            {
                case CSSStyle.SZ:
                    return SetArrivalGridSZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.HK:
                    return SetArrivalGridHK(grid, FONTSIZE, rowHeight, rowCount, lbTime);
                case CSSStyle.GZ:
                    return SetArrivalGridGZ(grid, FONTSIZE, rowHeight, rowCount, lbTime);
            }
            return false;
        }
        public static bool SetArrivalGridSZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    if (sender != null && e.RowIndex >= 0)
                    {
                        var currentgrid = (DataGridView)sender;
                        switch (currentgrid.Columns[e.ColumnIndex].Name)
                        {
                            case "REMARK":
                                if (e.Value.ToString().Length > 0)
                                {
                                    if (e.Value.ToString().IndexOf("Delayed") >= 0 || e.Value.ToString().IndexOf("延误") >= 0)
                                    {
                                        e.CellStyle.BackColor = Color.Red;
                                        e.CellStyle.ForeColor = Color.Yellow;
                                    }
                                    else if (e.Value.ToString().IndexOf("Cancelled") >= 0 || e.Value.ToString().IndexOf("取消") >= 0)
                                    {
                                        e.CellStyle.BackColor = Color.YellowGreen;
                                    }
                                    else
                                    {
                                        e.CellStyle.BackColor = Color.Blue;
                                        e.CellStyle.ForeColor = Color.YellowGreen;
                                    }
                                }
                                break;
                        }
                        CellDrawStingDefalut(sender, e);
                    }
                }));



                SetStyleSZ(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        public static bool SetArrivalGridHK(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        e.Graphics.TextRenderingHint = global.Variable.HINT;
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;

                            if (e.Value != null && e.Value.GetType() == typeof(string))
                            {
                                var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                                if (textLength > e.CellBounds.Width)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            switch (currentgrid.Columns[e.ColumnIndex].Name)
                            {
                                case "ICON":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STA", e.RowIndex].Value.ToString()) &&
                                        !string.IsNullOrWhiteSpace(currentgrid["FLIGHT", e.RowIndex].Value.ToString()))
                                    {
                                        e.Graphics.DrawLine(new Pen(Color.White, 1),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y + e.CellBounds.Height * 0.9)),
                                            new Point(e.CellBounds.X - 1, (int)(e.CellBounds.Y - e.CellBounds.Height * 0.9)));
                                    }
                                    break;
                                case "FROMVIA":
                                    if (string.IsNullOrWhiteSpace(currentgrid["STA", e.RowIndex].Value.ToString()) &&
                                            !string.IsNullOrWhiteSpace(e.Value.ToString()))
                                    {//处理3个共享航班
                                        StringFormat stringFormat = new StringFormat();
                                        stringFormat.Alignment = StringAlignment.Near;
                                        stringFormat.LineAlignment = StringAlignment.Center;
                                        stringFormat.Trimming = StringTrimming.Word;
                                        e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                                        var icon = global.Function.GetIcon(e.Value.ToString().Substring(0, 2));
                                        var iconSize = (int)(e.CellBounds.Height * 0.8125);
                                        var newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2, iconSize, iconSize);
                                        e.Graphics.DrawImage(global.Function.GetIcon(e.Value.ToString().Substring(0, 2)), newRect);
                                        var stringRect = new Rectangle(e.CellBounds.X + iconSize, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), stringRect, stringFormat);


                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e, false);
                                        e.Handled = true;
                                    }
                                    break;
                                default:
                                    var textLength = e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                                    if (textLength > e.CellBounds.Width)
                                    {
                                        e.Handled = true;
                                    }
                                    else
                                    {
                                        CellDrawStingDefalut(sender, e);
                                    }
                                    break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }));

                SetStyleHK(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }
        public static bool SetArrivalGridGZ(DataGridView grid, float fontSize, int rowHeight, int rowCount, Label lbTime = null)
        {
            try
            {
                grid.CellPainting += new DataGridViewCellPaintingEventHandler(new DataGridViewCellPaintingEventHandler((sender, e) =>
                {
                    try
                    {
                        if (sender != null && e.RowIndex >= 0)
                        {
                            var currentgrid = (DataGridView)sender;
                            var value = currentgrid.Rows[e.RowIndex].Cells["REMARK"].Value.ToString();
                            if (value.IndexOf("Delayed") >= 0 || value.ToString().IndexOf("延误") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.IndexOf("Cancelled") >= 0 || value.IndexOf("取消") >= 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.YellowGreen;
                                }
                            }
                            else if (value.Length > 0)
                            {
                                if (e.Value.GetType() == typeof(string))
                                {
                                    e.CellStyle.ForeColor = Color.Yellow;
                                }
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.White;
                            }

                            CellDrawStingDefalut(sender, e);
                        }
                    }
                    catch
                    {
                    }
                }));


                SetStyleGZ(grid, fontSize, rowHeight, lbTime);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                return false;
            }
        }

        private static void SetStyleHK(DataGridView grid, float fontSize, int rowHeight, Label lbTime = null)
        {
            var fontStyle = global.Variable.RowCount <= 13 ? FontStyle.Regular : FontStyle.Bold;
            grid.TabStop = false;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            grid.ScrollBars = System.Windows.Forms.ScrollBars.None;


            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = (int)(rowHeight * 1.2);
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.BackgroundColor = System.Drawing.Color.Black;
            grid.RowTemplate.Height = rowHeight;
            var gridViewHeadersCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridViewHeadersCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridViewHeadersCellStyle.BackColor = Color.Black;
            gridViewHeadersCellStyle.Font = new System.Drawing.Font("黑体", (float)fontSize * 0.7F, fontStyle, System.Drawing.GraphicsUnit.Pixel);
            gridViewHeadersCellStyle.ForeColor = HeaderForeColor;
            gridViewHeadersCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            gridViewHeadersCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            gridViewHeadersCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = gridViewHeadersCellStyle;
            if (lbTime != null)
            {
                lbTime.BackColor = Color.Black;
                lbTime.ForeColor = Color.Orange;
            }

            var gridRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridRowsDefaultCellStyle.BackColor = fidsstyle.Style.RowBackColor;
            gridRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, fontStyle, System.Drawing.GraphicsUnit.Pixel);
            gridRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.RowsDefaultCellStyle = gridRowsDefaultCellStyle;

            var gridAlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridAlternatingRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridAlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            gridAlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, fontStyle, System.Drawing.GraphicsUnit.Pixel);
            gridAlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = gridAlternatingRowsDefaultCellStyle;

        }
        private static void SetStyleSZ(DataGridView grid, float fontSize, int rowHeight, Label lbTime = null)
        {
            grid.TabStop = false;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            grid.ScrollBars = System.Windows.Forms.ScrollBars.None;


            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = rowHeight;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.BackgroundColor = System.Drawing.Color.Black;
            grid.RowTemplate.Height = rowHeight;
            var gridViewHeadersCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridViewHeadersCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridViewHeadersCellStyle.BackColor = Color.FromArgb(5, 184, 216);
            gridViewHeadersCellStyle.Font = new System.Drawing.Font("黑体", (float)fontSize * 0.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridViewHeadersCellStyle.ForeColor = Color.FromArgb(50, 255, 255);
            gridViewHeadersCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            gridViewHeadersCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            gridViewHeadersCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = gridViewHeadersCellStyle;

            if (lbTime != null)
            {
                lbTime.ForeColor = Color.FromArgb(50, 255, 255);
                lbTime.BackColor = Color.FromArgb(5, 184, 216);
            }

            var gridRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridRowsDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            gridRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.RowsDefaultCellStyle = gridRowsDefaultCellStyle;

            var gridAlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridAlternatingRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridAlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            gridAlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridAlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = gridAlternatingRowsDefaultCellStyle;
        }
        private static void SetStyleGZ(DataGridView grid, float fontSize, int rowHeight, Label lbTime = null)
        {
            grid.TabStop = false;
            grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            grid.ScrollBars = System.Windows.Forms.ScrollBars.None;


            grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = rowHeight;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.BackgroundColor = System.Drawing.Color.Black;
            grid.RowTemplate.Height = rowHeight;
            var gridViewHeadersCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridViewHeadersCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridViewHeadersCellStyle.BackColor = Color.Gray;
            gridViewHeadersCellStyle.Font = new System.Drawing.Font("黑体", (float)fontSize * 0.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridViewHeadersCellStyle.ForeColor = Color.White;
            gridViewHeadersCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            gridViewHeadersCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            gridViewHeadersCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = gridViewHeadersCellStyle;
            if (lbTime != null)
            {
                lbTime.ForeColor = Color.White;
                lbTime.BackColor = Color.Gray;
            }
            var gridRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridRowsDefaultCellStyle.BackColor = System.Drawing.Color.Purple;
            gridRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.RowsDefaultCellStyle = gridRowsDefaultCellStyle;

            var gridAlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            gridAlternatingRowsDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            gridAlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            gridAlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("黑体", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            gridAlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle = gridAlternatingRowsDefaultCellStyle;
        }


        private static void CellDrawStingDefalut(object sender, DataGridViewCellPaintingEventArgs e, bool handle = true, StringAlignment h = StringAlignment.Near)
        {
            if (e.RowIndex >= 0 && e.Value != null && e.Value.GetType() == typeof(string))
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);//非选中的背景色
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);//用背景色填充单元格
                var drawString = (String)e.Value;
                var width = GridGraphics.MeasureString(e.Value.ToString(), new Font("黑体", e.CellStyle.Font.Size, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Width;
                if (width > e.CellBounds.Width)
                {
                    var startCount = StringCount;
                    if (StringCount > e.Value.ToString().Length)
                    {
                        startCount = StringCount - e.Value.ToString().Length;
                    }
                }


                var fontHeight = GridGraphics.MeasureString("X", new Font("黑体", e.CellStyle.Font.Size, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)).Height;

                if (e.Value.GetType() == typeof(System.String))
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = h;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.Word;
                    var Y = e.CellBounds.Y + (e.CellBounds.Height - fontHeight) / 4 * 3;
                    var rect = new Rectangle(e.CellBounds.X, (int)Y, e.CellBounds.Width, (int)fontHeight);
                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                               new SolidBrush(e.CellStyle.ForeColor), rect, stringFormat);
                }
                else
                {
                    e.PaintContent(new Rectangle(0, 0, 0, 0));//画内容
                }

                e.Handled = handle;
            }
        }


    }

    enum CSSStyle
    {
        SZ,
        HK,
        GZ
    }
}
