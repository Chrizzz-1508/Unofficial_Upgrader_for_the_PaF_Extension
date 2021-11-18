using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_and_Friends_Upgrader
{
    public partial class frmChrizzz : Form
    {
        public frmChrizzz()
        {
            InitializeComponent();
        }

        private void pbPaypal_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.paypal.com/donate/?hosted_button_id=F35RJZAWDPMQ2");
        }

        private void pbTwitch_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.twitch.tv/chrizzz_1508");
        }
    }
}
