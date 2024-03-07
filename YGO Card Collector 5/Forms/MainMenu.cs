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
            RadioBinderOption.MouseEnter += OnMouseEnterRadio;
                    
            SoundServer.PlayBackgroundMusic(Song.MainMenu);

            //Load Form theme
            Tools.InitalizeThemeOnForm(this);           
        }
        #endregion

        #region Public Methods
        public void ReturnToForm()
        {
            Tools.InitalizeThemeOnForm(this);
            SoundServer.PlayBackgroundMusic(Song.MainMenu);
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
            else if (RadioBinderOption.Checked)
            {
                CollectorBinderMode BM = new CollectorBinderMode(this);
                BM.Show();
            }
        }
        private void lblDatabaseUpdateOption_Click(object sender, EventArgs e)
        {
            //if the APP is NOT Running on the Full DB Mode, disable the DB Submenus
            if (SettingsData.FULLDBMode)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);

                //Open Database Manager
                Hide();
                DBUpdateTool DM = new DBUpdateTool(this);
                DM.Show();
            }
            else
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                lblDBRestrict.Visible = true;
                Tools.WaitNSeconds(2000);
                lblDBRestrict.Visible = false;
            }
            
        }
        private void lblDatabaseOption_Click(object sender, EventArgs e)
        {
            if (SettingsData.FULLDBMode)
            {
                SoundServer.PlaySoundEffect(SoundEffect.Click);

                //Open Database Manager
                Hide();
                DatabaseManager DM = new DatabaseManager(this);
                DM.Show();
            }
            else
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                lblDBRestrict.Visible = true;
                Tools.WaitNSeconds(2000);
                lblDBRestrict.Visible = false;
            }
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
        private void RadioBinderOption_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
        }
        #endregion    
    }
}
