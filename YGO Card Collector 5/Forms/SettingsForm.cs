//Joel Campos
//2/19/2024
//Settings Form Class

using System;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class SettingsForm : Form
    {
        #region Constructors
        public SettingsForm(FormLauncher mainmenuform)
        {
            SoundServer.PlayBackgroundMusic(Song.MainMenu, true);
            InitializeComponent();
            _Mainmenuform = mainmenuform;
            ReloadSettings();

            //Assign the event 
            RadioPackSortingOLD.MouseEnter += OnMouseEnterRadio;
            RadioPackSortingNEW.MouseEnter += OnMouseEnterRadio;
            RadioTestModeON.MouseEnter += OnMouseEnterRadio;
            RadioTestModeOFF.MouseEnter += OnMouseEnterRadio;
            RadioHeadlessON.MouseEnter += OnMouseEnterRadio;
            RadioHeadlessOFF.MouseEnter += OnMouseEnterRadio;
            RadioThemeDM.MouseEnter += OnMouseEnterRadio;
            RadioThemeDMG.MouseEnter += OnMouseEnterRadio;
            RadioThemeTraptrix.MouseEnter += OnMouseEnterRadio;
            RadioThemeBlueEyesUltimate.MouseEnter += OnMouseEnterRadio;
            RadioMusicON.MouseEnter += OnMouseEnterRadio;
            RadioMusicOFF.MouseEnter += OnMouseEnterRadio;
            RadioSFXON.MouseEnter += OnMouseEnterRadio;
            RadioSFXOFF.MouseEnter += OnMouseEnterRadio;
        }
        #endregion

        #region Internal Data
        private FormLauncher _Mainmenuform;
        #endregion

        #region Private Methods
        private void ReloadSettings()
        {
            RadioPackSortingOLD.Checked = SettingsData.SetPackListSortingOLDToNEW;
            RadioPackSortingNEW.Checked = !SettingsData.SetPackListSortingOLDToNEW;
            RadioTestModeON.Checked = SettingsData.DBUpdateTestMode;
            RadioTestModeOFF.Checked = !SettingsData.DBUpdateTestMode;
            RadioHeadlessON.Checked = SettingsData.AutomationHeadless;
            RadioHeadlessOFF.Checked = !SettingsData.AutomationHeadless;
            RadioMusicON.Checked = SettingsData.MusicOn;
            RadioMusicOFF.Checked = !SettingsData.MusicOn;
            RadioSFXON.Checked = SettingsData.SFXOn;
            RadioSFXOFF.Checked = !SettingsData.SFXOn;

            AppTheme _CurrentTHeme = SettingsData.CurrentTheme;
            switch(SettingsData.CurrentTheme) 
            {
                case AppTheme.DarkMagician: RadioThemeDM.Checked = true; break;
                case AppTheme.DarkMagicianGirl: RadioThemeDMG.Checked = true; break;
                case AppTheme.Traptrix: RadioThemeTraptrix.Checked = true; break;
                case AppTheme.BlueEyesUltimate: RadioThemeBlueEyesUltimate.Checked = true; break;
            }

            
        }
        #endregion

        #region Event Listeners
        private void RadioPackSortingOLD_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioPackSortingOLD.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchSetListSortingSetting(true);
            }            
        }
        private void RadioPackSortingNEW_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPackSortingNEW.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchSetListSortingSetting(false);
            }
        }
        private void RadioTestModeON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioTestModeON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchDBUpdateTestModeSetting(true);
            }           
        }
        private void RadioTestModeOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioTestModeOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchDBUpdateTestModeSetting(false);
            }
        }
        private void RadioHeadlessON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioHeadlessON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchHeadlessModeSetting(true);
            }
        }
        private void RadioHeadlessOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHeadlessOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
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
            _Mainmenuform.ReturnToForm();
        }
        private void RadioThemeDM_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioThemeDM.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchCurrentThemeSetting(0);
            }
        }
        private void RadioThemeDMG_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeDMG.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchCurrentThemeSetting(1);
            }
        }
        private void RadioThemeTraptrix_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeTraptrix.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchCurrentThemeSetting(2);
            }
        }
        private void RadioThemeBlueEyesUltimate_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioThemeBlueEyesUltimate.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchCurrentThemeSetting(3);
            }
        }
        private void OnMouseEnterRadio(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
        }
        private void RadioMusicON_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioTestModeON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchMusicSetting(true);
                SoundServer.PlayBackgroundMusic(Song.MainMenu, true);
            }
        }
        private void RadioMusicOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioTestModeOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchMusicSetting(false);
                SoundServer.StopBackgroundMusic();
            }
        }
        private void RadioSFXON_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSFXON.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchSFXSetting(true);
            }
        }
        private void RadioSFXOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSFXOFF.Checked)
            {
                SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
                SettingsData.SwitchSFXSetting(false);
            }
        }
        #endregion
    }
}