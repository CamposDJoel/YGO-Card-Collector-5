//Joel Campos
//1/27/2024
//Launcher Form Class

using System;
using System.Drawing;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class FormLauncher : Form
    {
        public FormLauncher()
        {
            SoundServer.PlayBackgroundMusic(Song.TitleScreen, true);

            InitializeComponent();

            lblLaunchAppOption.MouseEnter += OnMouseEnterLabel;
            lblLaunchAppOption.MouseLeave += OnMouseLeaveLabel;

            lblSettingsOption.MouseEnter += OnMouseEnterLabel;
            lblSettingsOption.MouseLeave += OnMouseLeaveLabel;

            lblDatabaseOption.MouseEnter += OnMouseEnterLabel;
            lblDatabaseOption.MouseLeave += OnMouseLeaveLabel;

            //Load App Settings
            SettingsData.InitializeSettings();

            //Load Form theme
            Tools.InitalizeThemeOnForm(this);
        }

        public void ReloadTheme()
        {
            Tools.InitalizeThemeOnForm(this);
        }

        private void LoadDB()
        {
            //Hide the menu options
            lblLaunchAppOption.Visible = false;
            lblSettingsOption.Visible = false;
            lblDatabaseOption.Visible = false;
            lblJsonStatus.Visible = false;

            bool Success = Database.LoadDB();
            if(!Success) 
            {
                lblJsonStatus.Visible = true;
                lblLaunchAppOption.Visible = true;
                lblSettingsOption.Visible = true;
                lblDatabaseOption.Visible = true;
            }
        }

        private void OnMouseEnterLabel(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label thisLabel = (Label)sender;
            thisLabel.BackColor = Color.Black;
        }
        private void OnMouseLeaveLabel(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            thisLabel.BackColor = Color.Transparent;
        }
        private void lblLaunchAppOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            LoadDB();

            //Open Collection tracker
            Hide();
            lblLaunchAppOption.Visible = true;
            lblSettingsOption.Visible = true;
            lblDatabaseOption.Visible = true;

            //Open the collector
            if(RadioDefaultOption.Checked)
            {
                Collector Co = new Collector(this);
                Co.Show();
            }
            else if(RadioBigWinOption.Checked)
            {
                CollectorBigWinMode Co = new CollectorBigWinMode(this);
                Co.Show();
            }
        }
        private void lblDatabaseOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            LoadDB();

            //Open Database Manager
            Hide();
            DatabaseManager DM = new DatabaseManager(this);
            DM.Show();

            //Hide the menu options
            lblLaunchAppOption.Visible = true;
            lblSettingsOption.Visible = true;
            lblDatabaseOption.Visible = true;
        }
        private void lblSettingsOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Hide();
            SettingsForm SF = new SettingsForm(this);
            SF.Show();
        }
        private void RadioDefaultOption_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
        }
        private void RadioBigWinOption_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
        }
    }
}
