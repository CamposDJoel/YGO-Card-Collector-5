using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(FormLauncher mainmenuform)
        {
            SoundServer.PlayBackgroundMusic(Song.MainMenu, true);
            InitializeComponent();
            _Mainmenuform = mainmenuform;
            ReloadSettings();
        }

        private FormLauncher _Mainmenuform;

        private void ReloadSettings()
        {
            RadioPackSortingOLD.Checked = SettingsData.SetPackListSortingOLDToNEW;
            RadioPackSortingNEW.Checked = !SettingsData.SetPackListSortingOLDToNEW;
            RadioTestModeON.Checked = SettingsData.DBUpdateTestMode;
            RadioTestModeOFF.Checked = !SettingsData.DBUpdateTestMode;
            RadioHeadlessON.Checked = SettingsData.AutomationHeadless;
            RadioHeadlessOFF.Checked = !SettingsData.AutomationHeadless;

            AppTheme _CurrentTHeme = SettingsData.CurrentTheme;
            switch(SettingsData.CurrentTheme) 
            {
                case AppTheme.DarkMagician: RadioThemeDM.Checked = true; break;
                case AppTheme.DarkMagicianGirl: RadioThemeDMG.Checked = true; break;
                case AppTheme.Traptrix: RadioThemeTraptrix.Checked = true; break;
                case AppTheme.BlueEyesUltimate: RadioThemeBlueEyesUltimate.Checked = true; break;
            }

            
        }

        private void RadioPackSortingOLD_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioPackSortingOLD.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchSetListSortingSetting(true);
            }            
        }
        private void RadioPackSortingNEW_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPackSortingNEW.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchSetListSortingSetting(false);
            }
        }
        private void RadioTestModeON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioTestModeON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchDBUpdateTestModeSetting(true);
            }           
        }
        private void RadioTestModeOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioTestModeOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchDBUpdateTestModeSetting(false);
            }
        }
        private void RadioHeadlessON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioHeadlessON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchHeadlessModeSetting(true);
            }
        }
        private void RadioHeadlessOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHeadlessOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchHeadlessModeSetting(false);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Dispose();
            _Mainmenuform.Show();
        }
        private void RadioThemeDM_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioThemeDM.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchCurrentThemeSetting(0);
                _Mainmenuform.ReloadTheme();
            }
        }
        private void RadioThemeDMG_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeDMG.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchCurrentThemeSetting(1);
                _Mainmenuform.ReloadTheme();
            }
        }
        private void RadioThemeTraptrix_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeTraptrix.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchCurrentThemeSetting(2);
                _Mainmenuform.ReloadTheme();
            }
        }
        private void RadioThemeBlueEyesUltimate_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeBlueEyesUltimate.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);
                SettingsData.SwitchCurrentThemeSetting(3);
                _Mainmenuform.ReloadTheme();
            }
        }
    }
}