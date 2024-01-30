//Joel Campos
//1/29/2024
//DatabaseManager Class

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YGO_Card_Collector_5

{
    public partial class DatabaseManager : Form
    {
        #region Constructors
        public DatabaseManager()
        {
            InitializeComponent();

            ReloadStats();
        }
        #endregion

        #region Internal Data
        private CardGroup _CurrentSelectedCardGroup = CardGroup.Aqua_Monsters;
        private DBUpdateHoldScren DBUpdateform;

        private MasterCard _CurrentMasterCardSelected;
        private SetCard _CurrentSetCardSelected;
        #endregion

        #region Public Methods
        public void ReloadStats()
        {
            LoadMasterListStats();
            LoadGroupViewStats();
        }
        #endregion

        #region Private Methods
        private void LoadMasterListStats()
        {
            lblTotalMasterCards.Text = Database.MasterCards.Count.ToString();
            lblTotalSetCards.Text = Database.SetCards.Count.ToString();

            lblTotalsAqua.Text = Database.AquaMonsters.Count.ToString();
            lblTotalsBeast.Text = Database.BeastMonsters.Count.ToString();
            lblTotalsBeastWarrior.Text = Database.BeastWarriorMonsters.Count.ToString();
            lblTotalsCyberse.Text = Database.CyberseMonsters.Count.ToString();
            lblTotalsDinosaur.Text = Database.DinosaurMonsters.Count.ToString();
            lblTotalsDivineBeast.Text = Database.DivineBeastMonsters.Count.ToString();
            lblTotalsDragon.Text = Database.DragonMonsters.Count.ToString();
            lblTotalsFairy.Text = Database.FairyMonsters.Count.ToString();
            lblTotalsFiend.Text = Database.FiendMonsters.Count.ToString();
            lblTotalsFish.Text = Database.FishMonsters.Count.ToString();
            lblTotalsIllusion.Text = Database.IllusionMonsters.Count.ToString();
            lblTotalsInsect.Text = Database.InsectMonsters.Count.ToString();
            lblTotalsMachine.Text = Database.MachineMonsters.Count.ToString();
            lblTotalsPlant.Text = Database.PlantMonsters.Count.ToString();
            lblTotalsPsychic.Text = Database.PsychicMonsters.Count.ToString();
            lblTotalsPyro.Text = Database.PyroMonsters.Count.ToString();
            lblTotalsReptile.Text = Database.ReptileMonsters.Count.ToString();
            lblTotalsRock.Text = Database.RockMonsters.Count.ToString();
            lblTotalsSeaSerpent.Text = Database.SeaSerpentMonsters.Count.ToString();
            lblTotalsSpellcaster.Text = Database.SpellcasterMonsters.Count.ToString();
            lblTotalsThunder.Text = Database.ThunderMonsters.Count.ToString();
            lblTotalsWarrior.Text = Database.WarriorMonsters.Count.ToString();
            lblTotalsWingedBeast.Text = Database.WingedBeastMonsters.Count.ToString();
            lblTotalsWyrm.Text = Database.WyrmMonsters.Count.ToString();
            lblTotalsZombie.Text = Database.ZombieMonsters.Count.ToString();
            lblTotalsNormalSpells.Text = Database.NormalSpells.Count.ToString();
            lblTotalsContSpells.Text = Database.ContinuousSpells.Count.ToString();
            lblTotalsQuickSpells.Text = Database.QuickPlaySpells.Count.ToString();
            lblTotalsEquipSpells.Text = Database.EquipSpells.Count.ToString();
            lblTotalsFieldSpells.Text = Database.FieldSpells.Count.ToString();
            lblTotalsRitualSpells.Text = Database.RitualSpells.Count.ToString();
            lblTotalsNormalTraps.Text = Database.NormalTraps.Count.ToString();
            lblTotalsContTraps.Text = Database.ContinuousTraps.Count.ToString();
            lblTotalsCounterTraps.Text = Database.CounterTraps.Count.ToString();
        }
        private void LoadGroupViewStats()
        {
            //Set the group total card count
            lblGroupTotals.Text = Database.GroupCardListByGroupName[_CurrentSelectedCardGroup].Count.ToString();

            lblCardGroupName.Text = Database.CardGroupToString(_CurrentSelectedCardGroup);

            listCardList.Items.Clear();
            List<MasterCard> currentList = Database.GroupCardListByGroupName[_CurrentSelectedCardGroup];
            foreach(MasterCard ThisCard in currentList) 
            {
                listCardList.Items.Add(ThisCard.Name);
            }

            //Select the first item
            listCardList.SetSelected(0, true);
        }
        private void btnUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.MasterCards.Count);
            DBUpdateform.Show();

            UpdateKomaniDB(CardGroup.AllCards);
        }
        private void btnGroupUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.SeaSerpentMonsters.Count);
            DBUpdateform.Show();

            UpdateKomaniDB(_CurrentSelectedCardGroup);          
        }
        private void TEST_SETUP(CardGroup CurrentTestGroup)
        {
            //Log
            AddLog("---TEST SETUP START---");
            AddLog("---TEST GROUP: " + CurrentTestGroup.ToString() + "---");
            DBUpdateform.SetOutputMessage("Searching Card Group...");

            //Open Konami's Card Search Page
            Driver.GoToKonamiSearchPage();
            KonamiSearchPage.WaitUntilPageIsLoaded();

            //Clear Cookies Banner
            KonamiSearchPage.AcceptCookiesBanner();

            //Search for the Card Group
            KonamiSearchPage.SearchCardGroup(CurrentTestGroup);
        }
        private void UpdateKomaniDB(CardGroup Group)
        {
            var watch = new Stopwatch();
            watch.Start();          

            int newCardsCount = 0;
            int cardsWithNewSetsCount = 0;

            //Launch the Chrome Driver to update Konami's Card list only (For the entire DB)
            Driver.OpenBrowser();

            //Test Setup: Go To Konamis Search Page and search for the Card Group               
            TEST_SETUP(Group);

            //Test Should start at the KonamiCardListPage of the respective group

            //Extract how many cards in total are in this group
            int totalCards = KonamiCardListPage.GetCardListTotalCards();
            AddLog(string.Format("Card Count in Page: {0}", totalCards));

            int totalPages = KonamiCardListPage.GetPageCount();
            Dictionary<string, string> CardList = new Dictionary<string, string>();
            DBUpdateform.SetOutputMessage("Extracting Card List...");
            for (int x = 1; x <= totalPages; x++)
            {
                int cardsInPage = KonamiCardListPage.GetCardsCountInCurrentPage();
                for (int y = 1; y <= cardsInPage; y++)
                {
                    string cardName = KonamiCardListPage.GetCardName(y);
                    string cardURL = KonamiCardListPage.GetCardURL(y);
                    //Add the Name/URL combo into the dictionary
                    CardList.Add(cardName, cardURL);
                }
                //Move to the next page except if we already on the last page
                if (x < totalPages) { KonamiCardListPage.ClickNextPage(); }
                else { KonamiCardListPage.ResetPageNumber(); }
            }

            //Now Access each individual Card
            foreach (KeyValuePair<string, string> ThisCard in CardList)
            {
                StringBuilder sb = new StringBuilder();

                //set the card name for readibility and use
                string CardName = ThisCard.Key;
                string KomaniURL = "https://www.db.yugioh-card.com/" + ThisCard.Value;
                sb.Append(string.Format("Card Name: {0}|", CardName));

                //Go to the card info page
                Driver.GoToURL(KomaniURL);
                KonamiCardInfoPage.WaitUntilPageIsLoaded();

                //Extract the amount of sets (we already have the name)
                int SetCardsInPage = KonamiCardInfoPage.GetSetsCount();

                //Check this card against the current DB
                if (Database.CardExists(CardName))
                {
                    //Save a ref to the MasterCard in DB for quick access
                    MasterCard ThisMasterCard = Database.GetCard(CardName);

                    //Check its sets
                    int SetCardsInDB = ThisMasterCard.SetCards.Count;

                    //Make comparison
                    if (SetCardsInPage > SetCardsInDB)
                    {
                        //Extract the set cards
                        cardsWithNewSetsCount++;

                        int NewSetCardsAmount = SetCardsInPage - SetCardsInDB;

                        sb.Append(string.Format("New Set Cards found: {0}|", NewSetCardsAmount));
                        //Add any new set to this card set list
                        for (int x = NewSetCardsAmount; x >= 1; x--)
                        {
                            //Pull the data
                            string releaseDate = KonamiCardInfoPage.GetSetReleaseDate(x);
                            string code = KonamiCardInfoPage.GetSetCode(x);
                            string setName = KonamiCardInfoPage.GetSetName(x);
                            string rarity = KonamiCardInfoPage.GetRarity(x);

                            //Add this set to it
                            ThisMasterCard.InsertSetCard(releaseDate, code, setName, rarity);
                            sb.Append(string.Format("Code: {0}|", code));
                        }
                    }
                    else
                    {
                        //Do nothing, there is nothing to update
                        sb.Append("No updates");
                    }
                }
                else
                {
                    MasterCard NewCARD;
                    sb.Append("New Card!|");
                    newCardsCount++;

                    //Otherwise, extract the whole card
                    if (KonamiCardInfoPage.IsThisPageNonMonster())
                    {
                        //Extract spell/trap
                        string species = KonamiCardInfoPage.GetSpecies();
                        NewCARD = new MasterCard(CardName, "NONE", species, "0", "0", "0", "0", KomaniURL);
                    }
                    else
                    {
                        //extract monster
                        //ORDER: ${CARDNAME}|${ATTRIBUTE}|${SPECIES}|${LEVELRANKLINK}|${ATA}|${DEF}|${PEND}|${SETSCOUNT}
                        string attribute = KonamiCardInfoPage.GetAttribute();
                        string species = KonamiCardInfoPage.GetSpecies();
                        string levelranklink = KonamiCardInfoPage.GetLevelRankLink();
                        string attack = KonamiCardInfoPage.GetAttack();
                        string defense = KonamiCardInfoPage.GetDefense();
                        string pendulum = KonamiCardInfoPage.GetPendulum();
                        NewCARD = new MasterCard(CardName, attribute, species, levelranklink, attack, defense, pendulum, KomaniURL);
                    }

                    //Add the sets
                    sb.Append(string.Format("Sets Count {0}|", SetCardsInPage));
                    for (int x = 1; x <= SetCardsInPage; x++)
                    {
                        //Pull the data
                        string releaseDate = KonamiCardInfoPage.GetSetReleaseDate(x);
                        string code = KonamiCardInfoPage.GetSetCode(x);
                        string setName = KonamiCardInfoPage.GetSetName(x);
                        string rarity = KonamiCardInfoPage.GetRarity(x);

                        //Add this set to it
                        NewCARD.AddSetCard(releaseDate, code, setName, rarity);

                        sb.Append(string.Format("Code: {0}|", code));
                    }

                    //Add the Card to the DB
                    Database.AddNewCardToDB(NewCARD);
                }

                AddLog(sb.ToString());
                //Send the completion flag
                DBUpdateform.SendCardCompletionSignal();
            }

            //END: CLose the Browser and Console
            Driver.CloseDriver();

            AddLog("----------------------------------");
            AddLog(string.Format("New Cards Found: {0}", newCardsCount));
            AddLog(string.Format("Cards with new Sets Found: {0}", cardsWithNewSetsCount));

            watch.Stop();
            AddLog($"Execution Time for card group was: {watch.Elapsed} |");

            DBUpdateform.SendFullCompletionSignal();
            WriteOutputFiles();
        }
        private void AddLog(string line)
        {
            Console.WriteLine(line);
            Driver.Log.Add(line);
        }
        private void WriteOutputFiles()
        {
            //save the log file
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\LOG.txt", Driver.Log);

            //Save the New JSON DB
            string output = JsonConvert.SerializeObject(Database.MasterCards);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\Output Files\\CardDB_Output.json", output);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Filters Event Handlers
        private void btnFilterAqua_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Aqua_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterBeast_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Beast_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterBeastWarrior_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.BeastWarrior_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterCyberce_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Cyberse_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterDinosaur_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Dinosaur_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterDivine_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.DivineBeast_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterDragon_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Dragon_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterFairy_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Fairy_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterFiend_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Fiend_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterFish_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Fish_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterIllusion_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.IllusionType_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterInsect_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Insect_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterMachine_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Machine_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterPlant_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Plant_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterPsychic_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Psychic_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterPyro_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Pyro_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterReptile_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Reptile_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterRock_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Rock_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterSeaSerpent_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.SeaSerpent_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterSpellcaster_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Spellcaster_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterThunder_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Thunder_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterWarrior_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Warrior_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterWingedBeast_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.WingedBeast_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterWyrm_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Wyrm_Monsters;
            LoadGroupViewStats();
        }
        private void btnFilterZombie_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Zombie_Monsters;
            LoadGroupViewStats();
        }
        private void btnNormalSpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Normal_Spells;
            LoadGroupViewStats();
        }
        private void btnContinousSpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Continuous_Spells;
            LoadGroupViewStats();
        }
        private void btnEquipSpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Equip_Spells;
            LoadGroupViewStats();
        }
        private void btnFieldSpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Field_Spells;
            LoadGroupViewStats();
        }
        private void btnQuickPlaySpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.QuickPlay_Spells;
            LoadGroupViewStats();
        }
        private void btnRitualSpell_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Ritual_Spells;
            LoadGroupViewStats();
        }
        private void btnNormalTrap_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Normal_Traps;
            LoadGroupViewStats();
        }
        private void btnContinuosTrap_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Continuous_Traps;
            LoadGroupViewStats();
        }
        private void btnCounterTrap_Click(object sender, EventArgs e)
        {
            _CurrentSelectedCardGroup = CardGroup.Counter_Traps;
            LoadGroupViewStats();
        }
        #endregion

        #region Event Listeners
        private void listCardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSetCards.Items.Clear();

            //Get the card name from the list item selected
            _CurrentMasterCardSelected = Database.MasterCardByName[listCardList.SelectedItem.ToString()];

            foreach(SetCard ThisSetCard in _CurrentMasterCardSelected.SetCards) 
            {
                string item = ThisSetCard.Code + "|" + ThisSetCard.Rarity;
                listSetCards.Items.Add(item);
            }

            listSetCards.SetSelected(0, true);
            checkProdeckEnableOverride.Checked = false;
            checkTCGEnableOverride.Checked = false;
        }
        private void listSetCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSetCardSelected = _CurrentMasterCardSelected.GetCardAtIndex(listSetCards.SelectedIndex);
            txtKonamiURL.Text = _CurrentMasterCardSelected.KonamiURL;
            txtProdeckURL.Text = _CurrentMasterCardSelected.ProdeckURL;
            txtTCGURL.Text = _CurrentSetCardSelected.TCGPlayerURL;
            lblMarketPrice.Text = _CurrentSetCardSelected.MarketPrice;
            lblMedianPrice.Text = _CurrentSetCardSelected.MediamPrice;
            checkProdeckEnableOverride.Checked = false;
            checkTCGEnableOverride.Checked = false;
        }
        private void checkProdeckEnableOverride_CheckedChanged(object sender, EventArgs e)
        {            
            if(checkProdeckEnableOverride.Checked == true)
            {
                txtProdeckURL.Enabled = true;
                btnProdeckOverride.Visible = true;
                if (_CurrentMasterCardSelected.ProdeckURLIsMissing())
                {
                    btnProdeckUnavailable.Visible = true;
                }
            }
            else
            {
                btnProdeckOverride.Visible = false;
                btnProdeckUnavailable.Visible = false;
                txtProdeckURL.Enabled = false;
                btnProdeckOverride.Visible = false;
                txtProdeckURL.Text = _CurrentMasterCardSelected.ProdeckURL;
            }           
        }
        private void checkTCGEnableOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTCGEnableOverride.Checked == true)
            {
                txtTCGURL.Enabled = true;
                btnTCGOverride.Visible = true;
                if (_CurrentSetCardSelected.TCGPlayerURLIsMissing())
                {
                    btnTCGUnavailable.Visible = true;
                }
            }
            else
            {
                btnTCGOverride.Visible = false;
                btnTCGUnavailable.Visible = false;
                txtTCGURL.Enabled = false;
                btnTCGOverride.Visible = false;
                txtTCGURL.Text = _CurrentSetCardSelected.TCGPlayerURL;
            }
        }
        private void btnProdeckOverride_Click(object sender, EventArgs e)
        {
            string input = txtProdeckURL.Text;
            if(input.StartsWith("https://ygoprodeck.com/card/"))
            {
                //Valid ulr, proceed
                _CurrentMasterCardSelected.ProdeckURL = input;
                checkProdeckEnableOverride.Checked = false;
            }
            else
            {
                txtProdeckURL.Text = "Not a Prodeck URL.";
            }
        }
        private void btnProdeckUnavailable_Click(object sender, EventArgs e)
        {
            _CurrentMasterCardSelected.ProdeckURL = "Unavailable";
            checkProdeckEnableOverride.Checked = false;
        }
        private void btnTCGOverride_Click(object sender, EventArgs e)
        {
            string input = txtTCGURL.Text;
            if (input.StartsWith("https://tcgplayer"))
            {
                //Valid ulr, proceed
                _CurrentSetCardSelected.TCGPlayerURL = input;
                checkTCGEnableOverride.Checked = false;
            }
            else
            {
                txtTCGURL.Text = "Not a TCG Player URL.";
            }
        }
        private void btnTCGUnavailable_Click(object sender, EventArgs e)
        {
            _CurrentSetCardSelected.TCGPlayerURL = "Unavailable";
            checkTCGEnableOverride.Checked = false;
        }
        #endregion
    }
}