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

            lblGroupTotals.Text = Database.AquaMonsters.Count.ToString();
        }
        #endregion

        #region Internal Data
        private CardGroup _CurrentSelectedCardGroup = CardGroup.SeaSerpent_Monsters;
        private DBUpdateHoldScren DBUpdateform;
        #endregion

        #region Private Methods
        private void btnUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.SeaSerpentMonsters.Count);
            DBUpdateform.Show();

            //Start the Script with all the cards lists
            List<CardGroup> CardGroups = new List<CardGroup>
            {
                CardGroup.Aqua_Monsters,
                CardGroup.Beast_Monsters,
                CardGroup.BeastWarrior_Monsters,
                CardGroup.Cyberse_Monsters,
                CardGroup.Dinosaur_Monsters,
                CardGroup.DivineBeast_Monsters,
                CardGroup.Dragon_Monsters,
                CardGroup.Fairy_Monsters,
                CardGroup.Fiend_Monsters,
                CardGroup.Fish_Monsters,
                CardGroup.IllusionType_Monsters,
                CardGroup.Insect_Monsters,
                CardGroup.Machine_Monsters,
                CardGroup.Plant_Monsters,
                CardGroup.Psychic_Monsters,
                CardGroup.Pyro_Monsters,
                CardGroup.Reptile_Monsters,
                CardGroup.Rock_Monsters,
                CardGroup.SeaSerpent_Monsters,
                CardGroup.Spellcaster_Monsters,
                CardGroup.Thunder_Monsters,
                CardGroup.Warrior_Monsters,
                CardGroup.WingedBeast_Monsters,
                CardGroup.Wyrm_Monsters,
                CardGroup.Zombie_Monsters,
                CardGroup.Normal_Spells,
                CardGroup.Continuous_Spells,
                CardGroup.QuickPlay_Spells,
                CardGroup.Field_Spells,
                CardGroup.Equip_Spells,
                CardGroup.Ritual_Spells,
                CardGroup.Normal_Traps,
                CardGroup.Continuous_Traps,
                CardGroup.Counter_Traps
            };

            UpdateKomaniDB(CardGroups);
        }
        private void btnGroupUpdateKonamiList_Click(object sender, EventArgs e)
        {
            Hide();
            DBUpdateform = new DBUpdateHoldScren(this, Database.SeaSerpentMonsters.Count);
            DBUpdateform.Show();

            //Start the Script with the current card group
            List<CardGroup> CardGroups = new List<CardGroup>
            {
                _CurrentSelectedCardGroup
            };

            UpdateKomaniDB(CardGroups);          
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
        private void UpdateKomaniDB(List<CardGroup> CardGroups)
        {
            var watch = new Stopwatch();
            watch.Start();

            //Launch the Chrome Driver to update Konami's Card list only (For the entire DB)
            Driver.OpenBrowser();

            int newCardsCount = 0;
            int cardsWithNewSetsCount = 0;

            foreach (CardGroup Group in CardGroups)
            {
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
    }
    public enum CardGroup
    {
        Aqua_Monsters = 0,
        Beast_Monsters,
        BeastWarrior_Monsters,
        Cyberse_Monsters,
        Dinosaur_Monsters,
        DivineBeast_Monsters,
        Dragon_Monsters,
        Fairy_Monsters,
        Fiend_Monsters,
        Fish_Monsters,
        IllusionType_Monsters,
        Insect_Monsters,
        Machine_Monsters,
        Plant_Monsters,
        Psychic_Monsters,
        Pyro_Monsters,
        Reptile_Monsters,
        Rock_Monsters,
        SeaSerpent_Monsters,
        Spellcaster_Monsters,
        Thunder_Monsters,
        Warrior_Monsters,
        WingedBeast_Monsters,
        Wyrm_Monsters,
        Zombie_Monsters,
        Normal_Spells,
        Continuous_Spells,
        QuickPlay_Spells,
        Equip_Spells,
        Field_Spells,
        Ritual_Spells,
        Normal_Traps,
        Continuous_Traps,
        Counter_Traps
    }
}