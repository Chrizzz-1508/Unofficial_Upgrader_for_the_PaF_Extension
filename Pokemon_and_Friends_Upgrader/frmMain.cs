using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pokemon_and_Friends_Upgrader
{
    public partial class frmMain : Form
    {
        public volatile string sPath = "";

        string sLoadingScreenPath;
        string sShinyScreenPath;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select your LB2 folder\nIt should contain the LioranBoard 2.0.exe";

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(fb.SelectedPath + "\\transmitter") || !File.Exists(fb.SelectedPath + "\\LioranBoard 2.0.exe"))
                    {
                        MessageBox.Show("Unfortunately this is not the LB2 folder.\nThe LB2 folder contains a transmitter folder and the Lioranboard 2.0.exe.\nPlease select the correct folder.");
                        btnSearch_Click(null,null);
                    }
                    else
                    {
                        if (!Directory.Exists(fb.SelectedPath + "\\Pokemon and Friends")) Directory.CreateDirectory(fb.SelectedPath + "\\Pokemon and Friends");
                        txtLB2.Text = fb.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't access the file. Please close the .ini File and Lioaran Board first." + ex.ToString());
            }
            
        }
        private void CopyFiles()
        {
            string sPAFPath = txtLB2.Text + @"\Pokemon and Friends";            

            if (!Directory.Exists(sPAFPath + @"\backup")) Directory.CreateDirectory(sPAFPath + @"\backup");
            if (!Directory.Exists(sPAFPath + @"\database")) Directory.CreateDirectory(sPAFPath + @"\database");
            if (!Directory.Exists(sPAFPath + @"\sources")) Directory.CreateDirectory(sPAFPath + @"\sources");
            if (!Directory.Exists(sPAFPath + @"\trainers")) Directory.CreateDirectory(sPAFPath + @"\trainers");
            if (!Directory.Exists(sPAFPath + @"\wallpaper")) Directory.CreateDirectory(sPAFPath + @"\wallpaper");
            if (!Directory.Exists(sPAFPath + @"\hdsprites240\normal")) Directory.CreateDirectory(sPAFPath + @"\hdsprites240\normal");
            if (!Directory.Exists(sPAFPath + @"\hdsprites240\shiny")) Directory.CreateDirectory(sPAFPath + @"\hdsprites240\shiny");
            if (!Directory.Exists(sPAFPath + @"\hdsprites240\normalgif")) Directory.CreateDirectory(sPAFPath + @"\hdsprites240\normalgif");
            if (!Directory.Exists(sPAFPath + @"\hdsprites240\shinygif")) Directory.CreateDirectory(sPAFPath + @"\hdsprites240\shinygif");
            if (!Directory.Exists(sPAFPath + @"\hdsprites512\normal")) Directory.CreateDirectory(sPAFPath + @"\hdsprites512\normal");
            if (!Directory.Exists(sPAFPath + @"\hdsprites512\shiny")) Directory.CreateDirectory(sPAFPath + @"\hdsprites512\shiny");

            //Copy Database
            DirectoryInfo diDatabase = new DirectoryInfo(@"files\database");
            foreach (FileInfo f in diDatabase.GetFiles())
            {
                string fptarget = sPAFPath + @"\database\" + f.Name;
                if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
            }

            //Copy Trainers
            DirectoryInfo diTrainers = new DirectoryInfo(@"files\trainers");
            foreach (FileInfo f in diTrainers.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\trainers\" + f.Name;
                    File.Copy(f.FullName, fptarget,true);
                } 
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

            //Copy Wallpapers
            DirectoryInfo diWallpapers = new DirectoryInfo(@"files\wallpaper");
            foreach (FileInfo f in diWallpapers.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\wallpaper\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Pokemon240PNG
            DirectoryInfo diPokemonPNG240Normal = new DirectoryInfo(@"files\hdsprites240\normal");
            foreach (FileInfo f in diPokemonPNG240Normal.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites240\normal\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

            DirectoryInfo diPokemonPNG240Shiny = new DirectoryInfo(@"files\hdsprites240\shiny");
            foreach (FileInfo f in diPokemonPNG240Shiny.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites240\shiny\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Pokemon512PNG
            DirectoryInfo diPokemonPNG512Normal = new DirectoryInfo(@"files\hdsprites512\normal");
            foreach (FileInfo f in diPokemonPNG512Normal.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites512\normal\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            DirectoryInfo diPokemonPNG512Shiny = new DirectoryInfo(@"files\hdsprites512\shiny");
            foreach (FileInfo f in diPokemonPNG512Shiny.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites512\shiny\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Other Stuff
            string ftSourceTargetPath = sPAFPath + @"\sources\";

            try { if (!File.Exists(ftSourceTargetPath + @"pokeball.png")) File.Copy(@"files\sources\pokeball.png", ftSourceTargetPath + @"pokeball.png"); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            try{ if (!File.Exists(ftSourceTargetPath + @"greatball.png")) File.Copy(@"files\sources\greatball.png", ftSourceTargetPath + @"greatball.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"ultraball.png")) File.Copy(@"files\sources\ultraball.png", ftSourceTargetPath + @"ultraball.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"masterball.png")) File.Copy(@"files\sources\masterball.png", ftSourceTargetPath + @"masterball.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"PokedexWallpaper.png")) File.Copy(@"files\sources\PokedexWallpaper.png", ftSourceTargetPath + @"PokedexWallpaper.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"PokedexWallpaper720.png")) File.Copy(@"files\sources\PokedexWallpaper720.png", ftSourceTargetPath + @"PokedexWallpaper720.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"pokemon_wallpaper.png")) File.Copy(@"files\sources\pokemon_wallpaper.png", ftSourceTargetPath + @"pokemon_wallpaper.png"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"Pokemon_Loading_Animation.webm")) File.Copy(@"files\loadinganimations\Pokemon_Loading_Animation.webm", ftSourceTargetPath + @"Pokemon_Loading_Animation.webm");} catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"SFX_BALL_POOF.wav")) File.Copy(@"files\sources\SFX_BALL_POOF.wav", ftSourceTargetPath + @"SFX_BALL_POOF.wav");} catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"SFX_BALL_TOSS.wav")) File.Copy(@"files\sources\SFX_BALL_TOSS.wav", ftSourceTargetPath + @"SFX_BALL_TOSS.wav");} catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"SFX_CAUGHT_MON.wav")) File.Copy(@"files\sources\SFX_CAUGHT_MON.wav", ftSourceTargetPath + @"SFX_CAUGHT_MON.wav"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ if (!File.Exists(ftSourceTargetPath + @"SFX_RUN.wav")) File.Copy(@"files\sources\SFX_RUN.wav", ftSourceTargetPath + @"SFX_RUN.wav"); } catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try { if (!File.Exists(ftSourceTargetPath + @"ShinyStars.png")) File.Copy(@"files\sources\ShinyStars.png", ftSourceTargetPath + @"ShinyStars.png"); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            try { File.Copy(sLoadingScreenPath, ftSourceTargetPath + @"LoadingScreen.png", true);} catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ File.Copy(sShinyScreenPath, ftSourceTargetPath + @"shiny.png", true);} catch(Exception ex) { MessageBox.Show(ex.ToString());}
            try{ File.Copy(@"files\loadingsounds\" + txtLoadingSound.Text, ftSourceTargetPath + @"Challenger Approaches.mp3", true);} catch(Exception ex) { MessageBox.Show(ex.ToString());}

            //Copy GIF Files

            DirectoryInfo diPokemonGIF240Normal = new DirectoryInfo(@"files\hdsprites240\normalgif");
            foreach (FileInfo f in diPokemonGIF240Normal.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites240\normalgif\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                } catch (Exception ex) { MessageBox.Show(ex.ToString()); };
            }

            DirectoryInfo diPokemonGIF240Shiny = new DirectoryInfo(@"files\hdsprites240\shinygif");
            foreach (FileInfo f in diPokemonGIF240Shiny.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hdsprites240\shinygif\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); };
            }
        }
    
        private void CreateLB2Extension()
        {
            StreamReader sr = new StreamReader(@"files\PaF_Unconverted");
            string sOutput = sr.ReadToEnd();
            sr.Close();


            //English
            //German
            //French
            //Spanish
            //Italian
            string VAR_LANGUAGE_VAR = "en";
            switch(cbLanguage.SelectedIndex)
            {
                case 1:
                    VAR_LANGUAGE_VAR = "de";
                    break;
                case 2:
                    VAR_LANGUAGE_VAR = "fr";
                    break;
                case 3:
                    VAR_LANGUAGE_VAR = "es";
                    break;
                case 4:
                    VAR_LANGUAGE_VAR = "it";
                    break;
                default:
                    break;
            }


            string VAR_USE_NON_AFFILIATE_VAR = "true";
            if (cbAffiliate.SelectedIndex == 1) VAR_USE_NON_AFFILIATE_VAR = "false";

            string VAR_USE_IGNORE_LB_VAR = "true";
            if (cbLeaderboard.SelectedIndex == 1) VAR_USE_IGNORE_LB_VAR = "false";

            string VAR_USE_GIFS_VAR = "true";
            if (cbUseGIFS.SelectedIndex == 1) VAR_USE_GIFS_VAR = "false";

            string VAR_USE_SPAWNCHANCE_VAR = "true";
            if (cbRandomSpawn.SelectedIndex == 1) VAR_USE_SPAWNCHANCE_VAR = "false";

            string VAR_USE_SPAWNMUSIC_VAR = "true";
            if (cbSpawnSound.SelectedIndex == 1) VAR_USE_SPAWNMUSIC_VAR = "false";

            string VAR_USE_LOADINGSCREEN_VAR = "true";
            if (cbUseLoadingScreen.SelectedIndex == 1) VAR_USE_LOADINGSCREEN_VAR = "false";

            string VAR_USE_LOADINGANIMATION_VAR = "true";
            if (cbLoadingAnimation.SelectedIndex == 1) VAR_USE_LOADINGANIMATION_VAR = "false";

            string VAR_USE_DISCORD_VAR = "true";
            if (cbUseDiscord.SelectedIndex == 1) VAR_USE_DISCORD_VAR = "false";

            string VAR_USE_BONUSTIME_VAR = "true";
            if (cbUseBonusTime.SelectedIndex == 1) VAR_USE_BONUSTIME_VAR = "false";

            string VAR_USE_GREATBALL_VAR = "true";
            if (cbGreatball.SelectedIndex == 1) VAR_USE_GREATBALL_VAR = "false";

            string VAR_USE_ULTRABALL_VAR = "true";
            if (cbUltraball.SelectedIndex == 1) VAR_USE_ULTRABALL_VAR = "false";

            string VAR_USE_MASTERBALL_VAR = "true";
            if (cbMasterball.SelectedIndex == 1) VAR_USE_MASTERBALL_VAR = "false";

            string VAR_USE_MYS_POK_VAR = "true";
            if (cbMysteryPokemon.SelectedIndex == 1) VAR_USE_MYS_POK_VAR = "false";

            string VAR_USE_MYS_SHINY_VAR = "true";
            if (cbMysteryShiny.SelectedIndex == 1) VAR_USE_MYS_SHINY_VAR = "false";

            string VAR_USE_SUMMON_VAR = "true";
            if (cbSummon.SelectedIndex == 1) VAR_USE_SUMMON_VAR = "false";

            string VAR_USE_GIFT_VAR = "true";
            if (cbGift.SelectedIndex == 1) VAR_USE_GIFT_VAR = "false";

            string VAR_USE_BREAKOUT_MSG_VAR = "true";
            if (cbUseBreakout.SelectedIndex == 1) VAR_USE_BREAKOUT_MSG_VAR = "false";

            string VAR_USE_RUN_MSG_VAR = "true";
            if (cbUseRunMessage.SelectedIndex == 1) VAR_USE_RUN_MSG_VAR = "false";

            string VAR_USE_REFUND_MSG_VAR = "true";
            if (cbRefundMessage.SelectedIndex == 1) VAR_USE_REFUND_MSG_VAR = "false";

            //V1.1

            string VAR_USE_GEN_1_VAR = "true";
            if (cbGen1.SelectedIndex == 1) VAR_USE_GEN_1_VAR = "false";

            string VAR_USE_GEN_2_VAR = "true";
            if (cbGen2.SelectedIndex == 1) VAR_USE_GEN_2_VAR = "false";

            string VAR_USE_GEN_3_VAR = "true";
            if (cbGen3.SelectedIndex == 1) VAR_USE_GEN_3_VAR = "false";

            string VAR_USE_GEN_4_VAR = "true";
            if (cbGen4.SelectedIndex == 1) VAR_USE_GEN_4_VAR = "false";

            string VAR_USE_GEN_5_VAR = "true";
            if (cbGen5.SelectedIndex == 1) VAR_USE_GEN_5_VAR = "false";

            string VAR_USE_GEN_6_VAR = "true";
            if (cbGen6.SelectedIndex == 1) VAR_USE_GEN_6_VAR = "false";

            string VAR_USE_GEN_7_VAR = "true";
            if (cbGen7.SelectedIndex == 1) VAR_USE_GEN_7_VAR = "false";

            string VAR_USE_GEN_8_VAR = "true";
            if (cbGen8.SelectedIndex == 1) VAR_USE_GEN_8_VAR = "false";

            string VAR_USE_REGIONALS_VAR = "true";
            if (cbRegional.SelectedIndex == 1) VAR_USE_REGIONALS_VAR = "false";

            string VAR_USE_CUSTOM_VAR = "true";
            if (cbCustom.SelectedIndex == 1) VAR_USE_CUSTOM_VAR = "false";

            string VAR_ANIMATED_TRAINERS_VAR = "true";
            if (cbAnimatedTrainers.SelectedIndex == 1) VAR_ANIMATED_TRAINERS_VAR = "false";

            string VAR_ANNOUNCE_VAR = "true";
            if (cbAnnounce.SelectedIndex == 1) VAR_ANNOUNCE_VAR = "false";


            sOutput = sOutput.Replace("VAR_LANGUAGE_VAR", VAR_LANGUAGE_VAR);
            sOutput = sOutput.Replace("VAR_POKE_PATH_VAR",txtLB2.Text.Replace(@"\","/") + @"/Pokemon and Friends/");
            sOutput = sOutput.Replace("VAR_USE_NON_AFFILIATE_VAR", VAR_USE_NON_AFFILIATE_VAR);
            sOutput = sOutput.Replace("VAR_THRESHOLD_VAR", txtAudioTreshhold.Text);
            sOutput = sOutput.Replace("VAR_USE_IGNORE_LB_VAR", VAR_USE_IGNORE_LB_VAR);
            sOutput = sOutput.Replace("VAR_OBSWSPORT_VAR",txtOBSWSPort.Text);
            sOutput = sOutput.Replace("VAR_OBSWSPW_VAR",txtOBSWSPW.Text);
            sOutput = sOutput.Replace("VAR_SHINYCHANCE_VAR",txtShinyChance.Text);
            sOutput = sOutput.Replace("VAR_USE_GIFS_VAR", VAR_USE_GIFS_VAR);
            sOutput = sOutput.Replace("VAR_CR_POKEBALL_VAR",txtCatchRatePokeball.Text);
            sOutput = sOutput.Replace("VAR_CR_GREATBALL_VAR",txtCatchRateGreatball.Text);
            sOutput = sOutput.Replace("VAR_CR_ULTRABALL_VAR",txtCatchRateUltraball.Text);
            sOutput = sOutput.Replace("VAR_CR_MIN_VAR",txtCatchIncMin.Text);
            sOutput = sOutput.Replace("VAR_CR_MAX_VAR", txtCatchIncMax.Text);
            sOutput = sOutput.Replace("VAR_SPAWN_TIME_VAR", txtSpawnTimer.Text);
            sOutput = sOutput.Replace("VAR_USE_SPAWNCHANCE_VAR", VAR_USE_SPAWNCHANCE_VAR);
            sOutput = sOutput.Replace("VAR_SPAWNCHANCE_VAR",txtSpawnChance.Text);
            sOutput = sOutput.Replace("VAR_USE_SPAWNMUSIC_VAR", VAR_USE_SPAWNMUSIC_VAR);
            sOutput = sOutput.Replace("VAR_USE_LOADINGSCREEN_VAR", VAR_USE_LOADINGSCREEN_VAR);
            sOutput = sOutput.Replace("VAR_USE_LOADINGANIMATION_VAR", VAR_USE_LOADINGANIMATION_VAR);
            sOutput = sOutput.Replace("VAR_RUN_MIN_VAR",txtRunMin.Text);
            sOutput = sOutput.Replace("VAR_RUN_MAX_VAR",txtRunMax.Text);
            sOutput = sOutput.Replace("VAR_RUN_TIME_VAR",txtRunTimer.Text);
            sOutput = sOutput.Replace("VAR_USE_DISCORD_VAR", VAR_USE_DISCORD_VAR);
            sOutput = sOutput.Replace("VAR_DC_CATCHHOOK_VAR",txtWebhookURL.Text);

            if(cbUseSeparateWebhook.SelectedIndex == 1) sOutput = sOutput.Replace("VAR_MYP_CATCHHOOK_VAR", txtWebhookURL.Text);
            else sOutput = sOutput.Replace("VAR_MYP_CATCHHOOK_VAR", txtMyPokemonWebhook.Text);

            sOutput = sOutput.Replace("VAR_USE_BONUSTIME_VAR", VAR_USE_BONUSTIME_VAR);
            sOutput = sOutput.Replace("VAR_BONUS_MIN_USERS_VAR",txtBonusMinUsers.Text);
            sOutput = sOutput.Replace("VAR_BONUS_DURATION_VAR",txtBonusTime.Text);
            sOutput = sOutput.Replace("VAR_BONUS_SPAWNTIME_VAR", txtBonusSpawnTimer.Text);
            sOutput = sOutput.Replace("VAR_USE_GREATBALL_VAR", VAR_USE_GREATBALL_VAR);
            sOutput = sOutput.Replace("VAR_USE_ULTRABALL_VAR", VAR_USE_ULTRABALL_VAR);
            sOutput = sOutput.Replace("VAR_USE_MASTERBALL_VAR", VAR_USE_MASTERBALL_VAR);
            sOutput = sOutput.Replace("VAR_USE_MYS_POK_VAR", VAR_USE_MYS_POK_VAR);
            sOutput = sOutput.Replace("VAR_USE_MYS_SHINY_VAR", VAR_USE_MYS_SHINY_VAR);
            sOutput = sOutput.Replace("VAR_USE_SUMMON_VAR", VAR_USE_SUMMON_VAR);
            sOutput = sOutput.Replace("VAR_USE_GIFT_VAR", VAR_USE_GIFT_VAR);
            sOutput = sOutput.Replace("VAR_USE_BREAKOUT_MSG_VAR", VAR_USE_BREAKOUT_MSG_VAR);
            sOutput = sOutput.Replace("VAR_USE_RUN_MSG_VAR", VAR_USE_RUN_MSG_VAR);
            sOutput = sOutput.Replace("VAR_USE_REFUND_MSG_VAR", VAR_USE_REFUND_MSG_VAR);
            
            sOutput = sOutput.Replace("VAR_MYSTERY_P_VAR",txtMysteryPokemon.Text);
            sOutput = sOutput.Replace("VAR_MYSTERY_S_VAR", txtMysteryShiny.Text);
            sOutput = sOutput.Replace("VAR_SUMMON_VAR", txtSummon.Text);
            sOutput = sOutput.Replace("VAR_GIFT_VAR", txtGift.Text);

            sOutput = sOutput.Replace("VAR_POKEBALL_VAR", txtPokeball.Text);
            sOutput = sOutput.Replace("VAR_GREATBALL_VAR",txtGreatball.Text);
            sOutput = sOutput.Replace("VAR_ULTRABALL_VAR",txtUltraball.Text);
            sOutput = sOutput.Replace("VAR_MASTERBALL_VAR", txtMasterball.Text);
           
            sOutput = sOutput.Replace("VAR_PRICE_MYSTERY_P_VAR", txtPriceMysteryPokemon.Text);
            sOutput = sOutput.Replace("VAR_PRICE_MYSTERY_S_VAR", txtPriceMysteryShiny.Text);
            sOutput = sOutput.Replace("VAR_PRICE_SUMMON_VAR", txtPriceSummon.Text);
            sOutput = sOutput.Replace("VAR_PRICE_GIFT_VAR", txtPriceGift.Text);
            
            sOutput = sOutput.Replace("VAR_PRICE_POKEBALL_VAR", txtPricePokeball.Text);
            sOutput = sOutput.Replace("VAR_PRICE_GREATBALL_VAR", txtPriceGreatball.Text);
            sOutput = sOutput.Replace("VAR_PRICE_ULTRABALL_VAR", txtPriceUltraball.Text);
            sOutput = sOutput.Replace("VAR_PRICE_MASTERBALL_VAR", txtPriceMasterball.Text);

            sOutput = sOutput.Replace("VAR_USE_GEN_1_VAR", VAR_USE_GEN_1_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_2_VAR", VAR_USE_GEN_2_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_3_VAR", VAR_USE_GEN_3_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_4_VAR", VAR_USE_GEN_4_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_5_VAR", VAR_USE_GEN_5_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_6_VAR", VAR_USE_GEN_6_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_7_VAR", VAR_USE_GEN_7_VAR);
            sOutput = sOutput.Replace("VAR_USE_GEN_8_VAR", VAR_USE_GEN_8_VAR);
            sOutput = sOutput.Replace("VAR_USE_REGIONALS_VAR", VAR_USE_REGIONALS_VAR);
            sOutput = sOutput.Replace("VAR_USE_CUSTOM_VAR", VAR_USE_CUSTOM_VAR);
            
            sOutput = sOutput.Replace("VAR_ANIMATED_TRAINERS_VAR",VAR_ANIMATED_TRAINERS_VAR);
            sOutput = sOutput.Replace("VAR_ANNOUNCE_VAR",VAR_ANNOUNCE_VAR);
            sOutput = sOutput.Replace("VAR_BROADCASTER_VAR", txtBroadcaster.Text.ToLowerInvariant());

            sOutput = sOutput.Replace("\"include_image\": { }", "\"include_image\": { } ,\"transmitter\":true, \"lioranboard_version\":\"2.07.9\", \"extension_triggers\":[\"PaFModInstall\"]}");


            using (StreamWriter sw = new StreamWriter(txtLB2.Text + @"\Pokemon and Friends\PaFGame.lb2"))
            {
                sw.Write(sOutput);
                sw.Flush();
                sw.Close();
            }
        }
        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (CheckValues())
            {
                CreateLB2Extension();
                pbLoading.Visible = true;
                lblLoading.Parent = pbLoading;
                lblLoading.Visible = true;
                Thread t = new Thread(CopyFiles);
                t.Start();
                while (t.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                pbLoading.Visible = false;

                if (!File.Exists(txtLB2.Text + @"\Pokemon and Friends\hdsprites240\normal\1.png") || (!File.Exists(txtLB2.Text + @"\Pokemon and Friends\hdsprites240\normalgif\1.gif") && cbUseGIFS.SelectedIndex == 0))
                {
                    if (DialogResult.Yes == MessageBox.Show("Not all files were copied successfully, do you want to try again?", "Try again?", MessageBoxButtons.YesNo)) btnInstall_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Installation completed.\n\nNext please Install the PaFGame.lb2 Extension from your \"LB2 => Pokemon and Friends\" folder and then type !poke-install into the chat.");
                }
            }
            else
            {
                MessageBox.Show("Not all the fields were filled out correctly.");
            }
        }
        private bool CheckValues()
        {
            if (string.IsNullOrEmpty(txtLB2.Text)) return false;
            if(string.IsNullOrEmpty(txtBroadcaster.Text)) return false; 
            if (cbUseDiscord.SelectedIndex == 0 && String.IsNullOrEmpty(txtWebhookURL.Text)) return false;
            return true;
        }

        #region "Initialize / Load / Close Stuff"
        private void frmMain_Load(object sender, EventArgs e)
        {
            initializeToolTips();
            LoadValues();
            LoadSources();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LB2 = txtLB2.Text;
            Properties.Settings.Default.Language = cbLanguage.SelectedIndex;
            Properties.Settings.Default.NonAffiliate = cbAffiliate.SelectedIndex;
            Properties.Settings.Default.Leaderboard = cbLeaderboard.SelectedIndex;
            Properties.Settings.Default.AudioTreshhold = txtAudioTreshhold.Text;
            Properties.Settings.Default.OBSWSPort = txtOBSWSPort.Text;
            Properties.Settings.Default.OBSWSPW = txtOBSWSPW.Text;

            Properties.Settings.Default.ShinyChance = txtShinyChance.Text;
            Properties.Settings.Default.Gifs = cbUseGIFS.SelectedIndex;

            Properties.Settings.Default.SpawnTimer = txtSpawnTimer.Text;
            Properties.Settings.Default.UseSpawnChance = cbRandomSpawn.SelectedIndex;
            Properties.Settings.Default.SpawnChance = txtSpawnChance.Text;
            Properties.Settings.Default.SpawnMusic = cbSpawnSound.SelectedIndex;
            Properties.Settings.Default.LoadingScreen = cbUseLoadingScreen.SelectedIndex;
            Properties.Settings.Default.LoadingAnimation = cbLoadingAnimation.SelectedIndex;
            
            Properties.Settings.Default.CatchValuePokeball = txtCatchRatePokeball.Text;
            Properties.Settings.Default.CatchValueGreatball = txtCatchRateGreatball.Text;
            Properties.Settings.Default.CatchValueUltraball = txtCatchRateUltraball.Text;
            Properties.Settings.Default.CatchMinIncrease = txtCatchIncMin.Text;
            Properties.Settings.Default.CatchMaxIncrease = txtCatchIncMax.Text;

            Properties.Settings.Default.UseBonustime = cbUseBonusTime.SelectedIndex;
            Properties.Settings.Default.BonusTimeDuration = txtBonusTime.Text;
            Properties.Settings.Default.BonusTimeMinUsers = txtBonusMinUsers.Text;
            Properties.Settings.Default.BonusTimeSpawnTimer = txtBonusSpawnTimer.Text;

            Properties.Settings.Default.RunAwayMinIncrease = txtRunMin.Text;
            Properties.Settings.Default.RunAwayMaxIncrease = txtRunMax.Text;
            Properties.Settings.Default.RunTimer = txtRunTimer.Text;

            Properties.Settings.Default.UseDiscord = cbUseDiscord.SelectedIndex;
            Properties.Settings.Default.UseSepareteWebhook = cbUseSeparateWebhook.SelectedIndex;
            Properties.Settings.Default.WebhookURLCatch = txtWebhookURL.Text;
            Properties.Settings.Default.WebhookURLMYP = txtMyPokemonWebhook.Text;

            Properties.Settings.Default.UseBreakoutMessage = cbUseBreakout.SelectedIndex;
            Properties.Settings.Default.UseRefundMessage = cbRefundMessage.SelectedIndex;
            Properties.Settings.Default.UseRunMessage = cbUseRunMessage.SelectedIndex;

            Properties.Settings.Default.LoadingSoundPath = txtLoadingSound.Text;
            Properties.Settings.Default.ShinyScreenPath = sShinyScreenPath;
            Properties.Settings.Default.LoadingScreenPath = sLoadingScreenPath;

            Properties.Settings.Default.NamePokeball = txtPokeball.Text;
            Properties.Settings.Default.PricePokeball = txtPricePokeball.Text;

            Properties.Settings.Default.NameGreatball = txtGreatball.Text;
            Properties.Settings.Default.UseGreatball = cbGreatball.SelectedIndex;
            Properties.Settings.Default.PriceGreatball = txtPriceGreatball.Text;

            Properties.Settings.Default.NameUltraball = txtUltraball.Text;
            Properties.Settings.Default.UseUltraball = cbUltraball.SelectedIndex;
            Properties.Settings.Default.PriceUltraball = txtPriceUltraball.Text;

            Properties.Settings.Default.NameMasterball = txtMasterball.Text;
            Properties.Settings.Default.UseMasterball = cbMasterball.SelectedIndex;
            Properties.Settings.Default.PriceMasterball = txtPriceMasterball.Text;

            Properties.Settings.Default.NameMysteryPokemon = txtMysteryPokemon.Text;
            Properties.Settings.Default.UseMysteryPokemon = cbMysteryPokemon.SelectedIndex;
            Properties.Settings.Default.PriceMysteryPokemon = txtPriceMysteryPokemon.Text;

            Properties.Settings.Default.NameMysteryShiny = txtMysteryShiny.Text;
            Properties.Settings.Default.UseMysteryShiny = cbMysteryShiny.SelectedIndex;
            Properties.Settings.Default.PriceMysteryShiny = txtPriceMysteryShiny.Text;

            Properties.Settings.Default.NameSummon = txtSummon.Text;
            Properties.Settings.Default.UseSummon = cbSummon.SelectedIndex;
            Properties.Settings.Default.PriceSummon = txtPriceSummon.Text;


            Properties.Settings.Default.NameGift = txtGift.Text;
            Properties.Settings.Default.UseGift = cbGift.SelectedIndex;
            Properties.Settings.Default.PriceGift = txtPriceGift.Text;

            Properties.Settings.Default.UseGen1 = cbGen1.SelectedIndex;
            Properties.Settings.Default.UseGen2 = cbGen2.SelectedIndex;
            Properties.Settings.Default.UseGen3 = cbGen3.SelectedIndex;
            Properties.Settings.Default.UseGen4 = cbGen4.SelectedIndex;
            Properties.Settings.Default.UseGen5 = cbGen5.SelectedIndex;
            Properties.Settings.Default.UseGen6 = cbGen6.SelectedIndex;
            Properties.Settings.Default.UseGen7 = cbGen7.SelectedIndex;
            Properties.Settings.Default.UseGen8 = cbGen8.SelectedIndex;
            Properties.Settings.Default.UseRegionals = cbRegional.SelectedIndex;
            Properties.Settings.Default.UseCustomPokemon = cbCustom.SelectedIndex;

            Properties.Settings.Default.UseAnimatedTrainers = cbAnimatedTrainers.SelectedIndex;
            Properties.Settings.Default.AnnounceRarePokemons = cbAnnounce.SelectedIndex;
            Properties.Settings.Default.BroadcasterName = txtBroadcaster.Text;
            
            Properties.Settings.Default.Save();
        }
        private void initializeToolTips()
        {          
            TTExplanation.SetToolTip(lblLB2, "Select your LB2 Folder");
            TTExplanation.SetToolTip(lblLanguage, "Select your Language");
            TTExplanation.SetToolTip(lblAffiliate, "Non Affiliate Mode turns off channel points and \nadds the !throw command instead.\nRecommended only for people who\nhaven't unlocked Channel Points yet");
            TTExplanation.SetToolTip(lblLeaderboard, "Turn on to not showup on the leaderboard");
            TTExplanation.SetToolTip(lblAudioTreshhold, "Sets the Limter of the Volume of the Sounds\nThe higher it is, the lower the maximum Volume of the Sounds will be\nRecommended Value is 30-35\n0 = Nearly no Limit");
            TTExplanation.SetToolTip(lblOBSWSPort, "OBS Websocket Port.\nDefault is \"4444\"\nCan be found in OBS under Tools => Websocket Server Settings");
            TTExplanation.SetToolTip(lblOBSWSPW, "OBS Websocket Password.\nCan be found in OBS under Tools => Websocket Server Settings\nCan be left empty if the Password checkbox is not ticked in the OBS Websocket Settings");

            TTExplanation.SetToolTip(lblShinyChance, "Shiny Chance in %");
            TTExplanation.SetToolTip(lblUseGIFs, "Use GIFs instead of the PNGS files.\nUnfortunately not available for all Pokemon\nyet (around 100 GIFs missing).\nIf GIF is not found, automatic\nfallback to the PNG.");

            TTExplanation.SetToolTip(lblSpawnTimer, "Time until a new pokemon spawns in seconds (300 = 5min)");
            TTExplanation.SetToolTip(lblRandomSpawn, "Turn on to make pokemons spawn with\na certain chance every x-min");
            TTExplanation.SetToolTip(lblSpawnChance, "Chance of the pokemon appearing every x-min");
            TTExplanation.SetToolTip(lblSpawnSound, "This lets you enable the Spawn sound");
            TTExplanation.SetToolTip(lblUseLoadingScreen, "This lets you enable the Loading Screen\nNot recommended with LoadingAnimation activated");
            TTExplanation.SetToolTip(lblUseLoadingAnimation, "This lets you enable a Loading Screen Animation\nNot recommended with LoadingScreen activated");

            TTExplanation.SetToolTip(lblCatchRatePokeball, "The higher this value is, the harder the pokemons will be catched\n\nUsed to calculate the catch rates of the different balls\n\nHave fun reading this xD\n\ncatch_increase = Random Number between catch_min_increase and catch_max_increase\nPokeball Catchrate = (ceil(poke_catchrate / global.catch_pokeball) + catch_increase)\nGreatball Catchrate = Pokeball Catchrate + catch_greatball\nUltraball\nCatchrate = Pokeball Catchrate + catch_ultraball\n\nExample for Legendary:\ncatch_increase = 4\n(ceil(3 / 4) + 4) => 5% chance with Pokeball / 15% Greatball / 20% Ultraball\n\nExample for Normal Pokemon:\ncatch_increase = 2\n(ceil(45 / 4) + 2) => 14% chance with Pokeball / 24% Greatball / 29% Ultraball\n\nExample for Common Pokemon:\ncatch_increase = 3\n(ceil(255 / 4) + 2) => 66% chance with Pokeball / 76% Greatball / 81% Ultraball");
            TTExplanation.SetToolTip(lblCatchRateGreatball, "The higher this value is, the easier the pokemons will be catched with a greatball\n\nUsed to calculate the catch rates of the different balls\n\nHave fun reading this xD\n\ncatch_increase = Random Number between catch_min_increase and catch_max_increase\nPokeball Catchrate = (ceil(poke_catchrate / global.catch_pokeball) + catch_increase)\nGreatball Catchrate = Pokeball Catchrate + catch_greatball\nUltraball\nCatchrate = Pokeball Catchrate + catch_ultraball\n\nExample for Legendary:\ncatch_increase = 4\n(ceil(3 / 4) + 4) => 5% chance with Pokeball / 15% Greatball / 20% Ultraball\n\nExample for Normal Pokemon:\ncatch_increase = 2\n(ceil(45 / 4) + 2) => 14% chance with Pokeball / 24% Greatball / 29% Ultraball\n\nExample for Common Pokemon:\ncatch_increase = 3\n(ceil(255 / 4) + 2) => 66% chance with Pokeball / 76% Greatball / 81% Ultraball");
            TTExplanation.SetToolTip(lblCatchRateUltraball, "The higher this value is, the harder the pokemons will be catched with an ultraball\n\nUsed to calculate the catch rates of the different balls\n\nHave fun reading this xD\n\ncatch_increase = Random Number between catch_min_increase and catch_max_increase\nPokeball Catchrate = (ceil(poke_catchrate / global.catch_pokeball) + catch_increase)\nGreatball Catchrate = Pokeball Catchrate + catch_greatball\nUltraball\nCatchrate = Pokeball Catchrate + catch_ultraball\n\nExample for Legendary:\ncatch_increase = 4\n(ceil(3 / 4) + 4) => 5% chance with Pokeball / 15% Greatball / 20% Ultraball\n\nExample for Normal Pokemon:\ncatch_increase = 2\n(ceil(45 / 4) + 2) => 14% chance with Pokeball / 24% Greatball / 29% Ultraball\n\nExample for Common Pokemon:\ncatch_increase = 3\n(ceil(255 / 4) + 2) => 66% chance with Pokeball / 76% Greatball / 81% Ultraball");
            TTExplanation.SetToolTip(lblCatchIncMin, "Used to calculate the catch rates of the different balls\n\nHave fun reading this xD\n\ncatch_increase = Random Number between catch_min_increase and catch_max_increase\nPokeball Catchrate = (ceil(poke_catchrate / global.catch_pokeball) + catch_increase)\nGreatball Catchrate = Pokeball Catchrate + catch_greatball\nUltraball\nCatchrate = Pokeball Catchrate + catch_ultraball\n\nExample for Legendary:\ncatch_increase = 4\n(ceil(3 / 4) + 4) => 5% chance with Pokeball / 15% Greatball / 20% Ultraball\n\nExample for Normal Pokemon:\ncatch_increase = 2\n(ceil(45 / 4) + 2) => 14% chance with Pokeball / 24% Greatball / 29% Ultraball\n\nExample for Common Pokemon:\ncatch_increase = 3\n(ceil(255 / 4) + 2) => 66% chance with Pokeball / 76% Greatball / 81% Ultraball");
            TTExplanation.SetToolTip(lblCatchIncMax, "Used to calculate the catch rates of the different balls\n\nHave fun reading this xD\n\ncatch_increase = Random Number between catch_min_increase and catch_max_increase\nPokeball Catchrate = (ceil(poke_catchrate / global.catch_pokeball) + catch_increase)\nGreatball Catchrate = Pokeball Catchrate + catch_greatball\nUltraball\nCatchrate = Pokeball Catchrate + catch_ultraball\n\nExample for Legendary:\ncatch_increase = 4\n(ceil(3 / 4) + 4) => 5% chance with Pokeball / 15% Greatball / 20% Ultraball\n\nExample for Normal Pokemon:\ncatch_increase = 2\n(ceil(45 / 4) + 2) => 14% chance with Pokeball / 24% Greatball / 29% Ultraball\n\nExample for Common Pokemon:\ncatch_increase = 3\n(ceil(255 / 4) + 2) => 66% chance with Pokeball / 76% Greatball / 81% Ultraball");

            TTExplanation.SetToolTip(lblUseBonusTime, "Enables the bonus time feature. This feature is triggered by\n!bonustime, hosts and raids and increases the spawn-, shiny- and catchrate for X min");
            TTExplanation.SetToolTip(lblBonusMinUsers, "Minimum amount of users to trigger the bonus time");
            TTExplanation.SetToolTip(lblBonusTime, "This sets the value of how long the bonus time will last in s (300 = 5min)");
            TTExplanation.SetToolTip(lblBonusSpawnTimer, "Time in seconds on how fast pokemons will spawn in bonus time");

            TTExplanation.SetToolTip(lblRunMin, "Pokemon starts with 0% escape rate. \nEverytime it breaks out, this is the minimum rate it can increase");
            TTExplanation.SetToolTip(lblRunMax, "Pokemon starts with 0% escape rate. \nEverytime it breaks out, this is the maximum rate it can increase");
            TTExplanation.SetToolTip(lblRunTimer, "Time until the current pokemon runs away when no \none throws a ball in miliseconds (180000 = 3min). Throws reset this timer");

            TTExplanation.SetToolTip(lblDiscord, "Enables the discord extension");
            TTExplanation.SetToolTip(lblUseSeparateWebhook, "Enable this if you want to use 2 webhooks to post into 2 different channels.\nOne for the catches, the other one for the !mypokemon command");
            TTExplanation.SetToolTip(lblWebhookURL, "Webhook URL for the Discord Webhook (Serversettings => Integration => Webhooks)");
            TTExplanation.SetToolTip(lblMYPWebhook, "Used as separate Webhook URL for the !mypokemon command");

            TTExplanation.SetToolTip(lblUseBreakout, "Shows when a pokemon breaks out in the chat. \nFor example: Oh no the wild Mew broke out");
            TTExplanation.SetToolTip(lblRefundMessage, "Shows when points are refunded at the end of the queue.");
            TTExplanation.SetToolTip(lblUseRunMessage, "Shows a message in Chat when the Pokemon runs away");

            TTExplanation.SetToolTip(lblLoadingScreen, "This lets you change the Loadingscreen");
            TTExplanation.SetToolTip(lblShinyWallpaper, "This lets you change the Shiny Wallpaper");
            TTExplanation.SetToolTip(lblLoadingSound, "This lets you change the Spawn Music");

            TTExplanation.SetToolTip(lblPokeball, "This lets you edit the Pokeball Channel Point Reward");
            TTExplanation.SetToolTip(lblGreatball, "This lets you edit the Greatball Channel Point Reward");
            TTExplanation.SetToolTip(lblUltraball, "This lets you edit the Ultraball Channel Point Reward");
            TTExplanation.SetToolTip(lblMasterball, "This lets you edit the Masterball Channel Point Reward");
            TTExplanation.SetToolTip(lblMysteryPokemon, "This lets you edit the Mystery Pokemon Channel Point Reward");
            TTExplanation.SetToolTip(lblMysteryShiny, "This lets you edit the Mystery Shiny Channel Point Reward");
            TTExplanation.SetToolTip(lblSummon, "This lets you edit the Summon Pokemon Channel Point Reward");
            TTExplanation.SetToolTip(lblGift, "This lets you edit the Give a Gift Channel Point Reward");

            TTExplanation.SetToolTip(lblGen1, "Adds the Pokemons from the Kanto \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen2, "Adds the Pokemons from the Johto \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen3, "Adds the Pokemons from the Hoenn \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen4, "Adds the Pokemons from the Sinnoh\nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen5, "Adds the Pokemons from the Einall\nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen6, "Adds the Pokemons from the Kalos \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen7, "Adds the Pokemons from the Alola \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblGen8, "Adds the Pokemons from the Galar \nregion to the available Pokemons");
            TTExplanation.SetToolTip(lblRegional, "Adds the regional forms of \nPokemons to the available Pokemons");
            TTExplanation.SetToolTip(lblCustom, "Adds custom created Pokemons \nto the available Pokemons\nwill need the \"Custom Pokemon\" Add On to work");

            TTExplanation.SetToolTip(lblAnimatedTrainers, "Trainers will be animated instead of\nbeeing static if they have an available GIF");
            TTExplanation.SetToolTip(lblBroadcaster, "Please enter your streamer name");
            TTExplanation.SetToolTip(lblAnnounce, "Announces in Chat when a legendary or \nmythical Pokemon has spawned");

        }
        private void LoadValues()
        {
            txtLB2.Text = Properties.Settings.Default.LB2;
            cbLanguage.SelectedIndex = Properties.Settings.Default.Language;
            cbAffiliate.SelectedIndex = Properties.Settings.Default.NonAffiliate;
            cbLeaderboard.SelectedIndex = Properties.Settings.Default.Leaderboard;
            txtAudioTreshhold.Text = Properties.Settings.Default.AudioTreshhold;
            txtOBSWSPort.Text = Properties.Settings.Default.OBSWSPort;
            txtOBSWSPW.Text = Properties.Settings.Default.OBSWSPW;

            txtShinyChance.Text = Properties.Settings.Default.ShinyChance;
            cbUseGIFS.SelectedIndex = Properties.Settings.Default.Gifs;

            txtSpawnTimer.Text = Properties.Settings.Default.SpawnTimer;
            cbRandomSpawn.SelectedIndex = Properties.Settings.Default.UseSpawnChance;
            txtSpawnChance.Text = Properties.Settings.Default.SpawnChance;
            cbSpawnSound.SelectedIndex = Properties.Settings.Default.SpawnMusic;
            cbUseLoadingScreen.SelectedIndex = Properties.Settings.Default.LoadingScreen;
            cbLoadingAnimation.SelectedIndex = Properties.Settings.Default.LoadingAnimation;

            txtCatchRatePokeball.Text = Properties.Settings.Default.CatchValuePokeball;
            txtCatchRateGreatball.Text = Properties.Settings.Default.CatchValueGreatball;
            txtCatchRateUltraball.Text = Properties.Settings.Default.CatchValueUltraball;
            txtCatchIncMin.Text = Properties.Settings.Default.CatchMinIncrease;
            txtCatchIncMax.Text = Properties.Settings.Default.CatchMaxIncrease;

            cbUseBonusTime.SelectedIndex = Properties.Settings.Default.UseBonustime;
            txtBonusTime.Text = Properties.Settings.Default.BonusTimeDuration;
            txtBonusMinUsers.Text = Properties.Settings.Default.BonusTimeMinUsers;
            txtBonusSpawnTimer.Text = Properties.Settings.Default.BonusTimeSpawnTimer;

            txtRunMin.Text = Properties.Settings.Default.RunAwayMinIncrease;
            txtRunMax.Text = Properties.Settings.Default.RunAwayMaxIncrease;
            txtRunTimer.Text = Properties.Settings.Default.RunTimer;

            cbUseDiscord.SelectedIndex = Properties.Settings.Default.UseDiscord;
            cbUseSeparateWebhook.SelectedIndex = Properties.Settings.Default.UseSepareteWebhook;
            txtWebhookURL.Text = Properties.Settings.Default.WebhookURLCatch;
            txtMyPokemonWebhook.Text = Properties.Settings.Default.WebhookURLMYP;

            cbUseBreakout.SelectedIndex = Properties.Settings.Default.UseBreakoutMessage;
            cbRefundMessage.SelectedIndex = Properties.Settings.Default.UseRefundMessage;
            cbUseRunMessage.SelectedIndex = Properties.Settings.Default.UseRunMessage;

            txtLoadingSound.Text = Properties.Settings.Default.LoadingSoundPath;
            sShinyScreenPath = Properties.Settings.Default.ShinyScreenPath;
            sLoadingScreenPath = Properties.Settings.Default.LoadingScreenPath;

            txtPokeball.Text = Properties.Settings.Default.NamePokeball;
            txtPricePokeball.Text = Properties.Settings.Default.PricePokeball;

            txtGreatball.Text = Properties.Settings.Default.NameGreatball;
            cbGreatball.SelectedIndex = Properties.Settings.Default.UseGreatball;
            txtPriceGreatball.Text = Properties.Settings.Default.PriceGreatball;

            txtUltraball.Text = Properties.Settings.Default.NameUltraball;
            cbUltraball.SelectedIndex = Properties.Settings.Default.UseUltraball;
            txtPriceUltraball.Text = Properties.Settings.Default.PriceUltraball;

            txtMasterball.Text = Properties.Settings.Default.NameMasterball;
            cbMasterball.SelectedIndex = Properties.Settings.Default.UseMasterball;
            txtPriceMasterball.Text = Properties.Settings.Default.PriceMasterball;

            txtMysteryPokemon.Text = Properties.Settings.Default.NameMysteryPokemon;
            cbMysteryPokemon.SelectedIndex = Properties.Settings.Default.UseMysteryPokemon;
            txtPriceMysteryPokemon.Text = Properties.Settings.Default.PriceMysteryPokemon;

            txtMysteryShiny.Text = Properties.Settings.Default.NameMysteryShiny;
            cbMysteryShiny.SelectedIndex = Properties.Settings.Default.UseMysteryShiny;
            txtPriceMysteryShiny.Text = Properties.Settings.Default.PriceMysteryShiny;

            txtSummon.Text = Properties.Settings.Default.NameSummon;
            cbSummon.SelectedIndex = Properties.Settings.Default.UseSummon;
            txtPriceSummon.Text = Properties.Settings.Default.PriceSummon;

            txtGift.Text = Properties.Settings.Default.NameGift;
            cbGift.SelectedIndex = Properties.Settings.Default.UseGift;
            txtPriceGift.Text = Properties.Settings.Default.PriceGift;

            cbGen1.SelectedIndex = Properties.Settings.Default.UseGen1;
            cbGen2.SelectedIndex = Properties.Settings.Default.UseGen2;
            cbGen3.SelectedIndex = Properties.Settings.Default.UseGen3;
            cbGen4.SelectedIndex = Properties.Settings.Default.UseGen4;
            cbGen5.SelectedIndex = Properties.Settings.Default.UseGen5;
            cbGen6.SelectedIndex = Properties.Settings.Default.UseGen6;
            cbGen7.SelectedIndex = Properties.Settings.Default.UseGen7;
            cbGen8.SelectedIndex = Properties.Settings.Default.UseGen8;
            cbRegional.SelectedIndex = Properties.Settings.Default.UseRegionals;
            cbCustom.SelectedIndex = Properties.Settings.Default.UseCustomPokemon;

            cbAnimatedTrainers.SelectedIndex = Properties.Settings.Default.UseAnimatedTrainers;
            cbAnnounce.SelectedIndex = Properties.Settings.Default.AnnounceRarePokemons;
            txtBroadcaster.Text = Properties.Settings.Default.BroadcasterName;
        }

        #endregion

        #region "ComboxBox"
        private void cbUseSeparateWebhook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUseSeparateWebhook.SelectedIndex == 0)
            {
                lblMYPWebhook.Visible = true;
                txtMyPokemonWebhook.Visible = true;
            }
            else
            {
                lblMYPWebhook.Visible = false;
                txtMyPokemonWebhook.Visible = false;
            }
        }
        private void cbUseDiscord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUseDiscord.SelectedIndex == 0)
            {
                txtWebhookURL.Visible = true;              
                lblWebhookURL.Visible = true;

                lblUseSeparateWebhook.Visible = true;
                cbUseSeparateWebhook.Visible = true;

                if (cbUseSeparateWebhook.SelectedIndex == 0)
                {
                    lblMYPWebhook.Visible = true;
                    txtMyPokemonWebhook.Visible = true;
                }
                else
                {
                    lblMYPWebhook.Visible = false;
                    txtMyPokemonWebhook.Visible = false;
                }
            }
            else
            {
                txtWebhookURL.Visible = false;
                lblWebhookURL.Visible = false;

                lblUseSeparateWebhook.Visible = false;
                cbUseSeparateWebhook.Visible = false;

                lblMYPWebhook.Visible = false;
                txtMyPokemonWebhook.Visible = false;
            }
        }
        private void cbRandomSpawn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRandomSpawn.SelectedIndex == 0)
            {
                lblSpawnChance.Visible = true;
                txtSpawnChance.Visible = true;
            }
            else
            {
                lblSpawnChance.Visible = false;
                txtSpawnChance.Visible = false;
            }
        }

        #endregion

        #region "Other Buttons"
        private void btnMigrate_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Please use this function only when you are switching from LB1 to LB2 for the first time, if not please don't use this. Do you want to continue?", "Migrate from LB1?", MessageBoxButtons.YesNo)) return;

            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Select your Pokemon_trainers.ini in the LB1 folder";
            f.Filter = "File|Pokemon_trainers.ini";

            if (f.ShowDialog() == DialogResult.OK)
            {
                File.Copy(f.FileName, f.FileName + ".backup" + DateTime.Now.ToString("yyyyMMdd"), true);
                using (StreamWriter sw = new StreamWriter("temp", false))
                {
                    List<string> lsUsernames = new List<string>();

                    using (StreamReader sr = new StreamReader(f.FileName))
                    {
                        string[] sUserblocks = sr.ReadToEnd().Split('[');
                        List<PokeTrainer> lsTrainers = new List<PokeTrainer>();
                        foreach (string s in sUserblocks)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                string sUsername = s.Split(']')[0];

                                if (sUsername != "current_number" && sUsername != "trainer_names_numbers" && !string.IsNullOrEmpty(sUsername))
                                {
                                    lsUsernames.Add(sUsername);
                                    int iPokedex = 0;
                                    int iShinys = 0;
                                    List<Line> lsNormalLines = new List<Line>();
                                    List<Line> lsShinyLines = new List<Line>();
                                    string[] saLines = s.Split(']')[1].Split('\n');
                                    foreach (string sLine in saLines)
                                    {
                                        if (!sLine.ToLowerInvariant().Contains("shinys") && !sLine.ToLowerInvariant().Contains("pokedex") && !sLine.ToLowerInvariant().Contains("]") && !string.IsNullOrEmpty((sLine)))
                                        {
                                            if (sLine.ToLowerInvariant().Contains("s"))
                                            {
                                                Line l = new Line((sLine));
                                                lsShinyLines.Add(l);
                                                iShinys++;
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    int i = Convert.ToInt32(sLine.Split('=')[0]);
                                                    Line l = new Line(sLine);
                                                    lsNormalLines.Add(l);
                                                    iPokedex++;
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    lsNormalLines = lsNormalLines.OrderBy(i => i.iNumber).ToList();
                                    lsShinyLines = lsShinyLines.OrderBy(i => i.iNumber).ToList();
                                    sw.WriteLine("[" + sUsername + "]");
                                    sw.WriteLine("pokedex=\"" + iPokedex.ToString() + ".000000\"");
                                    sw.WriteLine("shinys=\"" + iShinys.ToString() + ".000000\"");
                                    for (int i = 0; i < lsNormalLines.Count; i++)
                                    {
                                        sw.WriteLine(lsNormalLines[i].sLine);
                                    }
                                    for (int i = 0; i < lsShinyLines.Count; i++)
                                    {
                                        string sLine = lsShinyLines[i].sLine;
                                        if (sLine[0] == '"') sLine = sLine.Remove(0, 1).Replace("\"=", "=");
                                        sw.WriteLine(sLine);
                                    }
                                }
                            }
                        }
                        sr.Close();
                    }

                    sw.WriteLine("[current_number]");
                    sw.WriteLine("amount=\"" + lsUsernames.Count + ".000000\"");
                    sw.WriteLine("[trainer_names_numbers]");
                    for (int i = 0; i < lsUsernames.Count; i++)
                    {
                        sw.WriteLine(i.ToString() + "=\"" + lsUsernames[i] + "\"");
                    }

                    sw.Flush();
                    sw.Close();
                }
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Please your LB2 folder.\nThe LB2 folder should contain the Lioranboard 2.0.exe.";

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(fb.SelectedPath + "\\transmitter") || !File.Exists(fb.SelectedPath + "\\LioranBoard 2.0.exe"))
                    {
                        MessageBox.Show("Migration failed.\nUnfortunately this is not the LB2 folder.\nThe LB2 folder contains a transmitter folder and the Lioranboard 2.0.exe.\nPlease try again and select the correct folder.");
                        return;
                    }
                    if (!Directory.Exists(fb.SelectedPath + "\\Pokemon and Friends")) Directory.CreateDirectory(fb.SelectedPath + "\\Pokemon and Friends");
                    File.Copy("temp", fb.SelectedPath + "\\Pokemon and Friends\\Pokemon_trainers.ini", true);
                    File.Delete("temp");

                    string sPathLB1 = f.FileName.ToLowerInvariant().Replace("pokemon_trainers.ini", "trainer_images.ini");
                    if (File.Exists(sPathLB1)) File.Copy(sPathLB1, fb.SelectedPath + "\\Pokemon and Friends\\trainer_images.ini", true);
                }

                MessageBox.Show("Pokemon_trainers.ini has been ported over to LB2!");
            }
        }
        private void btnSupport_Click(object sender, EventArgs e)
        {
            frmChrizzz frm = new frmChrizzz();
            frm.Show();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("Pokemon and Friends Mod V1.0.pdf");
            if (DialogResult.Yes == MessageBox.Show("Need more help? Feel free to join my discord! Wanna join now?", "Help", MessageBoxButtons.YesNo))
            {
                Process.Start("https://discord.gg/A3VF9kW");
            }
        }
        private void btnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Mod was developed by chrizzz_1508.\n\nSpecial thanks to:\nWaldoAndFriends - Developing the Base Version\nTempest - Beta Testing\nKefiren - Beta Testing\nMurtherX - Beta Testing\nPox4eveR - Beta Testing");
        }

        #endregion

        #region "Select Stuff"

        private void btnLoadingSound_Click(object sender, EventArgs e)
        {
            frmSelectLoadingSound frm = new frmSelectLoadingSound();
            frm.txt = txtLoadingSound;
            frm.ShowDialog();
        }
        private void LoadSources()
        {
            sLoadingScreenPath = Properties.Settings.Default.LoadingScreenPath;
            if (File.Exists(sLoadingScreenPath))
            {
                pbLoadingScreen.Image = Image.FromFile(sLoadingScreenPath);
            }

            sShinyScreenPath = Properties.Settings.Default.ShinyScreenPath;
            if (File.Exists(sShinyScreenPath))
            {
                pbShinyScreen.Image = Image.FromFile(sShinyScreenPath);
            }
            txtLoadingSound.Text = Properties.Settings.Default.LoadingSoundPath;
        }
        private void btnSelectLoadingScreen_Click(object sender, EventArgs e)
        {
            frmSelectLoadingScreen frm = new frmSelectLoadingScreen();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                sLoadingScreenPath = frm._txt;
                string sFileOutput = sLoadingScreenPath.Split('\\')[sLoadingScreenPath.Split('\\').Length - 1];
                if (!File.Exists(@"files\loadingscreens\" + sFileOutput))
                {
                    File.Copy(sLoadingScreenPath, @"files\loadingscreens\" + sFileOutput, true);
                }
                pbLoadingScreen.Image = Image.FromFile(@"files\loadingscreens\" + sFileOutput);
            }
        }
        private void btnSelectShinyScreen_Click(object sender, EventArgs e)
        {
            frmSelectShiny frm = new frmSelectShiny();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                sShinyScreenPath = frm._txt;
                string sFileOutput = sShinyScreenPath.Split('\\')[sShinyScreenPath.Split('\\').Length - 1];
                if (!File.Exists(@"files\shinybackgrounds\" + sFileOutput))
                {
                    File.Copy(sShinyScreenPath, @"files\shinybackgrounds\" + sFileOutput, true);
                }
                pbShinyScreen.Image = Image.FromFile(@"files\shinybackgrounds\" + sFileOutput);
            }
        }
        private void TestSound(object sender, EventArgs e)
        {
            Mp3Player.Stop();
            if (File.Exists(@"files\loadingsounds\" + txtLoadingSound.Text))
            {
                Mp3Player.Play(@"files\loadingsounds\" + txtLoadingSound.Text, false);
            }
        }
        #endregion

        private void btnPokemonSettings_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnChannelPointSettings_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void btnGermanGuide_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=Wue5iiK9eMQ&t"); 
        }

        private void btnEnglishGuide_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=YA-5pqSsbK4");
        }

        private void btnSetItUpForMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you want, I can also do the complete Setup for you, for a small donation / tip.\n\nJust dm me on Discord (Chrizzz#0810) if you are interessted in this service.");
        }
    }

    public class PokeTrainer
    {
        public string sName;
        public int iDex;
        public int iShinys;

        public PokeTrainer(string sName, int iDex, int iShinys)
        {
            this.sName = sName;
            this.iDex = iDex;
            this.iShinys = iShinys;
        }
    }
    public class Line
    {
        public string sLine;
        public int iNumber;

        public Line(string sLine)
        {
            this.sLine = sLine.TrimEnd(new char[] { '\r', '\n' });
            try
            {
                this.iNumber = Convert.ToInt32(sLine.Replace("S", "").Replace("\"", "").Replace("=1.000000", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(sLine + "\n" + ex.ToString());
            }
        }
    }

}

