//Joel Campos
//1/29/2024
//DatabaseManager Class

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YGO_Card_Collector_5

{
    public partial class DatabaseManager : Form
    {
        #region Constructors
        public DatabaseManager(FormLauncher mainmenuform)
        {
            InitializeComponent();
            _MainMenuForm = mainmenuform;
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

        private MasterCard _UnavaURL_CurrentProdeckMasterCardSelected;
        private MasterCard _UnavaURL_CurrentTCGMasterCardSelected;
        private SetCard _UnavaURL_CurrentSetCardSelected;

        private List<SetInfo> _CurrentSetInfoListSelected;
        private List<Label> _SetDetailsLabels = new List<Label>();

        private FormLauncher _MainMenuForm;
        #endregion

        #region Public Methods
        public void ReloadStats()
        {
            LoadMasterListStats();
            LoadGroupViewStats();
            LoadMissingURLsLists();
            LoadUnavailableURLsLists();
            LoadMissingCardsUrlsList();
            LoadSetsExplorer();
            LoadPriceReportLists();
        }
        #endregion

        #region Private Methods
        private void LoadMasterListStats()
        {
            lblTotalMasterCards.Text = Database.MasterCards.Count.ToString();
            lblTotalSetCards.Text = Database.SetCards.Count.ToString();

            lblTotalsAqua.Text = Database.GroupCardListByGroupName[CardGroup.Aqua_Monsters].Count.ToString();
            lblTotalsBeast.Text = Database.GroupCardListByGroupName[CardGroup.Beast_Monsters].Count.ToString();
            lblTotalsBeastWarrior.Text = Database.GroupCardListByGroupName[CardGroup.BeastWarrior_Monsters].Count.ToString();
            lblTotalsCyberse.Text = Database.GroupCardListByGroupName[CardGroup.Cyberse_Monsters].Count.ToString();
            lblTotalsDinosaur.Text = Database.GroupCardListByGroupName[CardGroup.Dinosaur_Monsters].Count.ToString();
            lblTotalsDivineBeast.Text = Database.GroupCardListByGroupName[CardGroup.DivineBeast_Monsters].Count.ToString();
            lblTotalsDragon.Text = Database.GroupCardListByGroupName[CardGroup.Dragon_Monsters].Count.ToString();
            lblTotalsFairy.Text = Database.GroupCardListByGroupName[CardGroup.Fairy_Monsters].Count.ToString();
            lblTotalsFiend.Text = Database.GroupCardListByGroupName[CardGroup.Fiend_Monsters].Count.ToString();
            lblTotalsFish.Text = Database.GroupCardListByGroupName[CardGroup.Fish_Monsters].Count.ToString();
            lblTotalsIllusion.Text = Database.GroupCardListByGroupName[CardGroup.IllusionType_Monsters].Count.ToString();
            lblTotalsInsect.Text = Database.GroupCardListByGroupName[CardGroup.Insect_Monsters].Count.ToString();
            lblTotalsMachine.Text = Database.GroupCardListByGroupName[CardGroup.Machine_Monsters].Count.ToString();
            lblTotalsPlant.Text = Database.GroupCardListByGroupName[CardGroup.Plant_Monsters].Count.ToString();
            lblTotalsPsychic.Text = Database.GroupCardListByGroupName[CardGroup.Psychic_Monsters].Count.ToString();
            lblTotalsPyro.Text = Database.GroupCardListByGroupName[CardGroup.Psychic_Monsters].Count.ToString();
            lblTotalsReptile.Text = Database.GroupCardListByGroupName[CardGroup.Reptile_Monsters].Count.ToString();
            lblTotalsRock.Text = Database.GroupCardListByGroupName[CardGroup.Rock_Monsters].Count.ToString();
            lblTotalsSeaSerpent.Text = Database.GroupCardListByGroupName[CardGroup.SeaSerpent_Monsters].Count.ToString();
            lblTotalsSpellcaster.Text = Database.GroupCardListByGroupName[CardGroup.Spellcaster_Monsters].Count.ToString();
            lblTotalsThunder.Text = Database.GroupCardListByGroupName[CardGroup.Thunder_Monsters].Count.ToString();
            lblTotalsWarrior.Text = Database.GroupCardListByGroupName[CardGroup.Warrior_Monsters].Count.ToString();
            lblTotalsWingedBeast.Text = Database.GroupCardListByGroupName[CardGroup.WingedBeast_Monsters].Count.ToString();
            lblTotalsWyrm.Text = Database.GroupCardListByGroupName[CardGroup.Wyrm_Monsters].Count.ToString();
            lblTotalsZombie.Text = Database.GroupCardListByGroupName[CardGroup.Zombie_Monsters].Count.ToString();
            lblTotalsNormalSpells.Text = Database.GroupCardListByGroupName[CardGroup.Normal_Spells].Count.ToString();
            lblTotalsContSpells.Text = Database.GroupCardListByGroupName[CardGroup.Continuous_Spells].Count.ToString();
            lblTotalsQuickSpells.Text = Database.GroupCardListByGroupName[CardGroup.QuickPlay_Spells].Count.ToString();
            lblTotalsEquipSpells.Text = Database.GroupCardListByGroupName[CardGroup.Equip_Spells].Count.ToString();
            lblTotalsFieldSpells.Text = Database.GroupCardListByGroupName[CardGroup.Field_Spells].Count.ToString();
            lblTotalsRitualSpells.Text = Database.GroupCardListByGroupName[CardGroup.Ritual_Spells].Count.ToString();
            lblTotalsNormalTraps.Text = Database.GroupCardListByGroupName[CardGroup.Normal_Spells].Count.ToString();
            lblTotalsContTraps.Text = Database.GroupCardListByGroupName[CardGroup.Continuous_Traps].Count.ToString();
            lblTotalsCounterTraps.Text = Database.GroupCardListByGroupName[CardGroup.Counter_Traps].Count.ToString();
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
                listTCGMissingURLs.Size = new System.Drawing.Size(408, 228);
                lblMissingTabArrow.Visible = false;
                lblMissingTabNote.Visible = false;
            }
            else
            {
                listTCGMissingURLs.Size = new System.Drawing.Size(200, 228);
                lblMissingTabArrow.Visible = true;
                lblMissingTabNote.Visible = true;
                foreach (string entry in Database.CardsWithoutTCGURLs) 
                {
                    listTCGMissingURLs.Items.Add(entry);
                }
            }
            listTCGMissingURLs.SetSelected(0, true);
        }       
        private void LoadUnavailableURLsLists()
        {
            //Prodeck lists
            listProdeckUnavailable.Items.Clear();
            if(Database.CardsWithUnavailableProdeckURL.Count == 0) 
            {
                listProdeckUnavailable.Items.Add("No Cards - Good Job! Database is up to date!");
            }
            else
            {
                foreach (string ThisCardsName in Database.CardsWithUnavailableProdeckURL)
                {
                    listProdeckUnavailable.Items.Add(ThisCardsName);

                }
            }           
            listProdeckUnavailable.SetSelected(0, true);



            listTCGUnavailableList.Items.Clear();
            if(Database.CardsWithUnavailableTCGURLs.Count == 0) 
            {
                listTCGUnavailableList.Items.Add("No Cards - Good Job! Database is up to date!");
                listTCGUnavailableURLsSets.Visible = false;
                listTCGUnavailableList.Size = new System.Drawing.Size(408, 228);
                lblMissingTabArrow2.Visible = false;
                lblMissingTabNote2.Visible = false;
            }
            else
            {
                listTCGUnavailableList.Size = new System.Drawing.Size(200, 228);
                lblMissingTabArrow2.Visible = true;
                lblMissingTabNote2.Visible = true;
                foreach (string ThisCardsName in Database.CardsWithUnavailableTCGURLs)
                {
                    listTCGUnavailableList.Items.Add(ThisCardsName);
                }
            }            
            listTCGUnavailableList.SetSelected(0, true);
        }
        private void LoadMissingCardsUrlsList()
        {
            StringBuilder sb = new StringBuilder();

            foreach(MasterCard ThisMasterCard in Database.MasterCards) 
            {
                int passcode = ThisMasterCard.ID;
               if(passcode != -1)
               {
                    //Check if the file exists
                    if (!File.Exists(Directory.GetCurrentDirectory() + "\\Images\\Cards\\" + passcode + ".jpg"))
                    {
                        sb.AppendLine("https://images.ygoprodeck.com/images/cards/" + passcode + ".jpg");
                    }

                }
            }

            if(sb.Length ==  0)
            {
                txtCardImagesURLoutput.Text = "NO Card Passcodes without Card Images, check this list once new Card Passcodes (IDs) are added to the DB.";
            }
            else
            {
                txtCardImagesURLoutput.Text = sb.ToString();
            }          
        }
        private void LoadSetsExplorer()
        {
            ListSetGroups.SetSelected(0, true);
        }
        private void LoadPriceReportLists()
        {
            //StringBuilder sb = new StringBuilder();
            List<SetCard> PriceList = new List<SetCard>();
            List<SetCard> PriceListMedian = new List<SetCard>();
            foreach (MasterCard ThisMasterCard in Database.MasterCards)
            {
                foreach(SetCard ThisSetCard in ThisMasterCard.SetCards) 
                {
                    if(ThisSetCard.Code != "")
                    {
                        PriceList.Add(ThisSetCard);
                        PriceListMedian.Add(ThisSetCard);
                    }                  
                }
            }

            PriceList.Sort(new SetCard.SortByPrice());
            PriceListMedian.Sort(new SetCard.SortByMedianPrice());

            //display the cards
            ListTop1000Report.Items.Clear();
            ListTop1000ReportMedian.Items.Clear();

            int marketPriceTotalValue = 0;
            int medianPriceTotalValue = 0;
            foreach(SetCard ThisSetCard in PriceList)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                string obtainedmark = "";
                if (ThisSetCard.Obtained) { obtainedmark = "- [x] "; }
                ListTop1000Report.Items.Add(string.Format("[{0}] {1}- [{2} | {3}] - {4}", ThisSetCard.MarketPrice, obtainedmark, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                marketPriceTotalValue += (int)ThisSetCard.GetDoubleMarketPrice();
            }
            foreach (SetCard ThisSetCard in PriceListMedian)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                string obtainedmark = "";
                if (ThisSetCard.Obtained) { obtainedmark = "- [x] "; }
                ListTop1000ReportMedian.Items.Add(string.Format("[{0}] {1}- [{2} | {3}] - {4}", ThisSetCard.MediamPrice, obtainedmark, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                medianPriceTotalValue += (int)ThisSetCard.GetDoubleMarketPrice();
            }

            lblMarketPriceTotalValue.Text = string.Format("Total Value: ${0}", marketPriceTotalValue.ToString());
            lblMedianPriceTotalValue.Text = string.Format("Total Value: ${0}", medianPriceTotalValue.ToString());
        }        
        #endregion

        #region Automation Scrips Methods
        //Konami Card List Update Methods
        private void UpdateKomaniDB(CardGroup TestGroup, int startIndex)
        {
            #region JOB #1 SETUP (Konami Card List Update)
            //Timer
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();

            //Log
            Driver.AddToFullLog("---UPDATE ENTIRE DB---");
            DBUpdateform.SetOutputMessage("Extracting Current Konami Card List...");

            //Launch the Chrome Driver to update Konami's Card list only (For the entire DB)
            Driver.OpenBrowser();

            //Open Konami's Card Search Page
            Driver.GoToKonamiSearchPage();
            KonamiSearchPage.WaitUntilPageIsLoaded();

            //Clear Cookies Banner
            KonamiSearchPage.AcceptCookiesBanner();

            //Search for the Card Group
            //KonamiSearchPage.SearchCardGroup(CardGroup.AllCards);
            KonamiSearchPage.SearchCardGroup(TestGroup);

            //Extract how many cards in total are in this group
            int totalCards = KonamiCardListPage.GetCardListTotalCards();
            Driver.AddToFullLog(string.Format("Total Card Count Konami's DB: {0}", totalCards));
            DBUpdateform.SetTotalCardsToScan(totalCards);
            #endregion

            #region JOB #1: KONAMI CARD LIST UPDATE
            //Test Start at Konami's Card List Page
            int totalPages = KonamiCardListPage.GetPageCount();
            Dictionary<string, string> CardList = new Dictionary<string, string>();
            for (int x = 1; x <= totalPages; x++)
            {
                DBUpdateform.SetOutputMessage(string.Format("Extracting Card Names on Page {0}/{1}", x, totalPages));
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
            DBUpdateform.SetTotalCardsToScan(CardList.Count);
            Driver.AddToFullLog("----------------------------------");

            //Now Access each individual Card
            int NewCardsCounter = 0;
            int CardsWithNewSetCardsCounter = 0;
            for (int i = startIndex; i < CardList.Count; i++)
            {
                StringBuilder sb = new StringBuilder();

                //set the card name for readibility and use
                string CardName = CardList.ElementAt(i).Key;
                string KomaniURL = "https://www.db.yugioh-card.com/" + CardList.ElementAt(i).Value;
                sb.Append(string.Format("Index: [{0}] | Card Name: {1}|", i, CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                        CardsWithNewSetCardsCounter++;

                        int NewSetCardsAmount = SetCardsInPage - SetCardsInDB;

                        sb.Append(string.Format("New Set Cards found: {0}|", NewSetCardsAmount));
                        StringBuilder updatesLogssb = new StringBuilder();
                        updatesLogssb.Append(string.Format("EXISTING MASTERCARD: {0} | NEW SETCARDS:", CardName));
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
                            updatesLogssb.Append(string.Format("[{0}|{1}]", code, rarity));
                        }
                        updatesLogssb.AppendLine("");
                        Driver.AddToUpdatesLog(updatesLogssb.ToString());
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
                    NewCardsCounter++;

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
                    StringBuilder updatesLogssb = new StringBuilder();
                    updatesLogssb.Append(string.Format("NEW MASTERCARD: {0} | SETCARDS:", CardName));
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
                        updatesLogssb.Append(string.Format("[{0}|{1}]", code, rarity));
                    }
                    updatesLogssb.AppendLine("");
                    Driver.AddToUpdatesLog(updatesLogssb.ToString());

                    //Add the Card to the DB
                    Database.AddNewCardToDB(NewCARD);
                }

                Driver.AddToFullLog(sb.ToString());
            }
            #endregion

            #region JOB #1 END
            DBUpdateform.SendJobFinishSignal();
            Driver.AddToFullLog(string.Format("New Cards Found: {0}", NewCardsCounter));
            Driver.AddToFullLog(string.Format("Cards with new Sets Found: {0}", CardsWithNewSetCardsCounter));
            Driver.AddToFullLog("----------------------------------");
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
            #endregion
        }
        private void SearchMissingURLs(List<string> CardsWithoutProdeckURL, List<string> CardsWithoutTCGURLs)
        {
            #region JOB #2 SETUP
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            Driver.AddToFullLog("--------------Missing Prodeck URLs---------------------");
            //Set the total cards to scan; total = missingproeckurlscard.count + missingTCGUrlsCards.count
            int misingURLTotalCardCount = CardsWithoutProdeckURL.Count + CardsWithoutTCGURLs.Count;
            DBUpdateform.SetTotalCardsToScan(misingURLTotalCardCount);
            #endregion

            #region JOB #2: MISSING URLs SEARCH          
            //Perform a manual Prodeck search to obtain URLs and Passcodes
            List<string> ProdeckUpdateSuccessList = new List<string>();
            foreach (string CardName in CardsWithoutProdeckURL)
            {
                //Open Prodeck Advance Search Page up
                Driver.GoToProdeckSearchPage();
                ProDeckCardSearchPage.WaitUntilPageIsLoaded();

                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Card:{0} | ", CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                    ProdeckUpdateSuccessList.Add(CardName);
                    sb.Append("Prodeck URL saved!");
                    Driver.AddToUpdatesLog(string.Format("New PRODECK URL and PASSCODE Set for Card: {0}", CardName));
                }
                else
                {
                    sb.Append("Prodeck search failed!");
                }

                //Log it and send the card completion signal
                Driver.AddToFullLog(sb.ToString());
            }
            //Remove the the CardsWithoutProdeckURL list any card in the Success List
            foreach (string CardName in ProdeckUpdateSuccessList)
            {
                Database.CardsWithoutProdeckURL.Remove(CardName);
            }

            Driver.AddToFullLog("--------------Missing TCG Player URLs---------------------");

            //Now search for the TCG Player URLs
            List<string> successListTCG = new List<string>();
            foreach (string CardName in CardsWithoutTCGURLs)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Card:{0}", CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                    foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
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
                                    bool PageLoadedCorrectly = TCGCardInfoPage.WaitUntilPageIsLoaded(true);

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
                                            if (ThisMasterCard.HasNoMissingTCGURLs())
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

                                if (MathcURLFound)
                                {
                                    //Break the loop and move to the next code                                    
                                    break;
                                }
                            }

                            if (MathcURLFound)
                            {
                                sb.AppendLine("Match URL FOUND!!!");
                                Driver.AddToUpdatesLog(string.Format("TCG Player URL extracted for SetCard: [{0}|{1}] - {2}", ThisSetCard.Code, ThisSetCard.Rarity, CardName));
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

                //Log it
                Driver.AddToFullLog(sb.ToString());
            }
            //Post run, remove the sucess searches from the CardsWithoutTCGkURL list
            foreach (string cardname in successListTCG)
            {
                Database.CardsWithoutTCGURLs.Remove(cardname);
            }
            #endregion

            #region JOB #3 END
            DBUpdateform.SendJobFinishSignal();
            Driver.AddToFullLog(string.Format("Prodeck URLs and Passcodes Found: {0}", ProdeckUpdateSuccessList.Count));
            Driver.AddToFullLog(string.Format("TCG Player URLs Found: {0}", successListTCG.Count));
            Driver.AddToFullLog("----------------------------------");
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
            #endregion
        }
        private void UpdatePrices(CardGroup TestGroup, int startIndex)
        {
            #region JOB #3 SETUP
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region JOB #3: Prices Update
            List<MasterCard> PriceUpdateTestGroup = Database.GroupCardListByGroupName[TestGroup];

            DBUpdateform.SetTotalCardsToScan(PriceUpdateTestGroup.Count);

            int PriceUpdateCounter = 0;
            //Scan each set card for each master card
            for (int i = startIndex; i < PriceUpdateTestGroup.Count; i++)
            {
                //Set the MasterCard for quick access
                MasterCard ThisMasterCard = PriceUpdateTestGroup[i];

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Index: [{0}] | Card:{1}", i, ThisMasterCard.Name));
                DBUpdateform.SendCardStartSignal(ThisMasterCard.Name);

                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    sb.Append(string.Format("Code:{0} Rarity: {1} | ", ThisSetCard.Code, ThisSetCard.Rarity));

                    try
                    {
                        if (ThisSetCard.HasTCGURL())
                        {
                            //Go to the test URL
                            Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                            TCGCardInfoPage.WaitUntilPageIsLoaded(false);

                            //Update prices since
                            string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                            string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                            ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                            sb.AppendLine("Prices Update!");
                            PriceUpdateCounter++;
                        }
                        else
                        {
                            if (ThisSetCard.TCGPlayerURLIsUnavailable()) { sb.AppendLine("URL Is Unavailable."); }
                            if (ThisSetCard.TCGPlayerURLIsMissing()) { sb.AppendLine("URL is Missing."); }

                        }
                    }
                    catch (Exception)
                    {
                        sb.AppendLine("Unhandled exception occurred, skipping this SetCard");
                    }
                }

                sb.AppendLine("---------------------------");
                Driver.AddToFullLog(sb.ToString());
            }
            #endregion

            #region JOB #3 END
            DBUpdateform.SendJobFinishSignal();
            Driver.AddToFullLog(string.Format("SetCards with Successful Price Update: {0}", PriceUpdateCounter));
            Driver.AddToFullLog("----------------------------------");
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
            #endregion
        }
        private void UpdateSetPrices(List<SetCard> CardList)
        {
            #region JOB #3 SETUP
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region JOB #3: Prices Update
            DBUpdateform.SetTotalCardsToScan(CardList.Count);
            int PriceUpdateCounter = 0;
            foreach (SetCard ThisSetCard in CardList)
            {
                DBUpdateform.SendCardStartSignal(ThisSetCard.GetCardName());
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Code:{0} Rarity: {1} | ", ThisSetCard.Code, ThisSetCard.Rarity));

                try
                {
                    if (ThisSetCard.HasTCGURL())
                    {
                        //Go to the test URL
                        Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                        TCGCardInfoPage.WaitUntilPageIsLoaded(false);

                        //Update prices since
                        string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                        string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                        ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                        sb.AppendLine("Prices Update!");
                        PriceUpdateCounter++;
                    }
                    else
                    {
                        if (ThisSetCard.TCGPlayerURLIsUnavailable()) { sb.AppendLine("URL Is Unavailable."); }
                        if (ThisSetCard.TCGPlayerURLIsMissing()) { sb.AppendLine("URL is Missing."); }

                    }
                }
                catch (Exception)
                {
                    sb.AppendLine("Unhandled exception occurred, skipping this SetCard");
                }

                Driver.AddToFullLog(sb.ToString());
                Driver.AddToUpdatesLog(sb.ToString());
            }
            #endregion

            #region JOB #3 END
            DBUpdateform.SendJobFinishSignal();
            Driver.AddToFullLog(string.Format("SetCards with Successful Price Update: {0}", PriceUpdateCounter));
            Driver.AddToFullLog("----------------------------------");
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
            #endregion
        }
        private void UpdatePricesDB_RarityCheck(CardGroup Group, int startIndex)
        {
            //START
            Driver.ClearLogs();
            var watch = new Stopwatch();
            watch.Start();

            //Setup
            //TODO: FIX TEST_SETUP_UpdatePrices();

            //Set the cardlist
            List<MasterCard> TestCardList = Database.GroupCardListByGroupName[Group];

            //Scan each set card for each master card
            for (int i = startIndex; i < TestCardList.Count; i++)
            {
                //Set the MasterCard for quick access
                MasterCard ThisMasterCard = TestCardList[i];

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Index: [{0}] | Card:{1}", i, ThisMasterCard.Name));
                DBUpdateform.SendCardStartSignal(ThisMasterCard.Name);

                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    sb.Append(string.Format("Code:{0} Rarity: {1} | ", ThisSetCard.Code, ThisSetCard.Rarity));

                    try
                    {
                        if (ThisSetCard.HasTCGURL())
                        {
                            //Go to the test URL
                            Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                            TCGCardInfoPage.WaitUntilPageIsLoaded(true);

                            //If the page corresponds to the code AND Rarity, then extract its price
                            string CodeInPage = TCGCardInfoPage.GetCode();
                            string RarityInPage = TCGCardInfoPage.GetRarity();
                            if (ThisSetCard.Code == CodeInPage && Tools.CompareInLowerCase(ThisSetCard.Rarity, RarityInPage))
                            {
                                //Update prices since
                                string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                                sb.AppendLine("Prices Update!");
                            }
                            else
                            {
                                //Found a card with code/rarity not matching
                                Database.TCGPagesThatDidntMatchRarity.Add(ThisMasterCard.Name + "|" + ThisSetCard.Code + "|" + ThisSetCard.Rarity + "|" + ThisSetCard.TCGPlayerURL);
                                sb.AppendLine("Code/Rarity didnt match, flagging the card|");
                            }

                                
                        }
                        else
                        {
                            if (ThisSetCard.TCGPlayerURLIsUnavailable()) { sb.AppendLine("URL Is Unavailable."); }
                            if (ThisSetCard.TCGPlayerURLIsMissing()) { sb.AppendLine("URL is Missing."); }

                        }
                    }
                    catch (Exception)
                    {
                        sb.AppendLine("Unhandled exception occurred, skipping this SetCard");
                    }
                }

                sb.AppendLine("---------------------------");
                Driver.AddToFullLog(sb.ToString());
            }

            //END
            Driver.CloseDriver();
            watch.Stop();
            Driver.AddToFullLog($"Execution Time for WHOLE Script was: {watch.Elapsed}");
            DBUpdateform.SendFullCompletionSignal();
            WriteOutputFiles();

            //Save TCG rarity matching list
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\TCGRecordsThatDidntMathcRarity.txt", Database.TCGPagesThatDidntMatchRarity);

        }
        private void UpdateEntireDatabase(CardGroup TestGroup)
        {
            //Start
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();

            //-----------------------------------------------------------

            # region JOB #1 SETUP (Konami Card List Update)
            //Log
            Driver.AddToFullLog("---UPDATE ENTIRE DB---");
            DBUpdateform.SetOutputMessage("Extracting Current Konami Card List...");

            //Launch the Chrome Driver to update Konami's Card list only (For the entire DB)
            Driver.OpenBrowser();

            //Open Konami's Card Search Page
            Driver.GoToKonamiSearchPage();
            KonamiSearchPage.WaitUntilPageIsLoaded();

            //Clear Cookies Banner
            KonamiSearchPage.AcceptCookiesBanner();

            //Search for the Card Group
            //KonamiSearchPage.SearchCardGroup(CardGroup.AllCards);
            KonamiSearchPage.SearchCardGroup(TestGroup);

            //Extract how many cards in total are in this group
            int totalCards = KonamiCardListPage.GetCardListTotalCards();
            Driver.AddToFullLog(string.Format("Total Card Count Konami's DB: {0}", totalCards));
            DBUpdateform.SetTotalCardsToScan(totalCards);
            #endregion

            #region JOB #1: KONAMI CARD LIST UPDATE
            DBUpdateform.SendJobStartSignal("Job 1/3: Updating Konami Card List");
            //Test Start at Konami's Card List Page
            int totalPages = KonamiCardListPage.GetPageCount();
            var CardListExtractionwatch = new Stopwatch();
            CardListExtractionwatch.Start();
            Dictionary<string, string> CardList = new Dictionary<string, string>();            
            for (int x = 1; x <= totalPages; x++)
            {
                DBUpdateform.SetOutputMessage(string.Format("Extracting Card Names on Page {0}/{1}",x,totalPages));
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
            CardListExtractionwatch.Stop();
            DBUpdateform.SetTotalCardsToScan(CardList.Count);
            Driver.AddToFullLog($"Execution Time for Card List Name Extraction was: {CardListExtractionwatch.Elapsed}");
            Driver.AddToFullLog("----------------------------------");

            //Now Access each individual Card
            var CardListUpdatewatch = new Stopwatch();
            CardListUpdatewatch.Start();
            int NewCardsCounter = 0;
            int CardsWithNewSetCardsCounter = 0;
            for(int i = 0; i < CardList.Count; i++)
            {               
                StringBuilder sb = new StringBuilder();

                //set the card name for readibility and use
                string CardName = CardList.ElementAt(i).Key;
                string KomaniURL = "https://www.db.yugioh-card.com/" + CardList.ElementAt(i).Value;                            
                sb.Append(string.Format("Index: [{0}] | Card Name: {1}|", i, CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                        CardsWithNewSetCardsCounter++;

                        int NewSetCardsAmount = SetCardsInPage - SetCardsInDB;

                        sb.Append(string.Format("New Set Cards found: {0}|", NewSetCardsAmount));
                        StringBuilder updatesLogssb = new StringBuilder();
                        updatesLogssb.Append(string.Format("EXISTING MASTERCARD: {0} | NEW SETCARDS:", CardName));
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
                            updatesLogssb.Append(string.Format("[{0}|{1}]", code, rarity));                            
                        }
                        updatesLogssb.AppendLine("");
                        Driver.AddToUpdatesLog(updatesLogssb.ToString());
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
                    NewCardsCounter++;

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
                    StringBuilder updatesLogssb = new StringBuilder();
                    updatesLogssb.Append(string.Format("NEW MASTERCARD: {0} | SETCARDS:", CardName));
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
                        updatesLogssb.Append(string.Format("[{0}|{1}]", code, rarity));
                    }
                    updatesLogssb.AppendLine("");
                    Driver.AddToUpdatesLog(updatesLogssb.ToString());

                    //Add the Card to the DB
                    Database.AddNewCardToDB(NewCARD);
                }

                Driver.AddToFullLog(sb.ToString());
            }
            #endregion

            #region JOB #1 END
            DBUpdateform.SendJobFinishSignal();
            CardListUpdatewatch.Stop();
            Driver.AddToFullLog(">>>>>>>>>>>>>>>>>>>Konami Card List Update Finished<<<<<<<<<<<<<<<<<<<<<<<<<");
            Driver.AddToFullLog($"Execution Time for Card List DB Update was: {CardListUpdatewatch.Elapsed}");
            Driver.AddToFullLog("----------------------------------");
            #endregion

            //-----------------------------------------------------------

            #region JOB #2: MISSING URLs SEARCH
            DBUpdateform.SendJobStartSignal("Job 2/3: Updating Prodeck and TCG URLs");
            var URLsUpdatewatch = new Stopwatch();
            URLsUpdatewatch.Start();

            Driver.AddToFullLog("--------------Missing Prodeck URLs---------------------");
            //Set the total cards to scan; total = missingproeckurlscard.count + missingTCGUrlsCards.count
            int misingURLTotalCardCount = Database.CardsWithoutProdeckURL.Count + Database.CardsWithoutTCGURLs.Count;
            DBUpdateform.SetTotalCardsToScan(misingURLTotalCardCount);

            //Perform a manual Prodeck search to obtain URLs and Passcodes
            List<string> ProdeckUpdateSuccessList = new List<string>();
            foreach (string CardName in Database.CardsWithoutProdeckURL)
            {
                //Open Prodeck Advance Search Page up
                Driver.GoToProdeckSearchPage();
                ProDeckCardSearchPage.WaitUntilPageIsLoaded();

                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Card:{0} | ", CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                    ProdeckUpdateSuccessList.Add(CardName);
                    sb.Append("Prodeck URL saved!");
                    Driver.AddToUpdatesLog(string.Format("New PRODECK URL and PASSCODE Set for Card: {0}", CardName));
                }
                else
                {
                    sb.Append("Prodeck search failed!");
                }

                //Log it and send the card completion signal
                Driver.AddToFullLog(sb.ToString());
            }      
            //Remove the the CardsWithoutProdeckURL list any card in the Success List
            foreach(string CardName in ProdeckUpdateSuccessList) 
            {
                Database.CardsWithoutProdeckURL.Remove(CardName);
            }

            Driver.AddToFullLog("--------------Missing TCG Player URLs---------------------");

            //Now search for the TCG Player URLs
            List<string> successListTCG = new List<string>();
            foreach (string CardName in Database.CardsWithoutTCGURLs)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Card:{0}", CardName));
                DBUpdateform.SendCardStartSignal(CardName);

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
                    foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
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
                                    bool PageLoadedCorrectly = TCGCardInfoPage.WaitUntilPageIsLoaded(true);

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
                                            if (ThisMasterCard.HasNoMissingTCGURLs())
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

                                if (MathcURLFound)
                                {
                                    //Break the loop and move to the next code                                    
                                    break;
                                }
                            }

                            if (MathcURLFound)
                            {
                                sb.AppendLine("Match URL FOUND!!!");
                                Driver.AddToUpdatesLog(string.Format("TCG Player URL extracted for SetCard: [{0}|{1}] - {2}", ThisSetCard.Code, ThisSetCard.Rarity, CardName));
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

                //Log it
                Driver.AddToFullLog(sb.ToString());
            }
            //Post run, remove the sucess searches from the CardsWithoutTCGkURL list
            foreach (string cardname in successListTCG)
            {
                Database.CardsWithoutTCGURLs.Remove(cardname);
            }

            //Log end results
            DBUpdateform.SendJobFinishSignal();
            URLsUpdatewatch.Stop();
            Driver.AddToFullLog(">>>>>>>>>>>>>>>>>>>Missing URLs Update Finished<<<<<<<<<<<<<<<<<<<<<<<<<");
            Driver.AddToFullLog($"Execution Time for Missing URLs Extraction was: {URLsUpdatewatch.Elapsed}");
            Driver.AddToFullLog("----------------------------------");
            #endregion

            #region JOB #3: Prices Update
            DBUpdateform.SendJobStartSignal("Job 3/3: All Cards' Prices");
            var PricesUpdatewatch = new Stopwatch();
            PricesUpdatewatch.Start();

            List<MasterCard> PriceUpdateTestGroup = Database.GroupCardListByGroupName[TestGroup];

            DBUpdateform.SetTotalCardsToScan(PriceUpdateTestGroup.Count);

            int PriceUpdateCounter = 0;
            //Scan each set card for each master card
            for (int i = 0; i < PriceUpdateTestGroup.Count; i++)
            {
                //Set the MasterCard for quick access
                MasterCard ThisMasterCard = PriceUpdateTestGroup[i];

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Index: [{0}] | Card:{1}", i, ThisMasterCard.Name));
                DBUpdateform.SendCardStartSignal(ThisMasterCard.Name);

                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    sb.Append(string.Format("Code:{0} Rarity: {1} | ", ThisSetCard.Code, ThisSetCard.Rarity));

                    try
                    {
                        if (ThisSetCard.HasTCGURL())
                        {
                            //Go to the test URL
                            Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                            TCGCardInfoPage.WaitUntilPageIsLoaded(false);

                            //Update prices since
                            string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                            string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                            ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                            sb.AppendLine("Prices Update!");
                            PriceUpdateCounter++;
                        }
                        else
                        {
                            if (ThisSetCard.TCGPlayerURLIsUnavailable()) { sb.AppendLine("URL Is Unavailable."); }
                            if (ThisSetCard.TCGPlayerURLIsMissing()) { sb.AppendLine("URL is Missing."); }

                        }
                    }
                    catch (Exception)
                    {
                        sb.AppendLine("Unhandled exception occurred, skipping this SetCard");
                    }
                }

                sb.AppendLine("---------------------------");
                Driver.AddToFullLog(sb.ToString());
            }

            //Log end results
            Driver.AddToUpdatesLog(string.Format("{0} SetCards' Prices have been updated!!", PriceUpdateCounter));
            PricesUpdatewatch.Stop();
            Driver.AddToFullLog(">>>>>>>>>>>>>>>>>>>Prices Update Finished<<<<<<<<<<<<<<<<<<<<<<<<<");
            Driver.AddToFullLog($"Execution Time for Prices Update was: {PricesUpdatewatch.Elapsed}");
            Driver.AddToFullLog("----------------------------------");
            #endregion

            //END
            Driver.AddToFullLog(string.Format("New Cards Found: {0}", NewCardsCounter));
            Driver.AddToFullLog(string.Format("Cards with new Sets Found: {0}", CardsWithNewSetCardsCounter));
            Driver.AddToFullLog(string.Format("Prodeck URLs and Passcodes Found: {0}", ProdeckUpdateSuccessList.Count));
            Driver.AddToFullLog(string.Format("TCG Player URLs Found: {0}", successListTCG.Count));
            Driver.AddToFullLog(string.Format("SetCards with Successful Price Update: {0}", PriceUpdateCounter));
            Driver.AddToFullLog("----------------------------------");
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
        }
        private void WriteOutputFiles()
        {
            //save the log file
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\FullLOG.txt", Driver.GetFullLogs());
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\UpdateLOG.txt", Driver.GetUpdateLogs());
          
            //Save the New JSON DB
            Database.SaveDatabaseInJSON();

            //Reload the entire UI stats and such
            ReloadStats();
        }
        #endregion

        #region Event Listeners (Master Card List Total Tab)
        private void btnUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            UpdateKomaniDB(CardGroup.AllCards, 0);
        }
        private void btnExtractURLs_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            SearchMissingURLs(Database.CardsWithoutProdeckURL, Database.CardsWithoutTCGURLs);
        }
        private void btnUpdatePrices_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            UpdatePrices(CardGroup.AllCards, 0);
        }
        private void btnUpdateFullDB_Click(object sender, EventArgs e)
        {
            //RUN THE WHOLE EFFING THING
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            try 
            {
                UpdateEntireDatabase(CardGroup.AllCards);
            }
            catch(Exception ex) 
            {
                //If anything unhandle happens still write out the current data
                Driver.AddToFullLog("An unhandle exception happened...");
                Driver.AddToFullLog("Review exception below:");               
                Driver.AddToFullLog("Message: "+ ex.Message);
                Driver.AddToFullLog("Stack Trace: "+ ex.StackTrace);
                WriteOutputFiles();
            }

            DBUpdateform.SendFullCompletionSignal();

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
        //Update Buttons
        private void btnGroupUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            UpdateKomaniDB(_CurrentSelectedCardGroup, 0);
        }
        private void btnGroupUpdateURLs_Click(object sender, EventArgs e)
        {
            //Generate the test list
            List<string> CardsWithoutProdeckURL = new List<string>();
            List<string> CardsWithoutTCGURLs = new List<string>();

            List<MasterCard> TestCardList = Database.GroupCardListByGroupName[_CurrentSelectedCardGroup];
            foreach (MasterCard ThisMasterCard in TestCardList)
            {
                if (ThisMasterCard.ProdeckURLIsMissing()) { CardsWithoutProdeckURL.Add(ThisMasterCard.Name); }

                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    if (ThisSetCard.Code != "")
                    {
                        if (ThisSetCard.TCGPlayerURLIsMissing()) { CardsWithoutTCGURLs.Add(ThisMasterCard.Name); }
                    }
                }
            }

            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();
            SearchMissingURLs(CardsWithoutProdeckURL, CardsWithoutTCGURLs);
        }
        private void btnGroupUpdatePrices_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            UpdatePrices(_CurrentSelectedCardGroup, 0);
            //UpdatePricesDB_RarityCheck(_CurrentSelectedCardGroup, 0);
        }
        private void btnUpdateFullGroup_Click(object sender, EventArgs e)
        {
            //RUN THE WHOLE EFFING THING (For the current group)
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            try
            {
                UpdateEntireDatabase(_CurrentSelectedCardGroup);
            }
            catch (Exception ex)
            {
                //If anything unhandle happens still write out the current data
                Driver.AddToFullLog("An unhandle exception happened...");
                Driver.AddToFullLog("Review exception below:");
                Driver.AddToFullLog("Message: " + ex.Message);
                Driver.AddToFullLog("Stack Trace: " + ex.StackTrace);
                WriteOutputFiles();
            }

            DBUpdateform.SendFullCompletionSignal();
        }
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
                    //Update DB file
                    Database.SaveDatabaseInJSON();
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
                //Update DB file
                Database.SaveDatabaseInJSON();
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
            //Update DB file
            Database.SaveDatabaseInJSON();
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
                //Update DB file
                Database.SaveDatabaseInJSON();
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
            //Update DB file
            Database.SaveDatabaseInJSON();
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
                txtPasscode2.Text = _MissingURL_CurrentProdeckMasterCardSelected.ID.ToString();
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
                    //Update DB file
                    Database.SaveDatabaseInJSON();
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
                //Update DB file
                Database.SaveDatabaseInJSON();
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
            //Update DB file
            Database.SaveDatabaseInJSON();
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

                //Reload stats
                ReloadStats();
                //Update DB file
                Database.SaveDatabaseInJSON();
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
            //Update DB file
            Database.SaveDatabaseInJSON();
        }
        #endregion

        #region Event Listeners (Unavailable URLs Tab)
        //3 List Containers
        private void listProdeckUnavailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cardname = listProdeckUnavailable.Text;

            if (cardname != "No Cards - Good Job! Database is up to date!")
            {
                _UnavaURL_CurrentProdeckMasterCardSelected = Database.GetCard(cardname);
                txtPasscode3.Text = _UnavaURL_CurrentProdeckMasterCardSelected.ID.ToString();
                GroupUnavailableProdeckOverride.Visible = true;

                //set up the override UI
                txtPasscode3.Text = _UnavaURL_CurrentProdeckMasterCardSelected.ID.ToString();
                txtProdeckURL3.Text = _UnavaURL_CurrentProdeckMasterCardSelected.ProdeckURL;
                //set the checks to false to lock fields at start
                checkPasscodeEnableOverride3.Checked = false;
                checkProdeckEnableOverride3.Checked = false;
                //but the passcode overide should be hiden if the card has already a set Passcode
                if (_UnavaURL_CurrentProdeckMasterCardSelected.ID == -1)
                {
                    lblMisingPasscodeWarning3.Visible = true;
                    checkPasscodeEnableOverride3.Visible = true;
                    //disable prodeck
                    checkProdeckEnableOverride3.Visible = false;
                }
                else
                {
                    lblMisingPasscodeWarning3.Visible = false;
                    checkPasscodeEnableOverride3.Visible = false;
                    //enable prodeck
                    checkProdeckEnableOverride3.Visible = true;
                }
            }
            else
            {
                GroupUnavailableProdeckOverride.Visible = false;
            }
        }
        private void listTCGUnavailableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cardname = listTCGUnavailableList.Text;

            if (cardname != "No Cards - Good Job! Database is up to date!")
            {
                //Populate the set card list
                listTCGUnavailableURLsSets.Items.Clear();
                _UnavaURL_CurrentTCGMasterCardSelected = Database.GetCard(cardname);

                foreach (SetCard ThisSetCard in _UnavaURL_CurrentTCGMasterCardSelected.SetCards)
                {
                    string item = ThisSetCard.Code + "|" + ThisSetCard.Rarity;
                    if (ThisSetCard.TCGPlayerURLIsUnavailable())
                    {
                        item = "[!] - " + item;
                    }
                    listTCGUnavailableURLsSets.Items.Add(item);
                }

                listTCGUnavailableURLsSets.SetSelected(0, true);
            }
            else
            {
                GroupUnavailableTCGOverride.Visible = false;
            }
        }
        private void listTCGUnavailableURLsSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int setCardIndex = listTCGUnavailableURLsSets.SelectedIndex;

            _UnavaURL_CurrentSetCardSelected = _UnavaURL_CurrentTCGMasterCardSelected.GetCardAtIndex(setCardIndex);

            if (_UnavaURL_CurrentSetCardSelected.TCGPlayerURLIsUnavailable())
            {
                //Diplay the override submenu
                GroupUnavailableTCGOverride.Visible = true;

                txtTCGURL3.Text = _UnavaURL_CurrentSetCardSelected.TCGPlayerURL;
                checkTCGEnableOverride3.Checked = false;
            }
            else
            {
                GroupUnavailableTCGOverride.Visible = false;
            }
        }
        //Passcode Overide Section
        private void checkPasscodeEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPasscodeEnableOverride3.Checked)
            {
                txtPasscode3.Enabled = true;
                btnPasscodeOverride3.Visible = true;
            }
            else
            {
                txtPasscode3.Text = _UnavaURL_CurrentProdeckMasterCardSelected.ID.ToString();
                txtPasscode3.Enabled = false;
                btnPasscodeOverride3.Visible = false;
            }
        }
        private void btnPasscodeOverride3_Click(object sender, EventArgs e)
        {
            //overide if the input is not -1 or a non-numeric
            string input = txtPasscode3.Text;
            if (input == "-1")
            {
                //invalid value
                txtPasscode3.Text = "Invalid ID input. Must be numeric and not -1";
            }
            else
            {
                try
                {
                    int idinput = Convert.ToInt32(input);
                    _UnavaURL_CurrentProdeckMasterCardSelected.ID = idinput;
                    //Success, update the UI
                    checkPasscodeEnableOverride3.Checked = false;
                    checkPasscodeEnableOverride3.Visible = false;
                    lblMisingPasscodeWarning3.Visible = false;
                    checkProdeckEnableOverride3.Visible = true;
                    //Update DB file
                    Database.SaveDatabaseInJSON();
                }
                catch (Exception)
                {
                    txtPasscode3.Text = "Invalid ID input. Must be numeric and not -1";
                }
            }
        }
        //Prodeck Override Section
        private void checkProdeckEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkProdeckEnableOverride3.Checked)
            {
                txtProdeckURL3.Enabled = true;
                btnProdeckOverride3.Visible = true;
            }
            else
            {
                btnProdeckOverride3.Visible = false;
                txtProdeckURL3.Enabled = false;
                txtProdeckURL3.Text = _UnavaURL_CurrentProdeckMasterCardSelected.ProdeckURL;
            }
        }
        private void btnProdeckOverride3_Click(object sender, EventArgs e)
        {
            string input = txtProdeckURL3.Text;
            if (input.StartsWith("https://ygoprodeck.com/card/"))
            {
                //Valid ulr, proceed
                _UnavaURL_CurrentProdeckMasterCardSelected.ProdeckURL = input;
                checkProdeckEnableOverride3.Checked = false;
                //Remove this card from the list now!!
                Database.CardsWithUnavailableProdeckURL.Remove(_UnavaURL_CurrentProdeckMasterCardSelected.Name);
                //Reload the UI
                ReloadStats();
                //Update DB file
                Database.SaveDatabaseInJSON();
            }
            else
            {
                txtProdeckURL3.Text = "Not a Prodeck URL.";
            }
        }
        //TCG Override Section
        private void checkTCGEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTCGEnableOverride3.Checked)
            {
                txtTCGURL3.Enabled = true;
                btnTCGOverride3.Visible = true;
            }
            else
            {
                btnTCGOverride3.Visible = false;
                txtTCGURL3.Enabled = false;
                txtTCGURL3.Text = _UnavaURL_CurrentSetCardSelected.TCGPlayerURL;
            }
        }
        private void btnTCGOverride3_Click(object sender, EventArgs e)
        {
            string input = txtTCGURL3.Text;
            if (input.StartsWith("https://tcgplayer") || input.StartsWith("https://www.tcgplayer.com/product/"))
            {
                //Valid ulr, proceed
                _UnavaURL_CurrentSetCardSelected.TCGPlayerURL = input;
                checkTCGEnableOverride3.Checked = false;
                //Remove card from the TCG Unavaliable URL list if no missing urls left from this card
                if (_UnavaURL_CurrentTCGMasterCardSelected.HasNoNnavaliableTCGURLs())
                {
                    Database.CardsWithUnavailableTCGURLs.Remove(_UnavaURL_CurrentTCGMasterCardSelected.Name);
                }

                //reload stats
                ReloadStats();
                //Update DB file
                Database.SaveDatabaseInJSON();
            }
            else
            {
                txtTCGURL3.Text = "Not a TCG Player URL.";
            }
        }
        #endregion

        #region Event Listeners (URLs For Missing Card Images Tab)
        private void btnRefreshImagesURLS_Click(object sender, EventArgs e)
        {
            LoadMissingCardsUrlsList();
        }
        #endregion

        #region Event Listeners (Set Pack Explorer Tab)
        private void ListSetGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = ListSetGroups.SelectedIndex;

            List<SetInfo> SetList = new List<SetInfo>();
            switch(indexSelected) 
            {
                case 0: SetList = Database.BoosterPacks; break;
                case 1: SetList = Database.SpEditionBoxes; break;
                case 2: SetList = Database.StarterDecks; break;
                case 3: SetList = Database.StructureDecks; break;
                case 4: SetList = Database.Tins; break;
                case 5: SetList = Database.SpeedDuel; break;
                case 6: SetList = Database.DuelistPacks; break;
                case 7: SetList = Database.DuelTerminal; break;
                case 8: SetList = Database.Others; break;
                case 9: SetList = Database.MBC; break;
                case 10: SetList = Database.Tournaments; break;
                case 11: SetList = Database.Promos; break;
                case 12: SetList = Database.VideoGames; break;
            }

            //Save a ref of this list for the SelectedIndexChanged event of the ListSets
            _CurrentSetInfoListSelected = SetList;

            ListSets.Items.Clear();
            foreach(SetInfo set in SetList) 
            {
                ListSets.Items.Add(set.GetInfoLine());
            }
            ListSets.SetSelected(0, true);
        }
        private void ListSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hide this list selector until the price panel is loaded
            ListSetGroups.Visible = false;
            ListSets.Visible = false;

            int CardSetIndex = ListSets.SelectedIndex;
            string SetName = _CurrentSetInfoListSelected[CardSetIndex].Name;
            if(Database.SetPackByName.ContainsKey(SetName))
            {
                //Dispose all the existing labels
                foreach(Label label in _SetDetailsLabels)
                {
                    label.Dispose();
                }
                _SetDetailsLabels.Clear();

                SetPack CurrentSetPack = Database.SetPackByName[SetName];
                CurrentSetPack.SortByCode();

                //Display the main card list
                PanelSetInfo.Visible = true;
                int CurrentY_Axis = 40;
                int Ysize = 15;
                foreach (SetCard ThisSetCard in CurrentSetPack.MainCardList)
                {
                    //Paint the row
                    PaintCardRow(ThisSetCard, CurrentY_Axis, Ysize);

                    //Move the Y Axis
                    CurrentY_Axis += 15;
                }

                //display the totals
                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName = new Label();
                PanelSetInfo.Controls.Add(totalsName);
                totalsName.Text = "Total value of this set:";
                totalsName.ForeColor = Color.White;
                totalsName.BorderStyle = BorderStyle.FixedSingle;
                totalsName.AutoSize = false;
                totalsName.Size = new Size(220, Ysize);
                totalsName.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName);

                //Totals Market
                Label totalsMarket = new Label();
                PanelSetInfo.Controls.Add(totalsMarket);
                totalsMarket.Text = "$" + CurrentSetPack.SetMainListMarketValue.ToString();
                totalsMarket.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket.ForeColor = Color.White;
                totalsMarket.AutoSize = false;
                totalsMarket.Size = new Size(60, Ysize);
                totalsMarket.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket);

                //Totals Median
                Label totalsMedian = new Label();
                PanelSetInfo.Controls.Add(totalsMedian);
                totalsMedian.Text = "$" + CurrentSetPack.SetMainListMedianValue.ToString();
                totalsMedian.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian.ForeColor = Color.White;
                totalsMedian.AutoSize = false;
                totalsMedian.Size = new Size(60, Ysize);
                totalsMedian.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian);

                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName2 = new Label();
                PanelSetInfo.Controls.Add(totalsName2);
                totalsName2.Text = "Total value of your collection:";
                totalsName2.ForeColor = Color.White;
                totalsName2.BorderStyle = BorderStyle.FixedSingle;
                totalsName2.AutoSize = false;
                totalsName2.Size = new Size(220, Ysize);
                totalsName2.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName2);

                //Totals Market
                Label totalsMarket2 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket2);
                totalsMarket2.Text = "$" + CurrentSetPack.SetMainListMarketValueObtained.ToString();
                totalsMarket2.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket2.ForeColor = Color.White;
                totalsMarket2.AutoSize = false;
                totalsMarket2.Size = new Size(60, Ysize);
                totalsMarket2.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket2);

                //Totals Median
                Label totalsMedian2 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian2);
                totalsMedian2.Text = "$" + CurrentSetPack.SetMainListMedianValueObtained.ToString();
                totalsMedian2.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian2.ForeColor = Color.White;
                totalsMedian2.AutoSize = false;
                totalsMedian2.Size = new Size(60, Ysize);
                totalsMedian2.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian2);



                //Display the Extra Card List Label
                CurrentY_Axis += 30;
                Label ExtraCardsHeader = new Label();
                PanelSetInfo.Controls.Add(ExtraCardsHeader);
                ExtraCardsHeader.Text = "Extra Rairty Cards:";
                ExtraCardsHeader.ForeColor = Color.White;
                ExtraCardsHeader.BorderStyle = BorderStyle.None;
                ExtraCardsHeader.AutoSize = false;
                ExtraCardsHeader.Size = new Size(300, 17);
                ExtraCardsHeader.Location = new Point(10, CurrentY_Axis);
                _SetDetailsLabels.Add(ExtraCardsHeader);
                CurrentY_Axis += 25;

                //Display the extra card list
                foreach (SetCard ThisSetCard in CurrentSetPack.ExtraCardList)
                {
                    //Paint the row
                    PaintCardRow(ThisSetCard, CurrentY_Axis, Ysize);

                    //Move the Y Axis
                    CurrentY_Axis += 15;
                }

                //display the totals
                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName3 = new Label();
                PanelSetInfo.Controls.Add(totalsName3);
                totalsName3.Text = "Total value of this set:";
                totalsName3.ForeColor = Color.White;
                totalsName3.BorderStyle = BorderStyle.FixedSingle;
                totalsName3.AutoSize = false;
                totalsName3.Size = new Size(220, Ysize);
                totalsName3.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName3);

                //Totals Market
                Label totalsMarket3 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket3);
                totalsMarket3.Text = "$" + CurrentSetPack.SetExtraListMarketValue.ToString();
                totalsMarket3.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket3.ForeColor = Color.White;
                totalsMarket3.AutoSize = false;
                totalsMarket3.Size = new Size(60, Ysize);
                totalsMarket3.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket3);

                //Totals Median
                Label totalsMedian3 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian3);
                totalsMedian3.Text = "$" + CurrentSetPack.SetExtraListMedianValue.ToString();
                totalsMedian3.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian3.ForeColor = Color.White;
                totalsMedian3.AutoSize = false;
                totalsMedian3.Size = new Size(60, Ysize);
                totalsMedian3.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian3);

                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName4 = new Label();
                PanelSetInfo.Controls.Add(totalsName4);
                totalsName4.Text = "Total value of your collection:";
                totalsName4.ForeColor = Color.White;
                totalsName4.BorderStyle = BorderStyle.FixedSingle;
                totalsName4.AutoSize = false;
                totalsName4.Size = new Size(220, Ysize);
                totalsName4.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName4);

                //Totals Market
                Label totalsMarket4 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket4);
                totalsMarket4.Text = "$" + CurrentSetPack.SetExtraListMarketValueObtained.ToString();
                totalsMarket4.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket4.ForeColor = Color.White;
                totalsMarket4.AutoSize = false;
                totalsMarket4.Size = new Size(60, Ysize);
                totalsMarket4.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket4);

                //Totals Median
                Label totalsMedian4 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian4);
                totalsMedian4.Text = "$" + CurrentSetPack.SetExtraListMedianValueObtained.ToString();
                totalsMedian4.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian4.ForeColor = Color.White;
                totalsMedian4.AutoSize = false;
                totalsMedian4.Size = new Size(60, Ysize);
                totalsMedian4.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian4);
            }
            else
            {
                PanelSetInfo.Visible = false;
            }

            //okay now show it again
            ListSetGroups.Visible = true;
            ListSets.Visible = true;

            void PaintCardRow(SetCard ThisSetCard, int CurrentY_Axis, int Ysize)
            {
                //Code
                Label codeLabel = new Label();
                PanelSetInfo.Controls.Add(codeLabel);
                codeLabel.Text = ThisSetCard.Code;
                codeLabel.ForeColor = Color.White;
                codeLabel.BorderStyle = BorderStyle.FixedSingle;
                codeLabel.AutoSize = false;
                codeLabel.Size = new Size(80, Ysize);
                codeLabel.Location = new Point(10, CurrentY_Axis);
                _SetDetailsLabels.Add(codeLabel);

                //Name label
                Label packname = new Label();
                PanelSetInfo.Controls.Add(packname);
                packname.Text = ThisSetCard.GetCardName();
                packname.ForeColor = Color.White;
                packname.BorderStyle = BorderStyle.FixedSingle;
                packname.AutoSize = false;
                packname.Size = new Size(220, Ysize);
                packname.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(packname);

                //Rarity Label
                Label rarityLabel = new Label();
                PanelSetInfo.Controls.Add(rarityLabel);
                rarityLabel.Text = ThisSetCard.Rarity;
                rarityLabel.BorderStyle = BorderStyle.FixedSingle;
                rarityLabel.ForeColor = Color.White;
                rarityLabel.AutoSize = false;
                rarityLabel.Size = new Size(80, Ysize);
                rarityLabel.Location = new Point(310, CurrentY_Axis);
                _SetDetailsLabels.Add(rarityLabel);

                switch (ThisSetCard.Rarity)
                {
                    case "Common": rarityLabel.ForeColor = Color.White; break;
                    case "Rare": rarityLabel.ForeColor = Color.PaleGreen; break;
                    case "Ultra Rare": rarityLabel.ForeColor = Color.Moccasin; break;
                    case "Ultimate Rare": rarityLabel.ForeColor = Color.HotPink; break;
                    case "Gold Rare": rarityLabel.ForeColor = Color.Gold; break;
                    case "Hobby": rarityLabel.ForeColor = Color.MediumPurple; break;
                    case "Millennium Secret Rare": rarityLabel.ForeColor = Color.Goldenrod; break;
                    case "Platinum Secret Rare": rarityLabel.ForeColor = Color.LightSkyBlue; break;
                    case "Starfoil": rarityLabel.ForeColor = Color.BlueViolet; break;
                    case "Shattefoil": rarityLabel.ForeColor = Color.MediumTurquoise; break;
                    case "Super Rare": rarityLabel.ForeColor = Color.SteelBlue; break;
                    case "Secret Rare": rarityLabel.ForeColor = Color.Pink; break;
                    case "Ghost Rare": rarityLabel.ForeColor = Color.PowderBlue; break;
                    case "Gold Secret": rarityLabel.ForeColor = Color.Yellow; break;
                    case "Platinum Rare": rarityLabel.ForeColor = Color.Aqua; break;
                    case "Mosaic Rare": rarityLabel.ForeColor = Color.DarkViolet; break;
                    case "Prismatic Secret Rare": rarityLabel.ForeColor = Color.Plum; break;
                    default: rarityLabel.ForeColor = Color.White; break;
                }

                //market Label
                Label marketLabel = new Label();
                PanelSetInfo.Controls.Add(marketLabel);
                marketLabel.Text = ThisSetCard.MarketPrice;
                marketLabel.BorderStyle = BorderStyle.FixedSingle;
                marketLabel.ForeColor = Color.White;
                marketLabel.AutoSize = false;
                marketLabel.Size = new Size(60, Ysize);
                marketLabel.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(marketLabel);

                if (ThisSetCard.GetDoubleMarketPrice() < 1)
                {
                    marketLabel.ForeColor = Color.White;
                }
                else if (ThisSetCard.GetDoubleMarketPrice() < 5)
                {
                    marketLabel.ForeColor = Color.LightGreen;
                }
                else if (ThisSetCard.GetDoubleMarketPrice() < 50)
                {
                    marketLabel.ForeColor = Color.HotPink;
                }
                else
                {
                    marketLabel.ForeColor = Color.Gold;
                }

                //median Label
                Label medianLabel = new Label();
                PanelSetInfo.Controls.Add(medianLabel);
                medianLabel.Text = ThisSetCard.MediamPrice;
                medianLabel.BorderStyle = BorderStyle.FixedSingle;
                medianLabel.ForeColor = Color.White;
                medianLabel.AutoSize = false;
                medianLabel.Size = new Size(60, Ysize);
                medianLabel.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(medianLabel);

                if (ThisSetCard.GetDoubleMedianPrice() < 1)
                {
                    medianLabel.ForeColor = Color.White;
                }
                else if (ThisSetCard.GetDoubleMedianPrice() < 5)
                {
                    medianLabel.ForeColor = Color.LightGreen;
                }
                else if (ThisSetCard.GetDoubleMedianPrice() < 50)
                {
                    medianLabel.ForeColor = Color.HotPink;
                }
                else
                {
                    medianLabel.ForeColor = Color.Gold;
                }

                //obtained Label
                Label obtainedLabel = new Label();
                PanelSetInfo.Controls.Add(obtainedLabel);
                if (ThisSetCard.Obtained) { obtainedLabel.Text = "X"; }
                obtainedLabel.BorderStyle = BorderStyle.FixedSingle;
                obtainedLabel.ForeColor = Color.White;
                obtainedLabel.AutoSize = false;
                obtainedLabel.Size = new Size(30, Ysize);
                obtainedLabel.Location = new Point(510, CurrentY_Axis);
                _SetDetailsLabels.Add(obtainedLabel);
            }
        }
        private void btnUpdateSetCardListPrices_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            int CardSetIndex = ListSets.SelectedIndex;
            string SetName = _CurrentSetInfoListSelected[CardSetIndex].Name;
            SetPack packToTest = Database.SetPackByName[SetName];
            UpdateSetPrices(packToTest.FullCardList);
        }
        #endregion

        #region Other Event Listeners
        private void btnTest_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this);
            DBUpdateform.Show();

            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();

            List<string> SuccesfulLines = new List<string>();
            List<string> unSuccesfulLines = new List<string>();

            //Open the file
            StreamReader SR_SaveFile = new StreamReader(
                Directory.GetCurrentDirectory() + "\\Database\\FixList.txt");

            //String that hold the data of one line of the txt file
            string line = "";

            line = SR_SaveFile.ReadLine();
            int cardCount = Convert.ToInt32(line);

            DBUpdateform.SetTotalCardsToScan(cardCount);

            for (int i = 0; i < cardCount; i++)
            {
                line = SR_SaveFile.ReadLine();
                string[] tokens = line.Split('|');
                string cardname = tokens[0];
                string code = tokens[1];
                string rarity = tokens[2];

                Driver.AddToFullLog(string.Format("This Code: {0} | Rarity: {1}", code, rarity));

                if (code.StartsWith("DUSA") || code.StartsWith("NKRT") || code.StartsWith("DT") || code.StartsWith("HL"))
                {
                    //skip
                    unSuccesfulLines.Add(line);
                    Driver.AddToFullLog("SetCard in skip list");
                }
                else
                {
                    DBUpdateform.SendCardStartSignal(cardname);
                    MasterCard ThisMasterCard = Database.MasterCardByName[cardname];
                    if (ThisMasterCard.HasProDeckURL())
                    {
                        //Set the SetCard Ref
                        SetCard ThisSetCard = ThisMasterCard.GetCardWithCodeAndRarity(code, rarity);

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


                        Driver.AddToFullLog(string.Format("URLS to verify: {0}", URLsToCheck.Count));
                        bool succesfulMatch = false;
                        int urlcheckcounter = 0;
                        //Now check all the URL for matches                  
                        foreach (string TestURL in URLsToCheck)
                        {
                            Driver.GoToURL(TestURL);
                            urlcheckcounter++;

                            if (TCGCardInfoPage.IsAValidPage())
                            {
                                bool PageLoadedCorrectly = TCGCardInfoPage.WaitUntilPageIsLoaded(true);

                                if (PageLoadedCorrectly)
                                {
                                    //If the page corresponds to the code AND Rarity, then extract its price
                                    string CodeInPage = TCGCardInfoPage.GetCode();
                                    string RarityInPage = TCGCardInfoPage.GetRarity();
                                    if (ThisSetCard.Code == CodeInPage && Tools.CompareInLowerCase(ThisSetCard.Rarity, RarityInPage))
                                    {
                                        //Save the URL and Update prices
                                        ThisSetCard.TCGPlayerURL = TestURL;

                                        //Update prices since we are here.
                                        string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                        string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                        double priceInPageMarket = Tools.CovertPriceToDouble(priceInPageMarketstr);
                                        double priceInPageMedian = Tools.CovertPriceToDouble(priceInPageMedianstr);
                                        ThisSetCard.OverridePrices(priceInPageMarketstr, priceInPageMedianstr);
                                        succesfulMatch = true;
                                        Driver.AddToFullLog(string.Format("Found URL's Counter: {0}", urlcheckcounter));
                                        break;
                                    }
                                }
                            }
                        }

                        if (succesfulMatch)
                        {
                            SuccesfulLines.Add(line);
                            Driver.AddToFullLog("------------------------>>>>>>>>URL FIXED!!");
                        }
                        else
                        {
                            unSuccesfulLines.Add(line);
                        }
                    }
                }
                Driver.AddToFullLog("-----------------------------------");
            }

            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\SuccessfullLines.txt", SuccesfulLines);
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\UnSuccessfullLines.txt", unSuccesfulLines);

            DBUpdateform.SendFullCompletionSignal();
            Driver.AddToFullLog(string.Format("Successful Fixed URLS: {0}", SuccesfulLines.Count));
            Driver.AddToFullLog(string.Format("UnSuccessful Fixed URLS: {0}", unSuccesfulLines.Count));
            Masterwatch.Stop();
            Driver.AddToFullLog($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.CloseDriver();
            WriteOutputFiles();
        }
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            Dispose();
            _MainMenuForm.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}