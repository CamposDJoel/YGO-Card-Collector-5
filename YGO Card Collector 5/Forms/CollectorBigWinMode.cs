//Joel Campos
//2/8/2024
//CollectorBigWinMode

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public partial class CollectorBigWinMode : Form
    {
        #region Constructors
        public CollectorBigWinMode(FormLauncher mainMenuForm)
        {
            SoundServer.PlayRNDBackgroundMusic();

            _MainMenuForm = mainMenuForm;
            InitializeComponent();
            InitializeCardViewImages();
            InitializeCardViewImagesVariants();
            InitializeCustomTagNames();
            LoadMasterCardList(CardGroup.AllCards);
            listSetGroups.SetSelected(0, true);

            //Load Form theme
            Tools.InitalizeThemeOnForm(this);

            void InitializeCardViewImages()
            {
                int Picture_XSIZE = 52;
                int Picture_YSIZE = 65;
                int CARD_XSIZE = Picture_XSIZE - 4;
                int CARD_YSIZE = Picture_YSIZE - 4;
                int ICON_SIZE = 18;
                int ROWS = 6;
                int COLUMNS = 15;

                int imageID = 0;
                int Y_Location = 20;
                for (int x = 0; x < ROWS; x++)
                {
                    int X_Location = 3;
                    for (int y = 0; y < COLUMNS; y++)
                    {
                        //Initialize the border box Image
                        Panel CardBox = new Panel();
                        GroupCardView.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(Picture_XSIZE, Picture_YSIZE);
                        _CardPanelList.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(ICON_SIZE, ICON_SIZE);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        _IconImageList.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(CARD_XSIZE, CARD_YSIZE);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(Image_click);
                        _CardImageList.Add(CardImage);

                        //Initialize the Rarity Icon
                        PictureBox CardRarity = new PictureBox();
                        CardBox.Controls.Add(CardRarity);
                        CardRarity.Location = new Point(1, 47);
                        CardRarity.BorderStyle = BorderStyle.FixedSingle;
                        CardRarity.Size = new Size(CARD_XSIZE, 15);
                        CardRarity.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardRarity.Visible = true;
                        CardRarity.BringToFront();
                        _CardRaritiesList.Add(CardRarity);

                        X_Location += Picture_XSIZE;
                        imageID++;
                    }
                    Y_Location += Picture_YSIZE;
                }
            }
            void InitializeCardViewImagesVariants()
            {
                int imageID = 0;
                int Y_Location = 20;
                for (int x = 0; x < 1; x++)
                {
                    int X_Location = 3;
                    for (int y = 0; y < 15; y++)
                    {
                        //Initialize the border box Image
                        Panel CardBox = new Panel();
                        GroupCardViewVariants.Controls.Add(CardBox);
                        CardBox.Location = new Point(X_Location, Y_Location);
                        CardBox.BorderStyle = BorderStyle.FixedSingle;
                        CardBox.Size = new Size(47, 60);
                        _CardPanelListV.Add(CardBox);

                        //Initialize the Card Collection Icon
                        PictureBox CardIcon = new PictureBox();
                        CardBox.Controls.Add(CardIcon);
                        CardIcon.Location = new Point(1, 1);
                        CardIcon.BorderStyle = BorderStyle.FixedSingle;
                        CardIcon.Size = new Size(15, 15);
                        CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardIcon.Tag = imageID;
                        //CardIcon.Visible = false;
                        _IconImageListV.Add(CardIcon);

                        //Initialize the card Image
                        PictureBox CardImage = new PictureBox();
                        CardBox.Controls.Add(CardImage);
                        CardImage.Location = new Point(1, 1);
                        CardImage.BorderStyle = BorderStyle.FixedSingle;
                        CardImage.Size = new Size(43, 56);
                        CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardImage.Tag = imageID;
                        CardImage.Click += new EventHandler(this.ImageVariant_click);
                        _CardImageListV.Add(CardImage);

                        //Initialize the Rarity Icon
                        PictureBox CardRarity = new PictureBox();
                        CardBox.Controls.Add(CardRarity);
                        CardRarity.Location = new Point(1, 42);
                        CardRarity.BorderStyle = BorderStyle.FixedSingle;
                        CardRarity.Size = new Size(43, 15);
                        CardRarity.SizeMode = PictureBoxSizeMode.StretchImage;
                        CardRarity.Visible = true;
                        CardRarity.BringToFront();
                        _CardRaritiesListV.Add(CardRarity);

                        X_Location += 47;
                        imageID++;
                    }
                    Y_Location += 60;
                }
            }
            void InitializeCustomTagNames()
            {
                lblTagStar.Text = SettingsData.StarTagName;
                lblTagSquare.Text = SettingsData.SquareTagName;
                lblTagTriangle.Text = SettingsData.TriangleTagName;
                lblTagCircle.Text = SettingsData.CircleTagName;
            }
        }
        #endregion

        #region Card List Update Display Methods
        private void LoadMasterCardList(CardGroup CurrentGroup)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            //Pull the correct MasterCard list
            _MasterCardViewMode = true;
            _CurrentMasterCardList = Database.GroupCardListByGroupName[CurrentGroup];
            _CurrentSetCardListVariants = new List<SetCard>();
            //Reset the card page to 1 and hide the Clear Filter button if displaying all card list
            _CurrentCardPage = 1;
            _CurrentCardPageVariant = 1;
            if (CurrentGroup == CardGroup.AllCards) { btnClear.Visible = false; }
            //Update the Card Viewer Card Page/Card Count header
            GroupCardView.Text = string.Format("PAGE: {0}  -  CARD GROUP: {1}  -  Total Cards: {2}", _CurrentCardPage, Database.CardGroupToString(_CurrentCardGroup), _CurrentMasterCardList.Count);

            //Reload the page contents with the new list loaded
            LoadPage();
            //And Click on the card on the firs page
            InitializeSelectedCard(0);
        }
        private void InitializeSelectedCard(int PictureBoxTag)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Hover);
            //clear the card border of the previous card clicked
            _CardPanelList[_PreviousCardInViewIndex].BackColor = Color.Black;
            _CardPanelListV[_PreviousVariantCardInViewIndex].BackColor = Color.Black;

            //Determine the index of this card in relation to the entire active list
            int index = ((_CurrentCardPage * CARDS_PER_PAGE) - CARDS_PER_PAGE) + PictureBoxTag;

            //Set the card in view border as green
            _CardPanelList[PictureBoxTag].BackColor = Color.Yellow;

            //Save this Picture Box tag as the "previous card" for the next click
            _PreviousCardInViewIndex = PictureBoxTag;

            //Set this Card Objects reference
            string CardID = "-1";
            string CardName = "NONE";
            if (_MasterCardViewMode)
            {
                if (_CurrentMasterCardList.Count > 0)
                {
                    _CurrentMasterCardInView = _CurrentMasterCardList[index];
                    CardID = _CurrentMasterCardInView.ID.ToString();
                    CardName = _CurrentMasterCardInView.Name;
                }
                
            }
            else
            {
                if (_CurrentSetCardList.Count > 0)
                {
                    _CurrentSetCardInView = _CurrentSetCardList[index];
                    CardID = _CurrentSetCardInView.GetCardID();
                    CardName = _CurrentSetCardInView.GetCardName();
                }                   
            }

            if (CardName != "NONE")
            {
                //Clear the current Main Image and replace with this new card in view
                ImageServer.SetImage(PicImage, ImageType.CardImage, CardID);

                //Show the Name in the UI
                lblCardInfo_Name.Text = CardName;

                //Initialize this card's tags            
                if (_MasterCardViewMode)
                {
                    InitializeTags(_CurrentMasterCardInView);
                }
                else
                {
                    MasterCard ThisSetCardsMasterCard = Database.MasterCardByCode[_CurrentSetCardInView.Code];
                    InitializeTags(ThisSetCardsMasterCard);
                }


                //Show the rariry and prices if in set view
                if (_MasterCardViewMode)
                {
                    lblRariryLabel.Visible = false;
                    lblRarity.Visible = false;
                    lblFloorPricelabel.Visible = false;
                    lblFloorPrice.Visible = false;
                    lblMarketPricelabel.Visible = false;
                    lblMarketPrice.Visible = false;
                    lblMedianPricelabel.Visible = false;
                    lblMedianPrice.Visible = false;
                    lblCodelabel.Visible = false;
                    lblCode.Visible = false;
                }
                else
                {
                    //Rarity Label
                    lblRariryLabel.Visible = true;
                    lblRarity.Visible = true;
                    lblRarity.Text = _CurrentSetCardInView.Rarity;
                    lblRarity.ForeColor = Tools.GetRarityColorForLabel(_CurrentSetCardInView.Rarity);
                    //Floor Price Label
                    lblFloorPricelabel.Visible = true;
                    lblFloorPrice.Visible = true;
                    lblFloorPrice.Text = _CurrentSetCardInView.FloorPrice;
                    lblFloorPrice.ForeColor = Tools.GetPriceColorForLabel(_CurrentSetCardInView.GetDoubleFloorPrice());
                    //Market Price Label
                    lblMarketPricelabel.Visible = true;
                    lblMarketPrice.Visible = true;
                    lblMarketPrice.Text = _CurrentSetCardInView.MarketPrice;
                    lblMarketPrice.ForeColor = Tools.GetPriceColorForLabel(_CurrentSetCardInView.GetDoubleMarketPrice());
                    //Median Price Label
                    lblMedianPricelabel.Visible = true;
                    lblMedianPrice.Visible = true;
                    lblMedianPrice.Text = _CurrentSetCardInView.MediamPrice;
                    lblMedianPrice.ForeColor = Tools.GetPriceColorForLabel(_CurrentSetCardInView.GetDoubleMedianPrice());
                    //Set Code Label
                    lblCodelabel.Visible = true;
                    lblCode.Visible = true;
                    lblCode.Text = _CurrentSetCardInView.Code;
                }

                //Show the PRODECK and TCG Links buttons if availablelblProdeckLink.Visible = true;
                lblProdeckLink.Visible = false;
                lblTCGLink.Visible = false;
                if (_MasterCardViewMode)
                {
                    if (_CurrentMasterCardInView.HasProDeckURL())
                    {
                        lblProdeckLink.Visible = true;
                    }
                    lblTCGLink.Visible = true;
                }
                else
                {
                    if (_CurrentSetCardInView.MasterCardHasProdeckURL())
                    {
                        lblProdeckLink.Visible = true;
                    }

                    if (_CurrentSetCardInView.HasTCGURL())
                    {
                        lblTCGLink.Visible = true;
                    }
                }

                bool[] tags;
                //Show the tag symbols
                if (_MasterCardViewMode)
                {
                    tags = _CurrentMasterCardInView.GetTags();
                }
                else
                {
                    tags = _CurrentSetCardInView.GetTags();
                }
                ImageServer.SetImage(PicTagStar, ImageType.TagIcon, TagIcon.Star.ToString() + tags[(int)TagIcon.Star]);
                ImageServer.SetImage(PicTagSquare, ImageType.TagIcon, TagIcon.Square.ToString() + tags[(int)TagIcon.Square]);
                ImageServer.SetImage(PicTagTriangle, ImageType.TagIcon, TagIcon.Triangle.ToString() + tags[(int)TagIcon.Triangle]);
                ImageServer.SetImage(PicTagCircle, ImageType.TagIcon, TagIcon.Circle.ToString() + tags[(int)TagIcon.Circle]);
            }               
        }
        private void InitializeSelectedCardVariant(int PictureBoxTag)
        {
            //clear the card border of the previous card clicked
            _CardPanelList[_PreviousCardInViewIndex].BackColor = Color.Black;
            _CardPanelListV[_PreviousVariantCardInViewIndex].BackColor = Color.Black;

            //Determine the index of this card in relation to the entire active list
            int index = ((_CurrentCardPageVariant * 15) - 15) + PictureBoxTag;

            //Set the card in view border as green
            _CardPanelListV[PictureBoxTag].BackColor = Color.Yellow;

            //Save this Picture Box tag as the "previous card" for the next click
            _PreviousVariantCardInViewIndex = PictureBoxTag;

            //Set this Card Objects reference
            _CurrentSetCardInView = _CurrentSetCardListVariants[index];
            string CardID = _CurrentSetCardInView.GetCardID();
            string CardName = _CurrentSetCardInView.GetCardName();

            //Clear the current Main Image and replace with this new card in view
            ImageServer.SetImage(PicImage, ImageType.CardImage, CardID);

            //Show the Name in the UI
            lblCardInfo_Name.Text = CardName;

            //Initialize this card's tags            
            MasterCard ThisSetCardsMasterCard = Database.MasterCardByCode[_CurrentSetCardInView.Code];
            InitializeTags(ThisSetCardsMasterCard);

            //Show the rariry and prices if in set view
            lblRariryLabel.Visible = true;
            lblRarity.Visible = true;
            lblRarity.Text = _CurrentSetCardInView.Rarity;
            switch (_CurrentSetCardInView.Rarity)
            {
                case "Common": lblRarity.ForeColor = Color.White; break;
                case "Rare": lblRarity.ForeColor = Color.PaleGreen; break;
                case "Ultra Rare": lblRarity.ForeColor = Color.Moccasin; break;
                case "Ultra Rare(Hobby League Version)": lblRarity.ForeColor = Color.Moccasin; break;
                case "Ultimate Rare": lblRarity.ForeColor = Color.HotPink; break;
                case "Gold Rare": lblRarity.ForeColor = Color.Gold; break;
                case "Hobby": lblRarity.ForeColor = Color.MediumPurple; break;
                case "Millennium Secret Rare": lblRarity.ForeColor = Color.Goldenrod; break;
                case "Platinum Secret Rare": lblRarity.ForeColor = Color.LightSkyBlue; break;
                case "Starfoil": lblRarity.ForeColor = Color.BlueViolet; break;
                case "Shattefoil": lblRarity.ForeColor = Color.MediumTurquoise; break;
                case "Super Rare": lblRarity.ForeColor = Color.SteelBlue; break;
                case "Secret Rare": lblRarity.ForeColor = Color.Pink; break;
                case "Ghost Rare": lblRarity.ForeColor = Color.PowderBlue; break;
                case "Premium Gold Rare": lblRarity.ForeColor = Color.DarkGoldenrod; break;
                case "Gold Secret": lblRarity.ForeColor = Color.Yellow; break;
                case "Platinum Rare": lblRarity.ForeColor = Color.Aqua; break;
                case "COLLECTOR'S RARE": lblRarity.ForeColor = Color.RosyBrown; break;
                case "Mosaic Rare": lblRarity.ForeColor = Color.DarkViolet; break;
                case "Quarter Century Secret Rare": lblRarity.ForeColor = Color.Plum; break;
                case "Prismatic Secret Rare": lblRarity.ForeColor = Color.Plum; break;
                case "Ultra Rare (Pharaoh's Rare)": lblRarity.ForeColor = Color.DarkRed; break;
                default: lblRarity.ForeColor = Color.White; break;
            }
            //Floor Price Label
            lblFloorPricelabel.Visible = true;
            lblFloorPrice.Visible = true;
            lblFloorPrice.Text = _CurrentSetCardInView.FloorPrice;
            lblFloorPrice.ForeColor = Tools.GetPriceColorForLabel(_CurrentSetCardInView.GetDoubleFloorPrice());
            //Market Price Label
            lblMarketPricelabel.Visible = true;
            lblMarketPrice.Visible = true;
            lblMarketPrice.Text = _CurrentSetCardInView.MarketPrice;
            lblMarketPrice.ForeColor = Tools.GetRarityColorForLabel(_CurrentSetCardInView.Rarity);
            //Median Price Label
            lblMedianPricelabel.Visible = true;
            lblMedianPrice.Visible = true;
            lblMedianPrice.Text = _CurrentSetCardInView.MediamPrice;
            lblMedianPrice.ForeColor = Tools.GetRarityColorForLabel(_CurrentSetCardInView.Rarity);
            lblCodelabel.Visible = true;
            lblCode.Visible = true;
            lblCode.Text = _CurrentSetCardInView.Code;

            //Show the PRODECK and TCG Links buttons if availablelblProdeckLink.Visible = true;
            lblProdeckLink.Visible = false;
            lblTCGLink.Visible = false;
            if (_CurrentSetCardInView.MasterCardHasProdeckURL())
            {
                lblProdeckLink.Visible = true;
            }

            if (_CurrentSetCardInView.HasTCGURL())
            {
                lblTCGLink.Visible = true;
            }
        }
        private void LoadPage()
        {
            //Set the total Card Count
            int TotalCardCount = 0;
            if (_MasterCardViewMode) { TotalCardCount = _CurrentMasterCardList.Count; }
            else { TotalCardCount = _CurrentSetCardList.Count; }

            //Start the iterator
            int PageIntialIndex = (_CurrentCardPage * CARDS_PER_PAGE) - CARDS_PER_PAGE;

            //Loop thru all the Card Images (in Main) to initialize them
            for (int x = 0; x < _CardImageList.Count; x++)
            {
                //Set the card iterator index
                int iterator = PageIntialIndex + x;

                //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                if (iterator >= TotalCardCount)
                {
                    _CardPanelList[x].Visible = false;
                }
                else
                {
                    //show the card
                    _CardPanelList[x].Visible = true;

                    //Save Ref to the Master/Set Card object that will be used
                    MasterCard ThisMasterCard = new MasterCard();
                    SetCard ThisSetCard = new SetCard();
                    if (_MasterCardViewMode) { ThisMasterCard = _CurrentMasterCardList[iterator]; }
                    else { ThisSetCard = _CurrentSetCardList[iterator]; }

                    //Initialize the card image
                    LoadCardImage(x, ThisMasterCard, ThisSetCard);

                    //Initialize the obtained icon
                    LoadCardObtainedIcon(x, ThisMasterCard, ThisSetCard);

                    //Initalize the Rarity Icon
                    LoadRarityLabel(x, ThisSetCard);
                }
            }

            int PageIntialIndexV = (_CurrentCardPageVariant * 15) - 15;
            //Lopp thr all the Card Images (in Variants) to initialize them
            for (int x = 0; x < _CardImageListV.Count; x++)
            {
                if (_MasterCardViewMode)
                {
                    //Hide all of them
                    _CardPanelListV[x].Visible = false;
                }
                else
                {
                    //Variants 
                    int TotalCardCountVariants = _CurrentSetCardListVariants.Count;

                    //Show based on the Variant card list
                    //Set the card iterator index
                    int iterator = PageIntialIndexV + x;

                    //If the Iterator passes over the Total Card Count: Hide the image for those indexes
                    if (iterator >= TotalCardCountVariants)
                    {
                        _CardPanelListV[x].Visible = false;
                    }
                    else
                    {
                        //show the card
                        _CardPanelListV[x].Visible = true;

                        //Save Ref to the Master/Set Card object that will be used
                        SetCard ThisSetCard = _CurrentSetCardListVariants[iterator];

                        //Initialize the card image
                        LoadCardImageV(x, ThisSetCard);

                        //Initialize the obtained icon
                        LoadCardObtainedIconV(x, ThisSetCard);

                        //Initalize the Rarity Icon
                        LoadRarityLabelV(x, ThisSetCard);
                    }
                }
            }

            UpdatePageBanners();

            void LoadCardImage(int x, MasterCard ThisMasterCard, SetCard ThisSetCard)
            {
                //Initalize the Card Image
                if (_YouCollectionViewON)
                {
                    //show the front/back of the card depending on the Obtained flag
                    if (_MasterCardViewMode)
                    {
                        //If the mastercard is/is not obtained
                        if (ThisMasterCard.IsOwned())
                        {
                            ImageServer.SetImage(_CardImageList[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                        }
                        else
                        {
                            ImageServer.SetImage(_CardImageList[x], ImageType.CardBack, "NONE");
                        }
                    }
                    else
                    {
                        //if the SetCard is/is not obtaineed
                        if (ThisSetCard.IsOwned())
                        {
                            ImageServer.SetImage(_CardImageList[x], ImageType.CardImage, ThisSetCard.GetCardID());
                        }
                        else
                        {
                            ImageServer.SetImage(_CardImageList[x], ImageType.CardBack, "NONE");
                        }
                    }
                }
                else
                {
                    //Always show the front of the card
                    if (_MasterCardViewMode)
                    {
                        ImageServer.SetImage(_CardImageList[x], ImageType.CardImage, ThisMasterCard.ID.ToString());
                    }
                    else
                    {
                        ImageServer.SetImage(_CardImageList[x], ImageType.CardImage, ThisSetCard.GetCardID());
                    }
                }
            }
            void LoadCardImageV(int x, SetCard ThisSetCard)
            {
                //Initalize the Card Image
                if (_YouCollectionViewON)
                {
                    //if the SetCard is/is not obtaineed
                    if (ThisSetCard.IsOwned())
                    {
                        ImageServer.SetImage(_CardImageListV[x], ImageType.CardImage, ThisSetCard.GetCardID());
                    }
                    else
                    {
                        ImageServer.SetImage(_CardImageListV[x], ImageType.CardBack, "NONE");
                    }
                }
                else
                {
                    //Always show the front of the card
                    ImageServer.SetImage(_CardImageListV[x], ImageType.CardImage, ThisSetCard.GetCardID());
                }
            }
            void LoadCardObtainedIcon(int x, MasterCard ThisMasterCard, SetCard ThisSetCard)
            {
                //Start with the Icon invisible
                _IconImageList[x].Visible = false;
                if (_MasterCardViewMode)
                {
                    //show the star or exclamation mark icon depending if all setcard obtaiend

                    if (ThisMasterCard.HasAllSetCardsObtained())
                    {
                        ImageServer.SetImage(_IconImageList[x], ImageType.StarIcon, "NONE");
                        _IconImageList[x].Visible = true;
                    }
                    else
                    {
                        if (ThisMasterCard.HasOneCardsObtained())
                        {
                            ImageServer.SetImage(_IconImageList[x], ImageType.ExclamationMark, "NONE");
                            _IconImageList[x].Visible = true;
                        }
                    }
                }
                else
                {
                    //Show the checkmark icon if setcard obtained
                    if (ThisSetCard.IsOwned())
                    {
                        ImageServer.SetImage(_IconImageList[x], ImageType.CheckMark, "NONE");
                        _IconImageList[x].Visible = true;
                    }
                }
            }
            void LoadCardObtainedIconV(int x, SetCard ThisSetCard)
            {
                //Start with the Icon invisible
                _IconImageListV[x].Visible = false;

                //Show the checkmark icon if setcard obtained
                if (ThisSetCard.IsOwned())
                {
                    ImageServer.SetImage(_IconImageListV[x], ImageType.CheckMark, "NONE");
                    _IconImageListV[x].Visible = true;
                }
            }
            void LoadRarityLabel(int x, SetCard ThisSetCard)
            {
                if (_MasterCardViewMode)
                {
                    _CardRaritiesList[x].Visible = false;
                }
                else
                {
                    if (ThisSetCard.Rarity == "Common")
                    {
                        _CardRaritiesList[x].Visible = false;
                    }
                    else
                    {
                        ImageServer.SetImage(_CardRaritiesList[x], ImageType.Rarity, ThisSetCard.Rarity);
                        _CardRaritiesList[x].Visible = true;
                    }
                }
            }
            void LoadRarityLabelV(int x, SetCard ThisSetCard)
            {
                if (ThisSetCard.Rarity == "Common")
                {
                    _CardRaritiesListV[x].Visible = false;
                }
                else
                {
                    ImageServer.SetImage(_CardRaritiesListV[x], ImageType.Rarity, ThisSetCard.Rarity);
                    _CardRaritiesListV[x].Visible = true;
                }
            }
            void UpdatePageBanners()
            {
                int lastPage = GetLastPage();
                if (_MasterCardViewMode)
                {
                    GroupCardView.Text = string.Format("PAGE: {0}/{1} | GROUP: {2} | Cards: {2}", _CurrentCardPage, lastPage, Database.CardGroupToString(_CurrentCardGroup), _CurrentMasterCardList.Count);
                    GroupCardViewVariants.Text = "PAGE: 1/1 - NO VARIANT CARD IS MASTER CARD LIST VIEW";
                }
                else
                {
                    int index = listSetlist.SelectedIndex;
                    string SetName = _CurrentSetInfoListSelected[index].Name;
                    string Code = _CurrentSetInfoListSelected[index].GetCode();

                    if (Database.SetPackByName.ContainsKey(SetName))
                    {
                        //Update the Card Viewer Card Page/Card Count header
                        GroupCardView.Text = string.Format("PAGE: {0}/{1} | CODE: {2} | Main Cards: {2}", _CurrentCardPage, lastPage, Code, _CurrentSetCardList.Count);
                        GroupCardViewVariants.Text = string.Format("PAGE: {0}/{1} | CODE: {3} | Variant Cards: {2}", _CurrentCardPageVariant, lastPage, Code, _CurrentSetCardListVariants.Count);
                    }
                    else
                    {
                        //Update the Card Viewer Card Page/Card Count header
                        GroupCardView.Text = string.Format("PAGE: {0}/{1} | CODE: \"{2}\" | Main Cards: 0", _CurrentCardPage, lastPage, Code);
                        GroupCardViewVariants.Text = string.Format("PAGE: {0}/{1} | CODE: \"{2}\" | Variant Cards: 0", _CurrentCardPageVariant, lastPage, Code);
                    }
                }
            }
        }
        private void InitializeTags(MasterCard ThisMasterCard)
        {
            //Clear all existing tags
            foreach (Label label in _TagLabelList) { label.Dispose(); }
            _TagLabelList.Clear();
            foreach (Panel panel in _TagContainerList) { panel.Dispose(); }
            _TagContainerList.Clear();

            int SetCardCount = ThisMasterCard.SetCards.Count;

            int Y_Location = 1;
            for (int x = 0; x < SetCardCount; x++)
            {
                string ActiveSetName = ThisMasterCard.GetCardAtIndex(x).Name;
                string ActiveSetCode = ThisMasterCard.GetCardAtIndex(x).Code;
                string ActiveSetRarity = ThisMasterCard.GetCardAtIndex(x).Rarity;
                bool ActiveSetObtained = ThisMasterCard.GetCardAtIndex(x).IsOwned();

                Panel TagContainer = new Panel();
                PanelTagList.Controls.Add(TagContainer);
                TagContainer.Location = new Point(1, Y_Location);
                TagContainer.BorderStyle = BorderStyle.FixedSingle;
                TagContainer.BackColor = Color.Black;
                TagContainer.Size = new Size(109, 36);
                TagContainer.AutoSize = false;
                TagContainer.Tag = x;
                _TagContainerList.Add(TagContainer);


                Label tagLabel = new Label();
                TagContainer.Controls.Add(tagLabel);
                tagLabel.Location = new Point(1, 1);
                tagLabel.BorderStyle = BorderStyle.None;
                tagLabel.BackColor = Color.Transparent;
                tagLabel.Size = new Size(107, 17);
                tagLabel.AutoSize = false;
                tagLabel.Font = new Font("Arial", 9);
                tagLabel.Text = ActiveSetCode;
                tagLabel.TextAlign = ContentAlignment.MiddleLeft;
                tagLabel.ForeColor = Color.White;
                tagLabel.Tag = x;
                tagLabel.Click += new EventHandler(SetCardLabel_clicked);
                _TagLabelList.Add(tagLabel);

                //During the SetCard view, have this SetCard clicked on the card view highlighted in red
                if (!_MasterCardViewMode)
                {
                    if (ActiveSetCode == _CurrentSetCardInView.Code && ActiveSetRarity == _CurrentSetCardInView.Rarity
                        && ActiveSetName == _CurrentSetCardInView.Name)
                    {
                        tagLabel.ForeColor = Color.Yellow;
                        _CurrentSetCartdInViewIndex = x;
    }
                }

                ////////////////////////////////////

                Label tagLabel2 = new Label();
                TagContainer.Controls.Add(tagLabel2);
                tagLabel2.Location = new Point(1, 18);
                tagLabel2.BorderStyle = BorderStyle.None;
                tagLabel2.BackColor = Color.Transparent;
                tagLabel2.Size = new Size(107, 17);
                tagLabel2.AutoSize = false;
                tagLabel2.Font = new Font("Arial", 9);
                if (ActiveSetRarity.Length > 13)
                {
                    tagLabel2.Font = new Font("Arial", 6);
                }
                tagLabel2.Text = ActiveSetRarity;
                tagLabel2.TextAlign = ContentAlignment.MiddleRight;
                tagLabel2.ForeColor = Color.White;
                tagLabel2.Tag = x;
                tagLabel2.Click += new EventHandler(SetCardLabel_clicked);
                _TagLabelList.Add(tagLabel2);

                //During the SetCard view, have this SetCard clicked on the card view highlighted in yellow
                if (!_MasterCardViewMode)
                {
                    if (ActiveSetCode == _CurrentSetCardInView.Code && ActiveSetRarity == _CurrentSetCardInView.Rarity
                        && ActiveSetName == _CurrentSetCardInView.Name)
                    {
                        tagLabel2.ForeColor = Color.Yellow;
                    }
                }


                //If the code for this set has an empty code, hide it,
                //and dont move the Y_Location so the next tag takes it location
                if (ActiveSetCode == "" || (ActiveSetName == "INVASION OF CHAOS" && ActiveSetCode.StartsWith("IOC-EN")))
                {
                    TagContainer.Visible = false;
                }
                else
                {
                    Y_Location += 36;
                }

                //Set Color base on if it is obtained or not
                if (ActiveSetObtained)
                {
                    TagContainer.BackColor = Color.Maroon;
                }
                else
                {
                    TagContainer.BackColor = Color.Black;
                }
            }

            //Resize the TagList Container
            int width = 133;
            if (SetCardCount < 7) { width = 113; }
            int height = 296;
            if (SetCardCount < 9) { height = ((SetCardCount * 36) + 4); }
            PanelTagList.Size = new Size(width, height);
        }
        #endregion

        #region Internal Data
        private FormLauncher _MainMenuForm;
        private List<MasterCard> _CurrentMasterCardList;
        private List<SetCard> _CurrentSetCardList;
        private List<SetCard> _CurrentSetCardListVariants;

        private CardGroup _CurrentCardGroup = CardGroup.AllCards;
        private bool _MasterCardViewMode = true;
        private int _CurrentCardPage = 1;
        private int _CurrentCardPageVariant = 1;
        private bool _YouCollectionViewON = false;

        private int _PreviousCardInViewIndex = 0;
        private int _PreviousVariantCardInViewIndex = 0;

        private MasterCard _CurrentMasterCardInView;
        private SetCard _CurrentSetCardInView;
        private int _CurrentSetCartdInViewIndex = 0;
        private List<SetInfo> _CurrentSetInfoListSelected;

        private int _CurrentCardImageIndexSelected = 0;
        private bool _KeyInputEnable = true;

        private const int CARDS_PER_PAGE = 90;

        //Main List
        private List<Panel> _CardPanelList = new List<Panel>();
        private List<PictureBox> _IconImageList = new List<PictureBox>();
        private List<PictureBox> _CardImageList = new List<PictureBox>();
        private List<PictureBox> _CardRaritiesList = new List<PictureBox>();
        //Variant Cards
        private List<Panel> _CardPanelListV = new List<Panel>();
        private List<PictureBox> _IconImageListV = new List<PictureBox>();
        private List<PictureBox> _CardImageListV = new List<PictureBox>();
        private List<PictureBox> _CardRaritiesListV = new List<PictureBox>();
        //Set Cards "Tags" 
        private List<Label> _TagLabelList = new List<Label>();
        private List<Panel> _TagContainerList = new List<Panel>();
        #endregion

        #region Event Listeners (Card/Set Clicking Events)
        private void Image_click(object sender, EventArgs e)
        {
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            _CurrentCardImageIndexSelected = (int)ThisPictureBox.Tag;
            InitializeSelectedCard(_CurrentCardImageIndexSelected);
        }
        private void ImageVariant_click(object sender, EventArgs e)
        {
            //Initialize the Card Selected based on the TAG of the image clicked.
            PictureBox ThisPictureBox = (PictureBox)sender;
            InitializeSelectedCardVariant((int)ThisPictureBox.Tag);
        }
        private void SetCardLabel_clicked(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.MarkCard);
            Label thisLabel = (Label)sender;
            int Index = (int)thisLabel.Tag;

            //Mark it
            if (_MasterCardViewMode)
            {
                _CurrentMasterCardInView.GetCardAtIndex(Index).FlipObtainedStatus();
            }
            else
            {
                _CurrentSetCardInView.FlipObtainedStatus();
            }

            LoadPage();

            //Change the Container Label
            if (_TagContainerList[Index].BackColor == Color.Maroon)
            {
                _TagContainerList[Index].BackColor = Color.Black;
            }
            else
            {
                _TagContainerList[Index].BackColor = Color.Maroon;
            }
        }
        #endregion

        #region Event Listeners (Links Button Labels)
        private void LaunchKonamiURL()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            if (_MasterCardViewMode)
            {
                Tools.LaunchURLIntoBrowser(_CurrentMasterCardInView.KonamiURL);
            }
            else
            {
                Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.GetKonamiDBURL());
            }
        }
        private void LaunchProdeckURL()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            if (_MasterCardViewMode)
            {
                if (_CurrentMasterCardInView.HasProDeckURL())
                {
                    Tools.LaunchURLIntoBrowser(_CurrentMasterCardInView.ProdeckURL);
                }
            }
            else
            {
                Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.GetProdeckURL());
            }
        }
        private void LaunchTCGPlayerURL()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            if (_MasterCardViewMode)
            {
                Tools.LaunchURLIntoBrowser("https://www.tcgplayer.com/search/all/product?q=" + _CurrentMasterCardInView.Name + "&view=grid");
            }
            else
            {
                if (_CurrentSetCardInView.HasTCGURL())
                {
                    Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.TCGPlayerURL);
                }
            }
        }
        private void lblKonamiLink_Click(object sender, EventArgs e)
        {
            LaunchKonamiURL();
        }
        private void lblProdeckLink_Click(object sender, EventArgs e)
        {
            LaunchProdeckURL();
        }
        private void lblTCGLink_Click(object sender, EventArgs e)
        {
            LaunchTCGPlayerURL();
        }
        #endregion

        #region Event Listeners (Top Menu Buttons)
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Dispose();
            _MainMenuForm.ReturnToForm();
        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Hide();

            StatsReport SR = new StatsReport(this);
            SR.Show();
        }
        private void btnSetPriceReport_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Hide();

            PricingReport PR = new PricingReport(this);
            PR.Show();
        }
        private void btnOpenSetValue_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            Hide();

            PricingReport PR = new PricingReport(this, listSetGroups.SelectedIndex, listSetlist.SelectedIndex);
            PR.Show();
        }
        #endregion

        #region Event Listeners (Card Viewer Controls) + Methods
        private void chkCollected_CheckedChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.RDSelection);
            //Flip the Your Collection View Mode flag and reload the page.
            _YouCollectionViewON = chkCollected.Checked;
            LoadPage();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            //Reset the card list to the Master Card List (All Cards)
            _CurrentCardGroup = CardGroup.AllCards;
            LoadMasterCardList(_CurrentCardGroup);
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            GoPreviousPage();
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            GoNextPage();
        }
        private void btnPreviousPageVariant_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            int CurrentCardListCount = _CurrentSetCardListVariants.Count;
            int lastpage = (CurrentCardListCount / 15) + 1;
            if (_CurrentCardPageVariant == 1) { _CurrentCardPageVariant = lastpage; }
            else { _CurrentCardPageVariant--; }
            LoadPage();
        }
        private void btnNextPageVariant_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            int CurrentCardListCount = _CurrentSetCardListVariants.Count;
            int lastpage = (CurrentCardListCount / 15) + 1;
            if (_CurrentCardPageVariant == lastpage) { _CurrentCardPageVariant = 1; }
            else { _CurrentCardPageVariant++; }
            LoadPage();
        }
        private void GoPreviousPage()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage();
            if (_CurrentCardPage == 1) { _CurrentCardPage = lastpage; }
            else { _CurrentCardPage--; }

            LoadPage();
        }
        private void GoNextPage()
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);

            int lastpage = GetLastPage();
            if (_CurrentCardPage == lastpage) { _CurrentCardPage = 1; }
            else { _CurrentCardPage++; }

            LoadPage();
            _CurrentCardImageIndexSelected = 0;
            InitializeSelectedCard(_CurrentCardImageIndexSelected);
        }
        private int GetLastPage()
        {
            int CurrentCardListCount = 0;
            if (_MasterCardViewMode) { CurrentCardListCount = _CurrentMasterCardList.Count; }
            else { CurrentCardListCount = _CurrentSetCardList.Count; }
            double pages = ((double)CurrentCardListCount / (double)CARDS_PER_PAGE);
            int lastpage = (int)pages;
            double remaining = pages - (int)pages;
            if (remaining > 0) { lastpage++; }
            return lastpage;
        }
        #endregion

        #region Other Event Listeners
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Event Listerner (Master Filters)
        private void btnFilterAqua_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Aqua_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterBeast_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Beast_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterBeastWarrior_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.BeastWarrior_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterCyberce_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Cyberse_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterDinosaur_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Dinosaur_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterDivine_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.DivineBeast_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterDragon_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Dragon_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterFairy_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Fairy_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterFiend_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Fiend_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterFish_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Fish_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterIllusion_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.IllusionType_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterInsect_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Insect_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterMachine_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Machine_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterPlant_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Plant_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterPsychic_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Psychic_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterPyro_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Pyro_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterReptile_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Reptile_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterRock_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Rock_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterSeaSerpent_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.SeaSerpent_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterSpellcaster_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Spellcaster_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterThunder_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Thunder_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterWarrior_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Warrior_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterWingedBeast_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.WingedBeast_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterWyrm_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Wyrm_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFilterZombie_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Zombie_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnNormalSpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Normal_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnContinousSpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Continuous_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnEquipSpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Equip_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFieldSpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Field_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnQuickPlaySpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.QuickPlay_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnRitualSpell_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Ritual_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnNormalTrap_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Normal_Traps;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnContinuosTrap_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Continuous_Traps;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnCounterTrap_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Counter_Traps;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnMonster_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.All_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnSpells_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.All_Spells;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnTraps_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.All_Trap;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Normal_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnEffect_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Effect_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFusion_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Fusion_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnRitual_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Ritual_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnSynchro_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Synchro_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnXyz_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Xyz_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnPendulum_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Pendulum_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnLink_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Link_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFlip_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Flip_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnSpirit_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Spirit_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnToon_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Toon_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnUnion_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Union_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnTuner_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Tuner_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnGemini_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Gemini_Monsters;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnDark_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Dark_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnLight_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Light_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnEarth_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Earth_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnWater_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Water_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnFire_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Fire_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnWind_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Wind_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnDivine_Click(object sender, EventArgs e)
        {
            _CurrentCardGroup = CardGroup.Divine_Attribute;
            LoadMasterCardList(_CurrentCardGroup);
            btnClear.Visible = true;
        }
        private void btnTextSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string SearchTerm = txtSearch.Text;
                _CurrentMasterCardList = Database.GetCardListWithSearchTerm(SearchTerm);

                //Set Flags
                _MasterCardViewMode = true;
                _CurrentCardPage = 1;
                btnClear.Visible = true;

                //Update the Card Viewer Card Page/Card Count header
                GroupCardView.Text = string.Format("PAGE: {0}  -  SEARCH TERM: \"{1}\"  -  Total Cards: {2}", _CurrentCardPage, SearchTerm, _CurrentMasterCardList.Count);

                LoadPage();
            }
        }
        private void btnCodeSearch_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            string searchTerm = txtCodeSearch.Text.ToString();
            searchTerm = searchTerm.ToUpper();

            //scan the data base for each set group match
            if (searchTerm.Length >= 3)
            {
                List<string> results = Database.GetSetPacksWithCode(searchTerm);

                //print the results
                StringBuilder sb = new StringBuilder();
                foreach (string line in results)
                {
                    sb.AppendLine(line);
                }
                if (results.Count == 0)
                {
                    lblCodeSearchOutput.Text = "No Results";
                }
                else
                {
                    lblCodeSearchOutput.Text = sb.ToString();
                }
            }
        }
        #endregion

        #region Event Listeners (Set Filtering)
        private void listSetGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            int indexSelected = listSetGroups.SelectedIndex;

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

            listSetlist.Items.Clear();
            foreach (SetInfo set in SetList)
            {
                listSetlist.Items.Add(set.GetInfoLine());
            }
            listSetlist.SetSelected(0, true);
        }
        private void listSetlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
        }
        private void btnFilterSet_Click(object sender, EventArgs e)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);
            _MasterCardViewMode = false;
            btnClear.Visible = true;
            int index = listSetlist.SelectedIndex;
            string SetName = _CurrentSetInfoListSelected[index].Name;
            string Code = _CurrentSetInfoListSelected[index].GetCode();


            _CurrentCardPage = 1;
            if (Database.SetPackByName.ContainsKey(SetName))
            {
                SetPack ThisSetPack = Database.SetPackByName[SetName];

                int MainSetCardCount = ThisSetPack.MainCardList.Count;
                int ExtraCardCount = ThisSetPack.ExtraCardList.Count;

                ThisSetPack.SortByCode();
                _CurrentSetCardList = ThisSetPack.MainCardList;
                _CurrentSetCardListVariants = ThisSetPack.ExtraCardList;
            }
            else
            {
                _CurrentSetCardList = new List<SetCard>();
            }

            //Click on the first card
            _CurrentCardImageIndexSelected = 0;
            InitializeSelectedCard(_CurrentCardImageIndexSelected);

            LoadPage();
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
                    if (_CurrentCardImageIndexSelected < 15)
                    {
                        //Do nothing it is the top row
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    }
                    else
                    {
                        //check if the Up card image is visible
                        if (_CardPanelList[_CurrentCardImageIndexSelected - 15].Visible)
                        {
                            //change the selection 
                            _CurrentCardImageIndexSelected -= 15;
                            InitializeSelectedCard(_CurrentCardImageIndexSelected);
                        }
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
                    if (_CurrentCardImageIndexSelected > CARDS_PER_PAGE - 16)
                    {
                        //Do nothing it is the top row
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    }
                    else
                    {
                        //check if the Up card image is visible
                        if (_CardPanelList[_CurrentCardImageIndexSelected + 15].Visible)
                        {
                            //change the selection 
                            _CurrentCardImageIndexSelected += 15;
                            InitializeSelectedCard(_CurrentCardImageIndexSelected);
                        }
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
                    if (_CurrentCardImageIndexSelected == 0)
                    {
                        //trigger go to previous page
                        GoPreviousPage();

                        //Find the last visible card in the page and select it
                        for (int x = CARDS_PER_PAGE - 1; x >= 0; x--)
                        {
                            if (_CardPanelList[x].Visible)
                            {
                                _CurrentCardImageIndexSelected = x;
                                InitializeSelectedCard(_CurrentCardImageIndexSelected);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //check if the Up card image is visible
                        if (_CardPanelList[_CurrentCardImageIndexSelected - 1].Visible)
                        {
                            //change the selection 
                            _CurrentCardImageIndexSelected -= 1;
                            InitializeSelectedCard(_CurrentCardImageIndexSelected);
                        }
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
                    if (_CurrentCardImageIndexSelected == CARDS_PER_PAGE - 1)
                    {
                        //Go to the next page and click the first card
                        GoNextPage();
                    }
                    else
                    {
                        //check if the Up card image is visible
                        if (_CardPanelList[_CurrentCardImageIndexSelected + 1].Visible)
                        {
                            //change the selection 
                            _CurrentCardImageIndexSelected += 1;
                            InitializeSelectedCard(_CurrentCardImageIndexSelected);
                        }
                        else
                        {
                            //You reached the last card in the list go to next page
                            //Go to the next page and click the first card
                            GoNextPage();
                            _CurrentCardImageIndexSelected = 0;
                            InitializeSelectedCard(_CurrentCardImageIndexSelected);
                        }
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F1)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    if (_MasterCardViewMode)
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    }
                    else
                    {
                        //Mark all the cards in the current set
                        SoundServer.PlaySoundEffect(SoundEffect.MarkAll);
                        foreach(SetCard thisCard in _CurrentSetCardList)
                        {
                            if(!thisCard.IsOwned())
                            {
                                thisCard.MarkOwnedStatus(true);
                            }
                        }
                        LoadPage();
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F5)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Open the Konami URL link
                    LaunchKonamiURL();
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F6)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Open prodeck URL
                    LaunchProdeckURL();
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F7)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Open TCG Player URL
                    LaunchTCGPlayerURL();
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F8)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    LoadPage();
                    _KeyInputEnable = true;
                }
                return true;               
            }
            else if (keyData == Keys.F9)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Tag the Star Icon
                    MarkTag(PicTagStar, TagIcon.Star);
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F10)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Tag the Square Icon
                    MarkTag(PicTagSquare, TagIcon.Square);
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F11)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Tag the Triangle Icon
                    MarkTag(PicTagTriangle, TagIcon.Triangle);
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.F12)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    //Tag the Circle Icon
                    MarkTag(PicTagCircle, TagIcon.Circle);
                    _KeyInputEnable = true;
                }
                return true;
            }
            else if (keyData == Keys.Enter || keyData == Keys.Oemtilde)
            {
                if (_KeyInputEnable)
                {
                    _KeyInputEnable = false;
                    if (_MasterCardViewMode)
                    {
                        SoundServer.PlaySoundEffect(SoundEffect.InvalidClick);
                    }
                    else
                    {
                        //Mark the current selected card
                        SoundServer.PlaySoundEffect(SoundEffect.MarkCard);
                        _CurrentSetCardInView.FlipObtainedStatus();

                        //Change the Container Label
                        int Index = _CurrentSetCartdInViewIndex;
                        if (_TagContainerList[Index].BackColor == Color.Maroon)
                        {
                            _TagContainerList[Index].BackColor = Color.Black;
                        }
                        else
                        {
                            _TagContainerList[Index].BackColor = Color.Maroon;
                        }

                        LoadPage();
                    }
                    _KeyInputEnable = true;
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Event Listeners Tag Markers
        private void MarkTag(PictureBox Box, TagIcon thisTag)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click);
            //Show the tag symbols
            if (_MasterCardViewMode)
            {
                bool tagON = _CurrentMasterCardInView.GetTag(thisTag);
                if (tagON)
                {
                    _CurrentMasterCardInView.SetTag(thisTag, false);
                }
                else
                {
                    _CurrentMasterCardInView.SetTag(thisTag, true);
                }
                ImageServer.SetImage(Box, ImageType.TagIcon, thisTag.ToString() + !tagON);
            }
            else
            {
                bool tagON = _CurrentSetCardInView.GetTag(thisTag);
                if (tagON)
                {
                    _CurrentSetCardInView.SetTag(thisTag, false);
                }
                else
                {
                    _CurrentSetCardInView.SetTag(thisTag, true);
                }
                ImageServer.SetImage(Box, ImageType.TagIcon, thisTag.ToString() + !tagON);
            }
        }
        private void PicTagStar_Click(object sender, EventArgs e)
        {
            MarkTag(PicTagStar, TagIcon.Star);
        }
        private void PicTagSquare_Click(object sender, EventArgs e)
        {
            MarkTag(PicTagSquare, TagIcon.Square);
        }
        private void PicTagTriangle_Click(object sender, EventArgs e)
        {
            MarkTag(PicTagTriangle, TagIcon.Triangle);
        }
        private void PicTagCircle_Click(object sender, EventArgs e)
        {
            MarkTag(PicTagCircle, TagIcon.Circle);
        }


        #endregion

        #region Event Listeners Tag Filtering
        private void FilterByTag(TagIcon thisTag)
        {
            SoundServer.PlaySoundEffect(SoundEffect.Click2);

            if (_MasterCardViewMode)
            {
                List<MasterCard> filteredlist = new List<MasterCard>();

                foreach (MasterCard ThisMasterCard in _CurrentMasterCardList)
                {
                    bool TagOn = ThisMasterCard.GetTag(thisTag);
                    if (TagOn)
                    {
                        filteredlist.Add(ThisMasterCard);
                    }
                }

                _CurrentMasterCardList = filteredlist;

                //Set Flags
                _MasterCardViewMode = true;

                //Update the Card Viewer Card Page/Card Count header
                GroupCardView.Text = string.Format("PAGE: {0}  -  TAG: \"{1}\"  -  Total Cards: {2}", _CurrentCardPage, thisTag.ToString(), _CurrentMasterCardList.Count);
            }
            else
            {
                List<SetCard> filteredlist = new List<SetCard>();
                foreach (SetCard ThisSetCard in _CurrentSetCardList)
                {
                    bool TagOn = ThisSetCard.GetTag(thisTag);
                    if (TagOn)
                    {
                        filteredlist.Add(ThisSetCard);
                    }
                }
                _CurrentSetCardList = filteredlist;

                //Variants
                List<SetCard> filteredlistVariants = new List<SetCard>();
                foreach (SetCard ThisSetCard in _CurrentSetCardListVariants)
                {
                    bool TagOn = ThisSetCard.GetTag(thisTag);
                    if (TagOn)
                    {
                        filteredlist.Add(ThisSetCard);
                    }
                }
                _CurrentSetCardListVariants = filteredlistVariants;


                //Update the Card Viewer Card Page/Card Count header
                GroupCardView.Text = string.Format("PAGE: {0}  -  TAG: \"{1}\"  -  Total Cards: {2}", _CurrentCardPage, thisTag.ToString(), _CurrentSetCardList.Count);
            }

            //Set Flags
            _CurrentCardPage = 1;
            btnClear.Visible = true;

            LoadPage();
        }
        private void btnTagStar_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Star);
        }
        private void btnTagSquare_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Square);
        }
        private void btnTagTriangle_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Triangle);
        }
        private void btnTagCircle_Click(object sender, EventArgs e)
        {
            FilterByTag(TagIcon.Circle);
        }
        #endregion
    }
}