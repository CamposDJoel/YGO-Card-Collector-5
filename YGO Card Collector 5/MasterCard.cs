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
        public bool Obtained { get { return _Obtained; } set { _Obtained = value; } }
        public List<SetCard> SetCards { get { return _SetCards; } }
        #endregion

        #region Public Methods
        public void AddSetCard(string date, string code, string name, string rarity)
        {
            _SetCards.Add(new SetCard(date, code, name, rarity));

        }
        public void InsertSetCard(string date, string code, string name, string rarity)
        {
            _SetCards.Insert(0, new SetCard(date, code, name, rarity));
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
        public SetCard GetCardAtIndex(int index)
        {
            return _SetCards[index];
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
        private bool _Obtained = false;
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

    public class SetCard
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
        public void OverridePrices(string market, string median)
        {
            _MarketPrice = market;
            _MediamPrice = median;
        }

        #region Public Accessors
        public string ReleaseDate { get { return _ReleaseDate; } set { _ReleaseDate = value; } }
        public string Code { get { return _Code; } set { _Code = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Rarity { get { return _Rarity; } set { _Rarity = value; } }
        public string MarketPrice { get { return _MarketPrice; } set { _MarketPrice = value; } }
        public string MediamPrice { get { return _MediamPrice; } set { _MediamPrice = value; } }
        public bool Obtained { get { return _Obtained; } set { _Obtained = value; } }
        public string TCGPlayerURL { get { return _TCGPlayerURL; } set { _TCGPlayerURL = value; } }
        #endregion

        #region Internal Data
        private string _ReleaseDate = "00/00/0000";
        private string _Code = "XXXX-EN000";
        private string _Name = "Invalid";
        private string _Rarity = "Unknown";
        private string _MarketPrice = "$0.00";
        private string _MediamPrice = "$0.00";
        private bool _Obtained = false;
        private string _TCGPlayerURL = "Missing";
        #endregion
    }
}
