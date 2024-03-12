//Joel Campows
//3/12/2024 
//SetPack Class

using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public class SetPack
    {
        #region Constructors
        public SetPack(string name, string sampleCode, string sampleYear)
        {
            _name = name;
            //Extract the code prefix
            int indexofline = sampleCode.IndexOf('-');
            _prefixCode = sampleCode.Substring(0, indexofline);

            if(sampleYear == "")
            {
                _releaseYear = "9999";
            }
            else
            {
                _releaseYear = sampleYear.Substring(4);
            }
        }
        #endregion

        #region Public Methods
        public void AddCard(SetCard newCard)
        {
            if(_mainSetByCode.ContainsKey(newCard.Code)) 
            {
                //add it to the extra cards
                _extraCards.Add(newCard);
            }
            else
            {
                //add it to the main list
                _mainSetCards.Add(newCard);
                _mainSetByCode.Add(newCard.Code, newCard);
            }
        }
        public void SortByCode()
        {
            if(!_sorted)
            {
                //you want to sort both the main and extra cards
                MainCardList.Sort(new SetCard.SortByCode());
                ExtraCardList.Sort(new SetCard.SortByCode());
                _sorted = true;
            }
        }
        public int GetMainListObtainedCount()
        {
            int count = 0;
            foreach (SetCard card in _mainSetCards)
            {
                if (card.IsOwned())
                {
                    count++;
                }
            }
            return count;
        }
        public int GetExtraListObtainedCount()
        {
            int count = 0;
            foreach (SetCard card in _extraCards)
            {
                if (card.IsOwned())
                {
                    count++;
                }
            }
            return count;
        }
        #endregion

        #region Public Accessors
        public string Code { get { return _prefixCode; } }
        public List<SetCard> FullCardList
        {
            get
            {
                List<SetCard> outputlist = new List<SetCard>();

                foreach(SetCard card in MainCardList)
                {
                    outputlist.Add(card);
                }
                foreach (SetCard card in ExtraCardList)
                {
                    outputlist.Add(card);
                }
                return outputlist;
            }
        }
        public double SetMainListFloorValue
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    totals = totals + card.GetDoubleFloorPrice();
                }

                return totals;
            }
        }
        public double SetMainListMarketValue
        {
            get
            {
                double totals = 0;

                foreach(SetCard card in _mainSetCards)
                {
                    totals = totals + card.GetDoubleMarketPrice();
                }

                return totals;
            }
        }
        public double SetMainListMedianValue
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    totals = totals + card.GetDoubleMedianPrice();
                }

                return totals;
            }
        }
        public double SetMainListFloorValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    if (card.IsOwned())
                    {
                        totals = totals + card.GetDoubleFloorPrice();
                    }
                }

                return totals;
            }
        }
        public double SetMainListMarketValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    if(card.IsOwned()) 
                    {
                        totals = totals + card.GetDoubleMarketPrice();
                    }                   
                }

                return totals;
            }
        }
        public double SetMainListMedianValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    if(card.IsOwned())
                    {
                        totals = totals + card.GetDoubleMedianPrice();
                    }                  
                }

                return totals;
            }
        }
        public double SetExtraListFloorValue
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    totals = totals + card.GetDoubleFloorPrice();
                }

                return totals;
            }
        }
        public double SetExtraListMarketValue
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    totals = totals + card.GetDoubleMarketPrice();
                }

                return totals;
            }
        }
        public double SetExtraListMedianValue
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    totals = totals + card.GetDoubleMedianPrice();
                }

                return totals;
            }
        }
        public double SetExtraListFloorValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    if (card.IsOwned())
                    {
                        totals = totals + card.GetDoubleFloorPrice();
                    }
                }

                return totals;
            }
        }
        public double SetExtraListMarketValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    if (card.IsOwned())
                    {
                        totals = totals + card.GetDoubleMarketPrice();
                    }
                }

                return totals;
            }
        }
        public double SetExtraListMedianValueObtained
        {
            get
            {
                double totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    if (card.IsOwned())
                    {
                        totals = totals + card.GetDoubleMedianPrice();
                    }
                }

                return totals;
            }
        }      
        public List<SetCard> MainCardList { get { return _mainSetCards; } }
        public List<SetCard> ExtraCardList { get { return _extraCards; } }
        #endregion

        #region Private Data
        private string _name;
        private string _releaseYear;
        private string _prefixCode;
        private bool _sorted = false;
        private Dictionary<string, SetCard> _mainSetByCode = new Dictionary<string, SetCard>();
        private List<SetCard> _mainSetCards = new List<SetCard>();
        private List<SetCard> _extraCards = new List<SetCard> ();
        #endregion
    }
}
