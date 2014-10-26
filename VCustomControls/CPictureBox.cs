using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCustomControls
{
    public partial class CPictureBox : PictureBox
    {
        private List<Image> pictureList;
        private int mark = 0;
        private Bitmap blackBoard;
        private PictureBoxSizeMode mode = PictureBoxSizeMode.CenterImage;
        private bool blackMask = false;

        public List<Image> PictureList
        {
            get
            {
                return pictureList;
            }
            set
            {
                pictureList = value;
            }
        }


        public PictureBoxSizeMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }

        public CPictureBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SizeMode = mode;
            blackBoard = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(blackBoard);
            g.Clear(Color.Black);

            ChangeTimer.Interval = 10000;
            ChangeTimer.Start();
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void SetBlackMask(bool show)
        {
            blackMask = show;
            if(show)
            {
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Image = null;
                this.BackColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.White;
                ChangeMask();
            }
        }

        public void GetPictureList(string path)
        {
            pictureList = new List<System.Drawing.Image>();
            DirectoryInfo mydir = new DirectoryInfo(path);
            var files = mydir.GetFiles().Where(o => o.Extension.ToLower() == ".jpg").ToArray();
            for (var i = 0; i < files.Length; i++)
            {
                var pictureFile = files[i];
                System.Drawing.Bitmap destBmp = new Bitmap(pictureFile.FullName);

                System.Drawing.Image bmp = new System.Drawing.Bitmap(destBmp);
                pictureList.Add(bmp);
                destBmp.Dispose();
            }
            if (pictureList.Count > 0)
            {
                this.Image = pictureList[0];
                mark += 1;

            }
        }

        public void ChangeInterval(int interval)
        {
            ChangeTimer.Stop();
            ChangeTimer.Interval = interval;
            ChangeTimer.Start();
        }

        private void ChangeMask()
        {
            try
            {
                if (this.Visible == true)
                {
                    if (blackMask || pictureList.Count == 0)
                    {
                        this.Image = blackBoard;
                        this.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        if (mark >= pictureList.Count)
                        {
                            mark = 0;
                        }
                        this.Image = pictureList[mark];
                        this.SizeMode = mode;
                        mark += 1;
                    }
                }
            }
            catch
            {

            }
        }
        private void ChangeTimer_Tick(object sender, EventArgs e)
        {
            ChangeMask();
        }
    }
}
