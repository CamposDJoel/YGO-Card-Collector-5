//Joel Campos
//1/27/2024
//Launcher Form Class

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class FormLauncher : Form
    {
        #region Constructors
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
            lblDatabaseUpdateOption.MouseEnter += OnMouseEnterLabel;
            lblDatabaseUpdateOption.MouseLeave += OnMouseLeaveLabel;

            RadioBigWinOption.MouseEnter += OnMouseEnterRadio;
            RadioDefaultOption.MouseEnter += OnMouseEnterRadio;


            //Load App Settings
            SettingsData.InitializeSettings();

            //Load Form theme
            Tools.InitalizeThemeOnForm(this);
        }
        #endregion

        #region Public Methods
        public void ReturnToForm()
        {
            Tools.InitalizeThemeOnForm(this);
            SoundServer.PlayBackgroundMusic(Song.TitleScreen, true);
            Show();
        }
        #endregion

        #region Event Listeners
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
        private void OnMouseEnterRadio(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
        }
        private void lblLaunchAppOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

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
        private void lblDatabaseUpdateOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            //Open Database Manager
            Hide();
            DBUpdateTool DM = new DBUpdateTool(this);
            DM.Show();

            //show the menu options
            lblLaunchAppOption.Visible = true;
            lblSettingsOption.Visible = true;
            lblDatabaseUpdateOption.Visible = true;
            lblDatabaseOption.Visible = true;
        }
        private void lblDatabaseOption_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

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
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
        }
        private void RadioBigWinOption_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
        }
        #endregion

        #region Load DB Event Listeners
        private void LoadDB(string DBType)
        {
            btnLoadDB.Enabled = false;
            btnLoadDB2019.Enabled = false;
            bool Success = Database.LoadDB(DBType);
            if (Success)
            {
                SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                Tools.WaitNSeconds(1000);
                btnLoadDB.Visible = false;
                btnLoadDB2019.Visible = false;
                lblLaunchAppOption.Visible = true;
                lblSettingsOption.Visible = true;
                lblDatabaseUpdateOption.Visible = true;
                lblDatabaseOption.Visible = true;
                GroupWinMode.Visible = true;
            }
            else
            {
                btnLoadDB.Enabled = true;
                btnLoadDB2019.Enabled = true;
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                lblJsonStatus.Visible = true;
            }
        }
        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            LoadDB("Master");
        }
        private void btnLoadDB2019_Click(object sender, EventArgs e)
        {
            LoadDB("2019");
        }
        #endregion
    }
}
