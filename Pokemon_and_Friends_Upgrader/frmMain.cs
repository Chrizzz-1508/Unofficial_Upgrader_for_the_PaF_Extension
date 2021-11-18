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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            initializeCBs();
            initializeToolTips();
            LoadValues();
            //btnHelp_Click(null, null);
        }

        private void initializeCBs()
        {
            cbLanguage.SelectedIndex = 0;
            cbUseBreakout.SelectedIndex = 0;
            cbUseDiscord.SelectedIndex = 0;
            cbUseLoadingScreen.SelectedIndex = 0;
            cbUseSpawnMusic.SelectedIndex = 0;
            cbMasterball.SelectedIndex = 0;
            cbUseGift.SelectedIndex = 0;
        }

        private void initializeToolTips()
        {
            TTExplanation.IsBalloon = true;
            TTExplanation.SetToolTip(lblBoard, "Select your LioranBoard Receiver(PC) Folder and let the Upgrader grab the correct board");
            TTExplanation.SetToolTip(lblLanguage, "Select your Language");
            TTExplanation.SetToolTip(lblRunMin, "Pokemon starts with 0% escape rate. \nEverytime it breaks out, this is the minimum rate it can increase");
            TTExplanation.SetToolTip(lblRunMax, "Pokemon starts with 0% escape rate. \nEverytime it breaks out, this is the maximum rate it can increase");
            TTExplanation.SetToolTip(lblFirstPokemon, "First Pokemon number that can appear");
            TTExplanation.SetToolTip(lblLastPokemon, "Last Pokemon number that can appear");
            TTExplanation.SetToolTip(lblShinyChance, "Shiny Chance in %");
            TTExplanation.SetToolTip(lblSpawnTimer, "Time until a new pokemon spawns \nin miliseconds (300000 = 5min)");
            TTExplanation.SetToolTip(lblRunTimer, "Time until the current pokemon runs away when no \none throws a ball in miliseconds (180000 = 3min). Throws reset this timer");
            TTExplanation.SetToolTip(lblGreatballTimer, "Time in miliseconds until the ball upgrades \nto a greatball. Only rises when a ball is available. (30000 = 30s)");
            TTExplanation.SetToolTip(lblUltraballTimer, "Time in miliseconds until the ball upgrades \nto a ultraball. Only rises when a ball is available. (60000 = 60s)");
            TTExplanation.SetToolTip(lblUseLoadinscreen, "Use a 5s loadinscreen before the pokemon \nspawns so that everyone can prepare themselves");
            TTExplanation.SetToolTip(lblUseMasterball, "Enable an expensive masterball for 100% catches");
            TTExplanation.SetToolTip(lblUseSpawnMusic, "Use a spawn music before the pokemon \nspawns so that everyone can prepare themselves");
            TTExplanation.SetToolTip(lblUseBreakout, "Shows when a pokemon breaks out in the chat. \nFor example: Oh no the wild Mew broke out");
            TTExplanation.SetToolTip(lblUseBreakout, "This sends a message to your discord whenever \nsomeone catches a pokemon. You need to install the Discord Webhook extension for LB first. \nYou can grab it from the LB discord in the releases channel");
            TTExplanation.SetToolTip(lblWebhookURL, "Webhook URL for the Discord Webhook (Serversettings => Integration => Webhooks)");
            TTExplanation.SetToolTip(lblWebhookUser, "Webhook User for the Discord Webhook (Serversettings => Integration => Webhooks)");
            TTExplanation.SetToolTip(lblCatchRate, "The higher you set this, the easier the viewers can catch the pokemon. \n1 out of (floor((300-poke_api_catch_rate_real)/Catch_Rate)) chance - 1 per ball");
            TTExplanation.SetToolTip(lblGift, "Enables the channel point reward Give a gift\n which lets the viewer reduce the runaway chance of the current pokemon");

        }

        private void cbUseDiscord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUseDiscord.SelectedIndex == 0)
            {
                txtWebhookURL.Enabled = true;
                txtWebhookUser.Enabled = true;
            }
            else
            {
                txtWebhookURL.Enabled = false;
                txtWebhookUser.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            of.Description = "Please select the LioranBoard Receiver(PC) Folder";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DirectoryInfo df = new DirectoryInfo(of.SelectedPath);
                    List<string> lsFoundConfigs = new List<string>();
                    foreach (FileInfo f in df.GetFiles())
                    {
                        if (f.Name.EndsWith(".ini") && f.Name.StartsWith("configs") && !f.Name.Contains("backup"))
                        {
                            lsFoundConfigs.Add(f.FullName);
                        }
                    }
                    for (int i = 0; i < lsFoundConfigs.Count; i++)
                    {
                        StreamReader srConfig = new StreamReader(lsFoundConfigs[i]);
                        string sTemp = srConfig.ReadToEnd();
                        srConfig.Close();
                        if ((sTemp.Contains("!poke-install") && sTemp.Contains("Install WaldoAndFriends Pokemon Game")))
                        {
                            if (DialogResult.Yes == MessageBox.Show("The file " + lsFoundConfigs[i] + " seems to be the original Pokemon Board File. Use it now?", "Use file?", MessageBoxButtons.YesNo))
                            {
                                txtBoardLocation.Text = lsFoundConfigs[i];
                                return;
                            }
                        }
                        else if (sTemp.ToLowerInvariant().Contains("poke_chrizzz"))
                        {
                            if (DialogResult.Yes == MessageBox.Show("The file " + lsFoundConfigs[i] + " seems to be the modified Pokemon Board File. Use it now?", "Use file?", MessageBoxButtons.YesNo))
                            {
                                txtBoardLocation.Text = lsFoundConfigs[i];
                                return;
                            }
                        }
                    }
                    MessageBox.Show("No file with the correct structure was found in this folder!");
                }
                
                catch(Exception ex)
                {
                    MessageBox.Show("Can't access the file. Please close the .ini File and Lioaran Board first." + ex.ToString());
                }
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if(CheckValues())
            {
                string sDiscord = "0";
                string sLoading = "0";
                string sBreakout = "0";
                string sLanguage = "en";
                string sMusic = "0";
                string sMasterball = "0";
                string sUseGift = "0";

                if (cbUseDiscord.SelectedIndex == 0)
                {
                    sDiscord = "1";
                }

                if (cbUseLoadingScreen.SelectedIndex == 0)
                {
                    sLoading = "1";
                }

                if (cbUseSpawnMusic.SelectedIndex == 0)
                {
                    sMusic = "1";
                }

                if (cbUseBreakout.SelectedIndex == 0)
                {
                    sBreakout = "1";
                }

                if (cbMasterball.SelectedIndex == 0)
                {
                    sMasterball = "1";
                }

                if (cbUseGift.SelectedIndex == 0)
                {
                    sUseGift = "1";
                }

                switch (cbLanguage.SelectedIndex)
                {
                    case 0:
                        sLanguage = "en";
                        break;
                    case 1:
                        sLanguage = "de";
                        break;
                    default:
                        break;
                }

                string[] saPath = txtBoardLocation.Text.Split('\\');
                string sPath = "";
                for (int i = 0; i < saPath.Length - 1; i++)
                {
                    sPath += saPath[i];
                    if (i < saPath.Length - 1) sPath += "\\";
                }

                File.Copy("files\\CreateTop10.exe", sPath + "\\CreateTop10.exe", true);
                File.Copy("files\\Pokedex.csv", sPath + "\\Pokedex.csv", true);
                File.Copy("files\\PokeWhisper.exe", sPath + "\\PokeWhisper.exe", true);
                using(StreamReader srconfig = new StreamReader("files\\PokeWhisper.exe.config"))
                {
                    StreamWriter swconfig = new StreamWriter(sPath + "\\PokeWhisper.exe.config");
                    swconfig.Write(srconfig.ReadToEnd().Replace("VAR_LANGUAGE_VAR", sLanguage));
                    swconfig.Flush();
                    swconfig.Close();
                    srconfig.Close();
                }

                sPath += @"Ext\Pokemon and Friends by WaldoAndFriends\";
                string sPathConverted = sPath.Replace("\\", "/");

                File.Copy(txtBoardLocation.Text, txtBoardLocation.Text + ".backup",true);
                File.Delete(txtBoardLocation.Text);

                StreamReader sr = new StreamReader("files\\PokemonInstaller");
                StreamWriter sw = new StreamWriter(txtBoardLocation.Text);
                string sText = sr.ReadToEnd();

                sText = sText.Replace("VAR_RUN_AWAY_MIN_VAR", txtRunMin.Text);
                sText = sText.Replace("VAR_RUN_AWAY_MAX_VAR", txtRunMax.Text);
                sText = sText.Replace("VAR_FIRST_POKEMON_VAR", txtFirstPokemon.Text);
                sText = sText.Replace("VAR_LAST_POKEMON_VAR", txtLastPokemon.Text);
                sText = sText.Replace("VAR_SHINY_CHANCE_VAR", txtShinyChance.Text);
                sText = sText.Replace("VAR_SPAWN_TIMER_VAR", txtSpawnTimer.Text);
                sText = sText.Replace("VAR_RUN_TIMER_VAR", txtRunTimer.Text);
                sText = sText.Replace("VAR_GREATBALL_TIMER_VAR", txtGreatballTimer.Text);
                sText = sText.Replace("VAR_ULTRABALL_TIMER_VAR", txtUltraballTimer.Text);
                sText = sText.Replace("VAR_DISCORD_WEBHOOK_VAR", txtWebhookURL.Text);
                sText = sText.Replace("VAR_DISCORD_USER_VAR", txtWebhookUser.Text);
                sText = sText.Replace("VAR_MAX_POKEMON_VAR", txtMaxPokemon.Text);
                sText = sText.Replace("VAR_GREATBALL_TIMER_VAR", txtGreatballTimer.Text);
                sText = sText.Replace("VAR_USE_DISCORD_VAR", sDiscord);
                sText = sText.Replace("VAR_LOADING_SCREEN_VAR", sLoading);
                sText = sText.Replace("VAR_BREAKOUT_MESSAGE_VAR", sBreakout);
                sText = sText.Replace("VAR_LANGUAGE_VAR", sLanguage);
                sText = sText.Replace("VAR_PATH_LOCATION_VAR", sPathConverted);
                sText = sText.Replace("VAR_CATCH_RATE_VAR", txtCatchRate.Text);
                sText = sText.Replace("VAR_SPAWN_MUSIC_VAR", sMusic);
                sText = sText.Replace("VAR_USE_MASTERBALL_VAR", sMasterball);
                sText = sText.Replace("VAR_USE_GIFT_VAR", sUseGift);


                sw.Write(sText);
                sw.Flush();
                sw.Close();
                sr.Close();

                //Copy Files:
                File.Copy(@"files\pokeball.png", sPath + @"sources\pokeball.png",true);
                File.Copy(@"files\greatball.png", sPath + @"sources\greatball.png", true);
                File.Copy(@"files\ultraball.png", sPath + @"sources\ultraball.png", true);
                File.Copy(@"files\masterball.png", sPath + @"sources\masterball.png", true);
                File.Copy(@"files\LoadingScreen.png", sPath + @"sources\LoadingScreen.png", true);
                File.Copy(@"files\Challenger Approaches.mp3", sPath + @"sources\Challenger Approaches.mp3", true);

                MessageBox.Show("Installation Completed.\nNow start LioranBoard, connect it with obs and run the !poke-upgrade command.\nIf you want to support me, feel free to hit that \"Support Me\"-Button");
            }
            else
            {
                MessageBox.Show("No Board found, please select the correct board to perform the upgrade.");
                btnSearch_Click(null, null);
            }
        }

        private bool CheckValues()
        {
            if (string.IsNullOrEmpty(txtBoardLocation.Text)) return false;

            return true;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Welcome to the Pokemon and friends upgrader.\nFirst of all I wanted to say that this is an unofficial Project created by me and it is not supported by the StreamUp Team.\nTo upgrade the program you need to follow these steps: \n\n1. Delete the Pokemon Scene from your OBS\n2. Close OBS and Lioran Board\n3. Select your LioranBoard Receiver(PC) Folder and let the Upgrader grab the correct board\n4. Setup your Values\n5. Hit Install\n6. Open OBS and LB and connect them\n7. Type !poke-upgrade\n(8.Adjust the volume of the scene and add pictures to the channelpoint rewards)\n9.Add the newly generated scene to the scenes where you want to use the game as a nested scene\n\nIf you have any questions, feel free to hop into my discord or dm me directly: Chrizzz#0810.\n\nWant to open discord now?", "Help", MessageBoxButtons.YesNo))
            {
                Process.Start("https://discord.gg/gggS8AD");
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This upgrader was developed by chrizzz_1508.\n\nSpecial thanks to:\nWaldoAndFriends - Developing the Base Version\nTempest - Beta Testing\nKefiren - Beta Testing\nMurtherX - Beta Testing\nPox4eveR - Beta Testing");
        }

        private void LoadValues()
        {
            txtWebhookURL.Text = Properties.Settings.Default.WebhookURL;
            txtRunMin.Text = Properties.Settings.Default.RunAwayMin;
            txtRunMax.Text = Properties.Settings.Default.RunAwayMax;
            txtFirstPokemon.Text = Properties.Settings.Default.FirstPokemonNr;
            txtLastPokemon.Text = Properties.Settings.Default.LastPokemonNr;
            txtShinyChance.Text = Properties.Settings.Default.ShinyPercentage;
            txtMaxPokemon.Text = Properties.Settings.Default.MaxAmountOfPokemon;
            txtSpawnTimer.Text = Properties.Settings.Default.SpawnTimer;
            txtRunTimer.Text = Properties.Settings.Default.RunTimer;
            txtGreatballTimer.Text = Properties.Settings.Default.GreatballTimer;
            txtUltraballTimer.Text = Properties.Settings.Default.UltraballTimer;
            txtWebhookUser.Text = Properties.Settings.Default.WebhookUser;
            txtCatchRate.Text = Properties.Settings.Default.CatchRate;

            cbLanguage.SelectedIndex = Properties.Settings.Default.Language;
            cbMasterball.SelectedIndex = Properties.Settings.Default.Masterball;
            cbUseLoadingScreen.SelectedIndex = Properties.Settings.Default.LoadingScreen;
            cbUseSpawnMusic.SelectedIndex = Properties.Settings.Default.SpawnMusic;
            cbUseBreakout.SelectedIndex = Properties.Settings.Default.BreakoutMessage;
            cbUseDiscord.SelectedIndex = Properties.Settings.Default.Discord;
            cbUseGift.SelectedIndex = Properties.Settings.Default.Gift;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WebhookURL = txtWebhookURL.Text;
            Properties.Settings.Default.RunAwayMin = txtRunMin.Text;
            Properties.Settings.Default.RunAwayMax = txtRunMax.Text;
            Properties.Settings.Default.FirstPokemonNr = txtFirstPokemon.Text;
            Properties.Settings.Default.LastPokemonNr = txtLastPokemon.Text;
            Properties.Settings.Default.ShinyPercentage = txtShinyChance.Text;
            Properties.Settings.Default.MaxAmountOfPokemon = txtMaxPokemon.Text;
            Properties.Settings.Default.SpawnTimer = txtSpawnTimer.Text;
            Properties.Settings.Default.RunTimer = txtRunTimer.Text;
            Properties.Settings.Default.GreatballTimer = txtGreatballTimer.Text;
            Properties.Settings.Default.UltraballTimer = txtUltraballTimer.Text;
            Properties.Settings.Default.WebhookUser = txtWebhookUser.Text;
            Properties.Settings.Default.CatchRate = txtCatchRate.Text;

            Properties.Settings.Default.Language = cbLanguage.SelectedIndex;
            Properties.Settings.Default.Masterball = cbMasterball.SelectedIndex;
            Properties.Settings.Default.LoadingScreen = cbUseLoadingScreen.SelectedIndex;
            Properties.Settings.Default.SpawnMusic = cbUseSpawnMusic.SelectedIndex;
            Properties.Settings.Default.BreakoutMessage = cbUseBreakout.SelectedIndex;
            Properties.Settings.Default.Discord = cbUseDiscord.SelectedIndex;
            Properties.Settings.Default.Gift = cbUseGift.SelectedIndex;

            Properties.Settings.Default.Save();

        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            frmChrizzz frm = new frmChrizzz();
            frm.Show();
        }
    }
}
