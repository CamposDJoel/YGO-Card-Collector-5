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

        

        private string _name;
        private string _releaseYear;
        private string _prefixCode;
        private Dictionary<string, SetCard> _mainSetByCode = new Dictionary<string, SetCard>();
        private List<SetCard> _mainSetCards = new List<SetCard>();
        private List<SetCard> _extraCards = new List<SetCard> ();
    }
}
