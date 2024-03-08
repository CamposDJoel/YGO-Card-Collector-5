//Joel Campos
//3/8/2024
//Deck Selector Form Class

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
    public partial class DeckSelectorForm : Form
    {
        public DeckSelectorForm(FormLauncher mainMenuForm)
        {
            _MainMenuForm = mainMenuForm;
            InitializeComponent();
            //Load Form theme and music
            Tools.InitalizeThemeOnForm(this);
            SoundServer.PlayBackgroundMusic(Song.DeckBuildMenu);

            //Load Deck list
            LoadDeckList();

            void LoadDeckList()
            {
                foreach(Deck thisDeck in Database.Decks) 
                {
                    listDeckList.Items.Add(thisDeck.Name);
                }

                if(Database.Decks.Count > 0) 
                {
                    listDeckList.SetSelected(0, true);
                }
            }
        }

        private FormLauncher _MainMenuForm;
        private int _CurrentDeckIndexSelected = -1;

        #region Other Event Listeners
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Dispose();
            _MainMenuForm.ReturnToForm();
        }

        private void listDeckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentDeckIndexSelected = listDeckList.SelectedIndex;
            btnEditDeck.Visible = true;
        }

        private void btnEditDeck_Click(object sender, EventArgs e)
        {
            Hide();
            DeckBuilder DB = new DeckBuilder(_CurrentDeckIndexSelected, this);
            DB.Show();
        }
    }
}
