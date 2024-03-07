//Joel Campos
//3/7/2024
//Launcher Form Class

using System;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();

            //Load App Settings
            SettingsData.InitializeSettings();

            SoundServer.PlayBackgroundMusic(Song.TitleScreen);

            //Load Form theme
            Tools.InitalizeThemeOnForm(this);
        }

        private void LoadDB(string DBType)
        {
            bool Success = Database.LoadDB(DBType);
            if (Success)
            {
                SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                Tools.WaitNSeconds(1000);
                btnLoadDB.Visible = false;
                btnLoadDB2019.Visible = false;
                GroupDBSelection.Visible = false;
                //Open the main menu form
                Hide();
                FormLauncher MM = new FormLauncher();
                MM.Show();
            }
            else
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                btnLoadDB.Visible = true;
                btnLoadDB2019.Visible = true;
                GroupDBSelection.Visible = true;
                lblJsonStatus.Visible = true;                              
            }
        }
        private void btnLoadDB_Click(object sender, EventArgs e)
        {           
            if(radioFULL.Checked)
            {
                SettingsData.FULLDBMode = true;
                LoadDB("FULL");
            }
            else
            {
                SettingsData.FULLDBMode = false;
                string year = listYearSelection.Text;
                LoadDB(year);
            }
        }
        private void btnLoadDB2019_Click(object sender, EventArgs e)
        {
            SettingsData.FULLDBMode = false;
            LoadDB("2019Custom");
        }
        private void radioFULL_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
        }
        private void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
            listYearSelection.SetSelected(0, true);
        }
    }
}