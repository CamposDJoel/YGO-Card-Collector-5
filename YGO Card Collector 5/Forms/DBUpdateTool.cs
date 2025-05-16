//Joel Campos
//2/18/2024
//DBUpdateTool Class

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DBUpdateTool : Form
    {
        #region Constructors
        public DBUpdateTool(FormLauncher mainmenuform)
        {
            InitializeComponent();
            _MainMenuForm = mainmenuform;
            ReloadUI();
            //Load Form theme
            Tools.InitalizeThemeOnForm(this);
        }
        #endregion

        #region Internal Data
        private Form _MainMenuForm;
        private StringBuilder LogSB = new StringBuilder();
        private List<MasterCard> MasterCardsWithMissingProdeck;
        private List<SetCard> SetCardsWithMissingTCG;
        private List<SetInfo> CurrentSetInfoListSelected;
        #endregion

        #region Private Methods
        private void ReloadUI()
        {
            LoadMissingURLLists();
            LoadMissingCardsUrlsList();
            LoadSets();

            void LoadMissingURLLists()
            {
                MasterCardsWithMissingProdeck = Database.GetCardListWithMissingProdeckURLs();
                SetCardsWithMissingTCG = Database.GetSetCardListWithMissingTCGURLs();

                listMissingProdeckStep2.Items.Clear();
                if (MasterCardsWithMissingProdeck.Count == 0)
                {
                    listMissingProdeckStep2.Items.Add("No Mastercards missing Prodeck URLs");
                }
                else
                {
                    foreach (MasterCard ThisMasterCard in MasterCardsWithMissingProdeck)
                    {
                        listMissingProdeckStep2.Items.Add(ThisMasterCard.Name);
                    }
                }
                listMissingProdeckStep2.SetSelected(0, true);

                listMissingTCGStep2.Items.Clear();
                if (SetCardsWithMissingTCG.Count == 0)
                {
                    listMissingTCGStep2.Items.Add("No Setcards missing TCG Player URLs");
                }
                else
                {
                    lblmissingtcgcount.Text = string.Format("Count: {0}", SetCardsWithMissingTCG.Count);
                    foreach (SetCard ThisSetCard in SetCardsWithMissingTCG)
                    {
                        listMissingTCGStep2.Items.Add(string.Format("[{0} | {1}] - {2}", ThisSetCard.Code, ThisSetCard.Rarity, ThisSetCard.GetCardName()));
                    }
                }
                listMissingTCGStep2.SetSelected(0, true);
            }
            void LoadMissingCardsUrlsList()
            {
                StringBuilder sb = new StringBuilder();

                foreach (MasterCard ThisMasterCard in Database.MasterCards)
                {
                    int passcode = ThisMasterCard.ID;
                    if (passcode != -1)
                    {
                        //Check if the file exists
                        if (!File.Exists(Directory.GetCurrentDirectory() + "\\Images\\Cards\\" + passcode + ".jpg"))
                        {
                            sb.AppendLine("https://images.ygoprodeck.com/images/cards/" + passcode + ".jpg");
                        }

                    }
                }

                if (sb.Length == 0)
                {
                    txtCardImagesURLoutput.Text = "NO Card Passcodes without Card Images, check this list once new Card Passcodes (IDs) are added to the DB.";
                }
                else
                {
                    txtCardImagesURLoutput.Text = sb.ToString();
                }
            }
            void LoadSets()
            {
                ListSetGroups.SetSelected(0, true);
            }
        }
        #endregion

        #region Step 1 Events/Methods
        private void btnStep1_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            btnBackToMainMenu.Visible = false;
            lblActiveActionStep1.Text = "";
            btnStep1.Visible = false;
            btnStep2.Visible = false;
            btnStep4.Visible = false;
            PanelContainerStep1.Visible = true;
            RunStep1Update();
            ReloadUI();
            btnStep1.Visible = true;
            btnStep2.Visible = true;
            btnStep4.Visible = true;
            btnBackToMainMenu.Visible = true;
        }
        private void RunStep1Update()
        {
            #region Step A: Start the Driver
            LogSB = new StringBuilder();
            LogIt("Starting Card DB Update...");
            lblJobStep1.Text = "JOB 1/5: Extract recently release sets.";
            BarProgressStep1.Value = 0;
            BarProgressStep1.Maximum = 13;
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();

            //Try to open the Chrome Driver
            try
            {
                Driver.OpenBrowser();
            }
            catch (Exception e)
            {
                LogIt(e.Message);
                LogIt("Fix the issue below and try again...");
                Masterwatch.Stop();
                return;
            }
            #endregion

            #region Step B: Extract All the recent Sets from Konami's DB
            //Obtain all the recent sets from all the groups
            List<string> boosterpacks;
            List<string> spboxes;
            List<string> starterdecks;
            List<string> structuredecks;
            List<string> tins;
            List<string> speedduel;
            List<string> duelistpacks;
            List<string> duelterminal;
            List<string> other;
            List<string> mbc;
            List<string> tournmaments;
            List<string> promos;
            List<string> vgs;
            try
            {
                Driver.GoToKonamiSetsPage();
                KonamiSetPacksPage.WaitUntilPageIsLoaded();
                KonamiSetPacksPage.ClickProductsTab();

                StartExtractingSet("Booster Packs");
                boosterpacks = KonamiSetPacksPage.GetGroupSetPacks("Booster Packs");

                StartExtractingSet("Sp. Edition Boxes");
                spboxes = KonamiSetPacksPage.GetGroupSetPacks("Sp. Edition Boxes");

                StartExtractingSet("Starter Decks");
                starterdecks = KonamiSetPacksPage.GetGroupSetPacks("Starter Decks");

                StartExtractingSet("Structure Decks");
                structuredecks = KonamiSetPacksPage.GetGroupSetPacks("Structure Decks");

                StartExtractingSet("Tins");
                tins = KonamiSetPacksPage.GetGroupSetPacks("Tins");

                StartExtractingSet("Speed Duel");
                speedduel = KonamiSetPacksPage.GetGroupSetPacks("Speed Duel");

                StartExtractingSet("Duelist Packs");
                duelistpacks = KonamiSetPacksPage.GetGroupSetPacks("Duelist Packs");

                StartExtractingSet("Duel Terminal");
                duelterminal = KonamiSetPacksPage.GetGroupSetPacks("Duel Terminal");

                StartExtractingSet("Others");
                other = KonamiSetPacksPage.GetGroupSetPacks("Others");

                KonamiSetPacksPage.ClickPerksTab();

                StartExtractingSet("MBC");
                mbc = KonamiSetPacksPage.GetGroupSetPacks("MBC");

                StartExtractingSet("Tournaments");
                tournmaments = KonamiSetPacksPage.GetGroupSetPacks("Tournaments");

                StartExtractingSet("Promos");
                promos = KonamiSetPacksPage.GetGroupSetPacks("Promos");

                StartExtractingSet("Video Games");
                vgs = KonamiSetPacksPage.GetGroupSetPacks("Video Games");
            }
            catch (Exception e)
            {
                LogIt(e.Message);
                LogIt("The issue below is most likely code updated related, please try with this is fixed.");
                Masterwatch.Stop();
                return;
            }
            #endregion

            #region Step C: Find the new Sets from the extracted lists to populate the Card Records to Update list
            lblJobStep1.Text = "JOB 2/5: Find the new Sets from the recent Sets.";
            BarProgressStep1.Value = 0;
            BarProgressStep1.Maximum = 13;
            Dictionary<string, string> CardRecordsToUpdate = new Dictionary<string, string>();
            try
            {
                StartFindingNew("Booster Packs");
                FindNewSetsFromExtractedList(boosterpacks, Database.BoosterPacks);
                StartFindingNew("Sp. Edition Boxes");
                FindNewSetsFromExtractedList(spboxes, Database.SpEditionBoxes);
                StartFindingNew("Starter Decks");
                FindNewSetsFromExtractedList(starterdecks, Database.StarterDecks);
                StartFindingNew("Structure Decks");
                FindNewSetsFromExtractedList(structuredecks, Database.StructureDecks);
                StartFindingNew("Tins");
                FindNewSetsFromExtractedList(tins, Database.Tins);
                StartFindingNew("Speed Duel");
                FindNewSetsFromExtractedList(speedduel, Database.SpeedDuel);
                StartFindingNew("Duelist Packs");
                FindNewSetsFromExtractedList(duelistpacks, Database.DuelistPacks);
                StartFindingNew("Duel Terminal");
                FindNewSetsFromExtractedList(duelterminal, Database.DuelTerminal);
                StartFindingNew("Others");
                FindNewSetsFromExtractedList(other, Database.Others);
                StartFindingNew("MBC");
                FindNewSetsFromExtractedList(mbc, Database.MBC);
                StartFindingNew("Tournaments");
                FindNewSetsFromExtractedList(tournmaments, Database.Tournaments);
                StartFindingNew("Promos");
                FindNewSetsFromExtractedList(promos, Database.Promos);
                StartFindingNew("Video Games");
                FindNewSetsFromExtractedList(vgs, Database.VideoGames);
            }
            catch (Exception e)
            {
                LogIt(e.Message);
                LogIt("The issue below is most likely code updated related, please try with this is fixed.");
                Masterwatch.Stop();
                return;
            }
            #endregion

            #region Step D: Update all the Cards in the Records to Update List
            //Now update each card into the database
            lblJobStep1.Text = "JOB 3/5: Update Card Records";
            BarProgressStep1.Value = 0;
            BarProgressStep1.Maximum = CardRecordsToUpdate.Count;
            int NewCardsCounter = 0;
            int CardsWithNewSetCardsCounter = 0;

            //Set these list for the Prodeck/TCG updates
            List<MasterCard> NewMasterCards = new List<MasterCard>();
            List<MasterCard> ExistingMasterCards = new List<MasterCard>();

            if (CardRecordsToUpdate.Count == 0)
            {
                LogIt("NO NEW RECORDS TO UPDATE! DB IS UP TO DATE!");
            }
            else
            {
                LogIt("-------UPDATING CARD RECORDS------------");

                foreach (KeyValuePair<string, string> cardRecord in CardRecordsToUpdate)
                {
                    StringBuilder sb = new StringBuilder();
                    //set the card name for readibility and use
                    string CardName = cardRecord.Key;
                    string KomaniURL = "https://www.db.yugioh-card.com/" + cardRecord.Value;
                    StartUpdateCardRecord(CardName);

                    Driver.GoToURL(KomaniURL);
                    KonamiCardInfoPage.WaitUntilPageIsLoaded();

                    //Extract the amount of sets (we already have the name)
                    int SetCardsInPage = KonamiCardInfoPage.GetSetsCount();

                    //Check this card against the current DB
                    if (Database.CardExists(CardName))
                    {
                        //Save a ref to the MasterCard in DB for quick access
                        MasterCard ThisMasterCard = Database.GetCard(CardName);
                        ExistingMasterCards.Add(ThisMasterCard);

                        //Check its sets
                        int SetCardsInDB = ThisMasterCard.SetCards.Count;

                        //Make comparison
                        if (SetCardsInPage > SetCardsInDB)
                        {
                            //Extract the set cards
                            CardsWithNewSetCardsCounter++;

                            int NewSetCardsAmount = SetCardsInPage - SetCardsInDB;

                            sb.Append(string.Format("New SetCards: {0} | ", NewSetCardsAmount));
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
                                Database.MasterCardByCode.Add(code, ThisMasterCard);
                                sb.Append(string.Format("Code: {0} | ", code));
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
                        sb.Append("New Card! | ");
                        NewCardsCounter++;

                        //Otherwise, extract the whole card
                        if (KonamiCardInfoPage.IsThisPageNonMonster())
                        {
                            //Extract spell/trap
                            string species = KonamiCardInfoPage.GetSpecies();
                            NewCARD = new MasterCard(CardName, "NONE", species, "0", "0", "0", "0", KomaniURL);
                            NewMasterCards.Add(NewCARD);
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
                            NewMasterCards.Add(NewCARD);
                        }

                        //Add the sets
                        sb.Append(string.Format("Sets Count {0} | ", SetCardsInPage));
                        for (int x = 1; x <= SetCardsInPage; x++)
                        {
                            //Pull the data
                            string releaseDate = KonamiCardInfoPage.GetSetReleaseDate(x);
                            string code = KonamiCardInfoPage.GetSetCode(x);
                            string setName = KonamiCardInfoPage.GetSetName(x);
                            string rarity = KonamiCardInfoPage.GetRarity(x);

                            //Add this set to it
                            NewCARD.AddSetCard(releaseDate, code, setName, rarity);
                            sb.Append(string.Format("Code: {0} | ", code));
                        }

                        //Add the Card to the DB
                        Database.AddNewCardToDB(NewCARD);
                    }

                    //Log the card execution
                    LogIt(sb.ToString());
                    LogIt("----------------------");
                }
            }
            #endregion

            //CHECK POINT: OVERIDE SAVE FILES
            Database.SaveDatabaseInTxt();           
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            Database.OverrideSetsJSON(); LogIt("[[[SetsDB.JSON Created]]]");

            #region Step E: Find New Card's Prodecks URLs/Passcodes
            lblJobStep1.Text = "JOB 4/5: Find Prodeck URLs for new MasterCards";
            BarProgressStep1.Value = 0;
            BarProgressStep1.Maximum = NewMasterCards.Count;

            //TODO: Do something with this data.
            List<string> CardsThatFailedManualSearch = new List<string>();

            if (NewMasterCards.Count == 0)
            {
                LogIt("NO NEW MASTERCARDS TO UPDATE.");
            }
            else
            {
                LogIt("-------SEARCHING NEW PRODECK URLS------------");
                foreach (MasterCard ThisMasterCard in NewMasterCards)
                {
                    string CardName = ThisMasterCard.Name;
                    StartProdeckURLSearch(CardName);

                    //Open Prodeck Advance Search Page up
                    Driver.GoToProdeckSearchPage();
                    ProDeckCardSearchPage.WaitUntilPageIsLoaded();

                    //Perform the search
                    bool SearchSucess = ProDeckCardSearchPage.SearchCard(CardName);

                    //if successful, save the Prodeck URL and Card ID, otherwise flag the fail on the log
                    if (SearchSucess)
                    {
                        LogIt("Prodeck Search Success!");

                        //Extract the card ID and override the ID
                        int ID = ProdeckCardInfoPage.GetCardID();
                        ThisMasterCard.ID = ID;

                        //save the url of this card so we dont have to search for it again
                        string currentURL = Driver.ChromeDriver.Url;
                        ThisMasterCard.ProdeckURL = currentURL;
                        LogIt("Prodeck URL and Card's Passcode saved!");
                    }
                    else
                    {
                        CardsThatFailedManualSearch.Add(CardName);
                        LogIt("Prodeck search failed!");
                    }
                    LogIt("-----------------------------------");
                }
            }
            #endregion

            #region Step F: Find TCG Player URLs and Prices
            lblJobStep1.Text = "JOB 5/5: Find TCG Player URLs for new SetCards";
            BarProgressStep1.Value = 0;
            BarProgressStep1.Maximum = CardRecordsToUpdate.Count;

            //TODO do something with this
            List<string> SetCardsThatDidntGetTGCURL = new List<string>();

            if (CardRecordsToUpdate.Count == 0)
            {
                LogIt("NO NEW RECORDS TO UPDATE! DB IS UP TO DATE!");
            }
            else
            {
                LogIt("-------SEARCHING NEW TCG PLAYER URLS------------");
                foreach (KeyValuePair<string, string> cardRecord in CardRecordsToUpdate)
                {
                    //set the card name for readibility and use
                    string CardName = cardRecord.Key;
                    string KomaniURL = "https://www.db.yugioh-card.com/" + cardRecord.Value;
                    StartTCGURLSearch(CardName);

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
                                LogIt(string.Format("Searching For Code: {0} Rarity: {1} |", ThisSetCard.Code, ThisSetCard.Rarity));

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
                                LogIt(string.Format("URLs extracted to check: {0}|", URLsToCheck.Count));

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
                                        Driver.ChromeDriver.Dispose();
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
                                                //Update prices since we are here.
                                                string priceInPageFloorstr = TCGCardInfoPage.GetFloorPrice();
                                                string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                                string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                                ThisSetCard.OverridePrices(priceInPageFloorstr, priceInPageMarketstr, priceInPageMedianstr);
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
                                    LogIt("!!!Match URL FOUND - Prices Updated!!!");
                                }
                                else
                                {
                                    SetCardsThatDidntGetTGCURL.Add(CardName);
                                    LogIt("No Matches");
                                }
                            }
                        }
                    }
                    else
                    {
                        LogIt("NO PRODECK URL - Search Skip until card has one.");
                    }

                    LogIt("---------------------------------------------------------");
                }
            }
            #endregion

            #region Step G: Overide DB files
            Database.OverrideSetsJSON(); LogIt("[[[SetsDB.JSON Created]]]");
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            #endregion

            #region Step H: Finalinze Logs and Close the Driver
            LogIt(string.Format("New Mastercards Found: {0}", NewCardsCounter));
            LogIt(string.Format("Mastercards with new SetCards Found: {0}", CardsWithNewSetCardsCounter));
            LogIt("----------------------------------");
            LogIt(string.Format("Cards that failed Prodeck Manual Search: {0}", CardsThatFailedManualSearch.Count));
            LogIt(string.Format("Cards that TCG URL WERE NOT found from Prodeck: {0}", SetCardsThatDidntGetTGCURL.Count));
            LogIt("----------------------------------");
            Masterwatch.Stop();
            LogIt($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.WriteLogsFile();
            Driver.CloseDriver();
            SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
            #endregion

            void FindNewSetsFromExtractedList(List<string> extractedList, List<SetInfo> DBGorupList)
            {

                for (int x = extractedList.Count - 1; x >= 0; x--)
                {
                    string set = extractedList[x];
                    //extract the set data
                    string[] tokens = set.Split('|');
                    string group = tokens[0];
                    string year = tokens[1];
                    string setname = tokens[2];
                    string url = tokens[3];

                    //Verify if this already exists in the SetsDB
                    if (!Database.SetsDB.Contains(string.Format("{0}|{1}|{2}", group, year, setname)))
                    {
                        //Go into this set's ULR
                        Driver.GoToURL(url);
                        KonamiSetCardListPage.WaitUntilPageIsLoaded();

                        if (KonamiSetCardListPage.IsThisSetASneakPeakPreview())
                        {
                            //ignore it. we are not adding sneak preak preview sets
                            LogIt(string.Format(">>>>>>>Set: {0}", setname));
                            LogIt("is a sneak peak preview, this set will not be adding to the DB.");
                        }
                        else if (KonamiSetCardListPage.IsthiSSetComingSoon())
                        {
                            //ignore it. we are not adding sneak preak preview sets
                            LogIt(string.Format(">>>>>>>Set: {0}", setname));
                            LogIt("This Set is Coming Soon, this set will not be adding to the DB.");
                        }
                        else
                        {
                            KonamiSetCardListPage.ClickViewAsList();

                            LogIt(string.Format(">>>>>>>NEW SET: {0}", setname));
                            //Add the set to the Group List
                            if (SettingsData.SetPackListSortingOLDToNEW)
                            {
                                DBGorupList.Add(new SetInfo(setname, year));
                            }
                            else
                            {
                                DBGorupList.Insert(0, new SetInfo(setname, year));
                            }

                            //Now extract the card list
                            int cardsInPage = KonamiSetCardListPage.GetCardCount();
                            for (int y = 1; y <= cardsInPage; y++)
                            {
                                string cardName = KonamiSetCardListPage.GetCardName(y);
                                string cardURL = KonamiSetCardListPage.GetCardURL(y);
                                //Add the Name/URL combo into the dictionary if this card's name is not in there yet
                                if (!CardRecordsToUpdate.ContainsKey(cardName))
                                {
                                    CardRecordsToUpdate.Add(cardName, cardURL);
                                }
                            }
                        }
                    }
                }
            }
            void StartExtractingSet(string group)
            {
                LogIt(string.Format("Extracting: {0}...", group));
                BarProgressStep1.Value++;
                lblActiveActionStep1.Text = string.Format("Update ({0}/{1}): {2}", BarProgressStep1.Value, BarProgressStep1.Maximum, group);
            }
            void StartFindingNew(string group)
            {
                LogIt(string.Format("Finding New: {0}...", group));
                BarProgressStep1.Value++;
                lblActiveActionStep1.Text = string.Format("Update ({0}/{1}): {2}", BarProgressStep1.Value, BarProgressStep1.Maximum, group);
            }
            void StartUpdateCardRecord(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep1.Value++;
                lblActiveActionStep1.Text = string.Format("Update ({0}/{1}): {2}", BarProgressStep1.Value, BarProgressStep1.Maximum, CardName);
            }
            void StartProdeckURLSearch(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep1.Value++;
                lblActiveActionStep1.Text = string.Format("Prodeck Search: ({0}/{1}): {2}", BarProgressStep1.Value, BarProgressStep1.Maximum, CardName);
            }
            void StartTCGURLSearch(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep1.Value++;
                lblActiveActionStep1.Text = string.Format("TCG URL Search: ({0}/{1}): {2}", BarProgressStep1.Value, BarProgressStep1.Maximum, CardName);
            }
            void LogIt(string message)
            {
                LogSB.Insert(0, message + "\n");
                Driver.AddToFullLog(message);
                lblLogStep1.Text = ">>" + LogSB.ToString();
            }
        }
        #endregion

        #region Step 2 Events/Methods
        private void btnStep2_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            btnBackToMainMenu.Visible = false;
            PanelOverride.Visible = false;
            lblActiveActionStep2.Text = "";
            btnStep1.Visible = false;
            btnStep2.Visible = false;
            btnStep4.Visible = false;
            PanelContainerStep2.Visible = true;
            RunStep2Update();
            ReloadUI();
            btnStep1.Visible = true;
            btnStep2.Visible = true;
            btnStep4.Visible = true;
            PanelOverride.Visible = true;
            btnBackToMainMenu.Visible = true;
        }
        private void RunStep2Update()
        {
            #region Step A: Generate the card lists
            List<MasterCard> MasterCardsWithMissingProdeck = Database.GetCardListWithMissingProdeckURLs();
            List<SetCard> SetCardsWithMissingTCG = Database.GetSetCardListWithMissingTCGURLs();
            #endregion

            #region Step B: Start the Driver
            LogSB = new StringBuilder();
            LogIt("Starting Prodeck/TCG Searches retry...");
            lblJobStep2.Text = "JOB 1/2: Search Prodeck URLs";
            BarProgressStep2.Value = 0;
            BarProgressStep2.Maximum = MasterCardsWithMissingProdeck.Count;
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region Step C: Find New Card's Prodecks URLs/Passcodes
            //TODO: Do something with this data.
            List<string> CardsThatFailedManualSearch = new List<string>();

            LogIt("-------SEARCHING NEW PRODECK URLS------------");
            foreach (MasterCard ThisMasterCard in MasterCardsWithMissingProdeck)
            {
                string CardName = ThisMasterCard.Name;
                StartProdeckURLSearch(CardName);

                //Open Prodeck Advance Search Page up
                Driver.GoToProdeckSearchPage();
                ProDeckCardSearchPage.WaitUntilPageIsLoaded();

                //Perform the search
                bool SearchSucess = false;
                try
                {
                    SearchSucess = ProDeckCardSearchPage.SearchCard(CardName);
                }
                catch(Exception)
                {
                    //do nothing
                }

                //if successful, save the Prodeck URL and Card ID, otherwise flag the fail on the log
                if (SearchSucess)
                {
                    LogIt("Prodeck Search Success!");

                    //Extract the card ID and override the ID
                    int ID = ProdeckCardInfoPage.GetCardID();
                    ThisMasterCard.ID = ID;

                    //save the url of this card so we dont have to search for it again
                    string currentURL = Driver.ChromeDriver.Url;
                    ThisMasterCard.ProdeckURL = currentURL;
                    //CHECK POINT: OVERIDE SAVE FILES
                    Database.SaveDatabaseInTxt();
                    Database.SaveDatabaseInJSON();
                    LogIt("Prodeck URL and Card's Passcode saved!");
                }
                else
                {
                    CardsThatFailedManualSearch.Add(CardName);
                    LogIt("Prodeck search failed!");
                }
                LogIt("-----------------------------------");
            }
            #endregion

            #region Step D: Find TCG Player URLs and Prices
            lblJobStep1.Text = "JOB 2/2: Search TCG Player URLs...";
            BarProgressStep2.Value = 0;
            BarProgressStep2.Maximum = SetCardsWithMissingTCG.Count;

            //TODO do something with this
            List<string> SetCardsThatDidntGetTGCURL = new List<string>();

            LogIt("-------SEARCHING NEW TCG PLAYER URLS------------");
            foreach (SetCard ThisSetCard in SetCardsWithMissingTCG)
            {
                //set the card name for readibility and use
                string CardName = ThisSetCard.GetCardName();
                StartTCGURLSearch(CardName);

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

                    LogIt(string.Format("Searching For Code: {0} Rarity: {1} |", ThisSetCard.Code, ThisSetCard.Rarity));

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
                    LogIt(string.Format("URLs extracted to check: {0} |", URLsToCheck.Count));

                    //Now check all the URL for matches
                    bool MathcURLFound = false;
                    foreach (string TestURL in URLsToCheck)
                    {
                        //Go to the test URL
                        try
                        {
                            string modetesturl = "";
                            if (ThisSetCard.Rarity == "Starfoil")
                            {
                                modetesturl = "-starfoil";
                            }
                            if (ThisSetCard.Rarity == "Shatterfoil")
                            {
                                modetesturl = "-shatterfoil";
                            }
                            Driver.GoToURL(TestURL);
                            string newURL = Driver.GetCurrentURL() + modetesturl;
                            Driver.GoToURL(newURL);
                        }
                        catch (Exception)
                        {
                            Driver.ChromeDriver.Dispose();
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
                                if (RarityInPage == "Starfoil Rare") { RarityInPage = "Starfoil"; }
                                if (RarityInPage == "Shatterfoil Rare") { RarityInPage = "Shatterfoil"; }


                                if (ThisSetCard.Code == CodeInPage && ThisSetCard.Rarity == RarityInPage)
                                {
                                    //Save the URL and Update prices
                                    ThisSetCard.TCGPlayerURL = TestURL;
                                    //Update prices since we are here.
                                    string priceInPageFloorstr = TCGCardInfoPage.GetFloorPrice();
                                    string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                    string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                    ThisSetCard.OverridePrices(priceInPageFloorstr, priceInPageMarketstr, priceInPageMedianstr);
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
                        LogIt("!!!Match URL FOUND - Prices Updated!!!");
                        Database.SaveDatabaseInTxt();
                        Database.SaveDatabaseInJSON();
                    }
                    else
                    {
                        SetCardsThatDidntGetTGCURL.Add(CardName);
                        LogIt("No Matches");
                    }
                }
                else
                {
                    LogIt("NO PRODECK URL - Search Skip until card has one.");
                }

                LogIt("---------------------------------------------------------");
            }
            #endregion

            #region Step E: Overide DB files
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            #endregion

            #region Step F: Finalinze Logs and Close the Driver
            LogIt(string.Format("Cards that failed Prodeck Manual Search: {0}", CardsThatFailedManualSearch.Count));
            LogIt(string.Format("Cards that TCG URL WERE NOT found from Prodeck: {0}", SetCardsThatDidntGetTGCURL.Count));
            LogIt("----------------------------------");
            Masterwatch.Stop();
            LogIt($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.WriteLogsFile();
            Driver.CloseDriver();
            SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
            #endregion

            void StartProdeckURLSearch(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep2.Value++;
                lblActiveActionStep2.Text = string.Format("Prodeck Search: ({0}/{1}): {2}", BarProgressStep2.Value, BarProgressStep2.Maximum, CardName);
            }
            void StartTCGURLSearch(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep2.Value++;
                lblActiveActionStep2.Text = string.Format("TCG URL Search: ({0}/{1}): {2}", BarProgressStep2.Value, BarProgressStep2.Maximum, CardName);
            }
            void LogIt(string message)
            {
                LogSB.Insert(0, message + "\n");
                Driver.AddToFullLog(message);
                lblLogStep2.Text = ">>" + LogSB.ToString();
            }
        }
        #endregion

        #region Step 2 Override Events
        private void listMissingProdeckStep2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            int index = listMissingProdeckStep2.SelectedIndex;
            string cardname = listMissingProdeckStep2.Text;

            if (cardname != "No Mastercards missing Prodeck URLs")
            {
                MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];
                txtPasscode3.Text = ThisMasterCard.ID.ToString();
                GroupUnavailableProdeckOverride.Visible = true;

                //set up the override UI
                txtPasscode3.Text = ThisMasterCard.ID.ToString();
                txtProdeckURL3.Text = ThisMasterCard.ProdeckURL;
                //set the checks to false to lock fields at start
                checkPasscodeEnableOverride3.Checked = false;
                checkProdeckEnableOverride3.Checked = false;
                //but the passcode overide should be hiden if the card has already a set Passcode
                if (ThisMasterCard.ID == -1)
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
        private void listMissingTCGStep2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            int index = listMissingTCGStep2.SelectedIndex;
            string cardname = listMissingTCGStep2.Text;

            if (cardname != "No Setcards missing TCG Player URLs")
            {
                SetCard ThisSetCard = SetCardsWithMissingTCG[index];


                if (ThisSetCard.TCGPlayerURLIsMissing())
                {
                    //Diplay the override submenu
                    GroupUnavailableTCGOverride.Visible = true;

                    txtTCGURL3.Text = ThisSetCard.TCGPlayerURL;
                    checkTCGEnableOverride3.Checked = false;
                }
                else
                {
                    GroupUnavailableTCGOverride.Visible = false;
                }
            }
        }
        private void checkPasscodeEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
            if (checkPasscodeEnableOverride3.Checked)
            {
                txtPasscode3.Enabled = true;
                btnPasscodeOverride3.Visible = true;
            }
            else
            {
                int index = listMissingProdeckStep2.SelectedIndex;
                MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];
                txtPasscode3.Text = ThisMasterCard.ID.ToString();
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
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
            }
            else
            {
                try
                {
                    int index = listMissingProdeckStep2.SelectedIndex;
                    MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];

                    int idinput = Convert.ToInt32(input);
                    ThisMasterCard.ID = idinput;
                    //Success, update the UI
                    checkPasscodeEnableOverride3.Checked = false;
                    checkPasscodeEnableOverride3.Visible = false;
                    lblMisingPasscodeWarning3.Visible = false;
                    checkProdeckEnableOverride3.Visible = true;
                    //Update DB file
                    Database.SaveDatabaseInJSON();
                    SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                    ReloadUI();
                }
                catch (Exception)
                {
                    txtPasscode3.Text = "Invalid ID input. Must be numeric and not -1";
                    SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                }
            }
        }
        private void checkProdeckEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
            if (checkProdeckEnableOverride3.Checked)
            {
                txtProdeckURL3.Enabled = true;
                btnProdeckOverride3.Visible = true;
            }
            else
            {
                int index = listMissingProdeckStep2.SelectedIndex;
                MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];
                txtProdeckURL3.Text = ThisMasterCard.ProdeckURL;
                btnProdeckOverride3.Visible = false;
                txtProdeckURL3.Enabled = false;
            }
        }
        private void btnProdeckOverride3_Click(object sender, EventArgs e)
        {
            string input = txtProdeckURL3.Text;
            if (input.StartsWith("https://ygoprodeck.com/card/"))
            {
                int index = listMissingProdeckStep2.SelectedIndex;
                MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];

                //Valid ulr, proceed
                ThisMasterCard.ProdeckURL = input;
                checkProdeckEnableOverride3.Checked = false;
                //Remove this card from the list now!!
                Database.CardsWithUnavailableProdeckURL.Remove(ThisMasterCard.Name);
                SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                //Update DB file
                Database.SaveDatabaseInJSON();
                //Reload the UI
                ReloadUI();
            }
            else
            {
                txtProdeckURL3.Text = "Not a Prodeck URL.";
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
            }
        }
        private void checkTCGEnableOverride3_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
            if (checkTCGEnableOverride3.Checked)
            {
                txtTCGURL3.Enabled = true;
                btnTCGOverride3.Visible = true;
            }
            else
            {
                int index = listMissingTCGStep2.SelectedIndex;
                SetCard ThisSetCard = SetCardsWithMissingTCG[index];
                txtTCGURL3.Text = ThisSetCard.TCGPlayerURL;
                btnTCGOverride3.Visible = false;
                txtTCGURL3.Enabled = false;
            }
        }
        private void btnTCGOverride3_Click(object sender, EventArgs e)
        {
            string input = txtTCGURL3.Text;
            if (input.StartsWith("https://tcgplayer") || input.StartsWith("https://www.tcgplayer.com/product/"))
            {
                int index = listMissingTCGStep2.SelectedIndex;
                SetCard ThisSetCard = SetCardsWithMissingTCG[index];

                //Valid ulr, proceed
                ThisSetCard.TCGPlayerURL = input;
                checkTCGEnableOverride3.Checked = false;
                SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
                //Update DB file
                Database.SaveDatabaseInJSON();
                //reload stats
                ReloadUI();
            }
            else
            {
                txtTCGURL3.Text = "Not a TCG Player URL.";
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
            }
        }
        #endregion

        #region Step 3 Events
        private void btnRefreshCardFiles_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            ReloadUI();
        }
        #endregion

        #region Step 4 Events/Methods
        private void btnStep4_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            btnBackToMainMenu.Visible = false;
            PanelSetPriceContainer.Visible = false;
            lblActiveActionStep4.Text = "";
            btnStep1.Visible = false;
            btnStep2.Visible = false;
            btnStep4.Visible = false;
            btnStep4B.Visible = false;
            PanelContainerStep4.Visible = true;
            RunStep4Update(0);
            btnStep1.Visible = true;
            btnStep2.Visible = true;
            btnStep4.Visible = true;
            btnStep4B.Visible = true;
            PanelSetPriceContainer.Visible = true;
            btnBackToMainMenu.Visible = true;
        }
        private void RunStep4Update(int startIndex)
        {
            #region Step A: Start the Driver
            LogSB = new StringBuilder();
            LogIt("Starting Prices Update...");
            lblJobStep4.Text = "JOB 1/1: Updating ALL prices";
            BarProgressStep4.Value = 0;
            BarProgressStep4.Maximum = Database.MasterCards.Count;
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region Step B: Update Prices
            int SuccessCounter = 0;
            int TotalSetCards = 0;
            LogIt("-------UPDATING PRICES------------");
            for (int i = 0; i < Database.MasterCards.Count; i++)
            {
                MasterCard ThisMasterCard = Database.MasterCards[i];
                string CardName = ThisMasterCard.Name;
                StartPriceUpdate(CardName);

                if (i >= startIndex)
                {
                    foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                    {
                        TotalSetCards++;
                        LogIt(string.Format("Code:{0} Rarity: {1}", ThisSetCard.Code, ThisSetCard.Rarity));

                        try
                        {
                            if (ThisSetCard.HasTCGURL())
                            {
                                //Go to the test URL
                                Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                                TCGCardInfoPage.WaitUntilPageIsLoaded(false);

                                //Update prices since
                                string priceInPageFloorstr = TCGCardInfoPage.GetFloorPrice();
                                string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                                string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                                ThisSetCard.OverridePrices(priceInPageFloorstr, priceInPageMarketstr, priceInPageMedianstr);
                                LogIt("Prices Update!");
                                SuccessCounter++;
                            }
                            else
                            {
                                if (ThisSetCard.TCGPlayerURLIsUnavailable()) { LogIt("URL Is Unavailable."); }
                                if (ThisSetCard.TCGPlayerURLIsMissing()) { LogIt("URL is Missing."); }

                            }
                        }
                        catch (Exception)
                        {
                            LogIt("Unhandled exception occurred, skipping this SetCard");
                        }
                    }
                }
                else
                {
                    LogIt("SKIP");
                }
                LogIt("------------------");
            }
            #endregion

            #region Step C: Overide DB files
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            #endregion

            #region Step D: Finalinze Logs and Close the Driver
            LogIt(string.Format("Succesful SetCard Price Updates: {0}/{1} Total SetCards.", SuccessCounter, TotalSetCards));
            LogIt("----------------------------------");
            Masterwatch.Stop();
            LogIt($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.WriteLogsFile();
            Driver.CloseDriver();
            SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
            #endregion

            void StartPriceUpdate(string CardName)
            {
                LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep4.Value++;
                lblActiveActionStep4.Text = string.Format("Updating Prices: ({0}/{1}): {2}", BarProgressStep4.Value, BarProgressStep4.Maximum, CardName);
            }
            void LogIt(string message)
            {
                if(LogSB.Length > 150)
                {
                    LogSB.Remove(LogSB.Length - 50, 50);
                }

                LogSB.Insert(0, message + "\n");
                Driver.AddToFullLog(message);
                lblLogStep4.Text = ">>" + LogSB.ToString();
            }
        }
        private void btnStep4B_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            btnBackToMainMenu.Visible = false;
            PanelSetPriceContainer.Visible = false;
            lblActiveActionStep4.Text = "";
            btnStep1.Visible = false;
            btnStep2.Visible = false;
            btnStep4.Visible = false;
            btnStep4B.Visible = false;
            PanelContainerStep4.Visible = true;
            RunStep4BUpdate();
            ReloadUI();
            btnStep1.Visible = true;
            btnStep2.Visible = true;
            btnStep4.Visible = true;
            btnStep4B.Visible = true;
            PanelSetPriceContainer.Visible = true;
            btnBackToMainMenu.Visible = true;
        }
        private void RunStep4BUpdate()
        {
            #region Step A: Generate the Card List
            int CardSetIndex = ListSets.SelectedIndex;
            string SetName = CurrentSetInfoListSelected[CardSetIndex].Name;
            SetPack packToTest = Database.SetPackByName[SetName];
            packToTest.SortByCode();
            List<SetCard> CardsToUpdate = packToTest.FullCardList;
            #endregion

            #region Step B: Start the Driver
            LogSB = new StringBuilder();
            LogIt("Starting Prices Update...");
            lblJobStep4.Text = "JOB 1/1: Updating This Set's prices";
            BarProgressStep4.Value = 0;
            BarProgressStep4.Maximum = CardsToUpdate.Count;
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region Step C: Update Prices
            int SuccessCounter = 0;
            int TotalSetCards = 0;
            LogIt("-------UPDATING PRICES------------");
            foreach (SetCard ThisSetCard in CardsToUpdate)
            {
                StartPriceUpdate(string.Format("Code:{0} Rarity: {1}", ThisSetCard.Code, ThisSetCard.Rarity));
                TotalSetCards++;

                try
                {
                    if (ThisSetCard.HasTCGURL())
                    {
                        //Go to the test URL
                        Driver.GoToURL(ThisSetCard.TCGPlayerURL);
                        TCGCardInfoPage.WaitUntilPageIsLoaded(false);

                        //Update prices since
                        string priceInPageFloorstr = TCGCardInfoPage.GetFloorPrice();
                        string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                        string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                        ThisSetCard.OverridePrices(priceInPageFloorstr, priceInPageMarketstr, priceInPageMedianstr);
                        LogIt("Prices Update!");
                        SuccessCounter++;
                    }
                    else
                    {
                        if (ThisSetCard.TCGPlayerURLIsUnavailable()) { LogIt("URL Is Unavailable."); }
                        if (ThisSetCard.TCGPlayerURLIsMissing()) { LogIt("URL is Missing."); }

                    }
                }
                catch (Exception)
                {
                    LogIt("Unhandled exception occurred, skipping this SetCard");
                }
            }
            #endregion

            #region Step D: Overide DB files
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            #endregion

            #region Step D: Finalinze Logs and Close the Driver
            LogIt(string.Format("Succesful SetCard Price Updates: {0}/{1} Total SetCards.", SuccessCounter, TotalSetCards));
            LogIt("----------------------------------");
            Masterwatch.Stop();
            LogIt($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.WriteLogsFile();
            Driver.CloseDriver();
            SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
            #endregion

            void StartPriceUpdate(string CardName)
            {
                LogIt(string.Format("SetCard: {0}", CardName));
                BarProgressStep4.Value++;
                lblActiveActionStep4.Text = string.Format("Updating Prices: ({0}/{1}): {2}", BarProgressStep4.Value, BarProgressStep4.Maximum, CardName);
            }
            void LogIt(string message)
            {
                LogSB.Insert(0, message + "\n");
                Driver.AddToFullLog(message);
                lblLogStep4.Text = ">>" + LogSB.ToString();
            }
        }
        private void ListSetGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            int indexSelected = ListSetGroups.SelectedIndex;

            List<SetInfo> SetList = new List<SetInfo>();
            switch (indexSelected)
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
            CurrentSetInfoListSelected = SetList;

            ListSets.Items.Clear();
            foreach (SetInfo set in SetList)
            {
                ListSets.Items.Add(set.GetInfoLine());
            }
            ListSets.SetSelected(0, true);
        }
        private void ListSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
        }
        #endregion

        #region Other Events
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Dispose();
            _MainMenuForm.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btnProdeckLaunch_Click(object sender, EventArgs e)
        {
            int index = listMissingProdeckStep2.SelectedIndex;
            MasterCard ThisMasterCard = MasterCardsWithMissingProdeck[index];
            string cardname = ThisMasterCard.Name;
            Tools.LaunchURLIntoBrowser("https://ygoprodeck.com/card-database/?&name=" + cardname + "&num=24&offset=0");
        }
        private void btnTCGLaunch_Click(object sender, EventArgs e)
        {
            int index = listMissingTCGStep2.SelectedIndex;
            SetCard ThisSetCard = SetCardsWithMissingTCG[index];
            string cardname = ThisSetCard.GetCardName();
            Tools.LaunchURLIntoBrowser("https://www.tcgplayer.com/search/all/product?q=" + cardname + "&view=grid");
        }

        private void btntestupdate_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            btnBackToMainMenu.Visible = false;
            PanelOverride.Visible = false;
            lblActiveActionStep2.Text = "";
            btnStep1.Visible = false;
            btnStep2.Visible = false;
            btnStep4.Visible = false;
            PanelContainerStep2.Visible = true;
            RunStep2UpdateCustom();
            ReloadUI();
            btnStep1.Visible = true;
            btnStep2.Visible = true;
            btnStep4.Visible = true;
            PanelOverride.Visible = true;
            btnBackToMainMenu.Visible = true;
        }
        private void RunStep2UpdateCustom()
        {
            #region Step A: Generate the card lists
            List<SetCard> SetCardsWithMissingTCG = Database.GetSetCardListWithMissingTCGURLs();
            #endregion

            #region Step B: Start the Driver
            LogSB = new StringBuilder();
            LogIt("Starting Prodeck/TCG Searches retry...");
            lblJobStep2.Text = "JOB 1/2: Search Prodeck URLs";
            //BarProgressStep2.Value = 0;
            //BarProgressStep2.Maximum = MasterCardsWithMissingProdeck.Count;
            Driver.ClearLogs();
            var Masterwatch = new Stopwatch();
            Masterwatch.Start();
            Driver.OpenBrowser();
            #endregion

            #region Step D: Find TCG Player URLs and Prices
            lblJobStep1.Text = "JOB 1/1: Search TCG Player URLs...";
            BarProgressStep2.Value = 0;
            BarProgressStep2.Maximum = SetCardsWithMissingTCG.Count;

            LogIt("-------SEARCHING NEW TCG PLAYER URLS------------");
            foreach (SetCard ThisSetCard in SetCardsWithMissingTCG)
            {
                //set the card name for readibility and use
                string CardName = ThisSetCard.GetCardName();
                StartTCGURLSearch(CardName);

                //Save a ref to the Master Card for quick access/clean code
                MasterCard ThisMasterCard = Database.GetCard(CardName);

                string codetosearch = txtCode.Text;
                string rarirytosearch = txtRarity.Text;
                string setNameToSearch = txtSetName.Text;
                string rarityMode = txtMod.Text;

                if (ThisSetCard.Code.StartsWith(codetosearch) && ThisSetCard.Rarity == rarirytosearch)
                {
                    LogIt(string.Format("Card Name: {0}", CardName));
                    //https://www.tcgplayer.com/product/551153/yugioh-25th-anniversary-rarity-collection-ii-accesscode-talker-platinum-secret-rare?page=1&Language=English
                    string name = ThisMasterCard.Name;                   
                    name = name.Replace(",", "");
                    name = name.Replace(".", "");
                    name = name.Replace("/", "-");
                    name = name.Replace("&", "and");
                    name = name.Replace("☆", "");
                    name = name.Replace("★", "");
                    name = name.Replace("@", "");
                    name = name.Replace("<", "");
                    name = name.Replace(">", "");
                    name = name.Replace("#", "");
                    name = name.Replace(":", "");
                    name = name.Replace("!", "");
                    name = name.Replace("?", "");
                    name = name.Replace(" - ", "-");
                    name = name.Replace(" ", "-");
                    string url = string.Format("https://store.tcgplayer.com/yugioh/{0}/{1}{2}?partner=YGOPRODeck&utm_campaign=affiliate&utm_medium=card-database-set-prices&utm_source=YGOPRODeck", setNameToSearch, name, rarityMode);
                    try
                    {
                        Driver.GoToURL(url);
                        TCGCardInfoPage.WaitUntilPageIsLoaded(true);
                        //Now validate the new URL
                        string CodeInPage = TCGCardInfoPage.GetCode();
                        string RarityInPage = TCGCardInfoPage.GetRarity();
                        string tcgModdedRarity = rarirytosearch;
                        if (rarirytosearch == "Ultimate Rare") { tcgModdedRarity = "Prismatic Ultimate Rare"; }
                        //if (rarirytosearch == "COLLECTOR'S RARE") { tcgModdedRarity = "Prismatic Collector's Rare"; }
                        if (rarirytosearch == "COLLECTOR'S RARE") { tcgModdedRarity = "Collector's Rare"; }

                        if (ThisSetCard.Code == CodeInPage && RarityInPage == tcgModdedRarity)
                        {
                            //Save the URL and Update prices
                            ThisSetCard.TCGPlayerURL = url;
                            //Update prices since we are here.
                            string priceInPageFloorstr = TCGCardInfoPage.GetFloorPrice();
                            string priceInPageMarketstr = TCGCardInfoPage.GetMarketPrice();
                            string priceInPageMedianstr = TCGCardInfoPage.GetMediamPrice();
                            ThisSetCard.OverridePrices(priceInPageFloorstr, priceInPageMarketstr, priceInPageMedianstr);
                            LogIt("!!!Match URL FOUND - Prices Updated!!!");
                            Database.SaveDatabaseInJSON();
                        }
                    }
                    catch (Exception)
                    {
                        //LogIt("Something fail, next!");
                    }
                }
            }
            #endregion

            #region Step E: Overide DB files
            Database.SaveDatabaseInJSON(); LogIt("[[[CardDB.JSON Created]]]");
            #endregion

            #region Step F: Finalinze Logs and Close the Driver
            LogIt("----------------------------------");
            Masterwatch.Stop();
            LogIt($"Execution Time for the WHOLE script was: {Masterwatch.Elapsed}");
            Driver.WriteLogsFile();
            Driver.CloseDriver();
            SoundServer.PlaySoundEffect(SoundEffect.DBLoaded);
            #endregion

            void StartTCGURLSearch(string CardName)
            {
                //LogIt(string.Format("Card Name: {0}", CardName));
                BarProgressStep2.Value++;
                lblActiveActionStep2.Text = string.Format("TCG URL Search: ({0}/{1}): {2}", BarProgressStep2.Value, BarProgressStep2.Maximum, CardName);
            }
            void LogIt(string message)
            {
                LogSB.Insert(0, message + "\n");
                Driver.AddToFullLog(message);
                lblLogStep2.Text = ">>" + LogSB.ToString();
            }
        }
    }
}