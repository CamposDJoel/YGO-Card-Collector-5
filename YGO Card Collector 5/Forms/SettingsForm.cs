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
        }

        private void RadioPackSortingOLD_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioPackSortingOLD.Checked)
            {
                SettingsData.SwitchSetListSortingSetting(true);
            }            
        }
        private void RadioPackSortingNEW_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPackSortingNEW.Checked)
            {
                SettingsData.SwitchSetListSortingSetting(false);
            }
        }
        private void RadioTestModeON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioTestModeON.Checked)
            {
                SettingsData.SwitchDBUpdateTestModeSetting(true);
            }           
        }
        private void RadioTestModeOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioTestModeOFF.Checked)
            {
                SettingsData.SwitchDBUpdateTestModeSetting(false);
            }
        }
        private void RadioHeadlessON_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioHeadlessON.Checked)
            {
                SettingsData.SwitchHeadlessModeSetting(true);
            }
        }
        private void RadioHeadlessOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHeadlessOFF.Checked)
            {
                SettingsData.SwitchHeadlessModeSetting(false);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            Dispose();
            _Mainmenuform.Show();
        }
    }
}