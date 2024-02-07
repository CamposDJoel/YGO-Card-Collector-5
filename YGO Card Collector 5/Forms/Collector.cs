//Joel Campos
//2/6/2024
//Collector Form Class

using OpenQA.Selenium.DevTools.V119.Emulation;
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
    public partial class Collector : Form
    {
        public Collector(FormLauncher mainMenuForm)
        {
            InitializeComponent();
            _MainMenuForm = mainMenuForm;
            LoadMasterCardList(CardGroup.AllCards);
            InitializeCardViewImages();
            LoadPage();
        }
        
        private void LoadMasterCardList(CardGroup CurrentGroup)
        {
            _MasterCardViewMode = true;
            _CurrentMasterCardList = Database.GroupCardListByGroupName[CurrentGroup];         
        }
        private void InitializeCardViewImages()
        {
            int imageID = 0;
            int Y_Location = 14;
            for (int x = 0; x < 5; x++)
            {
                int X_Location = 14;
                for (int y = 0; y < 9; y++)
                {
                    //Initialize the border box Image
                    Panel CardBox = new Panel();
                    GroupCardView.Controls.Add(CardBox);
                    CardBox.Location = new Point(X_Location, Y_Location);
                    CardBox.BorderStyle = BorderStyle.FixedSingle;
                    CardBox.Size = new Size(47, 60);
                    _CardPanelList.Add(CardBox);

                    //Initialize the Card Collection Icon
                    PictureBox CardIcon = new PictureBox();
                    CardBox.Controls.Add(CardIcon);
                    CardIcon.Location = new Point(1, 1);
                    CardIcon.BorderStyle = BorderStyle.FixedSingle;
                    CardIcon.Size = new Size(15, 15);
                    CardIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                    CardIcon.Tag = imageID;
                    //CardIcon.Visible = false;
                    _IconImageList.Add(CardIcon);

                    //Initialize the card Image
                    PictureBox CardImage = new PictureBox();
                    CardBox.Controls.Add(CardImage);
                    CardImage.Location = new Point(1, 1);
                    CardImage.BorderStyle = BorderStyle.FixedSingle;
                    CardImage.Size = new Size(43, 56);
                    CardImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    CardImage.Tag = imageID;
                    CardImage.Click += new EventHandler(this.Image_click);
                    _CardImageList.Add(CardImage);

                    //Initialize the Rarity Icon
                    PictureBox CardRarity = new PictureBox();
                    CardBox.Controls.Add(CardRarity);
                    CardRarity.Location = new Point(1, 42);
                    CardRarity.BorderStyle = BorderStyle.FixedSingle;
                    CardRarity.Size = new Size(43, 15);
                    CardRarity.SizeMode = PictureBoxSizeMode.StretchImage;
                    CardRarity.Visible = true;
                    CardRarity.BringToFront();
                    _CardRaritiesList.Add(CardRarity);

                    X_Location += 47;
                    imageID++;
                }
                Y_Location += 60;
            }

            //LoadPage();
        }
        private void LoadPage()
        {
            //Set the group info at the Card View Group Box
            int TotalCardCount = 0;
            if (_MasterCardViewMode) { TotalCardCount = _CurrentMasterCardList.Count; }
            else { TotalCardCount = _CurrentSetCardList.Count; }          
            GroupCardView.Text = string.Format("PAGE: {0}  -  CARD GROUP: {1}  -  Total Cards: {2}", _CurrentCardPage, Database.CardGroupToString(_CurrentCardGroup), TotalCardCount);

            //Start the iterator
            int PageIntialIndex = (_CurrentCardPage * 45) - 45;

            //Loop thru all the Card Images to initialize them
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

            void LoadCardImage(int x, MasterCard ThisMasterCard, SetCard ThisSetCard)
            {
                //Initalize the Card Image
                if (_YouCollectionViewON)
                {
                    //show the front/back of the card depending on the Obtained flag
                    if (_MasterCardViewMode)
                    {
                        //If the mastercard is/is not obtained
                        if (ThisMasterCard.Obtained)
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
                        if (ThisSetCard.Obtained)
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
                        if(ThisMasterCard.HasOneCardsObtained())
                        {
                            ImageServer.SetImage(_IconImageList[x], ImageType.ExclamationMark, "NONE");
                            _IconImageList[x].Visible = true;
                        }                        
                    }                    
                }
                else
                {
                    //Show the checkmark icon if setcard obtained
                    if (ThisSetCard.Obtained)
                    {
                        ImageServer.SetImage(_IconImageList[x], ImageType.CheckMark, "NONE");
                        _IconImageList[x].Visible = true;
                    }
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
        }

        private FormLauncher _MainMenuForm;
        private List<MasterCard> _CurrentMasterCardList;
        private List<SetCard> _CurrentSetCardList;
        private bool _MasterCardViewMode = true;
        private int _CurrentCardPage = 1;
        private CardGroup _CurrentCardGroup = CardGroup.AllCards;
        private bool _YouCollectionViewON = false;
        private int _PreviousCardInViewIndex = 0;

        private MasterCard _CurrentMasterCardInView;
        private SetCard _CurrentSetCardInView;

        private List<Panel> _CardPanelList = new List<Panel>();
        private List<PictureBox> _IconImageList = new List<PictureBox>();
        private List<PictureBox> _CardImageList = new List<PictureBox>();
        private List<PictureBox> _CardRaritiesList = new List<PictureBox>();

        void Image_click(object sender, EventArgs e)
        {
            //clear the card border of the previous card clicked
            _CardPanelList[_PreviousCardInViewIndex].BackColor = Color.Black;

            //Generate the Picture Box object
            PictureBox thisPictureBox = (PictureBox)sender;

            //Determine the index of this card in relation to the entire active list
            int index = ((_CurrentCardPage * 45) - 45) + (int)thisPictureBox.Tag;

            //Set the card in view border as green
            _CardPanelList[(int)thisPictureBox.Tag].BackColor = Color.LawnGreen;

            //Save this Picture Box tag as the "previous card" for the next click
            _PreviousCardInViewIndex = (int)thisPictureBox.Tag;

            //Set this Card Objects reference
            string CardID = "-1";
            string CardName = "NONE";
            if (_MasterCardViewMode)
            {
                _CurrentMasterCardInView = _CurrentMasterCardList[index];
                CardID = _CurrentMasterCardInView.ID.ToString();
                CardName = _CurrentMasterCardInView.Name;
            }
            else
            {
                _CurrentSetCardInView = _CurrentSetCardList[index];
                CardID = _CurrentSetCardInView.GetCardID();
                CardName = _CurrentSetCardInView.GetCardName();
            }

            //Clear the current Main Image and replace with this new card in view
            ImageServer.SetImage(PicImage, ImageType.CardImage, CardID);

            //Show the Name in the UI
            lblCardInfo_Name.Text = CardName;

            //Initialize this card's tags
            //InitializeTags(_CardObjectInView);

            //Show the rariry and prices if in set view
            if (_MasterCardViewMode)
            {
                lblRariryLabel.Visible = false;
                lblRarity.Visible = false;
                lblMarketPricelabel.Visible = false;
                lblMarketPrice.Visible = false;
                lblMedianPricelabel.Visible = false;
                lblMedianPrice.Visible = false;
                lblCodelabel.Visible = false;
                lblCode.Visible = false;
            }
            else
            {
                lblRariryLabel.Visible = true;
                lblRarity.Visible = true;
                lblRarity.Text = _CurrentSetCardInView.Rarity;
                switch (_CurrentSetCardInView.Rarity)
                {
                    case "Common": lblRarity.ForeColor = Color.White; break;
                    case "Rare": lblRarity.ForeColor = Color.PaleGreen; break;
                    case "Ultra Rare": lblRarity.ForeColor = Color.Moccasin; break;
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
                    case "Prismatic Secret Rare": lblRarity.ForeColor = Color.Plum; break;
                    case "Ultra Rare (Pharaoh's Rare)": lblRarity.ForeColor = Color.DarkRed; break;
                    default: lblRarity.ForeColor = Color.White; break;
                }


                lblMarketPricelabel.Visible = true;
                lblMarketPrice.Visible = true;
                lblMarketPrice.Text = _CurrentSetCardInView.MarketPrice;
                if (_CurrentSetCardInView.GetDoubleMarketPrice() < 1)
                {
                    lblMarketPrice.ForeColor = Color.White;
                }
                else if (_CurrentSetCardInView.GetDoubleMarketPrice() < 5)
                {
                    lblMarketPrice.ForeColor = Color.LightGreen;
                }
                else if (_CurrentSetCardInView.GetDoubleMarketPrice() < 50)
                {
                    lblMarketPrice.ForeColor = Color.HotPink;
                }
                else
                {
                    lblMarketPrice.ForeColor = Color.Gold;
                }
                lblMedianPricelabel.Visible = true;
                lblMedianPrice.Visible = true;
                lblMedianPrice.Text = _CurrentSetCardInView.MediamPrice;
                if (_CurrentSetCardInView.GetDoubleMedianPrice() < 1)
                {
                    lblMedianPrice.ForeColor = Color.White;
                }
                else if (_CurrentSetCardInView.GetDoubleMedianPrice() < 5)
                {
                    lblMedianPrice.ForeColor = Color.LightGreen;
                }
                else if (_CurrentSetCardInView.GetDoubleMedianPrice() < 50)
                {
                    lblMedianPrice.ForeColor = Color.HotPink;
                }
                else
                {
                    lblMedianPrice.ForeColor = Color.Gold;
                }
                lblCodelabel.Visible = true;
                lblCode.Visible = true;
                lblCode.Text = _CurrentSetCardInView.Code;
            }

            //Show the PRODECK and TCG Links buttons if availablelblProdeckLink.Visible = true;
            lblProdeckLink.Visible = false;
            lblTCGLink.Visible = false;
            if (_MasterCardViewMode)
            {
                if(_CurrentMasterCardInView.HasProDeckURL()) 
                {
                    lblProdeckLink.Visible = true;
                }
            }
            else
            {
               if(_CurrentSetCardInView.MasterCardHasProdeckURL()) 
               {
                    lblProdeckLink.Visible = true;
               }

               if(_CurrentSetCardInView.HasTCGURL())
                {
                    lblTCGLink.Visible = true;
                }
            }
        }

        #region Event Listeners (Links Button Labels)
        private void lblKonamiLink_Click(object sender, EventArgs e)
        {
            if(_MasterCardViewMode)
            {
                Tools.LaunchURLIntoBrowser(_CurrentMasterCardInView.KonamiURL);
            }
            else
            {
                Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.GetKonamiDBURL());
            }
            
        }
        private void lblProdeckLink_Click(object sender, EventArgs e)
        {
            if (_MasterCardViewMode)
            {
                Tools.LaunchURLIntoBrowser(_CurrentMasterCardInView.ProdeckURL);
            }
            else
            {
                Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.GetProdeckURL());
            }
        }
        private void lblTCGLink_Click(object sender, EventArgs e)
        {
            Tools.LaunchURLIntoBrowser(_CurrentSetCardInView.TCGPlayerURL);
        }
        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            Dispose();
            _MainMenuForm.Show();
        }
    }
}
