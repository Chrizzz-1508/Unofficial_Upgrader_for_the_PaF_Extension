using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_and_Friends_Upgrader
{
    public partial class frmSelectShiny : Form
    {
        List<string> lsShiny = new List<string>();
        int iShiny = 0;
        public string _txt;

        public TextBox txt;


        public frmSelectShiny()
        {
            InitializeComponent();
        }

        private void frmSelectShiny_Load(object sender, EventArgs e)
        {
            DirectoryInfo df = new DirectoryInfo("files");
            foreach(FileInfo f in df.GetFiles())
            {
                if (f.Name.Contains(".png") || f.Name.Contains(".jpg"))
                {
                    using(Image img2 = Image.FromFile(f.FullName))
                    if (img2.Width == 240 && img2.Height == 240)
                    {
                        lsShiny.Add(f.FullName);
                    }
                }
            }
            UpdateBackgrounds();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(iShiny < lsShiny.Count - 1)
            {
                iShiny++;
            }
            else
            {
                iShiny = 0;
            }
            UpdateBackgrounds();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select your Shiny Background";
            file.Filter = "Image Files(*.PNG;*.JPG.)|*.PNG;*.JPG";
            if(file.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(file.FileName);
                if (img.Width == 240 && img.Height == 240)
                {
                    lsShiny.Add(file.FileName);
                    iShiny = lsShiny.Count - 1;
                    UpdateBackgrounds();
                }
                else
                {
                    MessageBox.Show("Resolution wrong. Only 240x240 allowed! Your file has " + img.Width + "x" + img.Height);
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (iShiny > 0)
            {
                iShiny--;
            }
            else
            {
                iShiny = lsShiny.Count -1;
            }
            UpdateBackgrounds();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _txt = lsShiny[iShiny];
            this.Close();
        }

        private void UpdateBackgrounds()
        {
            Image img = Image.FromFile(lsShiny[iShiny]);
            pbPreview1.BackgroundImage = img;
            pbPreview2.BackgroundImage = img;
            pbPreview3.BackgroundImage = img;
        }
    }
}
