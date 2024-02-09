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
    public partial class StatsReport : Form
    {
        public StatsReport()
        {
            InitializeComponent();
            LoadMasterStats();
        }

        private void LoadMasterStats()
        {
            //Monsters
            List<CardGroup> _MonsterCardGroups = new List<CardGroup>
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
            };
            int Y_Axis = 16;
            foreach(CardGroup group in _MonsterCardGroups)
            {
                InitializeMasterStatRow(Group_MS_Monsters, Y_Axis, group);
                Y_Axis += 15;
            }

            //Spells
            List<CardGroup> _SpellCardGroups = new List<CardGroup>
            {
                CardGroup.Normal_Spells,
                CardGroup.Continuous_Spells,
                CardGroup.QuickPlay_Spells,
                CardGroup.Equip_Spells,
                CardGroup.Field_Spells,
                CardGroup.Ritual_Spells
            };
            Y_Axis = 16;
            foreach (CardGroup group in _SpellCardGroups)
            {
                InitializeMasterStatRow(Group_MS_Spells, Y_Axis, group);
                Y_Axis += 15;
            }

            //Traps
            List<CardGroup> _TrapCardGroups = new List<CardGroup>
            {
                CardGroup.Normal_Traps,
                CardGroup.Continuous_Traps,
                CardGroup.Counter_Traps
            };
            Y_Axis = 16;
            foreach (CardGroup group in _TrapCardGroups)
            {
                InitializeMasterStatRow(Group_MS_Traps, Y_Axis, group);
                Y_Axis += 15;
            }

            //Totals
            List<CardGroup> _TotalsCardGroups = new List<CardGroup>
            {
                CardGroup.All_Monsters,
                CardGroup.All_Spells,
                CardGroup.All_Trap,
                CardGroup.AllCards
            };
            Y_Axis = 16;
            foreach (CardGroup group in _TotalsCardGroups)
            {
                InitializeMasterStatRow(Group_MS_Totals, Y_Axis, group);
                Y_Axis += 15;
            }

            //Colors
            List<CardGroup> _ColorsCardGroups = new List<CardGroup>
            {
                CardGroup.Normal_Monsters,
                CardGroup.Effect_Monsters,
                CardGroup.Fusion_Monsters,
                CardGroup.Ritual_Monsters,
                CardGroup.Synchro_Monsters,
                CardGroup.Xyz_Monsters,
                CardGroup.Pendulum_Monsters,
                CardGroup.Link_Monsters
            };
            Y_Axis = 16;
            foreach (CardGroup group in _ColorsCardGroups)
            {
                InitializeMasterStatRow(Group_MS_Colors, Y_Axis, group);
                Y_Axis += 15;
            }

            void InitializeMasterStatRow(GroupBox ThisGroupBox, int GroupNameLabelYPoint, CardGroup ThisGroup)
            {
                //get data
                int ObtainedCount = Database.GetCardGroupObtainedCount(ThisGroup);
                int TotalCount = Database.GroupCardListByGroupName[ThisGroup].Count;

                int Ysize = 16;

                //Initialize components               
                //Monster Type Label
                Label GroupNameLabel = new Label();
                ThisGroupBox.Controls.Add(GroupNameLabel);
                GroupNameLabel.Text = Database.CardGroupToString(ThisGroup);
                GroupNameLabel.BorderStyle = BorderStyle.FixedSingle;
                GroupNameLabel.AutoSize = false;
                GroupNameLabel.Size = new Size(115, Ysize);
                GroupNameLabel.Location = new Point(3, GroupNameLabelYPoint);

                //Obtained label
                Label ObtainedLabel = new Label();
                ThisGroupBox.Controls.Add(ObtainedLabel);
                ObtainedLabel.Text = ObtainedCount.ToString();
                ObtainedLabel.BorderStyle = BorderStyle.FixedSingle;
                ObtainedLabel.AutoSize = false;
                ObtainedLabel.Size = new Size(48, Ysize);
                ObtainedLabel.TextAlign = ContentAlignment.MiddleRight;
                ObtainedLabel.Location = new Point(117, GroupNameLabelYPoint);

                //"/" label
                Label LashLabel = new Label();
                ThisGroupBox.Controls.Add(LashLabel);
                LashLabel.Text = "/";
                LashLabel.BorderStyle = BorderStyle.FixedSingle;
                LashLabel.AutoSize = false;
                LashLabel.Size = new Size(15, Ysize);
                LashLabel.Location = new Point(164, GroupNameLabelYPoint);

                //Base Total label
                Label BaseTotalLabel = new Label();
                ThisGroupBox.Controls.Add(BaseTotalLabel);
                BaseTotalLabel.Text = TotalCount.ToString();
                BaseTotalLabel.BorderStyle = BorderStyle.FixedSingle;
                BaseTotalLabel.AutoSize = false;
                BaseTotalLabel.Size = new Size(48, Ysize);
                BaseTotalLabel.TextAlign = ContentAlignment.MiddleRight;
                BaseTotalLabel.Location = new Point(178, GroupNameLabelYPoint);


                double obtainedAmount = ObtainedCount;
                double baseAmount = TotalCount;
                double percentage = 0;
                if (TotalCount > 0) { percentage = (obtainedAmount / baseAmount) * 100; }


                //Percentage label
                Label PercentageLabel = new Label();
                ThisGroupBox.Controls.Add(PercentageLabel);
                PercentageLabel.Text = (int)percentage + "%";
                PercentageLabel.BorderStyle = BorderStyle.FixedSingle;
                PercentageLabel.AutoSize = false;
                PercentageLabel.Size = new Size(60, Ysize);
                PercentageLabel.TextAlign = ContentAlignment.MiddleRight;
                PercentageLabel.Location = new Point(220, GroupNameLabelYPoint);

                ProgressBar bar = new ProgressBar();
                ThisGroupBox.Controls.Add(bar);
                bar.Value = (int)percentage;
                bar.Size = new Size(100, Ysize);
                bar.Location = new Point(279, GroupNameLabelYPoint);
                if(percentage == 100)
                {
                    PercentageLabel.ForeColor = Color.Aqua;
                }

                /*if (percentage <= 33)
                {
                    PercentageLabel.ForeColor = Color.Red;
                }
                else if (percentage <= 66)
                {
                    PercentageLabel.ForeColor = Color.Yellow;
                }
                else if (percentage <= 99)
                {
                    PercentageLabel.ForeColor = Color.Lime;
                }
                else
                {
                    PercentageLabel.ForeColor = Color.Aqua;
                }*/

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
