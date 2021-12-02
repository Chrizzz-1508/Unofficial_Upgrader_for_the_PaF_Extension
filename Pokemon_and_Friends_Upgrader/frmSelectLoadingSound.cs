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
    public partial class frmSelectLoadingSound : Form
    {
        public TextBox txt;
        public frmSelectLoadingSound()
        {
            InitializeComponent();
        }

        private void frmSelectLoadingSound_Load(object sender, EventArgs e)
        {
            DirectoryInfo df = new DirectoryInfo("files");
            foreach(FileInfo f in df.GetFiles())
            {
                if (f.Name.Contains(".mp3"))
                {
                    MP3 m = new MP3(f.FullName);
                    lbSound.Items.Add(m);
                }
                lbSound.Sorted = true;
                if (lbSound.Items.Count > 0) lbSound.SelectedIndex = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select your Loading Sound";
            file.Filter = "Audio Files(*.MP3)|*.MP3";
            if(file.ShowDialog() == DialogResult.OK)
            {
                MP3 m = new MP3(file.FileName);
                lbSound.Items.Add(m);
                lbSound.Sorted = true;
                for(int i = 0; i < lbSound.Items.Count; i++)
                {
                    if (((MP3)lbSound.Items[i]) == m) lbSound.SelectedIndex = i;
                }
            }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            MP3 m = ((MP3)lbSound.SelectedItem);
            txt.Text = m.sName;
            if(!File.Exists(@"files\" + m.sName))
            {
                File.Copy(m.sPath, @"files\" + m.sName, false);
            }
            this.Close();
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            Mp3Player.Stop();
            if(lbSound.SelectedIndex > -1)
            {
                MP3 m = (MP3)lbSound.SelectedItem;
                if (File.Exists(m.sPath))
                {
                    Mp3Player.Play(m.sPath, false);
                }
            }
            
        }

        private void lbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mp3Player.Stop();
        }
    }
}
