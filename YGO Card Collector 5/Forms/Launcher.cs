//Joel Campos
//1/27/2024
//Launcher Form Class

using System;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class FormLauncher : Form
    {
        public FormLauncher()
        {
            InitializeComponent();

            lblLaunchAppOption.MouseEnter += OnMouseEnterLabel;
            lblLaunchAppOption.MouseLeave += OnMouseLeaveLabel;

            lblSettingsOption.MouseEnter += OnMouseEnterLabel;
            lblSettingsOption.MouseLeave += OnMouseLeaveLabel;

            lblDatabaseOption.MouseEnter += OnMouseEnterLabel;
            lblDatabaseOption.MouseLeave += OnMouseLeaveLabel;
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
            //SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label thisLabel = (Label)sender;
            thisLabel.BorderStyle = BorderStyle.FixedSingle;
        }
        private void OnMouseLeaveLabel(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            thisLabel.BorderStyle = BorderStyle.None;
        }
        private void lblLaunchAppOption_Click(object sender, EventArgs e)
        {
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
            else if(RadioCompactOption.Checked)
            {
                //TODO
            }
        }
        private void lblDatabaseOption_Click(object sender, EventArgs e)
        {
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
            Hide();
            SettingsForm SF = new SettingsForm(this);
            SF.Show();
        }
    }
}
