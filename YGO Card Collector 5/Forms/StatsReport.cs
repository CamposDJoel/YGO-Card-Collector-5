//Joel Campos
//2/9/2024
//StatsReport Class

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
        public StatsReport(Object collertorform)
        {
            InitializeComponent();
            LoadMasterStats();
            LoadSetsStats();
            CollectorForm = collertorform;
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
            }
        }
        private void LoadSetsStats()
        {
            int Y_Axis = 19;
            foreach(SetInfo ThisSetInfo in Database.BoosterPacks) 
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabBoosters);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.SpEditionBoxes)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabSpEditionBoxes);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.StarterDecks)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabStarterDecks);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.StructureDecks)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabStructDecks);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.Tins)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabTins);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.SpeedDuel)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabSpeedDuel);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.DuelistPacks)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabDP);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.DuelTerminal)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabDT);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.Others)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabOther);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.MBC)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabMBC);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.Tournaments)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabTournaments);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.Promos)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabPromos);
                Y_Axis += 16;
            }

            Y_Axis = 19;
            foreach (SetInfo ThisSetInfo in Database.VideoGames)
            {
                InitalizeSetStatRow(ThisSetInfo, Y_Axis, TabVGs);
                Y_Axis += 16;
            }

            void InitalizeSetStatRow(SetInfo ThisSetInfo, int Y_Location, TabPage ThisPage)
            {
                //Get all the freaking data
                string year = ThisSetInfo.Year;
                string name = ThisSetInfo.Name;
                string code = ThisSetInfo.GetCode();
                int mainListObtained = ThisSetInfo.GetMainListObtained();
                int variantListObtained = ThisSetInfo.GetVariantListObtained();
                int mainListCardTotal = ThisSetInfo.GetMainListCardTotal();
                int variantListCardTotal = ThisSetInfo.GetVariantListCardTotal();

                bool FullSetOwned = mainListObtained == mainListCardTotal;

                //Start displaying the row elements
                Label yearCode = new Label();
                ThisPage.Controls.Add(yearCode);
                yearCode.Text = string.Format("{0} | {1}", year, code);              
                yearCode.BorderStyle = BorderStyle.FixedSingle;
                yearCode.AutoSize = false;
                yearCode.Font = new Font("Arial Rounded MT Bold", 9);               
                yearCode.Size = new Size(89, 17);
                yearCode.Location = new Point(6, Y_Location);
                if (_SetStatRowColor)
                {
                    yearCode.ForeColor = Color.White;
                }
                else
                {
                    yearCode.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { yearCode.ForeColor = Color.Aqua; }

                Label setname = new Label();
                ThisPage.Controls.Add(setname);
                setname.Text = name;
                setname.ForeColor = Color.White;
                setname.BorderStyle = BorderStyle.FixedSingle;
                setname.AutoSize = false;
                setname.Font = new Font("Arial Rounded MT Bold", 9);               
                setname.Size = new Size(292, 17);
                setname.Location = new Point(94, Y_Location);
                if (_SetStatRowColor)
                {
                    setname.ForeColor = Color.White;
                }
                else
                {
                    setname.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { setname.ForeColor = Color.Aqua; }

                Label mainCardlist = new Label();
                ThisPage.Controls.Add(mainCardlist);
                mainCardlist.Text = mainListObtained.ToString();
                mainCardlist.ForeColor = Color.White;
                mainCardlist.BorderStyle = BorderStyle.FixedSingle;
                mainCardlist.AutoSize = false;
                mainCardlist.Font = new Font("Arial Rounded MT Bold", 9);
                mainCardlist.TextAlign = ContentAlignment.MiddleRight;               
                mainCardlist.Size = new Size(30, 17);
                mainCardlist.Location = new Point(385, Y_Location);
                if (_SetStatRowColor)
                {
                    mainCardlist.ForeColor = Color.White;
                }
                else
                {
                    mainCardlist.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { mainCardlist.ForeColor = Color.Aqua; }

                Label mainCardlist2 = new Label();
                ThisPage.Controls.Add(mainCardlist2);
                mainCardlist2.Text = "/";
                mainCardlist2.ForeColor = Color.White;
                mainCardlist2.BorderStyle = BorderStyle.FixedSingle;
                mainCardlist2.AutoSize = false;
                mainCardlist2.Font = new Font("Arial Rounded MT Bold", 9);              
                mainCardlist2.Size = new Size(10, 17);
                mainCardlist2.Location = new Point(414, Y_Location);
                if (_SetStatRowColor)
                {
                    mainCardlist2.ForeColor = Color.White;
                }
                else
                {
                    mainCardlist2.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { mainCardlist2.ForeColor = Color.Aqua; }

                Label mainCardlist3 = new Label();
                ThisPage.Controls.Add(mainCardlist3);
                mainCardlist3.Text = mainListCardTotal.ToString();  
                mainCardlist3.ForeColor = Color.White;
                mainCardlist3.BorderStyle = BorderStyle.FixedSingle;
                mainCardlist3.AutoSize = false;
                mainCardlist3.Font = new Font("Arial Rounded MT Bold", 9);
                mainCardlist3.TextAlign = ContentAlignment.MiddleRight;
                mainCardlist3.ForeColor = Color.Gold;
                mainCardlist3.Size = new Size(30, 17);
                mainCardlist3.Location = new Point(423, Y_Location);
                if (_SetStatRowColor)
                {
                    mainCardlist3.ForeColor = Color.White;
                }
                else
                {
                    mainCardlist3.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { mainCardlist3.ForeColor = Color.Aqua; }

                double percentage1 = 0;
                if (mainListObtained > 0) { percentage1 = (mainListObtained / mainListCardTotal) * 100; }

                Label percentagelabel = new Label();
                ThisPage.Controls.Add(percentagelabel);
                percentagelabel.Text = percentage1 + "%";
                percentagelabel.ForeColor = Color.White;
                percentagelabel.BorderStyle = BorderStyle.FixedSingle;
                percentagelabel.AutoSize = false;
                percentagelabel.Font = new Font("Arial Rounded MT Bold", 9);
                percentagelabel.TextAlign = ContentAlignment.MiddleRight;
                percentagelabel.ForeColor = Color.Gold;
                percentagelabel.Size = new Size(40, 17);
                percentagelabel.Location = new Point(452, Y_Location);
                if (_SetStatRowColor)
                {
                    percentagelabel.ForeColor = Color.White;
                }
                else
                {
                    percentagelabel.ForeColor = Color.Yellow;
                }
                if (FullSetOwned) { percentagelabel.ForeColor = Color.Aqua; }



                ProgressBar bar = new ProgressBar();
                ThisPage.Controls.Add(bar);
                bar.Value = (int)percentage1;
                bar.Size = new Size(100, 17);
                bar.Location = new Point(491, Y_Location);

                if(variantListCardTotal > 0) 
                {
                    Label variantCardlist = new Label();
                    ThisPage.Controls.Add(variantCardlist);
                    variantCardlist.Text = variantListObtained.ToString();
                    variantCardlist.ForeColor = Color.White;
                    variantCardlist.BorderStyle = BorderStyle.FixedSingle;
                    variantCardlist.AutoSize = false;
                    variantCardlist.Font = new Font("Arial Rounded MT Bold", 9);
                    variantCardlist.TextAlign = ContentAlignment.MiddleRight;                    
                    variantCardlist.Size = new Size(30, 17);
                    variantCardlist.Location = new Point(590, Y_Location);
                    if (_SetStatRowColor)
                    {
                        variantCardlist.ForeColor = Color.White;
                    }
                    else
                    {
                        variantCardlist.ForeColor = Color.Yellow;
                    }

                    Label variantCardlist2 = new Label();
                    ThisPage.Controls.Add(variantCardlist2);
                    variantCardlist2.Text = "/";
                    variantCardlist2.ForeColor = Color.White;
                    variantCardlist2.BorderStyle = BorderStyle.FixedSingle;
                    variantCardlist2.AutoSize = false;
                    variantCardlist2.Font = new Font("Arial Rounded MT Bold", 9);                    
                    variantCardlist2.Size = new Size(10, 17);
                    variantCardlist2.Location = new Point(619, Y_Location);
                    if (_SetStatRowColor)
                    {
                        variantCardlist2.ForeColor = Color.White;
                    }
                    else
                    {
                        variantCardlist2.ForeColor = Color.Yellow;
                    }

                    Label variantCardlist3 = new Label();
                    ThisPage.Controls.Add(variantCardlist3);
                    variantCardlist3.Text = variantListCardTotal.ToString();
                    variantCardlist3.ForeColor = Color.White;
                    variantCardlist3.BorderStyle = BorderStyle.FixedSingle;
                    variantCardlist3.AutoSize = false;
                    variantCardlist3.Font = new Font("Arial Rounded MT Bold", 9);
                    variantCardlist3.TextAlign = ContentAlignment.MiddleRight;                    
                    variantCardlist3.Size = new Size(30, 17);
                    variantCardlist3.Location = new Point(628, Y_Location);
                    if (_SetStatRowColor)
                    {
                        variantCardlist3.ForeColor = Color.White;
                    }
                    else
                    {
                        variantCardlist3.ForeColor = Color.Yellow;
                    }

                    double percentage2 = 0;
                    if (variantListObtained > 0) { percentage2 = (variantListObtained / variantListCardTotal) * 100; }

                    ProgressBar bar2 = new ProgressBar();
                    ThisPage.Controls.Add(bar2);
                    bar2.Value = (int)percentage2;
                    bar2.Size = new Size(100, 17);
                    bar2.Location = new Point(657, Y_Location);
                }

                //Flip the flag
                _SetStatRowColor = !_SetStatRowColor;
            }
        }

        private bool _SetStatRowColor = true;
        private Object CollectorForm;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBackToCollector_Click(object sender, EventArgs e)
        {
            Dispose();
            Form CollectorsForm = (Form)CollectorForm;
            CollectorsForm.Show();
        }
    }
}
