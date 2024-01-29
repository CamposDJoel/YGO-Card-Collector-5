//Joel Campos
//1/29/2024
//Database Class

using System.Collections.Generic;

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

        #region Card Group Lists
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
}
