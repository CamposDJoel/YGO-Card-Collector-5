//Joel Campos
//1/27/2024
//Master Card/Set Card Object Classes

using System;
using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public class MasterCard: IComparable<MasterCard>
    {
        #region Constructors
        public MasterCard() { }
        public MasterCard(string name, string attribute, string species, string levelranklink, string ata, string def, string pen, string url)
        {
            _Name = name;
            _Attribute = attribute;
            _Type = species;
            _LevelRankLink = levelranklink;
            _Attack = ata;
            _Defense = def;
            _Pendulum = pen;
            _KonamiURL = url;
        }
        public MasterCard(int id, string name, string attribute, string species, string levelranklink, string ata, string def, string pen, string url, string prodeckurl, bool[] tags)
        {
            _ID = id;
            _Name = name;
            _Attribute = attribute;
            _Type = species;
            _LevelRankLink = levelranklink;
            _Attack = ata;
            _Defense = def;
            _Pendulum = pen;
            _KonamiURL = url;
            _ProdeckURL = prodeckurl;
            _Tags = tags;
        }
        #endregion

        #region Public Accessors
        public string Name { get { return _Name; } set { _Name = value; } }
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Attribute { get { return _Attribute; } set { _Attribute = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string LevelRankLink { get { return _LevelRankLink; } set { _LevelRankLink = value; } }
        public string Attack { get { return _Attack; } set { _Attack = value; } }
        public string Defense { get { return _Defense; } set { _Defense = value; } }
        public string Pendulum { get { return _Pendulum; } set { _Pendulum = value; } }
        public string ProdeckURL { get { return _ProdeckURL; } set { _ProdeckURL = value; } }
        public string KonamiURL { get { return _KonamiURL; } set { _KonamiURL = value; } }
        public List<SetCard> SetCards { get { return _SetCards; } }
        #endregion

        #region Public Methods
        public void AddSetCard(string date, string code, string name, string rarity)
        {
            _SetCards.Add(new SetCard(date, code, name, rarity));
            //this SetCard wont have a TCGPlayer URL set, add it to the list of missing URLs
            Database.CardsWithoutTCGURLs.Add(_Name);
        }
        public void InsertSetCard(string date, string code, string name, string rarity)
        {
            _SetCards.Insert(0, new SetCard(date, code, name, rarity));
            //this SetCard wont have a TCGPlayer URL set, add it to the list of missing URLs
            Database.CardsWithoutTCGURLs.Add(_Name);
        }
        public bool IsOwned()
        {
            return _Owned;
        }
        public void MarkOwnedStatus(bool status)
        {
            _Owned = status;
        }
        public bool HasProDeckURL()
        {
            return !ProdeckURLIsUnavailable() && !ProdeckURLIsMissing(); 
        }
        public bool ProdeckURLIsUnavailable()
        {
            return _ProdeckURL == "Unavailable";
        }
        public bool ProdeckURLIsMissing()
        {
            return _ProdeckURL == "Missing";
        }
        public bool HasNoMissingTCGURLs()
        {
            bool missingFound = false;
            foreach(SetCard ThisSetCard in _SetCards)
            {
               if(ThisSetCard.TCGPlayerURLIsMissing()) 
               {
                    missingFound = true; break;
               }
            }
            return !missingFound;
        }
        public bool HasNoNnavaliableTCGURLs()
        {
            bool missingFound = false;
            foreach (SetCard ThisSetCard in _SetCards)
            {
                if (ThisSetCard.TCGPlayerURLIsUnavailable())
                {
                    missingFound = true; break;
                }
            }
            return !missingFound;
        }
        public SetCard GetCardAtIndex(int index)
        {
            return _SetCards[index];
        }
        public SetCard GetCardWithCodeAndRarity(string code, string rarity)
        {
            SetCard card = null;
            foreach(SetCard setCard in _SetCards) 
            {
                if(setCard.Code == code && setCard.Rarity == rarity) { card = setCard; }
            }
            return card;
        }
        public bool[] GetTags() 
        {
            return _Tags;
        }
        public bool HasNoTagMarked()
        {
            bool nonefound = true;
            foreach(bool tagOn in _Tags)
            {
                if(tagOn)
                {
                    nonefound = false; break;
                }
            }
            return nonefound;
        }
        public bool GetTag(TagIcon tag)
        {
            if(tag == TagIcon.NONE)
            {
                return _Tags[0] == false && _Tags[1] == false && _Tags[2] == false && _Tags[3] == false;
            }
            else
            {
                return _Tags[(int)tag];
            }         
        }
        public void SetTag(TagIcon tag, bool value)
        {
            _Tags[(int)tag] = value;
            Database.UpdateTagsSaveFile(_Name);
        }
        public void OverrideTagsFromSaveFile(bool a, bool b, bool c, bool d)
        {
            _Tags[0] = a;
            _Tags[1] = b;
            _Tags[2] = c;
            _Tags[3] = d;
        }
        public bool HasAllSetCardsObtained()
        {
            bool allObtained = true;
            foreach(SetCard SetCard in _SetCards)
            {
                if(SetCard.Code != "")
                {
                    if(!SetCard.IsOwned()) 
                    {
                        allObtained = false; break;
                    }
                }
            }    
            return allObtained;
        }
        public bool HasOneCardsObtained()
        {
            bool oneObtained = false;
            foreach (SetCard SetCard in _SetCards)
            {
                if (SetCard.Code != "")
                {
                    if (SetCard.IsOwned())
                    {
                        oneObtained = true; break;
                    }
                }
            }
            return oneObtained;
        }
        public MasterCard GetCopyWithoutSets()
        {
            return new MasterCard(_ID, _Name, _Attribute, _Type, _LevelRankLink, _Attack, _Defense, _Pendulum, _KonamiURL, _ProdeckURL, _Tags);

        }
        public void OverrideSetCards(List<SetCard> NewSets)
        {
            _SetCards = NewSets;
        }
        public bool IsAExtraDeckMonster()
        {
            return _Type.Contains("Fusion") || _Type.Contains("Synchro") || _Type.Contains("Xyz") || _Type.Contains("Link");
        }
        public int GetIndexOfCheapestSetCard()
        {
            int index = -1;
            double cheapestPrice = 999999.99;

            for(int x = 0; x < SetCards.Count; x++)
            {
                SetCard thisSetCard = SetCards[x];
                double thisPrice = thisSetCard.GetDoubleFloorPrice();
                if(thisPrice != 0)
                {
                    if (thisPrice < cheapestPrice)
                    {
                        index = x;
                        cheapestPrice = thisPrice;
                    }
                }                
            }

            return index;
        }
        #endregion

        #region Internal Data
        private int _ID = -1;
        private string _Name;
        private string _Attribute;
        private string _Type;
        private string _LevelRankLink;
        private string _Attack;
        private string _Defense;
        private string _Pendulum;
        private string _KonamiURL = "Missing";
        private string _ProdeckURL = "Missing";
        private bool _Owned = false;
        private bool[] _Tags = new bool[4];
        private List<SetCard> _SetCards = new List<SetCard>();
        #endregion

        #region IComparable Methods
        public int CompareTo(MasterCard other)
        {
            return Name.CompareTo(other.Name);
        }
        public class SortByName : IComparer<MasterCard>
        {
            public int Compare(MasterCard c1, MasterCard c2)
            {
                string card1tag = c1.Name;
                string card2tag = c2.Name;
                return String.Compare(card1tag, card2tag);
            }
        }
        #endregion
    }

    public class SetCard: IComparable
    {
        #region Constructors
        public SetCard() 
        { 
        }

        public SetCard(string date, string code, string name, string rarity)
        {
            _ReleaseDate = date;
            _Code = code;
            _Name = name;
            _Rarity = rarity;
        }
        #endregion

        #region Public Methods
        public bool IsOwned()
        {
            return _Owned;
        }
        public bool HasTCGURL()
        {
            return !TCGPlayerURLIsMissing() && !TCGPlayerURLIsUnavailable();
        }
        public bool TCGPlayerURLIsMissing()
        {
            return _TCGPlayerURL == "Missing";
        }
        public bool TCGPlayerURLIsUnavailable()
        {
            return _TCGPlayerURL == "Unavailable";
        }
        public void OverridePrices(string floor, string market, string median)
        {
            _FloorPrice = floor;
            _MarketPrice = market;
            _MediamPrice = median;
        }
        public string GetCardName()
        {
            return Database.MasterCardByCode[_Code].Name;
        }
        public string GetCardID()
        {
            return Database.MasterCardByCode[_Code].ID.ToString();
        }
        public string GetKonamiDBURL()
        {
            return Database.MasterCardByCode[_Code].KonamiURL;
        }
        public string GetProdeckURL()
        {
            return Database.MasterCardByCode[_Code].ProdeckURL;
        }
        public bool MasterCardHasProdeckURL()
        {
            return Database.MasterCardByCode[_Code].HasProDeckURL();
        }
        public double GetDoubleFloorPrice()
        {
            return Tools.CovertPriceToDouble(_FloorPrice);
        }
        public double GetDoubleMarketPrice()
        {
            return Tools.CovertPriceToDouble(_MarketPrice);
        }
        public double GetDoubleMedianPrice()
        {
            return Tools.CovertPriceToDouble(_MediamPrice);
        }
        public string GetKEY()
        {
            return string.Format("{0}|{1}|{2}|{3}", _Code, _Rarity, GetCardName(), _Name);
        }
        public bool[] GetTags()
        {
            return Database.MasterCardByName[GetCardName()].GetTags();
        }
        public bool GetTag(TagIcon tag)
        {
            return Database.MasterCardByName[GetCardName()].GetTag(tag);
        }
        public void SetTag(TagIcon tag, bool value) 
        {
            Database.MasterCardByName[GetCardName()].SetTag(tag, value);
        }
        public void MarkOwnedStatus(bool newStatus)
        {
            _Owned = newStatus;

            if(_Owned) 
            {
                Database.MasterCardByCode[_Code].MarkOwnedStatus(true);
            }
            else
            {
                //Remove the MasterCard obtained flag is no setcard are obtained anymore
                if (Database.MasterCardByCode[_Code].HasOneCardsObtained())
                {
                    Database.MasterCardByCode[_Code].MarkOwnedStatus(false);
                }
            }

            //Update Save file
            Database.UpdateSaveFile(GetKEY(), _Owned);
        }
        public void FlipObtainedStatus()
        {
            if(_Owned) 
            {
                _Owned = false;
                //Remove the MasterCard obtained flag is no setcard are obtained anymore
                if(!Database.MasterCardByCode[_Code].HasOneCardsObtained())
                {
                    Database.MasterCardByCode[_Code].MarkOwnedStatus(false);
                }               
            }
            else
            {
                _Owned = true;
                //Mark the MasterCard as obtained
                Database.MasterCardByCode[_Code].MarkOwnedStatus(true);
            }
            //Update Save file
            Database.UpdateSaveFile(GetKEY(), _Owned);
        }
        public void FlipObtainedStatusNOUPDATE()
        {
            if (_Owned)
            {
                _Owned = false;
                //Remove the MasterCard obtained flag is no setcard are obtained anymore
                if (Database.MasterCardByCode[_Code].HasOneCardsObtained())
                {
                    Database.MasterCardByCode[_Code].MarkOwnedStatus(false);
                }
            }
            else
            {
                _Owned = true;
                //Mark the MasterCard as obtained
                Database.MasterCardByCode[_Code].MarkOwnedStatus(true);
            }
        }
        public bool WasReleasedBy(string year)
        {
            if(_ReleaseDate == "")
            {
                return false;
            }
            else
            {
                string releaseYear = _ReleaseDate.Split('-')[0];
                int releaseYearInInt = Convert.ToInt32(releaseYear);
                int targetYearInInt = Convert.ToInt32(year);

                return releaseYearInInt <= targetYearInInt;
            }          
        }
        #endregion

        #region Public Accessors
        public string ReleaseDate { get { return _ReleaseDate; } set { _ReleaseDate = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Rarity { get { return _Rarity; } set { _Rarity = value; } }
        public string FloorPrice { get { return _FloorPrice; } set { _FloorPrice = value; } }
        public string MarketPrice { get { return _MarketPrice; } set { _MarketPrice = value; } }
        public string MediamPrice { get { return _MediamPrice; } set { _MediamPrice = value; } }
        public string TCGPlayerURL { get { return _TCGPlayerURL; } set { _TCGPlayerURL = value; } }
        #endregion

        #region Internal Data
        private string _ReleaseDate = "00/00/0000";
        private string _Code = "XXXX-EN000";
        private string _Name = "Invalid";
        private string _Rarity = "Unknown";
        private string _FloorPrice = "$0.00";
        private string _MarketPrice = "$0.00";
        private string _MediamPrice = "$0.00";
        private bool _Owned = false;
        private string _TCGPlayerURL = "Missing";
        #endregion

        public int CompareTo(object obj)
        {
            SetCard otherPriceItem = obj as SetCard;
            return otherPriceItem._Code.CompareTo(_Code);
        }
        public class SortByFloorPrice : IComparer<SetCard>
        {
            public int Compare(SetCard c1, SetCard c2)
            {
                double card1price = c1.GetDoubleFloorPrice();
                double card2price = c2.GetDoubleFloorPrice();
                if (card1price < card2price) { return 1; }
                else if (card1price > card2price) { return -1; }
                else { return 0; }
            }
        }
        public class SortByPrice : IComparer<SetCard>
        {
            public int Compare(SetCard c1, SetCard c2)
            {
                double card1price = c1.GetDoubleMarketPrice();
                double card2price = c2.GetDoubleMarketPrice();
                if (card1price < card2price) { return 1; }
                else if (card1price > card2price) { return -1; } 
                else { return 0; }
            }
        }
        public class SortByMedianPrice : IComparer<SetCard>
        {
            public int Compare(SetCard c1, SetCard c2)
            {
                double card1price = c1.GetDoubleMedianPrice();
                double card2price = c2.GetDoubleMedianPrice();
                if (card1price < card2price) { return 1; }
                else if (card1price > card2price) { return -1; }
                else { return 0; }
            }
        }
        public class SortByCode : IComparer<SetCard>
        {
            public int Compare(SetCard c1, SetCard c2)
            {
                string card1code = c1.Code;
                string card2code = c2.Code;
                return string.Compare(card1code, card2code);
            }
        }
    }

    public enum TagIcon
    {
        Star = 0,
        Square,
        Triangle,
        Circle,
        NONE
    }
}
