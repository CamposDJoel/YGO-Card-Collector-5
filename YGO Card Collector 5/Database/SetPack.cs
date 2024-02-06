using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public class SetPack
    {
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
        public int SetMainListMarketValue
        {
            get
            {
                int totals = 0;

                foreach(SetCard card in _mainSetCards)
                {
                    totals = totals + (int)card.GetDoubleMarketPrice();
                }

                return totals;
            }
        }
        public int SetMainListMedianValue
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    totals = totals + (int)card.GetDoubleMedianPrice();
                }

                return totals;
            }
        }
        public int SetMainListMarketValueObtained
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    if(card.Obtained) 
                    {
                        totals = totals + (int)card.GetDoubleMarketPrice();
                    }                   
                }

                return totals;
            }
        }
        public int SetMainListMedianValueObtained
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _mainSetCards)
                {
                    if(card.Obtained)
                    {
                        totals = totals + (int)card.GetDoubleMedianPrice();
                    }                  
                }

                return totals;
            }
        }
        public int SetExtraListMarketValue
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    totals = totals + (int)card.GetDoubleMarketPrice();
                }

                return totals;
            }
        }
        public int SetExtraListMedianValue
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    totals = totals + (int)card.GetDoubleMedianPrice();
                }

                return totals;
            }
        }
        public int SetExtraListMarketValueObtained
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    if (card.Obtained)
                    {
                        totals = totals + (int)card.GetDoubleMarketPrice();
                    }
                }

                return totals;
            }
        }
        public int SetExtraListMedianValueObtained
        {
            get
            {
                int totals = 0;

                foreach (SetCard card in _extraCards)
                {
                    if (card.Obtained)
                    {
                        totals = totals + (int)card.GetDoubleMedianPrice();
                    }
                }

                return totals;
            }
        }

        public List<SetCard> MainCardList { get { return _mainSetCards; } }
        public List<SetCard> ExtraCardList { get { return _extraCards; } }

        

        private string _name;
        private string _releaseYear;
        private string _prefixCode;
        private bool _sorted = false;
        private Dictionary<string, SetCard> _mainSetByCode = new Dictionary<string, SetCard>();
        private List<SetCard> _mainSetCards = new List<SetCard>();
        private List<SetCard> _extraCards = new List<SetCard> ();
    }
}
