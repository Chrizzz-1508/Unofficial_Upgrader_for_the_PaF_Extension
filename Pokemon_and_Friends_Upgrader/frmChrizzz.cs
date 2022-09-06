using System;
using System.Diagnostics;
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
            Process.Start(@"https://www.paypal.com/paypalme/chrizzz1508");
        }

        private void pbTwitch_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.twitch.tv/chrizzz_1508");
        }
    }
}
