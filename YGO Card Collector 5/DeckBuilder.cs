//Joel Campos
//3/7/2024
//Deck Builder Class


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class DeckBuilder : Form
    {
        #region Constructors
        public DeckBuilder(int deckId)
        {           
            InitializeComponent();
            InitializeCardImages_BOX();
            InitializeCardImages_DECK();
            InitializeCardImages_EXTRA();
            InitializeCardImages_SIDE();

            //Database.LoadDB("FULL");

            //Initialize the Box Card List from the MasterCard List
            _CurrentBoxCardList = Database.MasterCards;

            //Initialize Deck Data
            ActiveDeck = Database.Decks[deckId];
            _CurrentDeckCardList = ActiveDeck.GetMainDeckMasterCardList();
            _CurrentExtraCardList = ActiveDeck.GetExtraDeckMasterCardList();
            _CurrentSideCardList = ActiveDeck.GetSideDeckMasterCardList();

            //Load the Pages of all Groups
            LoadPage_BOX();
            LoadPage_DECK();
            LoadPage_EXTRA();
            LoadPage_SIDE();

            //Set the initial cursor on the first card of the Box group
            ClickCardFromBox(0);

            void InitializeCardImages_BOX()
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
                        GroupBoxViewer.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(Picture_XSIZE, Picture_YSIZE);
                        _CardPanelListBOX.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(ICON_SIZE, ICON_SIZE);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        //CardIcon.Visible = false;
                        _IconImageListBOX.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(CARD_XSIZE, CARD_YSIZE);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(ImageBOX_click);
                        _CardImageListBOX.Add(CardImage);

                        X_Location += Picture_XSIZE;
                        imageID++;
                    }
                    Y_Location += Picture_YSIZE;
                }
            }
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
                        //CardIcon.Visible = false;
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
        private void LoadPage_BOX()
        {
            //Set the total Card Count
            int TotalCardCount = _CurrentBoxCardList.Count;

            //Start the iterator
            int PageIntialIndex = (_CurrentPageBOX * CARDS_PER_PAGE_BOX) - CARDS_PER_PAGE_BOX;

            //Loop thru all the Card Images to initialize them
            for (int x = 0; x < CARDS_PER_PAGE_BOX; x++)
            {
                //Set the card iterator index
                int iterator = PageIntialIndex + x;

                //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                if (iterator >= TotalCardCount)
                {
                    _CardPanelListBOX[x].Visible = false;
                }
                else
                {
                    //show the card
                    _CardPanelListBOX[x].Visible = true;

                    //Save Ref to the MasterCard object that will be used
                    MasterCard ThisMasterCard = _CurrentBoxCardList[iterator];

                    //Initialize the card image
                    ImageServer.SetImage(_CardImageListBOX[x], ImageType.CardImage, ThisMasterCard.ID.ToString());

                    //Initialize the obtained icon
                    LoadCardObtainedIcon(x, ThisMasterCard);
                }
            }

            //Update the group banner text
            int LastPage = GetLastPage(_CurrentBoxCardList, CARDS_PER_PAGE_BOX);
            GroupBoxViewer.Text = string.Format("BOX - Cards: {0} - PAGE {1}/{2}", TotalCardCount, _CurrentPageBOX, LastPage);

            void LoadCardObtainedIcon(int x, MasterCard ThisMasterCard)
            {
                //Start with the Icon invisible
                _IconImageListBOX[x].Visible = false;
                if (ThisMasterCard.HasOneCardsObtained())
                {
                    ImageServer.SetImage(_IconImageListBOX[x], ImageType.CheckMark, "NONE");
                    _IconImageListBOX[x].Visible = true;
                }
            }
        }
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
                    ImageServer.SetImage(_CardImageListDECK[x], ImageType.CardImage, ThisMasterCard.ID.ToString());

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
                    ImageServer.SetImage(_CardImageListEXTRA[x], ImageType.CardImage, ThisMasterCard.ID.ToString());

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
                    ImageServer.SetImage(_CardImageListSIDE[x], ImageType.CardImage, ThisMasterCard.ID.ToString());

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
        private void GoPreviousPage_BOX()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentBoxCardList, CARDS_PER_PAGE_BOX);
            if (lastpage != 0)
            {
                if (_CurrentPageBOX == 1) { _CurrentPageBOX = lastpage; }
                else { _CurrentPageBOX--; }

                LoadPage_BOX();
                _CurrentCardSelectedIndex = 0;
                InitializeSelectedCardInfo(0, CursorLocation.Box);
            }
        }
        private void GoNextPage_BOX() 
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage(_CurrentBoxCardList, CARDS_PER_PAGE_BOX);
            if (lastpage != 0)
            {
                if (_CurrentPageBOX == lastpage) { _CurrentPageBOX = 1; }
                else { _CurrentPageBOX++; }

                LoadPage_BOX();
                InitializeSelectedCardInfo(0, CursorLocation.Box);
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
        private void ClickCardFromBox(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.Box);

            //Update the action button to determine the move action
            if (_CurrentCardInView.IsAExtraDeckMonster())
            {
                if (_CurrentExtraCardList.Count == 15)
                {
                    btnMoveAction.Text = "EXTRA DECK FULL";
                    btnMoveAction.Enabled = false;
                }
                else
                {
                    if (ListContains3CopiesOf(_CurrentExtraCardList, _CurrentCardInView.Name))
                    {
                        btnMoveAction.Text = "MAX COPIES";
                        btnMoveAction.Enabled = false;
                    }
                    else
                    {
                        btnMoveAction.Text = "Send to Extra Deck >>";
                        btnMoveAction.Enabled = true;
                    }
                }
            }
            else
            {
                if (_CurrentDeckCardList.Count == 60)
                {
                    btnMoveAction.Text = "MAIN DECK FULL";
                    btnMoveAction.Enabled = false;
                }
                else
                {
                    if (ListContains3CopiesOf(_CurrentDeckCardList, _CurrentCardInView.Name))
                    {
                        btnMoveAction.Text = "MAX COPIES";
                        btnMoveAction.Enabled = false;
                    }
                    else
                    {
                        btnMoveAction.Text = "Send to Main Deck >>";
                        btnMoveAction.Enabled = true;
                    }
                }
            }

            btnMoveActionSide.Visible = true;
            if (_CurrentSideCardList.Count == 15)
            {
                btnMoveActionSide.Text = "SIDE DECK FULL";
                btnMoveActionSide.Enabled = false;
            }
            else
            {
                if (ListContains3CopiesOf(_CurrentSideCardList, _CurrentCardInView.Name))
                {
                    btnMoveActionSide.Text = "MAX COPIES";
                    btnMoveActionSide.Enabled = false;
                }
                else
                {
                    btnMoveActionSide.Text = "Send to Side Deck >>";
                    btnMoveActionSide.Enabled = true;
                }
            }
        }
        private void ClickCardFromDeck(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.MainDeck);

            btnMoveAction.Text = "Remove from Main Deck";
            btnMoveAction.Enabled = true;

            btnMoveActionSide.Visible = false;
        }
        private void ClickCardFromExtra(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.ExtraDeck);

            btnMoveAction.Text = "Remove from Extra Deck";
            btnMoveAction.Enabled = true;

            btnMoveActionSide.Visible = false;
        }
        private void ClickCardFromSide(int index)
        {
            InitializeSelectedCardInfo(index, CursorLocation.SideDeck);

            btnMoveAction.Text = "Remove from Extra Deck";
            btnMoveAction.Enabled = true;

            btnMoveActionSide.Visible = false;
        }
        private void InitializeSelectedCardInfo(int newIndex, CursorLocation newLocation)
        {
            //Hide the old cursor location
            switch(_CurrentCursoLocation)
            {
                case CursorLocation.Box:       _CardPanelListBOX[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
                case CursorLocation.MainDeck:  _CardPanelListDECK[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
                case CursorLocation.ExtraDeck: _CardPanelListEXTRA[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
                case CursorLocation.SideDeck:  _CardPanelListSIDE[_CurrentCardSelectedIndex].BackColor = Color.Black; break;
            }

            //Update new location/index
            _CurrentCursoLocation = newLocation;
            _CurrentCardSelectedIndex = newIndex;

            //Show the new Cursor Locator
            switch (_CurrentCursoLocation)
            {
                case CursorLocation.Box: _CardPanelListBOX[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
                case CursorLocation.MainDeck: _CardPanelListDECK[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
                case CursorLocation.ExtraDeck: _CardPanelListEXTRA[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
                case CursorLocation.SideDeck: _CardPanelListSIDE[_CurrentCardSelectedIndex].BackColor = Color.Yellow; break;
            }

            //picCardImage
            switch (newLocation)
            {
                case CursorLocation.Box: 
                    int index = (_CurrentPageBOX * CARDS_PER_PAGE_BOX) - CARDS_PER_PAGE_BOX;
                    index += _CurrentCardSelectedIndex;
                    //Set the CurrentCardInView Object
                    _CurrentCardInView = _CurrentBoxCardList[index];
                    break;

                case CursorLocation.MainDeck:
                    index = (_CurrentPageDECK * CARDS_PER_PAGE_DECK) - CARDS_PER_PAGE_DECK;
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
        }
        private void FilterByMasterGroup(CardGroup group)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);

            _CurrentBoxCardList = Database.GroupCardListByGroupName[group];
            _CurrentPageBOX = 1;
            if (group == CardGroup.AllCards)
            { 
                btnClearFilter.Visible = false;
            }
            else
            {
                btnClearFilter.Visible = true;
            }

            LoadPage_BOX();
            InitializeSelectedCardInfo(0, CursorLocation.Box);
        }
        private void FilterByTag(TagIcon thisTag)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);

            List<MasterCard> filteredlist = new List<MasterCard>();

            foreach (MasterCard ThisMasterCard in _CurrentBoxCardList)
            {
                bool TagOn = ThisMasterCard.GetTag(thisTag);
                if (TagOn)
                {
                    filteredlist.Add(ThisMasterCard);
                }
            }

            _CurrentBoxCardList = filteredlist;

            //Set Flags
            _CurrentPageBOX = 1;
            btnClearFilter.Visible = true;

            LoadPage_BOX();
        }
        private bool ListContains3CopiesOf(List<MasterCard> currentlist, string cardname)
        {
            int count = 0;
            foreach(MasterCard ThisMasterCard in currentlist)
            {
                if(ThisMasterCard.Name == cardname) 
                {
                    count++;
                }
            }
            return count == 3;
        }
        private void SaveData()
        {
            Database.UpdateDeckSaveFile();
        }
        #endregion

        #region Private Data

        private Deck ActiveDeck;
        private List<MasterCard> _CurrentBoxCardList;
        private List<MasterCard> _CurrentDeckCardList;
        private List<MasterCard> _CurrentExtraCardList;
        private List<MasterCard> _CurrentSideCardList;

        private int CARDS_PER_PAGE_BOX = 35;
        private int CARDS_PER_PAGE_DECK = 35;
        private int CARDS_PER_PAGE_EXTRA = 7;
        private int CARDS_PER_PAGE_SIDE = 7;

        private int _CurrentPageBOX = 1;
        private int _CurrentPageDECK = 1;
        private int _CurrentPageEXTRA = 1;
        private int _CurrentPageSIDE = 1;

        private List<Panel> _CardPanelListBOX = new List<Panel>();
        private List<PictureBox> _IconImageListBOX = new List<PictureBox>();
        private List<PictureBox> _CardImageListBOX = new List<PictureBox>();

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

        private bool _KeyInputEnable = true;
        #endregion

        #region Event Listeners
        private void ImageBOX_click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            int index = (int)ThisPictureBox.Tag;
            ClickCardFromBox(index);
        }
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
        private void btnBoxPreviousPage_Click(object sender, EventArgs e)
        {
            GoPreviousPage_BOX();
        }
        private void btnBoxNextPage_Click(object sender, EventArgs e)
        {
            GoNextPage_BOX();
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

        #region Private Enums
        private enum CursorLocation
        {
            Box,
            MainDeck,
            ExtraDeck,
            SideDeck
        }
        #endregion

        #region Box Filters Event Listeners
        private void btnFilterAqua_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Aqua_Monsters);
        }
        private void btnFilterZombie_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Zombie_Monsters);
        }
        private void btnFilterWyrm_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Wyrm_Monsters);
        }
        private void btnFilterWingedBeast_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.WingedBeast_Monsters);
        }
        private void btnFilterWarrior_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Warrior_Monsters);
        }
        private void btnFilterThunder_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Thunder_Monsters);
        }
        private void btnFilterSpellcaster_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Spellcaster_Monsters);
        }
        private void btnFilterPsychic_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Psychic_Monsters);
        }
        private void btnFilterFiend_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Fiend_Monsters);
        }
        private void btnFilterCyberce_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Cyberse_Monsters);
        }
        private void btnFilterSeaSerpent_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.SeaSerpent_Monsters);
        }
        private void btnFilterPlant_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Plant_Monsters);
        }
        private void btnFilterFairy_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Fairy_Monsters);
        }
        private void btnFilterRock_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Rock_Monsters);
        }
        private void btnFilterReptile_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Reptile_Monsters);
        }
        private void btnFilterPyro_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Pyro_Monsters);
        }
        private void btnFilterMachine_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Machine_Monsters);
        }
        private void btnFilterInsect_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Insect_Monsters);
        }
        private void btnFilterFish_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Fish_Monsters);
        }
        private void btnFilterDragon_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Dragon_Monsters);
        }
        private void btnFilterDivine_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.DivineBeast_Monsters);
        }
        private void btnFilterDinosaur_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Dinosaur_Monsters);
        }
        private void btnFilterBeastWarrior_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.BeastWarrior_Monsters);
        }
        private void btnFilterBeast_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Beast_Monsters);
        }
        private void btnFilterIllusion_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.IllusionType_Monsters);
        }
        private void btnRitualSpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Ritual_Spells);
        }
        private void btnContinousSpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Continuous_Spells);
        }
        private void btnEquipSpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Equip_Spells);
        }
        private void btnNormalSpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Normal_Spells);
        }
        private void btnQuickPlaySpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.QuickPlay_Spells);
        }
        private void btnFieldSpell_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Field_Spells);
        }
        private void btnNormalTrap_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Normal_Traps);
        }
        private void btnContinuosTrap_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Continuous_Traps);
        }
        private void btnCounterTrap_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Counter_Traps);
        }
        private void btnMonster_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.All_Monsters);
        }
        private void btnSpells_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.All_Spells);
        }
        private void btnTraps_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.All_Trap);
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Normal_Monsters);
        }
        private void btnLink_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Link_Monsters);
        }
        private void btnPendulum_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Pendulum_Monsters);
        }
        private void btnXyz_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Xyz_Monsters);
        }
        private void btnSynchro_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Synchro_Monsters);
        }
        private void btnRitual_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Ritual_Monsters);
        }
        private void btnFusion_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Fusion_Monsters);
        }
        private void btnEffect_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Effect_Monsters);
        }
        private void btnFlip_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Flip_Monsters);
        }
        private void btnTuner_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Tuner_Monsters);
        }
        private void btnUnion_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Union_Monsters);
        }
        private void btnGemini_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Gemini_Monsters);
        }
        private void btnSpirit_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Spirit_Monsters);
        }
        private void btnToon_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Toon_Monsters);
        }
        private void btnDark_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Dark_Attribute);
        }
        private void btnWind_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Wind_Attribute);
        }
        private void btnFire_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Fire_Attribute);
        }
        private void btnWater_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Water_Attribute);
        }
        private void btnEarth_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Earth_Attribute);
        }
        private void btnLight_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Light_Attribute);
        }
        private void btnDivine_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.Divine_Attribute);
        }
        private void btnTextSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string SearchTerm = txtSearch.Text;
                _CurrentBoxCardList = Database.GetCardListWithSearchTerm(SearchTerm);

                //Set Flags
                _CurrentPageBOX = 1;
                btnClearFilter.Visible = true;
                LoadPage_BOX();
            }
        }
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            FilterByMasterGroup(CardGroup.AllCards);
        }
        private void btnTagCircle_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Circle);
        }
        private void btnTagSquare_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Square);
        }
        private void btnTagTriangle_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Triangle);
        }
        private void btnTagStar_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Star);
        }
        #endregion

        #region Action Buttons
        private void btnMoveAction_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            switch (_CurrentCursoLocation) 
            {
                case CursorLocation.Box:
                    //Send the card to the Main/Extra deck
                    if (btnMoveAction.Text == "Send to Main Deck >>") 
                    { 
                        _CurrentDeckCardList.Add(_CurrentCardInView);
                        ActiveDeck.AddMainDeckCard(_CurrentCardInView.Name);
                        LoadPage_DECK(); 
                    }
                    if (btnMoveAction.Text == "Send to Extra Deck >>") 
                    { 
                        _CurrentExtraCardList.Add(_CurrentCardInView);
                        ActiveDeck.AddExtraDeckCard(_CurrentCardInView.Name);
                        LoadPage_EXTRA(); 
                    }
                    ClickCardFromBox(_CurrentCardSelectedIndex);
                    break;
                case CursorLocation.MainDeck:
                    //Remove the card from main deck
                    int index = (_CurrentPageDECK * CARDS_PER_PAGE_DECK) - CARDS_PER_PAGE_DECK;
                    index += _CurrentCardSelectedIndex;
                    _CurrentDeckCardList.RemoveAt(index);
                    ActiveDeck.RemoveFromMainDeck(index);
                    //Reselect a card from deck OR if deck is now empty chande the cursor to box
                    if(_CurrentDeckCardList.Count == 0)
                    {
                        ClickCardFromBox(0);
                    }
                    else
                    {
                        ClickCardFromDeck(0);
                    }
                    LoadPage_DECK();
                    break;
                case CursorLocation.ExtraDeck:
                    //Remove the card from main deck
                    index = (_CurrentPageEXTRA * CARDS_PER_PAGE_EXTRA) - CARDS_PER_PAGE_EXTRA;
                    index += _CurrentCardSelectedIndex;
                    _CurrentExtraCardList.RemoveAt(index);
                    ActiveDeck.RemoveFromExtraDeck(index);
                    //Reselect a card from deck OR if deck is now empty chande the cursor to box
                    if (_CurrentExtraCardList.Count == 0)
                    {
                        ClickCardFromBox(0);
                    }
                    else
                    {
                        ClickCardFromExtra(0);
                    }
                    LoadPage_EXTRA();
                    break;
                case CursorLocation.SideDeck:
                    //Remove the card from main deck
                    index = (_CurrentPageSIDE * CARDS_PER_PAGE_SIDE) - CARDS_PER_PAGE_SIDE;
                    index += _CurrentCardSelectedIndex;
                    _CurrentSideCardList.RemoveAt(index);
                    ActiveDeck.RemoveFromSideDeck(index);
                    //Reselect a card from deck OR if deck is now empty chande the cursor to box
                    if (_CurrentSideCardList.Count == 0)
                    {
                        ClickCardFromBox(0);
                    }
                    else
                    {
                        ClickCardFromSide(0);
                    }
                    LoadPage_SIDE();
                    break;
            }

            SaveData();
        }
        private void btnMoveActionSide_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            switch (_CurrentCursoLocation)
            {
                case CursorLocation.Box:
                    //Send the card to the Main/Extra deck
                    _CurrentSideCardList.Add(_CurrentCardInView); LoadPage_SIDE();
                    ActiveDeck.AddSideDeckCard(_CurrentCardInView.Name);
                    ClickCardFromBox(_CurrentCardSelectedIndex);
                    break;
            }

            SaveData();
        }
        private void btnTCGPLayer_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Tools.LaunchURLIntoBrowser("https://www.tcgplayer.com/search/all/product?q=" + _CurrentCardInView.Name + "&view=grid");
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
                    switch(_CurrentCursoLocation)
                    {
                        case CursorLocation.Box:
                            if (_CurrentCardSelectedIndex < 7)
                            {
                                //Do nothing it is the top row
                                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                            }
                            else
                            {
                                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                                //check if the Up card image is visible
                                if (_CardPanelListBOX[_CurrentCardSelectedIndex - 7].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 7, CursorLocation.Box);
                                }
                            }
                            break;
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
                        case CursorLocation.Box:
                            if (_CurrentCardSelectedIndex > 27)
                            {
                                //Do nothing it is the top row
                                SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                            }
                            else
                            {
                                SoundServer.PlaySoundEffect(SoundEffect.Hover);
                                //check if the Up card image is visible
                                if (_CardPanelListBOX[_CurrentCardSelectedIndex + 7].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 7, CursorLocation.Box);
                                }
                            }
                            break;
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
                    switch(_CurrentCursoLocation)
                    {
                        case CursorLocation.Box:
                            if (_CurrentCardSelectedIndex == 0)
                            {
                                GoPreviousPage_BOX();
                                //Find the last visible card in the page and select it
                                for (int x = 34; x >= 0; x--)
                                {
                                    if (_CardPanelListBOX[x].Visible)
                                    {
                                        InitializeSelectedCardInfo(x, CursorLocation.Box);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //check if the left card image is visible
                                if (_CardPanelListBOX[_CurrentCardSelectedIndex - 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex - 1, CursorLocation.Box);
                                }
                            }
                            break;
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
                        case CursorLocation.Box:
                            if (_CurrentCardSelectedIndex == 34)
                            {
                                GoNextPage_BOX();
                            }
                            else
                            {
                                //check if the right card image is visible
                                if (_CardPanelListBOX[_CurrentCardSelectedIndex + 1].Visible)
                                {
                                    //change the selection 
                                    InitializeSelectedCardInfo(_CurrentCardSelectedIndex + 1, CursorLocation.Box);
                                }
                                else
                                {
                                    GoNextPage_BOX();
                                }
                            }
                            break;
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
    }
}