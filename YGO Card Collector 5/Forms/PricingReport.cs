﻿//Joel Campos
//2/13/2024
//Pricing Report Class

using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public partial class PricingReport : Form
    {
        #region Constructors
        public PricingReport(Object collertorform)
        {
            InitializeComponent();
            CollectorForm = collertorform;
            LoadCollectionPriceReportLists();
            LoadDBPriceReportLists();
            LoadSetsExplorer(0);
        }
        public PricingReport(Object collertorform, int groupIndex, int setIndex)
        {
            InitializeComponent();
            CollectorForm = collertorform;
            LoadCollectionPriceReportLists();
            LoadDBPriceReportLists();
            LoadSetsExplorer(groupIndex);

            //Switch to the Set Explorer Tab Immediately
            TABCONTROLMASTER.SelectedTab = TabSetExplorer;

            //Then the actual set.
            ListSets.SetSelected(setIndex, true);
        }
        #endregion

        #region Internal Data
        private Object CollectorForm;
        private List<SetInfo> _CurrentSetInfoListSelected;
        private List<Label> _SetDetailsLabels = new List<Label>();
        #endregion

        #region Private Methods
        private void LoadCollectionPriceReportLists()
        {
            List<SetCard> PriceList = new List<SetCard>();
            List<SetCard> PriceListMedian = new List<SetCard>();
            foreach (MasterCard ThisMasterCard in Database.MasterCards)
            {
                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    if (ThisSetCard.Code != "")
                    {
                        if(ThisSetCard.Obtained)
                        {
                            PriceList.Add(ThisSetCard);
                            PriceListMedian.Add(ThisSetCard);
                        }                        
                    }
                }
            }

            PriceList.Sort(new SetCard.SortByPrice());
            PriceListMedian.Sort(new SetCard.SortByMedianPrice());

            //display the cards
            ListTop1000ReportCollection.Items.Clear();
            ListTop1000ReportMedianCollection.Items.Clear();

            double marketPriceTotalValue = 0;
            double medianPriceTotalValue = 0;
            foreach (SetCard ThisSetCard in PriceList)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                ListTop1000ReportCollection.Items.Add(string.Format("[{0}] - [{1} | {2}] - {3}", ThisSetCard.MarketPrice, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                marketPriceTotalValue += ThisSetCard.GetDoubleMarketPrice();
            }
            foreach (SetCard ThisSetCard in PriceListMedian)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                ListTop1000ReportMedianCollection.Items.Add(string.Format("[{0}] - [{1} | {2}] - {3}", ThisSetCard.MediamPrice, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                medianPriceTotalValue += ThisSetCard.GetDoubleMarketPrice();
            }

            lblMarketPriceTotalValueCollection.Text = string.Format("Total Value: ${0}", marketPriceTotalValue.ToString());
            lblMedianPriceTotalValueCollection.Text = string.Format("Total Value: ${0}", medianPriceTotalValue.ToString());
        }
        private void LoadDBPriceReportLists()
        {
            //StringBuilder sb = new StringBuilder();
            List<SetCard> PriceList = new List<SetCard>();
            List<SetCard> PriceListMedian = new List<SetCard>();
            foreach (MasterCard ThisMasterCard in Database.MasterCards)
            {
                foreach (SetCard ThisSetCard in ThisMasterCard.SetCards)
                {
                    if (ThisSetCard.Code != "")
                    {
                        PriceList.Add(ThisSetCard);
                        PriceListMedian.Add(ThisSetCard);
                    }
                }
            }

            PriceList.Sort(new SetCard.SortByPrice());
            PriceListMedian.Sort(new SetCard.SortByMedianPrice());

            //display the cards
            ListTop1000ReportDB.Items.Clear();
            ListTop1000ReportMedianDB.Items.Clear();

            int marketPriceTotalValue = 0;
            int medianPriceTotalValue = 0;
            foreach (SetCard ThisSetCard in PriceList)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                string obtainedmark = "";
                if (ThisSetCard.Obtained) { obtainedmark = "- [x] "; }
                ListTop1000ReportDB.Items.Add(string.Format("[{0}] {1}- [{2} | {3}] - {4}", ThisSetCard.MarketPrice, obtainedmark, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                marketPriceTotalValue += (int)ThisSetCard.GetDoubleMarketPrice();
            }
            foreach (SetCard ThisSetCard in PriceListMedian)
            {
                string cardname = Database.MasterCardByCode[ThisSetCard.Code].Name;
                string obtainedmark = "";
                if (ThisSetCard.Obtained) { obtainedmark = "- [x] "; }
                ListTop1000ReportMedianDB.Items.Add(string.Format("[{0}] {1}- [{2} | {3}] - {4}", ThisSetCard.MediamPrice, obtainedmark, ThisSetCard.Code, ThisSetCard.Rarity, cardname));
                medianPriceTotalValue += (int)ThisSetCard.GetDoubleMarketPrice();
            }

            lblMarketPriceTotalValueDB.Text = string.Format("Total Value: ${0}", marketPriceTotalValue.ToString());
            lblMedianPriceTotalValueDb.Text = string.Format("Total Value: ${0}", medianPriceTotalValue.ToString());
        }
        private void LoadSetsExplorer(int initialindex)
        {
            ListSetGroups.SetSelected(initialindex, true);
        }
        #endregion

        #region Event Listeners (Set Pack Explorer Tab)
        private void ListSetGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            _CurrentSetInfoListSelected = SetList;

            ListSets.Items.Clear();
            foreach (SetInfo set in SetList)
            {
                ListSets.Items.Add(set.GetInfoLine());
            }
            ListSets.SetSelected(0, true);
        }
        private void ListSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hide this list selector until the price panel is loaded
            ListSetGroups.Visible = false;
            ListSets.Visible = false;

            int CardSetIndex = ListSets.SelectedIndex;
            string SetName = _CurrentSetInfoListSelected[CardSetIndex].Name;
            if (Database.SetPackByName.ContainsKey(SetName))
            {
                //Dispose all the existing labels
                foreach (Label label in _SetDetailsLabels)
                {
                    label.Dispose();
                }
                _SetDetailsLabels.Clear();

                SetPack CurrentSetPack = Database.SetPackByName[SetName];
                CurrentSetPack.SortByCode();

                //Display the main card list
                PanelSetInfo.Visible = true;
                int CurrentY_Axis = 40;
                int Ysize = 15;
                foreach (SetCard ThisSetCard in CurrentSetPack.MainCardList)
                {
                    //Paint the row
                    PaintCardRow(ThisSetCard, CurrentY_Axis, Ysize);

                    //Move the Y Axis
                    CurrentY_Axis += 15;
                }

                //display the totals
                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName = new Label();
                PanelSetInfo.Controls.Add(totalsName);
                totalsName.Text = "Total value of this set:";
                totalsName.ForeColor = Color.White;
                totalsName.BorderStyle = BorderStyle.FixedSingle;
                totalsName.AutoSize = false;
                totalsName.Size = new Size(220, Ysize);
                totalsName.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName);

                //Totals Market
                Label totalsMarket = new Label();
                PanelSetInfo.Controls.Add(totalsMarket);
                totalsMarket.Text = "$" + CurrentSetPack.SetMainListMarketValue.ToString();
                totalsMarket.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket.ForeColor = Color.White;
                totalsMarket.AutoSize = false;
                totalsMarket.Size = new Size(60, Ysize);
                totalsMarket.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket);

                //Totals Median
                Label totalsMedian = new Label();
                PanelSetInfo.Controls.Add(totalsMedian);
                totalsMedian.Text = "$" + CurrentSetPack.SetMainListMedianValue.ToString();
                totalsMedian.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian.ForeColor = Color.White;
                totalsMedian.AutoSize = false;
                totalsMedian.Size = new Size(60, Ysize);
                totalsMedian.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian);

                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName2 = new Label();
                PanelSetInfo.Controls.Add(totalsName2);
                totalsName2.Text = "Total value of your collection:";
                totalsName2.ForeColor = Color.White;
                totalsName2.BorderStyle = BorderStyle.FixedSingle;
                totalsName2.AutoSize = false;
                totalsName2.Size = new Size(220, Ysize);
                totalsName2.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName2);

                //Totals Market
                Label totalsMarket2 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket2);
                totalsMarket2.Text = "$" + CurrentSetPack.SetMainListMarketValueObtained.ToString();
                totalsMarket2.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket2.ForeColor = Color.White;
                totalsMarket2.AutoSize = false;
                totalsMarket2.Size = new Size(60, Ysize);
                totalsMarket2.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket2);

                //Totals Median
                Label totalsMedian2 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian2);
                totalsMedian2.Text = "$" + CurrentSetPack.SetMainListMedianValueObtained.ToString();
                totalsMedian2.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian2.ForeColor = Color.White;
                totalsMedian2.AutoSize = false;
                totalsMedian2.Size = new Size(60, Ysize);
                totalsMedian2.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian2);


                //Display the Extra Card List Label
                CurrentY_Axis += 30;
                Label ExtraCardsHeader = new Label();
                PanelSetInfo.Controls.Add(ExtraCardsHeader);
                ExtraCardsHeader.Text = "Extra Rairty Cards:";
                ExtraCardsHeader.ForeColor = Color.White;
                ExtraCardsHeader.BorderStyle = BorderStyle.None;
                ExtraCardsHeader.AutoSize = false;
                ExtraCardsHeader.Size = new Size(300, 17);
                ExtraCardsHeader.Location = new Point(10, CurrentY_Axis);
                _SetDetailsLabels.Add(ExtraCardsHeader);
                CurrentY_Axis += 25;

                //Display the extra card list
                foreach (SetCard ThisSetCard in CurrentSetPack.ExtraCardList)
                {
                    //Paint the row
                    PaintCardRow(ThisSetCard, CurrentY_Axis, Ysize);

                    //Move the Y Axis
                    CurrentY_Axis += 15;
                }

                //display the totals
                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName3 = new Label();
                PanelSetInfo.Controls.Add(totalsName3);
                totalsName3.Text = "Total value of this set:";
                totalsName3.ForeColor = Color.White;
                totalsName3.BorderStyle = BorderStyle.FixedSingle;
                totalsName3.AutoSize = false;
                totalsName3.Size = new Size(220, Ysize);
                totalsName3.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName3);

                //Totals Market
                Label totalsMarket3 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket3);
                totalsMarket3.Text = "$" + CurrentSetPack.SetExtraListMarketValue.ToString();
                totalsMarket3.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket3.ForeColor = Color.White;
                totalsMarket3.AutoSize = false;
                totalsMarket3.Size = new Size(60, Ysize);
                totalsMarket3.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket3);

                //Totals Median
                Label totalsMedian3 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian3);
                totalsMedian3.Text = "$" + CurrentSetPack.SetExtraListMedianValue.ToString();
                totalsMedian3.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian3.ForeColor = Color.White;
                totalsMedian3.AutoSize = false;
                totalsMedian3.Size = new Size(60, Ysize);
                totalsMedian3.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian3);

                CurrentY_Axis += 15;
                //Totals Name
                Label totalsName4 = new Label();
                PanelSetInfo.Controls.Add(totalsName4);
                totalsName4.Text = "Total value of your collection:";
                totalsName4.ForeColor = Color.White;
                totalsName4.BorderStyle = BorderStyle.FixedSingle;
                totalsName4.AutoSize = false;
                totalsName4.Size = new Size(220, Ysize);
                totalsName4.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsName4);

                //Totals Market
                Label totalsMarket4 = new Label();
                PanelSetInfo.Controls.Add(totalsMarket4);
                totalsMarket4.Text = "$" + CurrentSetPack.SetExtraListMarketValueObtained.ToString();
                totalsMarket4.BorderStyle = BorderStyle.FixedSingle;
                totalsMarket4.ForeColor = Color.White;
                totalsMarket4.AutoSize = false;
                totalsMarket4.Size = new Size(60, Ysize);
                totalsMarket4.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMarket4);

                //Totals Median
                Label totalsMedian4 = new Label();
                PanelSetInfo.Controls.Add(totalsMedian4);
                totalsMedian4.Text = "$" + CurrentSetPack.SetExtraListMedianValueObtained.ToString();
                totalsMedian4.BorderStyle = BorderStyle.FixedSingle;
                totalsMedian4.ForeColor = Color.White;
                totalsMedian4.AutoSize = false;
                totalsMedian4.Size = new Size(60, Ysize);
                totalsMedian4.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(totalsMedian4);
            }
            else
            {
                PanelSetInfo.Visible = false;
            }

            //okay now show it again
            ListSetGroups.Visible = true;
            ListSets.Visible = true;

            void PaintCardRow(SetCard ThisSetCard, int CurrentY_Axis, int Ysize)
            {
                //Code
                Label codeLabel = new Label();
                PanelSetInfo.Controls.Add(codeLabel);
                codeLabel.Text = ThisSetCard.Code;
                codeLabel.ForeColor = Color.White;
                codeLabel.BorderStyle = BorderStyle.FixedSingle;
                codeLabel.AutoSize = false;
                codeLabel.Size = new Size(80, Ysize);
                codeLabel.Location = new Point(10, CurrentY_Axis);
                _SetDetailsLabels.Add(codeLabel);

                //Name label
                Label packname = new Label();
                PanelSetInfo.Controls.Add(packname);
                packname.Text = ThisSetCard.GetCardName();
                packname.ForeColor = Color.White;
                packname.BorderStyle = BorderStyle.FixedSingle;
                if (ThisSetCard.HasTCGURL())
                {
                    packname.Tag = ThisSetCard.TCGPlayerURL;
                    packname.Click += new EventHandler(NameLabel_click);
                    packname.MouseEnter += new EventHandler(OnMouseEnterLabel);
                    packname.MouseLeave += new EventHandler(OnMouseLeaveLabel);
                }
                packname.AutoSize = false;
                packname.Size = new Size(220, Ysize);
                packname.Location = new Point(90, CurrentY_Axis);
                _SetDetailsLabels.Add(packname);

                //Rarity Label
                Label rarityLabel = new Label();
                PanelSetInfo.Controls.Add(rarityLabel);
                rarityLabel.Text = ThisSetCard.Rarity;
                rarityLabel.BorderStyle = BorderStyle.FixedSingle;
                rarityLabel.ForeColor = Tools.GetRarityColorForLabel(ThisSetCard.Rarity);
                rarityLabel.AutoSize = false;
                rarityLabel.Size = new Size(80, Ysize);
                rarityLabel.Location = new Point(310, CurrentY_Axis);
                _SetDetailsLabels.Add(rarityLabel);

                //market Label
                Label marketLabel = new Label();
                PanelSetInfo.Controls.Add(marketLabel);
                marketLabel.Text = ThisSetCard.MarketPrice;
                marketLabel.BorderStyle = BorderStyle.FixedSingle;
                marketLabel.ForeColor = Tools.GetPriceColorForLabel(ThisSetCard.GetDoubleMarketPrice());
                marketLabel.AutoSize = false;
                marketLabel.Size = new Size(60, Ysize);
                marketLabel.Location = new Point(390, CurrentY_Axis);
                _SetDetailsLabels.Add(marketLabel);

                //median Label
                Label medianLabel = new Label();
                PanelSetInfo.Controls.Add(medianLabel);
                medianLabel.Text = ThisSetCard.MediamPrice;
                medianLabel.BorderStyle = BorderStyle.FixedSingle;
                medianLabel.ForeColor = Tools.GetPriceColorForLabel(ThisSetCard.GetDoubleMedianPrice());
                medianLabel.AutoSize = false;
                medianLabel.Size = new Size(60, Ysize);
                medianLabel.Location = new Point(450, CurrentY_Axis);
                _SetDetailsLabels.Add(medianLabel);

                //obtained Label
                Label obtainedLabel = new Label();
                PanelSetInfo.Controls.Add(obtainedLabel);
                if (ThisSetCard.Obtained) { obtainedLabel.Text = "X"; }
                obtainedLabel.BorderStyle = BorderStyle.FixedSingle;
                obtainedLabel.ForeColor = Color.White;
                obtainedLabel.AutoSize = false;
                obtainedLabel.Size = new Size(30, Ysize);
                obtainedLabel.Location = new Point(510, CurrentY_Axis);
                _SetDetailsLabels.Add(obtainedLabel);
            }
        }
        private void NameLabel_click(object sender, EventArgs e)
        {
            //Initialize the Card Selected based on the TAG of the image clicked.
            Label ThisLabel = (Label)sender;
            Tools.LaunchURLIntoBrowser(ThisLabel.Tag.ToString());
        }
        private void OnMouseEnterLabel(object sender, EventArgs e)
        {
            //SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label thisLabel = (Label)sender;
            thisLabel.ForeColor = Color.Yellow;
        }
        private void OnMouseLeaveLabel(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            thisLabel.ForeColor = Color.White;
        }
        #endregion

        #region Other Event Listeners
        private void btnBackToCollector_Click(object sender, EventArgs e)
        {
            Dispose();
            Form CollectorsForm = (Form)CollectorForm;
            CollectorsForm.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}