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
using System.Text.RegularExpressions;
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
        }

        public void LoadDeckList()
        {
            listDeckList.Items.Clear();
            foreach (Deck thisDeck in Database.Decks)
            {
                listDeckList.Items.Add(thisDeck.Name);
            }

            if (Database.Decks.Count > 0)
            {
                checkEnableEdit.Enabled = true;
                listDeckList.SetSelected(0, true);
            }
            else
            {
                checkEnableEdit.Enabled = false;
                checkEnableEdit.Checked = false;
                txtSelectedName.Text = string.Empty;
                txtSelectedDescription.Text = string.Empty;
                lblSelectedMainDeckCount.Text = string.Empty;
                lblSelectedExtraDeckCount.Text = string.Empty;
                lblSelectedSideDeckCount.Text = string.Empty;
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
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            _CurrentDeckIndexSelected = listDeckList.SelectedIndex;
            btnEditDeck.Visible = true;
            checkEnableEdit.Checked = false;
            //Update info
            txtSelectedName.Text = Database.Decks[_CurrentDeckIndexSelected].Name;
            txtSelectedDescription.Text = Database.Decks[_CurrentDeckIndexSelected].Description;
            lblSelectedMainDeckCount.Text = string.Format("{0} Cards", Database.Decks[_CurrentDeckIndexSelected].MainDeck.Count);
            lblSelectedExtraDeckCount.Text = string.Format("{0} Cards", Database.Decks[_CurrentDeckIndexSelected].ExtraDeck.Count);
            lblSelectedSideDeckCount.Text = string.Format("{0} Cards", Database.Decks[_CurrentDeckIndexSelected].SideDeck.Count);
        }
        private void btnEditDeck_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            Hide();
            DeckBuilder DB = new DeckBuilder(_CurrentDeckIndexSelected, this);
            DB.Show();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string nameinput = txtNewDeckName.Text;
            string descriptioninput = txtNewDeckDescription.Text;
            if (!Regex.IsMatch(nameinput, @"^[a-zA-Z0-9]+$"))
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                lblError.Text = "Name must contain ONLY Letters/Numbers";
                lblError.Visible = true;
                Tools.WaitNSeconds(2000);
                lblError.Visible = false;
            }
            else 
            {
                if(Database.DeckWithNameExists(nameinput))
                {
                    SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    lblError.Text = "Deck with that name already exists";
                    lblError.Visible = true;
                    Tools.WaitNSeconds(2000);
                    lblError.Visible = false;
                }
                else
                {
                    if(nameinput.Length >= 20)
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                        lblError.Text = "Name too long";
                        lblError.Visible = true;
                        Tools.WaitNSeconds(2000);
                        lblError.Visible = false;
                    }
                    else
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                        //Procceed to create the Deck Object
                        Deck newDeck = new Deck(nameinput, descriptioninput);
                        Database.Decks.Add(newDeck);

                        //Reload the decklist
                        LoadDeckList();

                        //Set the selector
                        listDeckList.SetSelected(listDeckList.Items.Count - 1, true);

                        //Override the save file
                        Database.UpdateDeckSaveFile();

                        //Open the Deck Builder form
                        Hide();
                        DeckBuilder DB = new DeckBuilder(_CurrentDeckIndexSelected, this);
                        DB.Show();
                    }                    
                }               
            }
        }
        private void checkEnableEdit_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            if (checkEnableEdit.Checked) 
            {
                txtSelectedName.Enabled = true;
                txtSelectedDescription.Enabled = true;
                btnSelectedUpdate.Enabled = true;
                btnDelete.Visible = true;
            }
            else
            {
                txtSelectedName.Enabled = false;
                txtSelectedDescription.Enabled = false;
                btnSelectedUpdate.Enabled = false;
                btnDelete.Visible = false;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete current selected deck
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            _CurrentDeckIndexSelected = listDeckList.SelectedIndex;

            Database.Decks.RemoveAt(_CurrentDeckIndexSelected);

            LoadDeckList();

            Database.UpdateDeckSaveFile();
        }
        private void btnSelectedUpdate_Click(object sender, EventArgs e)
        {
            string nameinput = txtSelectedName.Text;
            string descriptioninput = txtSelectedDescription.Text;
            if (!Regex.IsMatch(nameinput, @"^[a-zA-Z0-9]+$"))
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                lblError2.Text = "Name must contain ONLY Letters/Numbers";
                lblError2.Visible = true;
                Tools.WaitNSeconds(2000);
                lblError2.Visible = false;
            }
            else
            {
                if (Database.DeckWithNameExists(nameinput))
                {
                    SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    lblError2.Text = "Deck with that name already exists";
                    lblError2.Visible = true;
                    Tools.WaitNSeconds(2000);
                    lblError2.Visible = false;
                }
                else
                {
                    if (nameinput.Length >= 20)
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                        lblError2.Text = "Name too long";
                        lblError2.Visible = true;
                        Tools.WaitNSeconds(2000);
                        lblError2.Visible = false;
                    }
                    else
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                        //Procceed to edit the deck name/description
                        Deck ThisDeck = Database.Decks[_CurrentDeckIndexSelected];
                        ThisDeck.Name = nameinput;
                        ThisDeck.Description = descriptioninput;

                        //Reload the decklist
                        LoadDeckList();

                        //Override the save file
                        Database.UpdateDeckSaveFile();
                    }                 
                }
            }
        }
    }
}
