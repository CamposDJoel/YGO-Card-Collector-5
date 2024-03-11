//Joel Campos
//3/11/2024
//Deck Pricing Report Class

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DeckPricingReport : Form
    {
        #region Constructors
        public DeckPricingReport(Deck activeDeck, DeckBuilder deckBuilderFormRef)
        {
            _deckBuilderFormRef = deckBuilderFormRef;
            InitializeComponent();

            //Load Form theme and music
            Tools.InitalizeThemeOnForm(this);

            //Initialize Card Images
            InitializeCardImages_DECK();
            InitializeCardImages_EXTRA();
            InitializeCardImages_SIDE();

            //Initialize Deck Data
            ActiveDeck = activeDeck;
            _CurrentDeckCardList = ActiveDeck.GetMainDeckMasterCardList();
            _CurrentExtraCardList = ActiveDeck.GetExtraDeckMasterCardList();
            _CurrentSideCardList = ActiveDeck.GetSideDeckMasterCardList();

            //Initailize Deck name
            lblDeckName.Text = string.Format("Deck: [{0}]", ActiveDeck.Name);

            //Load the Pages of all Groups
            LoadPage_DECK();
            LoadPage_EXTRA();
            LoadPage_SIDE();

            //Set the initial cursor on the first card of the Box group
            ClickCardFromDeck(0);

            //Initialize Cheapest Deck Report
            InitializeCheapestDeckData();

            void InitializeCardImages_DECK()
            {
                int Picture_XSIZE = 39;
                int Picture_YSIZE = 50;
                int CARD_XSIZE = Picture_XSIZE - 4;
                int CARD_YSIZE = Picture_YSIZE - 4;
                int ICON_SIZE = 15;
                int ROWS = 5;
                int COLUMNS = 7;

                int imageID = 0;
                int Y_Location = 15;

                for (int x = 0; x < ROWS; x++)
                {
                    int X_Location = 6;
                    for (int y = 0; y < COLUMNS; y++)
                    {
                        //Initialize the border box Image
                        Panel CardBox = new Panel();
                        GroupDeck.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(Picture_XSIZE, Picture_YSIZE);
                        _CardPanelListDECK.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(ICON_SIZE, ICON_SIZE);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        //CardIcon.Visible = false;
                        _IconImageListDECK.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(CARD_XSIZE, CARD_YSIZE);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(ImageDECK_click);
                        _CardImageListDECK.Add(CardImage);

                        X_Location += Picture_XSIZE;
                        imageID++;
                    }
                    Y_Location += Picture_YSIZE;
                }
            }
            void InitializeCardImages_EXTRA()
            {
                int Picture_XSIZE = 39;
                int Picture_YSIZE = 50;
                int CARD_XSIZE = Picture_XSIZE - 4;
                int CARD_YSIZE = Picture_YSIZE - 4;
                int ICON_SIZE = 15;
                int ROWS = 1;
                int COLUMNS = 7;

                int imageID = 0;
                int Y_Location = 15;

                for (int x = 0; x < ROWS; x++)
                {
                    int X_Location = 6;
                    for (int y = 0; y < COLUMNS; y++)
                    {
                        //Initialize the border box Image
                        Panel CardBox = new Panel();
                        GroupExtra.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(Picture_XSIZE, Picture_YSIZE);
                        _CardPanelListEXTRA.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(ICON_SIZE, ICON_SIZE);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        //CardIcon.Visible = false;
                        _IconImageListEXTRA.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(CARD_XSIZE, CARD_YSIZE);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(ImageEXTRA_click);
                        _CardImageListEXTRA.Add(CardImage);

                        X_Location += Picture_XSIZE;
                        imageID++;
                    }
                    Y_Location += Picture_YSIZE;
                }
            }
            void InitializeCardImages_SIDE()
            {
                int Picture_XSIZE = 39;
                int Picture_YSIZE = 50;
                int CARD_XSIZE = Picture_XSIZE - 4;
                int CARD_YSIZE = Picture_YSIZE - 4;
                int ICON_SIZE = 15;
                int ROWS = 1;
                int COLUMNS = 7;

                int imageID = 0;
                int Y_Location = 15;

                for (int x = 0; x < ROWS; x++)
                {
                    int X_Location = 6;
                    for (int y = 0; y < COLUMNS; y++)
                    {
                        //Initialize the border box Image
                        Panel CardBox = new Panel();
                        GroupSide.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(Picture_XSIZE, Picture_YSIZE);
                        _CardPanelListSIDE.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(ICON_SIZE, ICON_SIZE);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        _IconImageListSIDE.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(CARD_XSIZE, CARD_YSIZE);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(ImageSIDE_click);
                        _CardImageListSIDE.Add(CardImage);

                        X_Location += Picture_XSIZE;
                        imageID++;
                    }
                    Y_Location += Picture_YSIZE;
                }
            }
        }
        #endregion

        #region Private Methods
        private void LoadPage_DECK()
        {
            //Set the total Card Count
            int TotalCardCount = _CurrentDeckCardList.Count;

            //Start the iterator
            int PageIntialIndex = (_CurrentPageDECK * CARDS_PER_PAGE_DECK) - CARDS_PER_PAGE_DECK;

            //Loop thru all the Card Images to initialize them
            for (int x = 0; x < CARDS_PER_PAGE_DECK; x++)
            {
                //Set the card iterator index
                int iterator = PageIntialIndex + x;

                //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                if (iterator >= TotalCardCount)
                {
                    _CardPanelListDECK[x].Visible = false;
                }
                else
                {
                    //show the card
                    _CardPanelListDECK[x].Visible = true;

                    //Save Ref to the MasterCard object that will be used
                    MasterCard ThisMasterCard = _CurrentDeckCardList[iterator];

                    //Initialize the card image
                    if (_HideMode)
                    {
                        //Show the front of the card if owner, otherwise show the back
                        if (ThisMasterCard.IsOwned())
                        {
                            ImageServer.SetImage(_CardImageListDECK[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                        }
                        else
                        {
                            ImageServer.SetImage(_CardImageListDECK[x], ImageType.CardBack, "");
                        }
                    }
                    else
                    {
                        //always show the front of the card
                        ImageServer.SetImage(_CardImageListDECK[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                    }

                    //Initialize the obtained icon
                    LoadCardObtainedIcon(x, ThisMasterCard);
                }
            }

            //Update the group banner text
            int LastPage = GetLastPage(_CurrentDeckCardList, CARDS_PER_PAGE_DECK);
            GroupDeck.Text = string.Format("MAIN DECK - Cards: {0} - PAGE {1}/{2}", TotalCardCount, _CurrentPageDECK, LastPage);

            void LoadCardObtainedIcon(int x, MasterCard ThisMasterCard)
            {
                //Start with the Icon invisible
                _IconImageListDECK[x].Visible = false;
                if (ThisMasterCard.HasOneCardsObtained())
                {
                    ImageServer.SetImage(_IconImageListDECK[x], ImageType.CheckMark, "NONE");
                    _IconImageListDECK[x].Visible = true;
                }
            }
        }
        private void LoadPage_EXTRA()
        {
            //Set the total Card Count
            int TotalCardCount = _CurrentExtraCardList.Count;

            //Start the iterator
            int PageIntialIndex = (_CurrentPageEXTRA * CARDS_PER_PAGE_EXTRA) - CARDS_PER_PAGE_EXTRA;

            //Loop thru all the Card Images to initialize them
            for (int x = 0; x < CARDS_PER_PAGE_EXTRA; x++)
            {
                //Set the card iterator index
                int iterator = PageIntialIndex + x;

                //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                if (iterator >= TotalCardCount)
                {
                    _CardPanelListEXTRA[x].Visible = false;
                }
                else
                {
                    //show the card
                    _CardPanelListEXTRA[x].Visible = true;

                    //Save Ref to the MasterCard object that will be used
                    MasterCard ThisMasterCard = _CurrentExtraCardList[iterator];

                    //Initialize the card image
                    if (_HideMode)
                    {
                        //Show the front of the card if owner, otherwise show the back
                        if (ThisMasterCard.IsOwned())
                        {
                            ImageServer.SetImage(_CardImageListEXTRA[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                        }
                        else
                        {
                            ImageServer.SetImage(_CardImageListEXTRA[x], ImageType.CardBack, "");
                        }
                    }
                    else
                    {
                        //always show the front of the card
                        ImageServer.SetImage(_CardImageListEXTRA[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                    }

                    //Initialize the obtained icon
                    LoadCardObtainedIcon(x, ThisMasterCard);
                }
            }

            //Update the group banner text
            int LastPage = GetLastPage(_CurrentExtraCardList, CARDS_PER_PAGE_EXTRA);
            GroupExtra.Text = string.Format("EXTRA DECK - Cards: {0} - PAGE {1}/{2}", TotalCardCount, _CurrentPageEXTRA, LastPage);

            void LoadCardObtainedIcon(int x, MasterCard ThisMasterCard)
            {
                //Start with the Icon invisible
                _IconImageListEXTRA[x].Visible = false;
                if (ThisMasterCard.HasOneCardsObtained())
                {
                    ImageServer.SetImage(_IconImageListEXTRA[x], ImageType.CheckMark, "NONE");
                    _IconImageListEXTRA[x].Visible = true;
                }
            }
        }
        private void LoadPage_SIDE()
        {
            //Set the total Card Count
            int TotalCardCount = _CurrentSideCardList.Count;

            //Start the iterator
            int PageIntialIndex = (_CurrentPageSIDE * CARDS_PER_PAGE_SIDE) - CARDS_PER_PAGE_SIDE;

            //Loop thru all the Card Images to initialize them
            for (int x = 0; x < CARDS_PER_PAGE_SIDE; x++)
            {
                //Set the card iterator index
                int iterator = PageIntialIndex + x;

                //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                if (iterator >= TotalCardCount)
                {
                    _CardPanelListSIDE[x].Visible = false;
                }
                else
                {
                    //show the card
                    _CardPanelListSIDE[x].Visible = true;

                    //Save Ref to the MasterCard object that will be used
                    MasterCard ThisMasterCard = _CurrentSideCardList[iterator];

                    //Initialize the card image
                    if (_HideMode)
                    {
                        //Show the front of the card if owner, otherwise show the back
                        if (ThisMasterCard.IsOwned())
                        {
                            ImageServer.SetImage(_CardImageListSIDE[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                        }
                        else
                        {
                            ImageServer.SetImage(_CardImageListSIDE[x], ImageType.CardBack, "");
                        }
                    }
                    else
                    {
                        //always show the front of the card
                        ImageServer.SetImage(_CardImageListSIDE[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                    }

                    //Initialize the obtained icon
                    LoadCardObtainedIcon(x, ThisMasterCard);
                }
            }

            //Update the group banner text
            int LastPage = GetLastPage(_CurrentSideCardList, CARDS_PER_PAGE_SIDE);
            GroupSide.Text = string.Format("SIDE DECK - Cards: {0} - PAGE {1}/{2}", TotalCardCount, _CurrentPageSIDE, LastPage);

            void LoadCardObtainedIcon(int x, MasterCard ThisMasterCard)
            {
                //Start with the Icon invisible
                _IconImageListSIDE[x].Visible = false;
                if (ThisMasterCard.HasOneCardsObtained())
                {
                    ImageServer.SetImage(_IconImageListSIDE[x], ImageType.CheckMark, "NONE");
                    _IconImageListSIDE[x].Visible = true;
                }
            }
        }
        private void GoPreviousPage_DECK()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentDeckCardList, CARDS_PER_PAGE_DECK);
            if (lastpage != 0)
            {
                if (_CurrentPageDECK == 1) { _CurrentPageDECK = lastpage; }
                else { _CurrentPageDECK--; }

                LoadPage_DECK();
                _CurrentCardSelectedIndex = 0;
                InitializeSelectedCardInfo(0, CursorLocation.MainDeck);
            }
        }
        private void GoNextPage_DECK()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentDeckCardList, CARDS_PER_PAGE_DECK);
            if (lastpage != 0)
            {
                if (_CurrentPageDECK == lastpage) { _CurrentPageDECK = 1; }
                else { _CurrentPageDECK++; }

                LoadPage_DECK();
                InitializeSelectedCardInfo(0, CursorLocation.MainDeck);
            }
        }
        private void GoNextPage_EXTRA()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentExtraCardList, CARDS_PER_PAGE_EXTRA);
            if (lastpage != 0)
            {
                if (_CurrentPageEXTRA == lastpage) { _CurrentPageEXTRA = 1; }
                else { _CurrentPageEXTRA++; }

                LoadPage_EXTRA();
                InitializeSelectedCardInfo(0, CursorLocation.ExtraDeck);
            }
        }
        private void GoPreviousPage_EXTRA()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentExtraCardList, CARDS_PER_PAGE_EXTRA);
            if (lastpage != 0)
            {
                if (_CurrentPageEXTRA == 1) { _CurrentPageEXTRA = lastpage; }
                else { _CurrentPageEXTRA--; }

                LoadPage_EXTRA();
                _CurrentCardSelectedIndex = 0;
                InitializeSelectedCardInfo(0, CursorLocation.ExtraDeck);
            }
        }
        private void GoNextPage_SIDE()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentSideCardList, CARDS_PER_PAGE_SIDE);
            if (lastpage != 0)
            {
                if (_CurrentPageSIDE == lastpage) { _CurrentPageSIDE = 1; }
                else { _CurrentPageSIDE++; }

                LoadPage_SIDE();
                InitializeSelectedCardInfo(0, CursorLocation.SideDeck);
            }
        }
        private void GoPreviousPage_SIDE()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentSideCardList, CARDS_PER_PAGE_SIDE);
            if (lastpage != 0)
            {
                if (_CurrentPageSIDE == 1) { _CurrentPageSIDE = lastpage; }
                else { _CurrentPageSIDE--; }

                LoadPage_SIDE();
                _CurrentCardSelectedIndex = 0;
                InitializeSelectedCardInfo(0, CursorLocation.SideDeck);
            }
        }
        private int GetLastPage(List<MasterCard> currentCardlist, int cardsperpage)
        {
            double pages = ((double)currentCardlist.Count / (double)cardsperpage);
            int lastpage = (int)pages;
            double remaining = pages - (int)pages;
            if (remaining > 0) { lastpage++; }
            return lastpage;
        }
        private void ClickCardFromDeck(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.MainDeck);
        }
        private void ClickCardFromExtra(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.ExtraDeck);
        }
        private void ClickCardFromSide(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.SideDeck);
        }
        private void InitializeSelectedCardInfo(int newIndex, CursorLocation newLocation)
        {
            //Hide the old cursor location
            switch (_CurrentCursoLocation)
            {
                case CursorLocation.MainDeck: _CardPanelListDECK[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
                case CursorLocation.ExtraDeck: _CardPanelListEXTRA[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
                case CursorLocation.SideDeck: _CardPanelListSIDE[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
            }

            //Update new location/index
            _CurrentCursoLocation = newLocation;
            _CurrentCardSelectedIndex = newIndex;

            //Show the new Cursor Locator
            switch (_CurrentCursoLocation)
            {
                case CursorLocation.MainDeck: _CardPanelListDECK[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
                case CursorLocation.ExtraDeck: _CardPanelListEXTRA[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
                case CursorLocation.SideDeck: _CardPanelListSIDE[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
            }

            //picCardImage
            switch (newLocation)
            {
                case CursorLocation.MainDeck:
                    int index = (_CurrentPageDECK * CARDS_PER_PAGE_DECK) - CARDS_PER_PAGE_DECK;
                    index += _CurrentCardSelectedIndex;
                    //Set the CurrentCardInView Object
                    _CurrentCardInView = _CurrentDeckCardList[index];
                    break;

                case CursorLocation.ExtraDeck:
                    index = (_CurrentPageEXTRA * CARDS_PER_PAGE_EXTRA) - CARDS_PER_PAGE_EXTRA;
                    index += _CurrentCardSelectedIndex;
                    //Set the CurrentCardInView Object
                    _CurrentCardInView = _CurrentExtraCardList[index];
                    break;

                case CursorLocation.SideDeck:
                    index = (_CurrentPageSIDE * CARDS_PER_PAGE_SIDE) - CARDS_PER_PAGE_SIDE;
                    index += _CurrentCardSelectedIndex;
                    //Set the CurrentCardInView Object
                    _CurrentCardInView = _CurrentSideCardList[index];
                    break;
            }

            //Set the card image
            ImageServer.SetImage(picCardImage, ImageType.CardImage, _CurrentCardInView.ID.ToString());

            //Initialize the set card prices
            InitializeSetCards();
        }
        private void InitializeSetCards()
        {
            //Clear the current SetCards Elements
            foreach (SetCardPriceRow thisRow in _SetCardsRows)
            {
                thisRow.Dispose();
            }
            _SetCardsRows.Clear();

            int X_Location = 2;
            int Y_Location = 16;
            int indexOfCheapestCard = _CurrentCardInView.GetIndexOfCheapestSetCard();
            for (int x = 0; x < _CurrentCardInView.SetCards.Count; x++)
            {
                SetCard ThisSetCard = _CurrentCardInView.SetCards[x];
                //Ignore empty-coded sets
                if (ThisSetCard.Code != "")
                {
                    bool isThisTheCheapestCard = (indexOfCheapestCard == x);
                    CreateSetCardRow(ThisSetCard, x, isThisTheCheapestCard);
                    Y_Location += 16;
                }
            }

            void CreateSetCardRow(SetCard ThisSetCard, int index, bool cheapestCard)
            {
                //Code Label
                Label lblCode = new Label();
                panelCardSetCards.Controls.Add(lblCode);
                lblCode.Text = ThisSetCard.Code.ToString();
                lblCode.BorderStyle = BorderStyle.FixedSingle;
                lblCode.AutoSize = false;
                lblCode.Font = new Font("Arial Rounded MT Bold", 8);
                lblCode.ForeColor = Color.White;
                lblCode.Size = new Size(80, 16);
                lblCode.Location = new Point(X_Location, Y_Location);
                lblCode.Tag = index;
                lblCode.MouseEnter += SetCardRow_MouseEnter;
                lblCode.MouseLeave += SetCardRow_MouseLeave;
                lblCode.Click += SetCardRow_click;

                //Rarity label
                Label lblRarity = new Label();
                panelCardSetCards.Controls.Add(lblRarity);
                lblRarity.Text = ThisSetCard.Rarity.ToString();
                lblRarity.BorderStyle = BorderStyle.FixedSingle;
                lblRarity.AutoSize = false;
                lblRarity.Font = new Font("Arial Rounded MT Bold", 8);
                lblRarity.ForeColor = Color.White;
                lblRarity.Size = new Size(88, 16);
                lblRarity.Location = new Point(X_Location + 80, Y_Location);
                lblRarity.Tag = index;
                lblRarity.MouseEnter += SetCardRow_MouseEnter;
                lblRarity.MouseLeave += SetCardRow_MouseLeave;
                lblRarity.Click += SetCardRow_click;

                //Floor Price
                Label lblPrice = new Label();
                panelCardSetCards.Controls.Add(lblPrice);
                lblPrice.Text = ThisSetCard.FloorPrice.ToString();
                lblPrice.BorderStyle = BorderStyle.FixedSingle;
                lblPrice.AutoSize = false;
                lblPrice.Font = new Font("Arial Rounded MT Bold", 8);
                lblPrice.ForeColor = Color.White;
                lblPrice.Size = new Size(65, 16);
                lblPrice.Location = new Point(X_Location + 80 + 88, Y_Location);
                lblPrice.Tag = index;
                lblPrice.MouseEnter += SetCardRow_MouseEnter;
                lblPrice.MouseLeave += SetCardRow_MouseLeave;
                lblPrice.Click += SetCardRow_click;

                //Own
                Label lblOwned = new Label();
                panelCardSetCards.Controls.Add(lblOwned);
                lblOwned.BorderStyle = BorderStyle.FixedSingle;
                lblOwned.AutoSize = false;
                lblOwned.Font = new Font("Arial Rounded MT Bold", 8);
                lblOwned.ForeColor = Color.White;
                lblOwned.Size = new Size(15, 16);
                lblOwned.Location = new Point(X_Location + 80 + 88 + 65, Y_Location);
                lblOwned.Tag = index;
                lblOwned.MouseEnter += SetCardRow_MouseEnter;
                lblOwned.MouseLeave += SetCardRow_MouseLeave;
                lblOwned.Click += SetCardRow_click;
                if (ThisSetCard.IsOwned())
                {
                    lblOwned.Text = "X";
                }
                else
                {
                    lblOwned.Text = "";
                }

                //Highlight row as Aqua if this is the cheapest card
                if(cheapestCard)
                {
                    lblCode.ForeColor = Color.Aqua;
                    lblRarity.ForeColor = Color.Aqua;
                    lblPrice.ForeColor = Color.Aqua;
                    lblOwned.ForeColor = Color.Aqua;
                }
                
                //Create the row
                SetCardPriceRow thisRow = new SetCardPriceRow(index, ThisSetCard, lblCode, lblRarity, lblPrice, lblOwned, cheapestCard);
                _SetCardsRows.Add(thisRow);

            }
        }
        private void InitializeCheapestDeckData()
        {
            int X_Location = 3;
            int Y_Location = 4;
            int RowHeight = 16;

            int masterrowcounter = 0;

            //MAIN DECK
            DrawDeckSectionHeader("MAIN DECK");
            DrawTableColumnsHeaders();            

            double totalcostMainDeck = 0.00;
            for(int x = 0; x < _CurrentDeckCardList.Count; x++) 
            {
                MasterCard ThisMasterCard = _CurrentDeckCardList[x];
                int cheapestCardIndex = ThisMasterCard.GetIndexOfCheapestSetCard();
                SetCard ThisSetCard;
                if(cheapestCardIndex == -1)
                {
                    //get any setcard
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(0);
                }
                else 
                {
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(cheapestCardIndex);
                    totalcostMainDeck += ThisSetCard.GetDoubleFloorPrice();
                }
                //Draw the row
                DrawTableRow(ThisSetCard, x);
            }

            //Draw the Main Deck Totals
            DrawMainDeckTotalsRow("Main Deck", totalcostMainDeck);

            //Skip 2 lines
            Y_Location += RowHeight;
            Y_Location += RowHeight;

            //EXTRA DECK
            DrawDeckSectionHeader("EXTRA DECK");
            DrawTableColumnsHeaders();

            double totalcostExtraDeck = 0.00;
            for (int x = 0; x < _CurrentExtraCardList.Count; x++)
            {
                MasterCard ThisMasterCard = _CurrentExtraCardList[x];
                int cheapestCardIndex = ThisMasterCard.GetIndexOfCheapestSetCard();
                SetCard ThisSetCard;
                if (cheapestCardIndex == -1)
                {
                    //get any setcard
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(0);
                }
                else
                {
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(cheapestCardIndex);
                    totalcostExtraDeck += ThisSetCard.GetDoubleFloorPrice();
                }
                //Draw the row
                DrawTableRow(ThisSetCard, x);
            }

            //Draw the Main Deck Totals
            DrawMainDeckTotalsRow("Extra Deck", totalcostExtraDeck);

            //Skip 2 lines
            Y_Location += RowHeight;
            Y_Location += RowHeight;

            //EXTRA DECK
            DrawDeckSectionHeader("SIDE DECK");
            DrawTableColumnsHeaders();

            double totalcostSideDeck = 0.00;
            for (int x = 0; x < _CurrentSideCardList.Count; x++)
            {
                MasterCard ThisMasterCard = _CurrentSideCardList[x];
                int cheapestCardIndex = ThisMasterCard.GetIndexOfCheapestSetCard();
                SetCard ThisSetCard;
                if (cheapestCardIndex == -1)
                {
                    //get any setcard
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(0);
                }
                else
                {
                    ThisSetCard = ThisMasterCard.GetCardAtIndex(cheapestCardIndex);
                    totalcostSideDeck += ThisSetCard.GetDoubleFloorPrice();
                }
                //Draw the row
                DrawTableRow(ThisSetCard, x);
            }

            //Draw the Main Deck Totals
            DrawMainDeckTotalsRow("Side Deck", totalcostSideDeck);

            //Skip 2 lines
            Y_Location += RowHeight;
            Y_Location += RowHeight;

            //Draw the Total Totals
            DrawMainDeckTotalsRow("Whole Deck", totalcostMainDeck + totalcostExtraDeck + totalcostSideDeck);


            void DrawDeckSectionHeader(string deckgroup)
            {
                Label lblMainDeckHeader = new Label();
                panelCheapestContainer.Controls.Add(lblMainDeckHeader);
                lblMainDeckHeader.Text = deckgroup;
                lblMainDeckHeader.BorderStyle = BorderStyle.None;
                lblMainDeckHeader.AutoSize = false;
                lblMainDeckHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblMainDeckHeader.ForeColor = Color.Green;
                lblMainDeckHeader.Size = new Size(120, RowHeight);
                lblMainDeckHeader.Location = new Point(X_Location, Y_Location);

                Y_Location += RowHeight;
            }
            void DrawTableColumnsHeaders()
            {
                Label lblCardnameHeader = new Label();
                panelCheapestContainer.Controls.Add(lblCardnameHeader);
                lblCardnameHeader.Text = "CARD NAME";
                lblCardnameHeader.BorderStyle = BorderStyle.None;
                lblCardnameHeader.AutoSize = false;
                lblCardnameHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblCardnameHeader.ForeColor = Color.Yellow;
                lblCardnameHeader.Size = new Size(120, RowHeight);
                lblCardnameHeader.Location = new Point(X_Location, Y_Location);

                Label lblCodeHeader = new Label();
                panelCheapestContainer.Controls.Add(lblCodeHeader);
                lblCodeHeader.Text = "CODE";
                lblCodeHeader.BorderStyle = BorderStyle.None;
                lblCodeHeader.AutoSize = false;
                lblCodeHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblCodeHeader.ForeColor = Color.Yellow;
                lblCodeHeader.Size = new Size(80, RowHeight);
                lblCodeHeader.Location = new Point(X_Location + 120, Y_Location);

                Label lblRarityHeader = new Label();
                panelCheapestContainer.Controls.Add(lblRarityHeader);
                lblRarityHeader.Text = "RARITY";
                lblRarityHeader.BorderStyle = BorderStyle.None;
                lblRarityHeader.AutoSize = false;
                lblRarityHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblRarityHeader.ForeColor = Color.Yellow;
                lblRarityHeader.Size = new Size(90, RowHeight);
                lblRarityHeader.Location = new Point(X_Location + 120 + 80, Y_Location);

                Label lblPriceHeader = new Label();
                panelCheapestContainer.Controls.Add(lblPriceHeader);
                lblPriceHeader.Text = "PRICE";
                lblPriceHeader.BorderStyle = BorderStyle.None;
                lblPriceHeader.AutoSize = false;
                lblPriceHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblPriceHeader.ForeColor = Color.Yellow;
                lblPriceHeader.Size = new Size(47, RowHeight);
                lblPriceHeader.Location = new Point(X_Location + 120 + 80 + 95, Y_Location);

                Label lblOwnedHeader = new Label();
                panelCheapestContainer.Controls.Add(lblOwnedHeader);
                lblOwnedHeader.Text = "OWNED";
                lblOwnedHeader.BorderStyle = BorderStyle.None;
                lblOwnedHeader.AutoSize = false;
                lblOwnedHeader.Font = new Font("Arial Rounded MT Bold", 9);
                lblOwnedHeader.ForeColor = Color.Yellow;
                lblOwnedHeader.Size = new Size(57, RowHeight);
                lblOwnedHeader.Location = new Point(X_Location + 120 + 80 + 142, Y_Location);
               
                Y_Location += RowHeight;
            }
            void DrawTableRow(SetCard ThisSetCard, int index)
            {
                //Card Name Label
                Label lblCardName = new Label();
                panelCheapestContainer.Controls.Add(lblCardName);
                lblCardName.Text = ThisSetCard.GetCardName();
                lblCardName.BorderStyle = BorderStyle.FixedSingle;
                lblCardName.AutoSize = false;
                lblCardName.Font = new Font("Arial Rounded MT Bold", 8);
                lblCardName.ForeColor = Color.White;
                lblCardName.Size = new Size(120, 16);
                lblCardName.Location = new Point(X_Location, Y_Location);
                lblCardName.Tag = masterrowcounter;
                lblCardName.MouseEnter += CheapReportRow_MouseEnter;
                lblCardName.MouseLeave += CheapReportRow_MouseLeave;
                lblCardName.Click += CheapReportRow_click;

                //Code Label
                Label lblCode = new Label();
                panelCheapestContainer.Controls.Add(lblCode);
                lblCode.Text = ThisSetCard.Code.ToString();
                lblCode.BorderStyle = BorderStyle.FixedSingle;
                lblCode.AutoSize = false;
                lblCode.Font = new Font("Arial Rounded MT Bold", 8);
                lblCode.ForeColor = Color.White;
                lblCode.Size = new Size(80, 16);
                lblCode.Location = new Point(X_Location + 120, Y_Location);
                lblCode.Tag = masterrowcounter;
                lblCode.MouseEnter += CheapReportRow_MouseEnter;
                lblCode.MouseLeave += CheapReportRow_MouseLeave;
                lblCode.Click += CheapReportRow_click;

                //Rarity label
                Label lblRarity = new Label();
                panelCheapestContainer.Controls.Add(lblRarity);
                lblRarity.Text = ThisSetCard.Rarity.ToString();
                lblRarity.BorderStyle = BorderStyle.FixedSingle;
                lblRarity.AutoSize = false;
                lblRarity.Font = new Font("Arial Rounded MT Bold", 8);
                lblRarity.ForeColor = Color.White;
                lblRarity.Size = new Size(100, 16);
                lblRarity.Location = new Point(X_Location + 120 + 80, Y_Location);
                lblRarity.Tag = masterrowcounter;
                lblRarity.MouseEnter += CheapReportRow_MouseEnter;
                lblRarity.MouseLeave += CheapReportRow_MouseLeave;
                lblRarity.Click += CheapReportRow_click;

                //Floor Price
                Label lblPrice = new Label();
                panelCheapestContainer.Controls.Add(lblPrice);
                lblPrice.Text = ThisSetCard.FloorPrice.ToString();
                lblPrice.BorderStyle = BorderStyle.FixedSingle;
                lblPrice.AutoSize = false;
                lblPrice.Font = new Font("Arial Rounded MT Bold", 8);
                lblPrice.ForeColor = Color.White;
                lblPrice.Size = new Size(65, 16);
                lblPrice.Location = new Point(X_Location + 120 + 80 + 100, Y_Location);
                lblPrice.Tag = masterrowcounter;
                lblPrice.MouseEnter += CheapReportRow_MouseEnter;
                lblPrice.MouseLeave += CheapReportRow_MouseLeave;
                lblPrice.Click += CheapReportRow_click;

                //Own
                Label lblOwned = new Label();
                panelCheapestContainer.Controls.Add(lblOwned);
                lblOwned.BorderStyle = BorderStyle.FixedSingle;
                lblOwned.AutoSize = false;
                lblOwned.Font = new Font("Arial Rounded MT Bold", 8);
                lblOwned.ForeColor = Color.White;
                lblOwned.Size = new Size(15, 16);
                lblOwned.Location = new Point(X_Location + 120 + 80 + 100 + 65, Y_Location);
                lblOwned.Tag = masterrowcounter;
                lblOwned.MouseEnter += CheapReportRow_MouseEnter;
                lblOwned.MouseLeave += CheapReportRow_MouseLeave;
                lblOwned.Click += CheapReportRow_click;
                if (ThisSetCard.IsOwned())
                {
                    lblOwned.Text = "X";
                }
                else
                {
                    lblOwned.Text = "";
                }

                CheapestCostRow thisRow = new CheapestCostRow(masterrowcounter, ThisSetCard, lblCardName, lblCode, lblRarity, lblPrice, lblOwned);
                masterrowcounter++;
                _CheapestCostRows.Add(thisRow);

                Y_Location += RowHeight;
            }
            void DrawMainDeckTotalsRow(string deck, double total)
            {
                //Card Name Label
                Label lblTotalDescription = new Label();
                panelCheapestContainer.Controls.Add(lblTotalDescription);
                lblTotalDescription.Text = string.Format("Total cost to build {0}:", deck);
                lblTotalDescription.BorderStyle = BorderStyle.FixedSingle;
                lblTotalDescription.AutoSize = false;
                lblTotalDescription.Font = new Font("Arial Rounded MT Bold", 8);
                lblTotalDescription.ForeColor = Color.Aqua;
                lblTotalDescription.Size = new Size(300, 16);
                lblTotalDescription.Location = new Point(X_Location, Y_Location);

                //Floor Price
                Label lblMainTotals = new Label();
                panelCheapestContainer.Controls.Add(lblMainTotals);
                lblMainTotals.Text = string.Format("${0}", total.ToString());
                lblMainTotals.BorderStyle = BorderStyle.FixedSingle;
                lblMainTotals.AutoSize = false;
                lblMainTotals.Font = new Font("Arial Rounded MT Bold", 8);
                lblMainTotals.ForeColor = Color.Aqua;
                lblMainTotals.Size = new Size(65, 16);
                lblMainTotals.Location = new Point(X_Location + 300, Y_Location);
            }
        }
        #endregion

        #region Private Data
        private DeckBuilder _deckBuilderFormRef;

        private Deck ActiveDeck;
        private List<MasterCard> _CurrentDeckCardList;
        private List<MasterCard> _CurrentExtraCardList;
        private List<MasterCard> _CurrentSideCardList;

        private int CARDS_PER_PAGE_DECK = 35;
        private int CARDS_PER_PAGE_EXTRA = 7;
        private int CARDS_PER_PAGE_SIDE = 7;

        private int _CurrentPageDECK = 1;
        private int _CurrentPageEXTRA = 1;
        private int _CurrentPageSIDE = 1;

        private List<Panel> _CardPanelListDECK = new List<Panel>();
        private List<PictureBox> _IconImageListDECK = new List<PictureBox>();
        private List<PictureBox> _CardImageListDECK = new List<PictureBox>();

        private List<Panel> _CardPanelListEXTRA = new List<Panel>();
        private List<PictureBox> _IconImageListEXTRA = new List<PictureBox>();
        private List<PictureBox> _CardImageListEXTRA = new List<PictureBox>();

        private List<Panel> _CardPanelListSIDE = new List<Panel>();
        private List<PictureBox> _IconImageListSIDE = new List<PictureBox>();
        private List<PictureBox> _CardImageListSIDE = new List<PictureBox>();

        private int _CurrentCardSelectedIndex = 0;
        private CursorLocation _CurrentCursoLocation = CursorLocation.Box;
        private MasterCard _CurrentCardInView;
        private bool _HideMode = false;

        private bool _KeyInputEnable = true;

        private List<SetCardPriceRow> _SetCardsRows = new List<SetCardPriceRow>();
        private List<CheapestCostRow> _CheapestCostRows = new List<CheapestCostRow>();
        #endregion

        #region Private Enums
        private enum CursorLocation
        {
            Box,
            MainDeck,
            ExtraDeck,
            SideDeck
        }
        #endregion

        #region Eventy Listeners
        private void ImageDECK_click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            int index = (int)ThisPictureBox.Tag;
            ClickCardFromDeck(index);
        }
        private void ImageEXTRA_click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            int index = (int)ThisPictureBox.Tag;
            ClickCardFromExtra(index);
        }
        private void ImageSIDE_click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            int index = (int)ThisPictureBox.Tag;
            ClickCardFromSide(index);
        }
        private void SetCardRow_MouseEnter(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label ThisLabel = (Label)sender;
            int index = Convert.ToInt32(ThisLabel.Tag);
            SetCardPriceRow ThisRow = _SetCardsRows[index];
            SetCard ThisSetCard = ThisRow.SetCard;

            if (ThisSetCard.HasTCGURL())
            {
                ThisRow.ChangeColor(Color.Yellow);
            }
            else
            {
                ThisRow.ChangeColor(Color.Red);
            }
        }
        private void SetCardRow_MouseLeave(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label ThisLabel = (Label)sender;
            int index = Convert.ToInt32(ThisLabel.Tag);
            SetCardPriceRow ThisRow = _SetCardsRows[index];
            ThisRow.ResetColor();
        }
        private void SetCardRow_click(object sender, EventArgs e)
        {           
            Label ThisLabel = (Label)sender;
            int index = Convert.ToInt32(ThisLabel.Tag);
            SetCardPriceRow ThisRow = _SetCardsRows[index];
            SetCard ThisSetCard = ThisRow.SetCard;

            if (ThisSetCard.HasTCGURL())
            {
                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                Tools.LaunchURLIntoBrowser(ThisSetCard.TCGPlayerURL);
            }
            else
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
            }
        }
        private void CheapReportRow_MouseEnter(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label ThisLabel = (Label)sender;
            int rowindex = Convert.ToInt32(ThisLabel.Tag);
            CheapestCostRow thisRow = _CheapestCostRows[rowindex];
            SetCard ThisSetCard = thisRow.SetCard;

            if (ThisSetCard.HasTCGURL())
            {
                thisRow.ChangeColor(Color.Yellow);
            }
            else
            {
                thisRow.ChangeColor(Color.Red);
            }
        }
        private void CheapReportRow_MouseLeave(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label ThisLabel = (Label)sender;
            int rowindex = Convert.ToInt32(ThisLabel.Tag);
            CheapestCostRow thisRow = _CheapestCostRows[rowindex];
            thisRow.ChangeColor(Color.White);
        }
        private void CheapReportRow_click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            Label ThisLabel = (Label)sender;
            int rowindex = Convert.ToInt32(ThisLabel.Tag);
            CheapestCostRow thisRow = _CheapestCostRows[rowindex];
            SetCard ThisSetCard = thisRow.SetCard;

            if (ThisSetCard.HasTCGURL())
            {
                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                Tools.LaunchURLIntoBrowser(ThisSetCard.TCGPlayerURL);
            }
            else
            {
                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnBackToDeckBuilder_Click(object sender, EventArgs e)
        {
            Dispose();
            _deckBuilderFormRef.Show();
        }
        private void btnNextPageDeck_Click(object sender, EventArgs e)
        {
            GoNextPage_DECK();
        }
        private void btnPreviousPageDeck_Click(object sender, EventArgs e)
        {
            GoPreviousPage_DECK();
        }
        private void btnNextPageExtra_Click(object sender, EventArgs e)
        {
            GoNextPage_EXTRA();
        }
        private void btnPreviousPageExtra_Click(object sender, EventArgs e)
        {
            GoPreviousPage_EXTRA();
        }
        private void btnNextPageSide_Click(object sender, EventArgs e)
        {
            GoNextPage_SIDE();
        }
        private void btnPreviousPageSide_Click(object sender, EventArgs e)
        {
            GoPreviousPage_SIDE();
        }
        #endregion  

        #region Keyboard Input Control
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    switch (_CurrentCursoLocation)
                    {
                        case CursorLocation.MainDeck:
                            if (_CurrentCardSelectedIndex < 7)
                            {
                                //Do nothing it is the top row
                                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                            }
                            else
                            {
                                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                                //check if the Up card image is visible
                                if (_CardPanelListDECK[_CurrentCardSelectedIndex - 7].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 7, CursorLocation.MainDeck);
                                }
                            }
                            break;
                        case CursorLocation.ExtraDeck:
                            SoundServer.PlaySoundEffect(SoundEffect.InvalidClick); break;
                        case CursorLocation.SideDeck:
                            SoundServer.PlaySoundEffect(SoundEffect.InvalidClick); break;
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.Down)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    switch (_CurrentCursoLocation)
                    {
                        case CursorLocation.MainDeck:
                            if (_CurrentCardSelectedIndex > 27)
                            {
                                //Do nothing it is the top row
                                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                            }
                            else
                            {
                                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                                //check if the Up card image is visible
                                if (_CardPanelListDECK[_CurrentCardSelectedIndex + 7].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 7, CursorLocation.MainDeck);
                                }
                            }
                            break;
                        case CursorLocation.ExtraDeck:
                            SoundServer.PlaySoundEffect(SoundEffect.InvalidClick); break;
                        case CursorLocation.SideDeck:
                            SoundServer.PlaySoundEffect(SoundEffect.InvalidClick); break;
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.Left)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    SoundServer.PlaySoundEffect(SoundEffect.Hover);
                    switch (_CurrentCursoLocation)
                    {
                        case CursorLocation.MainDeck:
                            if (_CurrentCardSelectedIndex == 0)
                            {
                                GoPreviousPage_DECK();
                                //Find the last visible card in the page and select it
                                for (int x = 34; x >= 0; x--)
                                {
                                    if (_CardPanelListDECK[x].Visible)
                                    {
                                        InitializeSelectedCardInfo(x, CursorLocation.MainDeck);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //check if the left card image is visible
                                if (_CardPanelListDECK[_CurrentCardSelectedIndex - 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 1, CursorLocation.MainDeck);
                                }
                            }
                            break;
                        case CursorLocation.ExtraDeck:
                            if (_CurrentCardSelectedIndex == 0)
                            {
                                GoPreviousPage_EXTRA();
                                //Find the last visible card in the page and select it
                                for (int x = 6; x >= 0; x--)
                                {
                                    if (_CardPanelListEXTRA[x].Visible)
                                    {
                                        InitializeSelectedCardInfo(x, CursorLocation.ExtraDeck);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //check if the left card image is visible
                                if (_CardPanelListEXTRA[_CurrentCardSelectedIndex - 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 1, CursorLocation.ExtraDeck);
                                }
                            }
                            break;
                        case CursorLocation.SideDeck:
                            if (_CurrentCardSelectedIndex == 0)
                            {
                                GoPreviousPage_SIDE();
                                //Find the last visible card in the page and select it
                                for (int x = 6; x >= 0; x--)
                                {
                                    if (_CardPanelListSIDE[x].Visible)
                                    {
                                        InitializeSelectedCardInfo(x, CursorLocation.SideDeck);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //check if the left card image is visible
                                if (_CardPanelListSIDE[_CurrentCardSelectedIndex - 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 1, CursorLocation.SideDeck);
                                }
                            }
                            break;
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.Right)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    SoundServer.PlaySoundEffect(SoundEffect.Hover);
                    switch (_CurrentCursoLocation)
                    {
                        case CursorLocation.MainDeck:
                            if (_CurrentCardSelectedIndex == 34)
                            {
                                GoNextPage_DECK();
                            }
                            else
                            {
                                //check if the right card image is visible
                                if (_CardPanelListDECK[_CurrentCardSelectedIndex + 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 1, CursorLocation.MainDeck);
                                }
                                else
                                {
                                    GoNextPage_DECK();
                                }
                            }
                            break;
                        case CursorLocation.ExtraDeck:
                            if (_CurrentCardSelectedIndex == 6)
                            {
                                GoNextPage_EXTRA();
                            }
                            else
                            {
                                //check if the right card image is visible
                                if (_CardPanelListEXTRA[_CurrentCardSelectedIndex + 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 1, CursorLocation.ExtraDeck);
                                }
                                else
                                {
                                    GoNextPage_EXTRA();
                                }
                            }
                            break;
                        case CursorLocation.SideDeck:
                            if (_CurrentCardSelectedIndex == 6)
                            {
                                GoNextPage_SIDE();
                            }
                            else
                            {
                                //check if the right card image is visible
                                if (_CardPanelListSIDE[_CurrentCardSelectedIndex + 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 1, CursorLocation.SideDeck);
                                }
                                else
                                {
                                    GoNextPage_SIDE();
                                }
                            }
                            break;
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private class SetCardPriceRow
        {
            public SetCardPriceRow(int index, SetCard thisSetCard,Label code, Label rarity, Label price, Label owned, bool isThisCheapestCard)
            {
                _Index = index;
                _Labels.Add(code);
                _Labels.Add(rarity);
                _Labels.Add(price);
                _Labels.Add(owned);
                _MySetCard = thisSetCard;
                _IsThisCheapestCard = isThisCheapestCard;
            }
            private int _Index = -1;
            private List<Label> _Labels = new List<Label>();
            private SetCard _MySetCard;
            private bool _IsThisCheapestCard;
            public void Dispose()
            {
                foreach(Label label in _Labels) 
                {
                    label.Dispose();
                }
                _Labels.Clear();
            }
            public void ChangeColor(Color thisColor)
            {
                foreach(Label thisLabel in _Labels)
                {
                    thisLabel.ForeColor = thisColor;
                }
            }
            public void ResetColor()
            {
                foreach (Label thisLabel in _Labels)
                {
                    if (_IsThisCheapestCard)
                    {
                        thisLabel.ForeColor = Color.Aqua;
                    }
                    else
                    {
                        thisLabel.ForeColor = Color.White;
                    }
                }
            }
            public SetCard SetCard { get { return _MySetCard; } }
        }

        private class CheapestCostRow
        {
            public CheapestCostRow(int index, SetCard thisSetCard, Label CardName, Label code, Label rarity, Label price, Label owned)
            {
                _Index = index;
                _Labels.Add(CardName);
                _Labels.Add(code);
                _Labels.Add(rarity);
                _Labels.Add(price);
                _Labels.Add(owned);
                _MySetCard = thisSetCard;
            }
            private int _Index = -1;
            private List<Label> _Labels = new List<Label>();
            private SetCard _MySetCard;
            public void Dispose()
            {
                foreach (Label label in _Labels)
                {
                    label.Dispose();
                }
                _Labels.Clear();
            }
            public void ChangeColor(Color thisColor)
            {
                foreach (Label thisLabel in _Labels)
                {
                    thisLabel.ForeColor = thisColor;
                }
            }
            public SetCard SetCard { get { return _MySetCard; } }
        }
    }
}
