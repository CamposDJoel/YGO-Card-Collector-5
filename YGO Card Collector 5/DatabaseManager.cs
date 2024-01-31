//Joel Campos
//1/29/2024
//DatabaseManager Class

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Web;
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

        private MasterCard _Explorer_CurrentMasterCardSelected;
        private SetCard _Explorer_CurrentSetCardSelected;

        private MasterCard _MissingURL_CurrentProdeckMasterCardSelected;
        private MasterCard _MissingURL_CurrentTCGMasterCardSelected;
        private SetCard _MissingURL_CurrentSetCardSelected;
        #endregion

        #region Public Methods
        public void ReloadStats()
        {
            LoadMasterListStats();
            LoadGroupViewStats();
            LoadMissingURLsLists();
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
        private void LoadMissingURLsLists()
        {
            //Prodeck list
            listProdeckMissingURLs.Items.Clear();
            if (Database.CardsWithoutProdeckURL.Count == 0)
            {
                listProdeckMissingURLs.Items.Add("No Cards - Good Job! Database is up to date!");
            }
            else
            {
                foreach(string CardName in Database.CardsWithoutProdeckURL) 
                {
                    listProdeckMissingURLs.Items.Add(CardName);
                }
            }
            listProdeckMissingURLs.SetSelected(0, true);

            //TCG list
            listTCGMissingURLs.Items.Clear();
            if(Database.CardsWithoutTCGURLs.Count == 0)
            {
                listTCGMissingURLs.Items.Add("No Cards - Good Job! Database is up to date!");
                listTCGMissingURLsSets.Visible = false;
            }
            else
            {
                foreach(string entry in Database.CardsWithoutTCGURLs) 
                {
                    listTCGMissingURLs.Items.Add(entry);
                }
            }
            listTCGMissingURLs.SetSelected(0, true);
        }       
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Automation Scrips Methods
        //Konami Card List Update Methods
        private void TEST_SETUP_KONAMIUPDATE(CardGroup CurrentTestGroup)
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
            Driver.Log.Clear();
            var watch = new Stopwatch();
            watch.Start();

            int newCardsCount = 0;
            int cardsWithNewSetsCount = 0;

            //Launch the Chrome Driver to update Konami's Card list only (For the entire DB)
            Driver.OpenBrowser();

            //Test Setup: Go To Konamis Search Page and search for the Card Group               
            TEST_SETUP_KONAMIUPDATE(Group);

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
        
        //Missing URLs Update Methods
        private void TEST_SETUP_URLsUPDATE()
        {
            //Log
            AddLog("---MISSING URLS UPDATE---");
            DBUpdateform.SetOutputMessage("Starting...");

            //Open Prodeck Advance Search Page up
            Driver.GoToProdeckSearchPage();
            ProDeckCardSearchPage.WaitUntilPageIsLoaded();
        }
        private void UpdateURLsDB()
        {
            //START
            Driver.Log.Clear();
            var watch = new Stopwatch();
            watch.Start();

            //Open Driver and Setup
            Driver.OpenBrowser();
            TEST_SETUP_URLsUPDATE();
            AddLog("--------------Missing Prodeck URLs---------------------");

            //Search for each card
            List<string> successListProdeck = new List<string>();
            foreach (string CardName in Database.CardsWithoutProdeckURL)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Card:{0}|", CardName));

                //Save a ref to the Master Card for quick access/clean code
                MasterCard ThisMasterCard = Database.GetCard(CardName);

                //Perform the search
                bool SearchSucess = ProDeckCardSearchPage.SearchCard(CardName);

                //if successful, save the Prodeck URL and Card ID, otherwise flag the fail on the log
                if (SearchSucess)
                {
                    sb.Append("Prodeck Search Success!|");

                    //Extract the card ID and override the ID
                    int ID = ProdeckCardInfoPage.GetCardID();
                    ThisMasterCard.ID = ID;

                    //save the url of this card so we dont have to search for it again
                    string currentURL = Driver.ChromeDriver.Url;
                    ThisMasterCard.ProdeckURL = currentURL;
                    successListProdeck.Add(CardName);
                    sb.Append("Prodeck URL saved!|");
                }
                else
                {
                    sb.Append("Prodeck search failed!|");
                }

                //Log it and send the card completion signal
                AddLog(sb.ToString());
                DBUpdateform.SendCardCompletionSignal();
            }

            //Post run, remove the sucess searches from the CardsWithoutProdeckURL list
            foreach (string cardname in successListProdeck)
            {
                Database.CardsWithoutProdeckURL.Remove(cardname);
            }

            //Reload the list in the DBManager UI
            LoadMissingURLsLists();

            AddLog("--------------Missing TCG Player URLs---------------------");

            //Now search for the TCG Player URLs
            List<string> successListTCG = new List<string>();
            foreach(string CardName in Database.CardsWithoutTCGURLs) 
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Card:{0}", CardName));
                
                //Save a ref to the Master Card for quick access/clean code
                MasterCard ThisMasterCard = Database.GetCard(CardName);
              
                //Go to the Card's Prodeck URL, if available
                if (ThisMasterCard.HasProDeckURL())
                {
                    //Go to the page
                    Driver.GoToURL(ThisMasterCard.ProdeckURL);
                    ProdeckCardInfoPage.WaitUntilPageIsLoaded();

                    //Open the View more URLs if has so
                    bool viewmore = false;
                    if (ProdeckCardInfoPage.PageContainsTCGPrices())
                    {
                        if (ProdeckCardInfoPage.TCGPricesHasViewMore())
                        {
                            //Click the view more and flag it for later
                            ProdeckCardInfoPage.ClickViewMore();
                            viewmore = true;                           
                        }
                    }

                    //For each card with missing TCG URL check if you can extract the URLs that match the set
                    foreach(SetCard ThisSetCard in ThisMasterCard.SetCards) 
                    {                        
                        //Only search for Set Cards that are "Missing"
                        if (ThisSetCard.TCGPlayerURLIsMissing())
                        {
                            sb.Append(string.Format("Searching For Code: {0} Rarity: {1} |", ThisSetCard.Code, ThisSetCard.Rarity));

                            //Extract available URLs from the page
                            List<string> URLsToCheck = new List<string>();
                            if (viewmore)
                            {
                                URLsToCheck = ProdeckCardInfoPage.GetPricesURLsViewMore(ThisSetCard.Name);
                            }
                            else
                            {
                                //extract the links directly from the page.
                                URLsToCheck = ProdeckCardInfoPage.GetPricesURLsFromPage();
                            }
                            sb.Append(string.Format("URLs extracted to check: {0}|", URLsToCheck.Count));

                            //Now check all the URL for matches
                            bool MathcURLFound = false;
                            foreach (string TestURL in URLsToCheck)
                            {                               
                                //Go to the test URL
                                try
                                {
                                    Driver.GoToURL(TestURL);
                                }
                                catch (Exception)
                                {
                                    Driver.ChromeDriver.Close();
                                    Driver.OpenBrowser();
                                    Driver.GoToURL(TestURL);
                                }

                                //if the URL is a valid TCG Player listing page, check the code and rarity
                                if (TCGCardInfoPage.IsAValidPage())
                                {
                                    bool PageLoadedCorrectly = TCGCardInfoPage.WaitUntilPageIsLoaded();

                                    if (PageLoadedCorrectly)
                                    {
                                        //If the page corresponds to the code AND Rarity, then extract its price
                                        string CodeInPage = TCGCardInfoPage.GetCode();
                                        string RarityInPage = TCGCardInfoPage.GetRarity();
                                        if (ThisSetCard.Code == CodeInPage && Tools.CompareInLowerCase(ThisSetCard.Rarity, RarityInPage))
                                        {
                                            //Save the URL and Update prices
                                            ThisSetCard.TCGPlayerURL = TestURL;
                                            //Add this card to the "success" list to remove the master card from the
                                            //Missing TCG urls list
                                            if(ThisMasterCard.HasNoMissingTCGURLs())
                                            {
                                                successListTCG.Add(ThisMasterCard.Name);
                                            }
                                            //Update prices since we are here.
                                            string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                            string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                            double priceInPageMarket = Tools.CovertPriceToDouble(priceInPageMarketstr);
                                            double priceInPageMedian = Tools.CovertPriceToDouble(priceInPageMedianstr);
                                            ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                                            MathcURLFound = true;
                                        }
                                    }
                                }

                                if(MathcURLFound)
                                {
                                    //Break the loop and move to the next code                                    
                                    break;
                                }
                            }

                            if (MathcURLFound)
                            {
                                sb.AppendLine("Match URL FOUND!!!");
                            }
                            else
                            {
                                sb.AppendLine("No Matches, find this URL manually...");
                            }
                        }                       
                    }                   
                }
                else
                {
                    sb.AppendLine("NO PRODECK URL - Search Skip until card has one.");
                }

                sb.AppendLine("---------------------------------------------------------");

                //Log it and send the card completion signal
                DBUpdateform.SendCardCompletionSignal();
                AddLog(sb.ToString());
            }

            //Post run, remove the sucess searches from the CardsWithoutTCGkURL list
            foreach (string cardname in successListTCG)
            {
                Database.CardsWithoutTCGURLs.Remove(cardname);
            }
            
            //END: CLose the Browser and Console
            Driver.CloseDriver();

            //Stop watch
            watch.Stop();
            AddLog($"Execution Time for card group was: {watch.Elapsed}");

            //Be done
            DBUpdateform.SendFullCompletionSignal();
            WriteOutputFiles();
        }

        //Logs and Post-Run Methods
        private void AddLog(string line)
        {
            //Console.WriteLine(line);
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
        #endregion

        #region Event Listeners (Master Card List Total Tab)
        private void btnUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.MasterCards.Count);
            DBUpdateform.Show();

            UpdateKomaniDB(CardGroup.AllCards);
        }
        private void btnExtractURLs_Click(object sender, EventArgs e)
        {
            int totalcardstocheck = Database.CardsWithoutProdeckURL.Count + Database.CardsWithoutTCGURLs.Count;
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, totalcardstocheck);
            DBUpdateform.Show();

            UpdateURLsDB();
        }
        private void btnGroupUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.SeaSerpentMonsters.Count);
            DBUpdateform.Show();

            UpdateKomaniDB(_CurrentSelectedCardGroup);
        }
        #endregion

        #region Event Listeners (Card List Explorer Tab - Filters)
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

        #region Event Listeners (Card List Explorer Tab - Rest)
        //2 Lists containers
        private void listCardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSetCards.Items.Clear();

            //Get the card name from the list item selected
            _Explorer_CurrentMasterCardSelected = Database.MasterCardByName[listCardList.SelectedItem.ToString()];

            foreach(SetCard ThisSetCard in _Explorer_CurrentMasterCardSelected.SetCards) 
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
            _Explorer_CurrentSetCardSelected = _Explorer_CurrentMasterCardSelected.GetCardAtIndex(listSetCards.SelectedIndex);
            //populate the 4 text  fields
            txtKonamiURL.Text = _Explorer_CurrentMasterCardSelected.KonamiURL;
            txtPasscode.Text = _Explorer_CurrentMasterCardSelected.ID.ToString();
            txtProdeckURL.Text = _Explorer_CurrentMasterCardSelected.ProdeckURL;
            txtTCGURL.Text = _Explorer_CurrentSetCardSelected.TCGPlayerURL;
            //populate prices
            lblMarketPrice.Text = _Explorer_CurrentSetCardSelected.MarketPrice;
            lblMedianPrice.Text = _Explorer_CurrentSetCardSelected.MediamPrice;
            //check override buttons to false to lock everything out
            checkProdeckEnableOverride.Checked = false;
            checkTCGEnableOverride.Checked = false;
            checkPasscodeEnableOverride.Checked = false;
            //but the passcode overide should be hiden if the card has already a set Passcode
            if(_Explorer_CurrentMasterCardSelected.ID == -1) 
            {
                lblMisingPasscodeWarning.Visible = true;
                checkPasscodeEnableOverride.Visible = true;
                //disable prodeck
                checkProdeckEnableOverride.Visible = false;
            }
            else
            {
                lblMisingPasscodeWarning.Visible = false;
                checkPasscodeEnableOverride.Visible = false;
                //enable prodeck
                checkProdeckEnableOverride.Visible = true;
            }
        }
        //Passcode Override Section Elements
        private void checkPasscodeEnableOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPasscodeEnableOverride.Checked)
            {
                txtPasscode.Enabled = true;
                btnPasscodeOverride.Visible = true;
            }
            else
            {
                txtPasscode.Text = _Explorer_CurrentMasterCardSelected.ID.ToString();
                txtPasscode.Enabled = false;
                btnPasscodeOverride.Visible = false;
            }
        }
        private void btnPasscodeOverride_Click(object sender, EventArgs e)
        {
            //overide if the input is not -1 or a non-numeric
            string input = txtPasscode.Text;
            if (input == "-1")
            {
                //invalid value
                txtPasscode.Text = "Invalid ID input. Must be numeric and not -1";
            }
            else
            {
                try
                {
                    int idinput = Convert.ToInt32(input);
                    _Explorer_CurrentMasterCardSelected.ID = idinput;
                    //Success, update the UI
                    checkPasscodeEnableOverride.Checked = false;
                    checkPasscodeEnableOverride.Visible = false;
                    lblMisingPasscodeWarning.Visible = false;
                    checkProdeckEnableOverride.Visible = true;
                }
                catch (Exception)
                {
                    txtPasscode.Text = "Invalid ID input. Must be numeric and not -1";
                }
            }
        }
        //Prodeck Override Section Elements
        private void checkProdeckEnableOverride_CheckedChanged(object sender, EventArgs e)
        {            
            if(checkProdeckEnableOverride.Checked)
            {
                txtProdeckURL.Enabled = true;
                btnProdeckOverride.Visible = true;
                if (_Explorer_CurrentMasterCardSelected.ProdeckURLIsMissing())
                {
                    btnProdeckUnavailable.Visible = true;
                }
            }
            else
            {
                btnProdeckOverride.Visible = false;
                btnProdeckUnavailable.Visible = false;
                txtProdeckURL.Enabled = false;
                txtProdeckURL.Text = _Explorer_CurrentMasterCardSelected.ProdeckURL;
            }           
        }
        private void btnProdeckOverride_Click(object sender, EventArgs e)
        {
            string input = txtProdeckURL.Text;
            if (input.StartsWith("https://ygoprodeck.com/card/"))
            {
                //Valid ulr, proceed
                _Explorer_CurrentMasterCardSelected.ProdeckURL = input;
                checkProdeckEnableOverride.Checked = false;
                //Remove card from the missing URL list
                Database.CardsWithoutProdeckURL.Remove(_Explorer_CurrentMasterCardSelected.Name);
                //Reload the Missing URL tab's UI
                LoadMissingURLsLists();
            }
            else
            {
                txtProdeckURL.Text = "Not a Prodeck URL.";
            }
        }
        private void btnProdeckUnavailable_Click(object sender, EventArgs e)
        {
            _Explorer_CurrentMasterCardSelected.ProdeckURL = "Unavailable";
            checkProdeckEnableOverride.Checked = false;
            //Remove this card from the missing url list and add it to the unavailable list
            Database.CardsWithoutProdeckURL.Remove(_Explorer_CurrentMasterCardSelected.Name);
            Database.CardsWithUnavailableProdeckURL.Add(_Explorer_CurrentMasterCardSelected.Name);
            //Reload this Tabs UI
            LoadGroupViewStats();
        }
        //TCG Override section Elements
        private void checkTCGEnableOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTCGEnableOverride.Checked)
            {
                txtTCGURL.Enabled = true;
                btnTCGOverride.Visible = true;
                if (_Explorer_CurrentSetCardSelected.TCGPlayerURLIsMissing())
                {
                    btnTCGUnavailable.Visible = true;
                }
            }
            else
            {
                btnTCGOverride.Visible = false;
                btnTCGUnavailable.Visible = false;
                txtTCGURL.Enabled = false;
                txtTCGURL.Text = _Explorer_CurrentSetCardSelected.TCGPlayerURL;
            }
        }        
        private void btnTCGOverride_Click(object sender, EventArgs e)
        {
            string input = txtTCGURL.Text;
            if (input.StartsWith("https://tcgplayer") || input.StartsWith("https://www.tcgplayer.com/product/"))
            {
                //Valid ulr, proceed
                _Explorer_CurrentSetCardSelected.TCGPlayerURL = input;
                checkTCGEnableOverride.Checked = false;
                //Remove card from the TCG missing URL list if no missing urls left from this card
                if(_Explorer_CurrentMasterCardSelected.HasNoMissingTCGURLs())
                {
                    Database.CardsWithoutTCGURLs.Remove(_Explorer_CurrentMasterCardSelected.Name);
                }

                //Reload the Missing URL tab's UI
                LoadMissingURLsLists();
            }
            else
            {
                txtTCGURL.Text = "Not a TCG Player URL.";
            }
        }
        private void btnTCGUnavailable_Click(object sender, EventArgs e)
        {
            _Explorer_CurrentSetCardSelected.TCGPlayerURL = "Unavailable";
            checkTCGEnableOverride.Checked = false;
            //Remove this card from the missing url list and add it to the unavailable list
            Database.CardsWithoutTCGURLs.Remove(_Explorer_CurrentMasterCardSelected.Name);
            Database.CardsWithUnavailableTCGURLs.Add(_Explorer_CurrentMasterCardSelected.Name);
            //Reload this Tabs UI
            LoadGroupViewStats();
        }
        #endregion

        #region Event Listeners (Missing URLs Tab)
        //3 List Containers
        private void listProdeckMissingURLs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cardname = listProdeckMissingURLs.Text;

            if(cardname != "No Cards - Good Job! Database is up to date!")
            {
                _MissingURL_CurrentProdeckMasterCardSelected = Database.GetCard(cardname);
                txtPasscode.Text = _Explorer_CurrentMasterCardSelected.ID.ToString();
                GroupMissingProdeckOverride.Visible = true;

                //set up the override UI
                txtPasscode2.Text = _MissingURL_CurrentProdeckMasterCardSelected.ID.ToString();
                txtProdeckURL2.Text = _MissingURL_CurrentProdeckMasterCardSelected.ProdeckURL;
                //set the checks to false to lock fields at start
                checkPasscodeEnableOverride2.Checked = false;
                checkProdeckEnableOverride2.Checked = false;
                //but the passcode overide should be hiden if the card has already a set Passcode
                if (_MissingURL_CurrentProdeckMasterCardSelected.ID == -1)
                {
                    lblMisingPasscodeWarning2.Visible = true;
                    checkPasscodeEnableOverride2.Visible = true;
                    //disable prodeck
                    checkProdeckEnableOverride2.Visible = false;
                }
                else
                {
                    lblMisingPasscodeWarning2.Visible = false;
                    checkPasscodeEnableOverride2.Visible = false;
                    //enable prodeck
                    checkProdeckEnableOverride2.Visible = true;
                }
            }
            else
            {
                GroupMissingProdeckOverride.Visible = false;
            }
        }
        private void listTCGMissingURLs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cardname = listTCGMissingURLs.Text;

            if (cardname != "No Cards - Good Job! Database is up to date!")
            {
                //Populate the set card list
                listTCGMissingURLsSets.Items.Clear();
                _MissingURL_CurrentTCGMasterCardSelected = Database.GetCard(cardname);

                foreach (SetCard ThisSetCard in _MissingURL_CurrentTCGMasterCardSelected.SetCards)
                {
                    string item = ThisSetCard.Code + "|" + ThisSetCard.Rarity;
                    if(ThisSetCard.TCGPlayerURLIsMissing())
                    {
                        item = "[!] - " + item;
                    }
                    listTCGMissingURLsSets.Items.Add(item);
                }

                listTCGMissingURLsSets.SetSelected(0, true);
            }
            else
            {
                GroupMissingTCGOverride.Visible = false;
            }
        }
        private void listTCGMissingURLsSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int setCardIndex = listTCGMissingURLsSets.SelectedIndex;
            _MissingURL_CurrentSetCardSelected = _MissingURL_CurrentTCGMasterCardSelected.GetCardAtIndex(setCardIndex);

            if(_MissingURL_CurrentSetCardSelected.TCGPlayerURLIsMissing())
            {
                //Diplay the override submenu
                GroupMissingTCGOverride.Visible = true;

                txtTCGURL2.Text = _MissingURL_CurrentSetCardSelected.TCGPlayerURL;
                checkTCGEnableOverride2.Checked = false;
            }
            else
            {
                GroupMissingTCGOverride.Visible = false;
            }
        }
        //Passcode Overide Section
        private void checkMissingPasscodeEnableOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPasscodeEnableOverride2.Checked)
            {
                txtPasscode2.Enabled = true;
                btnPasscodeOverride2.Visible = true;
            }
            else
            {
                txtPasscode2.Text = _MissingURL_CurrentProdeckMasterCardSelected.ID.ToString();
                txtPasscode2.Enabled = false;
                btnPasscodeOverride2.Visible = false;
            }
        }
        private void btnMissingPasscodeOverride_Click(object sender, EventArgs e)
        {
            //overide if the input is not -1 or a non-numeric
            string input = txtPasscode2.Text;
            if (input == "-1")
            {
                //invalid value
                txtPasscode2.Text = "Invalid ID input. Must be numeric and not -1";
            }
            else
            {
                try
                {
                    int idinput = Convert.ToInt32(input);
                    _MissingURL_CurrentProdeckMasterCardSelected.ID = idinput;
                    //Success, update the UI
                    checkPasscodeEnableOverride2.Checked = false;
                    checkPasscodeEnableOverride2.Visible = false;
                    lblMisingPasscodeWarning2.Visible = false;
                    checkProdeckEnableOverride2.Visible = true;
                }
                catch (Exception)
                {
                    txtPasscode2.Text = "Invalid ID input. Must be numeric and not -1";
                }
            }
        }
        //Prodeck Override Section
        private void checkMissingProdeckEnableOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (checkProdeckEnableOverride2.Checked)
            {
                txtProdeckURL2.Enabled = true;
                btnProdeckOverride2.Visible = true;
                if (_MissingURL_CurrentProdeckMasterCardSelected.ProdeckURLIsMissing())
                {
                    btnProdeckUnavailable2.Visible = true;
                }
            }
            else
            {
                btnProdeckOverride2.Visible = false;
                btnProdeckUnavailable2.Visible = false;
                txtProdeckURL2.Enabled = false;
                txtProdeckURL2.Text = _MissingURL_CurrentProdeckMasterCardSelected.ProdeckURL;
            }
        }
        private void btnProdeckOverride2_Click(object sender, EventArgs e)
        {
            string input = txtProdeckURL2.Text;
            if (input.StartsWith("https://ygoprodeck.com/card/"))
            {
                //Valid ulr, proceed
                _MissingURL_CurrentProdeckMasterCardSelected.ProdeckURL = input;
                checkProdeckEnableOverride2.Checked = false;
                //Remove this card from the list now!!
                Database.CardsWithoutProdeckURL.Remove(_MissingURL_CurrentProdeckMasterCardSelected.Name);
                //Reload the UI
                ReloadStats();
            }
            else
            {
                txtProdeckURL2.Text = "Not a Prodeck URL.";
            }
        }
        private void btnProdeckUnavailable2_Click(object sender, EventArgs e)
        {
            _MissingURL_CurrentProdeckMasterCardSelected.ProdeckURL = "Unavailable";
            checkProdeckEnableOverride2.Checked = false;
            //Remove this card from the list now!!
            Database.CardsWithoutProdeckURL.Remove(_MissingURL_CurrentProdeckMasterCardSelected.Name);
            //Reload the UI
            ReloadStats();
            //Add this card to the unavailable list
            Database.CardsWithUnavailableProdeckURL.Remove(_MissingURL_CurrentProdeckMasterCardSelected.Name);
        }
        //TCG Override Section
        private void checkTCGEnableOverride2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTCGEnableOverride2.Checked)
            {
                txtTCGURL2.Enabled = true;
                btnTCGOverride2.Visible = true;
                if (_MissingURL_CurrentSetCardSelected.TCGPlayerURLIsMissing())
                {
                    btnTCGUnavailable2.Visible = true;
                }
            }
            else
            {
                btnTCGOverride2.Visible = false;
                btnTCGUnavailable2.Visible = false;
                txtTCGURL2.Enabled = false;
                txtTCGURL2.Text = _MissingURL_CurrentSetCardSelected.TCGPlayerURL;
            }
        }
        private void btnTCGOverride2_Click(object sender, EventArgs e)
        {
            string input = txtTCGURL2.Text;
            if (input.StartsWith("https://tcgplayer") || input.StartsWith("https://www.tcgplayer.com/product/"))
            {
                //Valid ulr, proceed
                _MissingURL_CurrentSetCardSelected.TCGPlayerURL = input;
                checkTCGEnableOverride2.Checked = false;
                //Remove card from the TCG missing URL list if no missing urls left from this card
                if (_MissingURL_CurrentTCGMasterCardSelected.HasNoMissingTCGURLs())
                {
                    Database.CardsWithoutTCGURLs.Remove(_MissingURL_CurrentTCGMasterCardSelected.Name);
                }

                //Reload the Missing URL tab's UI
                LoadMissingURLsLists();
            }
            else
            {
                txtTCGURL2.Text = "Not a TCG Player URL.";
            }
        }
        private void btnTCGUnavailable2_Click(object sender, EventArgs e)
        {
            _MissingURL_CurrentSetCardSelected.TCGPlayerURL = "Unavailable";
            checkTCGEnableOverride2.Checked = false;
            //Remove this card from the list now!!
            Database.CardsWithoutTCGURLs.Remove(_MissingURL_CurrentTCGMasterCardSelected.Name);
            //Reload the UI
            ReloadStats();
            //Add this card to the unavailable list
            Database.CardsWithUnavailableTCGURLs.Remove(_MissingURL_CurrentTCGMasterCardSelected.Name);
        }
        #endregion
    }
}