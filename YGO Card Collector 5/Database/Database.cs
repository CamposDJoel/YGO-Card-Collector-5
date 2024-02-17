//Joel Campos
//1/29/2024
//Database Class

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace YGO_Card_Collector_5
{
    public static class Database
    {
        #region Internal Data
        private static bool Initialized = false;
        //Master Cards
        public static Dictionary<string, MasterCard> MasterCardByName = new Dictionary<string, MasterCard>();
        public static Dictionary<string, MasterCard> MasterCardByCode = new Dictionary<string, MasterCard>();
        public static List<MasterCard> MasterCards = new List<MasterCard>();
        private static List<string> SaveFileData = new List<string>();
        //Sets List DB
        private static List<string> SetsDB = new List<string>();
        //Set Cards
        public static Dictionary<string, SetCard> SetCardByKey = new Dictionary<string, SetCard>();
        public static List<SetCard> SetCards = new List<SetCard>();
        //Set Packs
        public static Dictionary<string, SetPack> SetPackByName = new Dictionary<string, SetPack>();        
        public static List<SetPack> SetPacks = new List<SetPack>();
        //Missing URL lists
        public static List<string> CardsWithoutProdeckURL = new List<string>();
        public static List<string> CardsWithoutTCGURLs = new List<string>();
        public static List<string> CardsWithUnavailableProdeckURL = new List<string>();
        public static List<string> CardsWithUnavailableTCGURLs = new List<string>();
        //test data
        public static List<string> TCGPagesThatDidntMatchRarity = new List<string>();
        #endregion

        #region Public Methods
        public static bool LoadDB()
        {
            if(!Initialized)
            {
                string jsonFilePath = Directory.GetCurrentDirectory() + "\\Database\\CardDB.json";
                string rawdata = File.ReadAllText(jsonFilePath);

                //Attempt to deserialize the JSON. If it fail simply show error.
                try
                {
                    MasterCards = JsonConvert.DeserializeObject<List<MasterCard>>(rawdata);
                }
                catch (Exception)
                {
                    return false;
                }

                //Load the Sets File
                LoadSetsNames();

                //Continue to sorting the master card list
                foreach (MasterCard ThisMasterCard in MasterCards)
                {
                    //Step 1: Add this card to the dictionary for quick search by name
                    MasterCardByName.Add(ThisMasterCard.Name, ThisMasterCard);

                    //Step 2A: Check if this card has a missing Prodeck URL and add it to the list
                    if (ThisMasterCard.ProdeckURLIsMissing()) { CardsWithoutProdeckURL.Add(ThisMasterCard.Name); }
                    //Step 2B: Check if this card has a Prodeck URL mark as "Unavailable" and add it to the list
                    if (ThisMasterCard.ProdeckURLIsUnavailable()) { CardsWithUnavailableProdeckURL.Add(ThisMasterCard.Name); }

                    //Step 3: Add this Master Card into its corresponding Card Group
                    AddCardIntoCardGroup(ThisMasterCard);

                    //Step 4: Sort each MasterCard's SetCards into its respective sets
                    foreach (SetCard thisSetCard in ThisMasterCard.SetCards)
                    {
                        //if this setCard in has no CODE, dont do shit with it
                        if (thisSetCard.Code == "")
                        {
                            //JUST IGNORE IT!
                        }
                        else
                        {
                            //Set a "Key" for this set card
                            string setCardKey = thisSetCard.Code + "|" + thisSetCard.Rarity + "|" + ThisMasterCard.Name;

                            //Konami has duplicate card sets in the DB (suckers!), to handle this, ignore any card with
                            //an already existing key in the DB
                            if (SetCardByKey.ContainsKey(setCardKey))
                            {
                                //Ignore this set card
                            }
                            else
                            {
                                //Actually sort this set card

                                //Add this card to the DB Set list and dictionary
                                SetCards.Add(thisSetCard);
                                SetCardByKey.Add(setCardKey, thisSetCard);

                                //Check if this Set Card has a TCG URL, if not, add it to the list of missing urls
                                if (thisSetCard.TCGPlayerURLIsMissing())
                                {
                                    if (!CardsWithoutTCGURLs.Contains(ThisMasterCard.Name))
                                    {
                                        CardsWithoutTCGURLs.Add(ThisMasterCard.Name);
                                    }
                                }
                                //Check if this Set Card has a TCG URL mark as "Unavailable", if so, add it to the list of unavailable urls
                                if (thisSetCard.TCGPlayerURLIsUnavailable())
                                {
                                    if (!CardsWithUnavailableTCGURLs.Contains(ThisMasterCard.Name))
                                    {
                                        CardsWithUnavailableTCGURLs.Add(ThisMasterCard.Name);
                                    }
                                }

                                //Save the SetCode to the MasterCardByCode to quick searces of Master Cards by a Set Code
                                if (!MasterCardByCode.ContainsKey(thisSetCard.Code))
                                {
                                    MasterCardByCode.Add(thisSetCard.Code, ThisMasterCard);
                                }

                                //Extract the Pack Name and check if it exists in the DB
                                string SetPackName = thisSetCard.Name;

                                if (!SetPackByName.ContainsKey(SetPackName))
                                {
                                    //Create the set pack
                                    SetPack NewPack = new SetPack(thisSetCard.Name, thisSetCard.Code, thisSetCard.ReleaseDate);
                                    SetPacks.Add(NewPack);
                                    SetPackByName.Add(SetPackName, NewPack);
                                }

                                //Now you can add the SetCard to the SetPack
                                SetPack SetToAddTo = SetPackByName[SetPackName];
                                SetToAddTo.AddCard(thisSetCard);
                            }
                        }
                    }

                    /*Step 5: Sort each SetPack by code order << DONT DO THIS. SORTING IS PER REQUEST BASIS
                    foreach(SetPack ThisPack in SetPacks)
                    {
                        ThisPack.MainCardList.Sort(new SortByCode());
                        ThisPack.ExtraCardList.Sort(new SortByCode());
                    }*/
                }

                //Initialize the CardGroupList dictionary for clean code access to these lists
                InitalizeCardGroupListsDict();

                //Read the SaveFile to mark all the Obtained cards
                LoadSaveFile();

                //Flag the DB as "Initialized" so we dont reload it
                Initialized = true;
                return true;
            }
            else
            {
                return true;
            }

            void LoadSetsNames()
            {
                string jsonFilePath = Directory.GetCurrentDirectory() + "\\Database\\SetsDB.json";
                string rawdata = File.ReadAllText(jsonFilePath);
                SetsDB = JsonConvert.DeserializeObject<List<string>>(rawdata);

                foreach(string set in SetsDB) 
                {
                    //extract the set data
                    string[] tokens = set.Split('|');
                    string group = tokens[0];
                    string year = tokens[1];
                    string setname = tokens[2];

                    //Pick the designated set list
                    List<SetInfo> thisSetList = new List<SetInfo>();
                    switch (group)
                    {
                        case "Booster Packs": thisSetList = BoosterPacks; break;
                        case "Sp. Edition Boxes": thisSetList = SpEditionBoxes; break;
                        case "Starter Decks": thisSetList = StarterDecks; break;
                        case "Structure Decks": thisSetList = StructureDecks; break;
                        case "Tins": thisSetList = Tins; break;
                        case "Speed Duel": thisSetList = SpeedDuel; break;
                        case "Duelist Packs": thisSetList = DuelistPacks; break;
                        case "Duel Terminal": thisSetList = DuelTerminal; break;
                        case "Others": thisSetList = Others; break;

                        case "MBC": thisSetList = MBC; break;
                        case "Tournaments": thisSetList = Tournaments; break;
                        case "Promos": thisSetList = Promos; break;
                        case "Video Games": thisSetList = VideoGames; break;
                    }

                    //Add/Insert it into the designed list
                    if (SettingsData.SetPackListSortingOLDToNEW)
                    {
                        //thisSetList.Insert(0, new SetInfo(setname, year));
                        thisSetList.Add(new SetInfo(setname, year));
                    }
                    else
                    {
                        //thisSetList.Add(new SetInfo(setname, year));
                        thisSetList.Insert(0, new SetInfo(setname, year));
                    }
                }
            }
            void InitalizeCardGroupListsDict()
            {
                GroupCardListByGroupName.Add(CardGroup.AllCards, MasterCards);
                GroupCardListByGroupName.Add(CardGroup.Aqua_Monsters, AquaMonsters);
                GroupCardListByGroupName.Add(CardGroup.Beast_Monsters, BeastMonsters);
                GroupCardListByGroupName.Add(CardGroup.BeastWarrior_Monsters, BeastWarriorMonsters);
                GroupCardListByGroupName.Add(CardGroup.Cyberse_Monsters, CyberseMonsters);
                GroupCardListByGroupName.Add(CardGroup.Dinosaur_Monsters, DinosaurMonsters);
                GroupCardListByGroupName.Add(CardGroup.DivineBeast_Monsters, DivineBeastMonsters);
                GroupCardListByGroupName.Add(CardGroup.Dragon_Monsters, DragonMonsters);
                GroupCardListByGroupName.Add(CardGroup.Fairy_Monsters, FairyMonsters);
                GroupCardListByGroupName.Add(CardGroup.Fiend_Monsters, FiendMonsters);
                GroupCardListByGroupName.Add(CardGroup.Fish_Monsters, FishMonsters);
                GroupCardListByGroupName.Add(CardGroup.IllusionType_Monsters, IllusionMonsters);
                GroupCardListByGroupName.Add(CardGroup.Insect_Monsters, InsectMonsters);
                GroupCardListByGroupName.Add(CardGroup.Machine_Monsters, MachineMonsters);
                GroupCardListByGroupName.Add(CardGroup.Plant_Monsters, PlantMonsters);
                GroupCardListByGroupName.Add(CardGroup.Psychic_Monsters, PsychicMonsters);
                GroupCardListByGroupName.Add(CardGroup.Pyro_Monsters, PyroMonsters);
                GroupCardListByGroupName.Add(CardGroup.Reptile_Monsters, ReptileMonsters);
                GroupCardListByGroupName.Add(CardGroup.Rock_Monsters, RockMonsters);
                GroupCardListByGroupName.Add(CardGroup.SeaSerpent_Monsters, SeaSerpentMonsters);
                GroupCardListByGroupName.Add(CardGroup.Spellcaster_Monsters, SpellcasterMonsters);
                GroupCardListByGroupName.Add(CardGroup.Thunder_Monsters, ThunderMonsters);
                GroupCardListByGroupName.Add(CardGroup.Warrior_Monsters, WarriorMonsters);
                GroupCardListByGroupName.Add(CardGroup.WingedBeast_Monsters, WingedBeastMonsters);
                GroupCardListByGroupName.Add(CardGroup.Wyrm_Monsters, WyrmMonsters);
                GroupCardListByGroupName.Add(CardGroup.Zombie_Monsters, ZombieMonsters);

                GroupCardListByGroupName.Add(CardGroup.Normal_Spells, NormalSpells);
                GroupCardListByGroupName.Add(CardGroup.Continuous_Spells, ContinuousSpells);
                GroupCardListByGroupName.Add(CardGroup.QuickPlay_Spells, QuickPlaySpells);
                GroupCardListByGroupName.Add(CardGroup.Equip_Spells, EquipSpells);
                GroupCardListByGroupName.Add(CardGroup.Field_Spells, FieldSpells);
                GroupCardListByGroupName.Add(CardGroup.Ritual_Spells, RitualSpells);

                GroupCardListByGroupName.Add(CardGroup.Normal_Traps, NormalTraps);
                GroupCardListByGroupName.Add(CardGroup.Continuous_Traps, ContinuousTraps);
                GroupCardListByGroupName.Add(CardGroup.Counter_Traps, CounterTraps);

                GroupCardListByGroupName.Add(CardGroup.All_Monsters, Monsters);
                GroupCardListByGroupName.Add(CardGroup.All_Spells, Spells);
                GroupCardListByGroupName.Add(CardGroup.All_Trap, Traps);

                GroupCardListByGroupName.Add(CardGroup.Normal_Monsters, Normal);
                GroupCardListByGroupName.Add(CardGroup.Effect_Monsters, Effect);
                GroupCardListByGroupName.Add(CardGroup.Fusion_Monsters, Fusion);
                GroupCardListByGroupName.Add(CardGroup.Ritual_Monsters, Ritual);
                GroupCardListByGroupName.Add(CardGroup.Synchro_Monsters, Synchro);
                GroupCardListByGroupName.Add(CardGroup.Xyz_Monsters, Xyz);
                GroupCardListByGroupName.Add(CardGroup.Pendulum_Monsters, Pendulum);
                GroupCardListByGroupName.Add(CardGroup.Link_Monsters, Link);

                GroupCardListByGroupName.Add(CardGroup.Flip_Monsters, Flip);
                GroupCardListByGroupName.Add(CardGroup.Spirit_Monsters, Spirit);
                GroupCardListByGroupName.Add(CardGroup.Toon_Monsters, Toon);
                GroupCardListByGroupName.Add(CardGroup.Union_Monsters, Union);
                GroupCardListByGroupName.Add(CardGroup.Tuner_Monsters, Tuner);
                GroupCardListByGroupName.Add(CardGroup.Gemini_Monsters, Gemini);

                GroupCardListByGroupName.Add(CardGroup.Light_Attribute, Light);
                GroupCardListByGroupName.Add(CardGroup.Dark_Attribute, Dark);
                GroupCardListByGroupName.Add(CardGroup.Water_Attribute, Water);
                GroupCardListByGroupName.Add(CardGroup.Fire_Attribute, Fire);
                GroupCardListByGroupName.Add(CardGroup.Earth_Attribute, Earth);
                GroupCardListByGroupName.Add(CardGroup.Wind_Attribute, Wind);
                GroupCardListByGroupName.Add(CardGroup.Divine_Attribute, Divine);
            }
            void LoadSaveFile()
            {
                StreamReader SR_SaveFile = new StreamReader(
                Directory.GetCurrentDirectory() + "\\Database\\SaveFile.txt");

                string line = SR_SaveFile.ReadLine();
                SaveFileData.Add(line);
                int cardCount = Convert.ToInt32(line);

                for(int i = 0; i < cardCount; i++)
                {
                    line = SR_SaveFile.ReadLine();
                    SaveFileData.Add(line);
                    SetCard SetCardToMark = SetCardByKey[line];
                    SetCardToMark.FlipObtainedStatusNOUPDATE();
                }

                SR_SaveFile?.Close();
            }
        }
        public static void UpdateSaveFile(string cardData, bool markAsOwned)
        {
            if(markAsOwned)
            {
                SaveFileData.Add(cardData);
                SaveFileData.RemoveAt(0);
                SaveFileData.Insert(0, SaveFileData.Count.ToString());
            }
            else
            {
                SaveFileData.Remove(cardData);
                SaveFileData.RemoveAt(0);
                SaveFileData.Insert(0, SaveFileData.Count.ToString());
            }

            if (SettingsData.DBUpdateTestMode)
            {
                File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Output Files\\TEST_SaveFile.txt", SaveFileData);
            }
            else
            {
                //Override the actual DB file
                File.WriteAllLines(Directory.GetCurrentDirectory() + "\\Database\\SaveFile.txt", SaveFileData);
            }
        }
        public static void SaveDatabaseInJSON()
        {
            string output = JsonConvert.SerializeObject(MasterCards);

            if (SettingsData.DBUpdateTestMode)
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Output Files\\CardDB_Output.json", output);
            }
            else
            {
                //Override the actual DB file
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Database\\CardDB.json", output);
            }
        }
        public static bool CardExists(string cardName)
        {
            return MasterCardByName.ContainsKey(cardName);
        }
        public static MasterCard GetCard(string cardName)
        {
            return MasterCardByName[cardName];
        }
        public static void AddNewCardToDB(MasterCard card)
        {
            //Add the card to the master list and sort it
            MasterCards.Add(card);
            MasterCardByName.Add(card.Name, card);
            MasterCards.Sort(new MasterCard.SortByName());

            //This new card wont have a Prodeck URL, add it to the list of missing URLs
            CardsWithoutProdeckURL.Add(card.Name);

            //Add the card into its card group list and sort it
            AddCardIntoCardGroup(card);
            SortCardGroupList(card.Type);

            void SortCardGroupList(string Group)
            {
                switch (Group)
                {
                    case "Normal Spell": NormalSpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Continuous Spell": ContinuousSpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Quick-Play Spell": QuickPlaySpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Equip Spell": EquipSpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Field Spell": FieldSpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Ritual Spell": RitualSpells.Sort(new MasterCard.SortByName()); Spells.Sort(new MasterCard.SortByName()); break;
                    case "Normal Trap": NormalTraps.Sort(new MasterCard.SortByName()); Traps.Sort(new MasterCard.SortByName()); break;
                    case "Continuous Trap": ContinuousTraps.Sort(new MasterCard.SortByName()); Traps.Sort(new MasterCard.SortByName()); break;
                    case "Counter Trap": CounterTraps.Sort(new MasterCard.SortByName()); Traps.Sort(new MasterCard.SortByName()); break;
                    default:
                        //Sort by Monster Type and subtypes
                        Monsters.Sort(new MasterCard.SortByName());
                        if (Group.Contains("Aqua")) { AquaMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Beast-Warrior")) { BeastWarriorMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Winged Beast")) { WingedBeastMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Divine-Beast")) { DivineBeastMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Beast")) { BeastMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Cyberse")) { CyberseMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Dinosaur")) { DinosaurMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Dragon")) { DragonMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Fairy")) { FairyMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Fiend")) { FiendMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Fish")) { FishMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Illusion")) { IllusionMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Insect")) { InsectMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Machine")) { MachineMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Plant")) { PlantMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Psychic")) { PsychicMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Pyro")) { PyroMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Reptile")) { ReptileMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Rock")) { RockMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Sea Serpent")) { SeaSerpentMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Spellcaster")) { SpellcasterMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Thunder")) { ThunderMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Warrior")) { WarriorMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Wyrm")) { WyrmMonsters.Sort(new MasterCard.SortByName()); }
                        else if (Group.Contains("Zombie")) { ZombieMonsters.Sort(new MasterCard.SortByName()); }
                        //Subtypes
                        if (Group.Contains("Normal")) { Normal.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Effect")) { Effect.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Fusion")) { Fusion.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Ritual")) { Ritual.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Synchro")) { Synchro.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Xyz")) { Xyz.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Pendulum")) { Pendulum.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Link")) { Link.Sort(new MasterCard.SortByName()); }
                        //Subtype 2
                        if (Group.Contains("Flip")) { Flip.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Spirit")) { Spirit.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Toon")) { Toon.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Union")) { Union.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("Gemini")) { Gemini.Sort(new MasterCard.SortByName()); }
                        //Attribute
                        if (Group.Contains("LIGHT")) { Light.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("DARK")) { Dark.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("WATER")) { Water.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("FIRE")) { Fire.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("WIND")) { Wind.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("EARTH")) { Earth.Sort(new MasterCard.SortByName()); }
                        if (Group.Contains("DIVINE")) { Divine.Sort(new MasterCard.SortByName()); }
                        break;
                }
            }
        }
        public static string CardGroupToString(CardGroup group)
        {
            switch (group)
            {
                case CardGroup.Aqua_Monsters: return "Aqua";
                case CardGroup.Beast_Monsters: return "Beast";
                case CardGroup.BeastWarrior_Monsters: return "Beast-Warrior";
                case CardGroup.Cyberse_Monsters: return "Cyberse";
                case CardGroup.Dinosaur_Monsters: return "Dinosaur";
                case CardGroup.DivineBeast_Monsters: return "Divine-Beast";
                case CardGroup.Dragon_Monsters: return "Dragon";
                case CardGroup.Fairy_Monsters: return "Fairy";
                case CardGroup.Fiend_Monsters: return "Fiend";
                case CardGroup.Fish_Monsters: return "Fish";
                case CardGroup.IllusionType_Monsters: return "Illusion";
                case CardGroup.Insect_Monsters: return "Insect";
                case CardGroup.Machine_Monsters: return "Machine";
                case CardGroup.Plant_Monsters: return "Plant";
                case CardGroup.Psychic_Monsters: return "Psychic";
                case CardGroup.Pyro_Monsters: return "Pyro";
                case CardGroup.Reptile_Monsters: return "Reptile";
                case CardGroup.Rock_Monsters: return "Rock";
                case CardGroup.SeaSerpent_Monsters: return "Sea Serpent";
                case CardGroup.Spellcaster_Monsters: return "Spellcaster";
                case CardGroup.Thunder_Monsters: return "Thunder";
                case CardGroup.Warrior_Monsters: return "Warrior";
                case CardGroup.WingedBeast_Monsters: return "Winged Beast";
                case CardGroup.Wyrm_Monsters: return "Wyrm";
                case CardGroup.Zombie_Monsters: return "Zombie";

                case CardGroup.Normal_Spells: return "Normal Spells";
                case CardGroup.Continuous_Spells: return "Continuous Spells";
                case CardGroup.QuickPlay_Spells: return "Quick-Play Spells";
                case CardGroup.Equip_Spells: return "Equip Spells";
                case CardGroup.Field_Spells: return "Field Spells";
                case CardGroup.Ritual_Spells: return "Ritual Spells";

                case CardGroup.Normal_Traps: return "Normal Traps";
                case CardGroup.Continuous_Traps: return "Continuous Traps";
                case CardGroup.Counter_Traps: return "Counter Traps";

                case CardGroup.All_Monsters: return "All Monsters";
                case CardGroup.All_Spells: return "All Spells";
                case CardGroup.All_Trap: return "All Traps";
                case CardGroup.AllCards: return "All Cards";

                case CardGroup.Normal_Monsters: return "Normal Monsters";
                case CardGroup.Effect_Monsters: return "Effect Monsters";
                case CardGroup.Fusion_Monsters: return "Fusion Monsters";
                case CardGroup.Ritual_Monsters: return "Ritual Monsters";
                case CardGroup.Synchro_Monsters: return "Synchro Monsters";
                case CardGroup.Xyz_Monsters: return "Xyz Monsters";
                case CardGroup.Pendulum_Monsters: return "Pendulum Monsters";
                case CardGroup.Link_Monsters: return "Link Monsters";
                default: return group.ToString();
            }
        }
        public static List<MasterCard> GetCardListWithSearchTerm(string searchTerm)
        {
            List<MasterCard> matchList = new List<MasterCard>();
            foreach(MasterCard ThisMasterCard in MasterCards) 
            {
                searchTerm = searchTerm.ToLower();
                string cardname = ThisMasterCard.Name;
                cardname = cardname.ToLower();
                if (cardname.Contains(searchTerm))
                {
                    matchList.Add(ThisMasterCard);
                }
            }
            return matchList;
        }
        public static int GetCardGroupObtainedCount(CardGroup group)
        {
            List<MasterCard> thisCardList = GroupCardListByGroupName[group];

            int count = 0;
            foreach(MasterCard ThisMasterCard in thisCardList) 
            {
                if(ThisMasterCard.IsOwned())
                {
                    count++;
                }
            }
            return count;
        }
        public static List<string> GetSetPacksWithCode(string code)
        {
            List<string> resuls = new List<string>();

            foreach(SetInfo setInfo in BoosterPacks)
            {
                if(setInfo.GetCode() == code) 
                {
                    resuls.Add(string.Format("Booster Pack: ({0}) {1}",setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in SpEditionBoxes)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Sp. Edition Box: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in StarterDecks)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Starter Deck: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in StructureDecks)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Structure Deck: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in Tins)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Tin: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in SpeedDuel)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Speed Duel: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in DuelistPacks)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("DP: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in DuelTerminal)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("DT: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in Others)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Other: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in MBC)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("MBC: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in Tournaments)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Tournament: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in Promos)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Promo: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }
            foreach (SetInfo setInfo in VideoGames)
            {
                if (setInfo.GetCode() == code)
                {
                    resuls.Add(string.Format("Video Game: ({0}) {1}", setInfo.Year, setInfo.Name));
                }
            }

            return resuls;
        }
        #endregion

        #region Private Methods
        private static void AddCardIntoCardGroup(MasterCard ThisMasterCard)
        {
            string Group = ThisMasterCard.Type;
            string Attribute = ThisMasterCard.Attribute;
            switch (Group)
            {
                case "Normal Spell": NormalSpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Continuous Spell": ContinuousSpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Quick-Play Spell": QuickPlaySpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Equip Spell": EquipSpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Field Spell": FieldSpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Ritual Spell": RitualSpells.Add(ThisMasterCard); Spells.Add(ThisMasterCard); break;
                case "Normal Trap": NormalTraps.Add(ThisMasterCard); Traps.Add(ThisMasterCard); break;
                case "Continuous Trap": ContinuousTraps.Add(ThisMasterCard); Traps.Add(ThisMasterCard); break;
                case "Counter Trap": CounterTraps.Add(ThisMasterCard); Traps.Add(ThisMasterCard); break;
                default:
                    //Sort by Monster Type and subtypes
                    Monsters.Add(ThisMasterCard);
                    if (Group.Contains("Aqua")) { AquaMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Beast-Warrior")) { BeastWarriorMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Winged Beast")) { WingedBeastMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Divine-Beast")) { DivineBeastMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Beast")) { BeastMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Cyberse")) { CyberseMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Dinosaur")) { DinosaurMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Dragon")) { DragonMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Fairy")) { FairyMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Fiend")) { FiendMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Fish")) { FishMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Illusion")) { IllusionMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Insect")) { InsectMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Machine")) { MachineMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Plant")) { PlantMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Psychic")) { PsychicMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Pyro")) { PyroMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Reptile")) { ReptileMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Rock")) { RockMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Sea Serpent")) { SeaSerpentMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Spellcaster")) { SpellcasterMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Thunder")) { ThunderMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Warrior")) { WarriorMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Wyrm")) { WyrmMonsters.Add(ThisMasterCard); }
                    else if (Group.Contains("Zombie")) { ZombieMonsters.Add(ThisMasterCard); }
                    //Subtypes
                    if (Group.Contains("Normal")) { Normal.Add(ThisMasterCard); }
                    if (Group.Contains("Effect")) 
                    { 
                        if(!Group.Contains("Normal") && !Group.Contains("Fusion") && !Group.Contains("Ritual") && !Group.Contains("Synchro")
                            && !Group.Contains("Xyz") && !Group.Contains("Pendulum") && !Group.Contains("Link"))
                        {
                            Effect.Add(ThisMasterCard);
                        }                        
                    }
                    if (Group.Contains("Fusion")) { Fusion.Add(ThisMasterCard); }
                    if (Group.Contains("Ritual")) { Ritual.Add(ThisMasterCard); }
                    if (Group.Contains("Synchro")) { Synchro.Add(ThisMasterCard); }
                    if (Group.Contains("Xyz")) { Xyz.Add(ThisMasterCard); }
                    if (Group.Contains("Pendulum")) { Pendulum.Add(ThisMasterCard); }
                    if (Group.Contains("Link")) { Link.Add(ThisMasterCard); }
                    //Subtype 2
                    if (Group.Contains("Flip")) { Flip.Add(ThisMasterCard); }
                    if (Group.Contains("Spirit")) { Spirit.Add(ThisMasterCard); }
                    if (Group.Contains("Toon")) { Toon.Add(ThisMasterCard); }
                    if (Group.Contains("Tuner")) { Tuner.Add(ThisMasterCard); }
                    if (Group.Contains("Union")) { Union.Add(ThisMasterCard); }
                    if (Group.Contains("Gemini")) { Gemini.Add(ThisMasterCard); }                    
                    break;
            }

            switch(Attribute)
            {
                case "LIGHT": Light.Add(ThisMasterCard); break;
                case "DARK": Dark.Add(ThisMasterCard); break;
                case "WATER": Water.Add(ThisMasterCard); break;
                case "FIRE": Fire.Add(ThisMasterCard); break;
                case "WIND": Wind.Add(ThisMasterCard); break;
                case "EARTH": Earth.Add(ThisMasterCard); break;
                case "DIVINE": Divine.Add(ThisMasterCard); break;
            }
        }
        #endregion

        #region Card Group Lists
        public static Dictionary<CardGroup, List<MasterCard>> GroupCardListByGroupName = new Dictionary<CardGroup, List<MasterCard>>();
        private static List<MasterCard> AquaMonsters = new List<MasterCard>();
        private static List<MasterCard> BeastMonsters = new List<MasterCard>();
        private static List<MasterCard> BeastWarriorMonsters = new List<MasterCard>();
        private static List<MasterCard> CyberseMonsters = new List<MasterCard>();
        private static List<MasterCard> DinosaurMonsters = new List<MasterCard>();
        private static List<MasterCard> DivineBeastMonsters = new List<MasterCard>();
        private static List<MasterCard> DragonMonsters = new List<MasterCard>();
        private static List<MasterCard> FairyMonsters = new List<MasterCard>();
        private static List<MasterCard> FiendMonsters = new List<MasterCard>();
        private static List<MasterCard> FishMonsters = new List<MasterCard>();
        private static List<MasterCard> IllusionMonsters = new List<MasterCard>();
        private static List<MasterCard> InsectMonsters = new List<MasterCard>();
        private static List<MasterCard> MachineMonsters = new List<MasterCard>();
        private static List<MasterCard> PlantMonsters = new List<MasterCard>();
        private static List<MasterCard> PsychicMonsters = new List<MasterCard>();
        private static List<MasterCard> PyroMonsters = new List<MasterCard>();
        private static List<MasterCard> ReptileMonsters = new List<MasterCard>();
        private static List<MasterCard> RockMonsters = new List<MasterCard>();
        private static List<MasterCard> SeaSerpentMonsters = new List<MasterCard>();
        private static List<MasterCard> SpellcasterMonsters = new List<MasterCard>();
        private static List<MasterCard> ThunderMonsters = new List<MasterCard>();
        private static List<MasterCard> WarriorMonsters = new List<MasterCard>();
        private static List<MasterCard> WingedBeastMonsters = new List<MasterCard>();
        private static List<MasterCard> WyrmMonsters = new List<MasterCard>();
        private static List<MasterCard> ZombieMonsters = new List<MasterCard>();
        private static List<MasterCard> NormalSpells = new List<MasterCard>();
        private static List<MasterCard> ContinuousSpells = new List<MasterCard>();
        private static List<MasterCard> QuickPlaySpells = new List<MasterCard>();
        private static List<MasterCard> EquipSpells = new List<MasterCard>();
        private static List<MasterCard> FieldSpells = new List<MasterCard>();
        private static List<MasterCard> RitualSpells = new List<MasterCard>();
        private static List<MasterCard> NormalTraps = new List<MasterCard>();
        private static List<MasterCard> ContinuousTraps = new List<MasterCard>();
        private static List<MasterCard> CounterTraps = new List<MasterCard>();

        //3 Card Groups
        private static List<MasterCard> Monsters = new List<MasterCard>();
        private static List<MasterCard> Spells = new List<MasterCard>();
        private static List<MasterCard> Traps = new List<MasterCard>();

        //subtypes
        private static List<MasterCard> Normal = new List<MasterCard>();
        private static List<MasterCard> Effect = new List<MasterCard>();
        private static List<MasterCard> Fusion = new List<MasterCard>();
        private static List<MasterCard> Ritual = new List<MasterCard>();
        private static List<MasterCard> Synchro = new List<MasterCard>();
        private static List<MasterCard> Xyz = new List<MasterCard>();
        private static List<MasterCard> Pendulum = new List<MasterCard>();
        private static List<MasterCard> Link = new List<MasterCard>();

        //subtypes 2
        private static List<MasterCard> Flip = new List<MasterCard>();
        private static List<MasterCard> Spirit = new List<MasterCard>();
        private static List<MasterCard> Toon = new List<MasterCard>();
        private static List<MasterCard> Union = new List<MasterCard>();
        private static List<MasterCard> Tuner = new List<MasterCard>();
        private static List<MasterCard> Gemini = new List<MasterCard>();

        //Attributes
        private static List<MasterCard> Light = new List<MasterCard>();
        private static List<MasterCard> Dark = new List<MasterCard>();
        private static List<MasterCard> Water = new List<MasterCard>();
        private static List<MasterCard> Fire = new List<MasterCard>();
        private static List<MasterCard> Wind = new List<MasterCard>();
        private static List<MasterCard> Earth = new List<MasterCard>();
        private static List<MasterCard> Divine = new List<MasterCard>();
        #endregion

        #region SetGroups Name Lists
        public static List<SetInfo> BoosterPacks = new List<SetInfo>();
        public static List<SetInfo> SpEditionBoxes = new List<SetInfo>();
        public static List<SetInfo> StarterDecks = new List<SetInfo>();
        public static List<SetInfo> StructureDecks = new List<SetInfo>();
        public static List<SetInfo> Tins = new List<SetInfo>();
        public static List<SetInfo> SpeedDuel = new List<SetInfo>();
        public static List<SetInfo> DuelistPacks = new List<SetInfo>();
        public static List<SetInfo> DuelTerminal = new List<SetInfo>();
        public static List<SetInfo> Others = new List<SetInfo>();
        public static List<SetInfo> MBC = new List<SetInfo>();
        public static List<SetInfo> Tournaments = new List<SetInfo>();
        public static List<SetInfo> Promos = new List<SetInfo>();
        public static List<SetInfo> VideoGames = new List<SetInfo>();
        #endregion       
    }
    public class SetInfo
    {
        public SetInfo(string name, string year)
        {
            _SetName = name;
            _SetYear = year;
        }

        public string GetInfoLine()
        {
            return string.Format("{0} | {1} - {2}", _SetYear, GetCode(), _SetName);
        }
        public string Name { get { return _SetName; } }
        public string Year { get { return _SetYear; } }
        public string GetCode()
        {
            if (Database.SetPackByName.ContainsKey(_SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[_SetName];
                return ThisSetPack.Code;
            }
            else
            {
                return "XXXX";
            }
        }
        public int GetMainListCardTotal()
        {
            if (Database.SetPackByName.ContainsKey(_SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[_SetName];
                return ThisSetPack.MainCardList.Count;
            }
            else
            {
                return 0;
            }
        }
        public int GetMainListObtained()
        {
            if (Database.SetPackByName.ContainsKey(_SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[_SetName];
                return ThisSetPack.GetMainListObtainedCount();
            }
            else
            {
                return 0;
            }
        }
        public int GetVariantListCardTotal()
        {
            if (Database.SetPackByName.ContainsKey(_SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[_SetName];
                return ThisSetPack.ExtraCardList.Count;
            }
            else
            {
                return 0;
            }
        }
        public int GetVariantListObtained()
        {
            if (Database.SetPackByName.ContainsKey(_SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[_SetName];
                return ThisSetPack.GetExtraListObtainedCount();
            }
            else
            {
                return 0;
            }
        }

        private string _SetName = "NONE";
        private string _SetYear = "0000";
    }

    #region CardGroupEnum
    public enum CardGroup
    {
        AllCards = 0,
        Aqua_Monsters,
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
        Counter_Traps,
        All_Monsters,
        All_Spells,
        All_Trap,
        Normal_Monsters,
        Effect_Monsters,
        Fusion_Monsters,
        Ritual_Monsters,
        Synchro_Monsters,
        Xyz_Monsters,
        Pendulum_Monsters,
        Link_Monsters,
        Flip_Monsters,
        Spirit_Monsters,
        Toon_Monsters,
        Union_Monsters,
        Tuner_Monsters,
        Gemini_Monsters,
        Light_Attribute,
        Dark_Attribute,
        Earth_Attribute,
        Water_Attribute,
        Fire_Attribute,
        Wind_Attribute,
        Divine_Attribute
    }
    #endregion
}
