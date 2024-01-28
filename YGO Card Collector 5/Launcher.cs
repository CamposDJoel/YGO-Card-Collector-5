//Joel Campos
//1/27/2024
//Launcher Form Class

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class FormLauncher : Form
    {
        public FormLauncher()
        {
            InitializeComponent();
        }

        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            string jsonFilePath = Directory.GetCurrentDirectory() + "\\Database\\CardDB.json";
            string rawdata = File.ReadAllText(jsonFilePath);
            btnLoadDB.Visible = false;
            BarProgress.Visible = true;
            PanelOutput.Visible = true;
            Tools.WaitNSeconds(1000);

            //Attempt to deserialize the JSON. If it fail simply show error.
            try 
            {               
                Database.MasterCards = JsonConvert.DeserializeObject<List<MasterCard>>(rawdata);
                lblJsonStatus.Text = "JSON DB Deserialization Successful!";          
            }
            catch (Exception)
            {
                btnLoadDB.Visible = true;
                BarProgress.Visible= false;
                lblJsonStatus.Text = "JSON DB Deserialization Failed! - Fix JSON!";
                return;
            }

            //Continue to sorting the master card list
            int counter = 1;
            BarProgress.Maximum = Database.MasterCards.Count;
            foreach (MasterCard ThisMasterCard in Database.MasterCards) 
            {
                //Message
                lblCardSorting.Text = string.Format("Sorting Card: {0}/{1}", counter, Database.MasterCards.Count);

                //Step 1: Add this card to the dictionary for quick search by name
                Database.MasterCardDict.Add(ThisMasterCard.Name, ThisMasterCard);

                //Step 2: Add this Master Card into its corresponding Card Group
                string Group = ThisMasterCard.Type;
                switch(Group)
                {
                    case "Normal Spell":        Database.NormalSpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Continuous Spell":    Database.ContinuousSpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Quick-Play Spell":    Database.QuickPlaySpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Equip Spell":         Database.EquipSpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Field Spell":         Database.FieldSpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Ritual Spell":        Database.RitualSpells.Add(ThisMasterCard); Database.Spells.Add(ThisMasterCard); break;
                    case "Normal Trap":         Database.NormalTraps.Add(ThisMasterCard); Database.Traps.Add(ThisMasterCard); break;
                    case "Continuous Trap":     Database.ContinuousTraps.Add(ThisMasterCard); Database.Traps.Add(ThisMasterCard); break;
                    case "Counter Trap":        Database.CounterTraps.Add(ThisMasterCard); Database.Traps.Add(ThisMasterCard); break;
                    default:
                        //Sort by Monster Type and subtypes
                        Database.Monsters.Add(ThisMasterCard);
                        if (Group.Contains("Aqua")) { Database.AquaMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Beast-Warrior")) { Database.BeastWarriorMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Winged Beast")) { Database.WingedBeastMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Divine-Beast")) { Database.DivineBeastMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Beast")) { Database.BeastMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Cyberse")) { Database.CyberseMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Dinosaur")) { Database.DinosaurMonsters.Add(ThisMasterCard); }                   
                        else if (Group.Contains("Dragon")) { Database.DragonMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Fairy")) { Database.FairyMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Fiend")) { Database.FiendMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Fish")) { Database.FishMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Illusion")) { Database.IllusionMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Insect")) { Database.InsectMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Machine")) { Database.MachineMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Plant")) { Database.PlantMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Psychic")) { Database.PsychicMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Pyro")) { Database.PyroMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Reptile")) { Database.ReptileMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Rock")) { Database.RockMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Sea Serpent")) { Database.SeaSerpentMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Spellcaster")) { Database.SpellcasterMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Thunder")) { Database.ThunderMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Warrior")) { Database.WarriorMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Wyrm")) { Database.WyrmMonsters.Add(ThisMasterCard); }
                        else if (Group.Contains("Zombie")) { Database.ZombieMonsters.Add(ThisMasterCard); }
                        //Subtypes
                        if (Group.Contains("Normal")) { Database.Normal.Add(ThisMasterCard); }
                        if (Group.Contains("Effect")) { Database.Effect.Add(ThisMasterCard); }
                        if (Group.Contains("Fusion")) { Database.Fusion.Add(ThisMasterCard); }
                        if (Group.Contains("Ritual")) { Database.Ritual.Add(ThisMasterCard); }
                        if (Group.Contains("Synchro")) { Database.Synchro.Add(ThisMasterCard); }
                        if (Group.Contains("Xyz")) { Database.Xyz.Add(ThisMasterCard); }
                        if (Group.Contains("Pendulum")) { Database.Pendulum.Add(ThisMasterCard); }
                        if (Group.Contains("Link")) { Database.Link.Add(ThisMasterCard); }
                        //Subtype 2
                        if (Group.Contains("Flip")) { Database.Flip.Add(ThisMasterCard); }
                        if (Group.Contains("Spirit")) { Database.Spirit.Add(ThisMasterCard); }
                        if (Group.Contains("Toon")) { Database.Toon.Add(ThisMasterCard); }
                        if (Group.Contains("Union")) { Database.Union.Add(ThisMasterCard); }
                        if (Group.Contains("Gemini")) { Database.Gemini.Add(ThisMasterCard); }
                        //Attribute
                        if (Group.Contains("LIGHT")) { Database.Light.Add(ThisMasterCard); }
                        if (Group.Contains("DARK")) { Database.Dark.Add(ThisMasterCard); }
                        if (Group.Contains("WATER")) { Database.Water.Add(ThisMasterCard); }
                        if (Group.Contains("FIRE")) { Database.Fire.Add(ThisMasterCard); }
                        if (Group.Contains("WIND")) { Database.Wind.Add(ThisMasterCard); }
                        if (Group.Contains("EARTH")) { Database.Earth.Add(ThisMasterCard); }
                        if (Group.Contains("DIVINE")) { Database.Divine.Add(ThisMasterCard); }
                        break;
                }

                //Step 3: Sort each MasterCard's SetCards into its respective sets


                //Last Step: Update progress bar
                BarProgress.Value = counter;
                counter++;
            }
            
        }
    }
}
