using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DatabaseManager : Form
    {
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
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdateKonamiList_Click(object sender, EventArgs e)
        {

        }
    }
}
