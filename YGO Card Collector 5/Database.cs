using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class Database
    {
        public static Dictionary<string, MasterCard> MasterCardDict = new Dictionary<string, MasterCard>();
        public static List<MasterCard> MasterCards = new List<MasterCard>();


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
    }
}
