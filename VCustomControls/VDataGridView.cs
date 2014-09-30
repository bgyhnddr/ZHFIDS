using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCustomControls
{
    public partial class VDataGridView : DataGridView
    {
        private List<int> _selectedIndexs = new List<int>();
        private int _preFirstCol = 0;
        private int _preFirstRow = 0;
        private bool _changingDS = false;

        public bool SelectRowSave = true;
        public bool ScrollSave = true;

        public VDataGridView()
        {
            InitializeComponent();
        }

        public VDataGridView(bool selectRowSave,bool scrollSave)
        {
            InitializeComponent();
            SelectRowSave = selectRowSave;
            ScrollSave = scrollSave;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (!_changingDS)
                base.OnPaint(pe);
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            if (!_changingDS)
            {
                _preFirstCol = this.FirstDisplayedScrollingColumnIndex;
                _preFirstRow = this.FirstDisplayedScrollingRowIndex;
            }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                _changingDS = true;
                _selectedIndexs.Clear();
                foreach (DataGridViewRow row in this.SelectedRows)
                {
                    _selectedIndexs.Add(row.Index);
                }

                base.DataSource = value;
                if (ScrollSave)
                {
                    if (this.Rows.Count > _preFirstRow)
                    {
                        this.FirstDisplayedScrollingRowIndex = _preFirstRow;
                    }
                    else if (this.Rows.Count > 0)
                    {
                        this.FirstDisplayedScrollingRowIndex = this.Rows.Count - 1;
                    }

                    if (this.Columns.Count > _preFirstCol && this.Columns[_preFirstCol].Displayed)
                    {
                        this.FirstDisplayedScrollingColumnIndex = _preFirstCol;
                    }
                }
                this.ClearSelection();
                // TODO reselect row
                if (SelectRowSave)
                {
                    _selectedIndexs.ForEach((o) =>
                    {
                        if (o < this.Rows.Count)
                        {
                            this.Rows[o].Selected = true;
                        }
                    });
                }
                
                _changingDS = false;
            }
        }
    }
}
