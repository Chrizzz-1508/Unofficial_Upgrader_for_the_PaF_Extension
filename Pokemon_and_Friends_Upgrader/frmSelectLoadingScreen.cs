using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pokemon_and_Friends_Upgrader
{
    public partial class frmSelectLoadingScreen : Form
    {
        List<string> lsLoading = new List<string>();
        int iLoading = 0;
        public string _txt;

        public TextBox txt;


        public frmSelectLoadingScreen()
        {
            InitializeComponent();
        }

        private void frmSelectLoadingScreen_Load(object sender, EventArgs e)
        {
            DirectoryInfo df = new DirectoryInfo("files\\loadingscreens");
            foreach (FileInfo f in df.GetFiles())
            {
                if (f.Name.Contains(".png") || f.Name.Contains(".jpg"))
                {
                    if (!f.Name.Contains("PokedexWallpaper"))
                    {
                        Image img = Image.FromFile(f.FullName);
                        if (img.Width == 1920 && img.Height == 1080)
                        {
                            lsLoading.Add(f.FullName);
                        }
                    }
                }
            }

            pbPreview.Image = Image.FromFile(lsLoading[iLoading]);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (iLoading < lsLoading.Count - 1)
            {
                iLoading++;
            }
            else
            {
                iLoading = 0;
            }
            pbPreview.Image = Image.FromFile(lsLoading[iLoading]);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select your Loading Screen";
            file.Filter = "Image Files(*.PNG;*.JPG.)|*.PNG;*.JPG";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(file.FileName);
                if (img.Width == 1920 && img.Height == 1080)
                {
                    lsLoading.Add(file.FileName);
                    iLoading = lsLoading.Count - 1;
                    pbPreview.Image = Image.FromFile(lsLoading[iLoading]);
                }
                else
                {
                    MessageBox.Show("Resolution wrong. Only 1920x1080 allowed! Your file has " + img.Width + "x" + img.Height);
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (iLoading > 0)
            {
                iLoading--;
            }
            else
            {
                iLoading = lsLoading.Count - 1;
            }
            pbPreview.Image = Image.FromFile(lsLoading[iLoading]);
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _txt = lsLoading[iLoading];
            this.Close();
        }
    }
}
