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
        //Master Cards
        public static Dictionary<string, MasterCard> MasterCardByName = new Dictionary<string, MasterCard>();
        public static Dictionary<string, MasterCard> MasterCardByCode = new Dictionary<string, MasterCard>();
        public static List<MasterCard> MasterCards = new List<MasterCard>();

        //Set Cards
        public static Dictionary<string, SetCard> SetCardByKey = new Dictionary<string, SetCard>();
        public static List<SetCard> SetCards = new List<SetCard>();

        public static Dictionary<string, SetPack> SetPackByName = new Dictionary<string, SetPack>();        
        public static List<SetPack> SetPacks = new List<SetPack>();

        public static List<string> CardsWithoutProdeckURL = new List<string>();
        public static List<string> CardsWithoutTCGURLs = new List<string>();
        public static List<string> CardsWithUnavailableProdeckURL = new List<string>();
        public static List<string> CardsWithUnavailableTCGURLs = new List<string>();

        public static List<string> TCGPagesThatDidntMatchRarity = new List<string>();

        public static bool LoadDB()
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
                        string setCardKey = thisSetCard.Code + "|" + thisSetCard.Rarity + "|" + thisSetCard.Name;

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
                            if(thisSetCard.TCGPlayerURLIsMissing())
                            {
                                if (!CardsWithoutTCGURLs.Contains(ThisMasterCard.Name))
                                {
                                    CardsWithoutTCGURLs.Add(ThisMasterCard.Name);
                                }
                            }
                            //Check if this Set Card has a TCG URL mark as "Unavailable", if so, add it to the list of unavailable urls
                            if (thisSetCard.TCGPlayerURLIsUnavailable())
                            {
                                if(!CardsWithUnavailableTCGURLs.Contains(ThisMasterCard.Name))
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
            }

            //Initialize the CardGroupList dictionary for clean code access to these lists
            InitalizeCardGroupListsDict();

            return true;

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

            //Add the card into its card group list and sort it
            AddCardIntoCardGroup(card);
            SortCardGroupList(card.Type);
        }
        public static void AddCardIntoCardGroup(MasterCard ThisMasterCard)
        {
            string Group = ThisMasterCard.Type;
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
                    if (Group.Contains("Effect")) { Effect.Add(ThisMasterCard); }
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
                    if (Group.Contains("Union")) { Union.Add(ThisMasterCard); }
                    if (Group.Contains("Gemini")) { Gemini.Add(ThisMasterCard); }
                    //Attribute
                    if (Group.Contains("LIGHT")) { Light.Add(ThisMasterCard); }
                    if (Group.Contains("DARK")) { Dark.Add(ThisMasterCard); }
                    if (Group.Contains("WATER")) { Water.Add(ThisMasterCard); }
                    if (Group.Contains("FIRE")) { Fire.Add(ThisMasterCard); }
                    if (Group.Contains("WIND")) { Wind.Add(ThisMasterCard); }
                    if (Group.Contains("EARTH")) { Earth.Add(ThisMasterCard); }
                    if (Group.Contains("DIVINE")) { Divine.Add(ThisMasterCard); }
                    break;
            }
        }
        public static void SortCardGroupList(string Group)
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
                default: return group.ToString();
            }
        }        

        #region Card Group Lists
        public static Dictionary<CardGroup, List<MasterCard>> GroupCardListByGroupName = new Dictionary<CardGroup, List<MasterCard>>();
        public static List<MasterCard> AquaMonsters = new List<MasterCard>();
        public static List<MasterCard> BeastMonsters = new List<MasterCard>();
        public static List<MasterCard> BeastWarriorMonsters = new List<MasterCard>();
        public static List<MasterCard> CyberseMonsters = new List<MasterCard>();
        public static List<MasterCard> DinosaurMonsters = new List<MasterCard>();
        public static List<MasterCard> DivineBeastMonsters = new List<MasterCard>();
        public static List<MasterCard> DragonMonsters = new List<MasterCard>();
        public static List<MasterCard> FairyMonsters = new List<MasterCard>();
        public static List<MasterCard> FiendMonsters = new List<MasterCard>();
        public static List<MasterCard> FishMonsters = new List<MasterCard>();
        public static List<MasterCard> IllusionMonsters = new List<MasterCard>();
        public static List<MasterCard> InsectMonsters = new List<MasterCard>();
        public static List<MasterCard> MachineMonsters = new List<MasterCard>();
        public static List<MasterCard> PlantMonsters = new List<MasterCard>();
        public static List<MasterCard> PsychicMonsters = new List<MasterCard>();
        public static List<MasterCard> PyroMonsters = new List<MasterCard>();
        public static List<MasterCard> ReptileMonsters = new List<MasterCard>();
        public static List<MasterCard> RockMonsters = new List<MasterCard>();
        public static List<MasterCard> SeaSerpentMonsters = new List<MasterCard>();
        public static List<MasterCard> SpellcasterMonsters = new List<MasterCard>();
        public static List<MasterCard> ThunderMonsters = new List<MasterCard>();
        public static List<MasterCard> WarriorMonsters = new List<MasterCard>();
        public static List<MasterCard> WingedBeastMonsters = new List<MasterCard>();
        public static List<MasterCard> WyrmMonsters = new List<MasterCard>();
        public static List<MasterCard> ZombieMonsters = new List<MasterCard>();
        public static List<MasterCard> NormalSpells = new List<MasterCard>();
        public static List<MasterCard> ContinuousSpells = new List<MasterCard>();
        public static List<MasterCard> QuickPlaySpells = new List<MasterCard>();
        public static List<MasterCard> EquipSpells = new List<MasterCard>();
        public static List<MasterCard> FieldSpells = new List<MasterCard>();
        public static List<MasterCard> RitualSpells = new List<MasterCard>();
        public static List<MasterCard> NormalTraps = new List<MasterCard>();
        public static List<MasterCard> ContinuousTraps = new List<MasterCard>();
        public static List<MasterCard> CounterTraps = new List<MasterCard>();

        //3 Card Groups
        public static List<MasterCard> Monsters = new List<MasterCard>();
        public static List<MasterCard> Spells = new List<MasterCard>();
        public static List<MasterCard> Traps = new List<MasterCard>();

        //subtypes
        public static List<MasterCard> Normal = new List<MasterCard>();
        public static List<MasterCard> Effect = new List<MasterCard>();
        public static List<MasterCard> Fusion = new List<MasterCard>();
        public static List<MasterCard> Ritual = new List<MasterCard>();
        public static List<MasterCard> Synchro = new List<MasterCard>();
        public static List<MasterCard> Xyz = new List<MasterCard>();
        public static List<MasterCard> Pendulum = new List<MasterCard>();
        public static List<MasterCard> Link = new List<MasterCard>();

        //subtypes 2
        public static List<MasterCard> Flip = new List<MasterCard>();
        public static List<MasterCard> Spirit = new List<MasterCard>();
        public static List<MasterCard> Toon = new List<MasterCard>();
        public static List<MasterCard> Union = new List<MasterCard>();
        public static List<MasterCard> Tuner = new List<MasterCard>();
        public static List<MasterCard> Gemini = new List<MasterCard>();

        //Attributes
        public static List<MasterCard> Light = new List<MasterCard>();
        public static List<MasterCard> Dark = new List<MasterCard>();
        public static List<MasterCard> Water = new List<MasterCard>();
        public static List<MasterCard> Fire = new List<MasterCard>();
        public static List<MasterCard> Wind = new List<MasterCard>();
        public static List<MasterCard> Earth = new List<MasterCard>();
        public static List<MasterCard> Divine = new List<MasterCard>();
        #endregion
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
        Counter_Traps
    }
    #endregion
}
