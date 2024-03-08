//Joel Campos
//3/8/2024
//Deck Class

using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public class Deck
    {
        #region Constructors
        public Deck()
        {
            
        }
        public Deck(int id, string name, string description, List<string> mainDeckCardList, List<string> extraDeckCardList, List<string> sideDeckCardList)
        {
            _Id = id;
            _Name = name;
            _Description = description;
            _MainDeckCardList = mainDeckCardList;
            _ExtraDeckCardList = extraDeckCardList;
            _SideDeckCardList = sideDeckCardList;
        }
        public Deck(int id, string name, string description)
        {
            _Id = id;
            _Name = name;
            _Description = description;
        }
        #endregion

        public List<MasterCard> GetMainDeckMasterCardList()
        {
            List<MasterCard> output = new List<MasterCard> ();
            foreach(string cardname in _MainDeckCardList) 
            {
                output.Add(Database.MasterCardByName[cardname]);
            }
            return output;
        }
        public List<MasterCard> GetExtraDeckMasterCardList()
        {
            List<MasterCard> output = new List<MasterCard>();
            foreach (string cardname in _ExtraDeckCardList)
            {
                output.Add(Database.MasterCardByName[cardname]);
            }
            return output;
        }
        public List<MasterCard> GetSideDeckMasterCardList()
        {
            List<MasterCard> output = new List<MasterCard>();
            foreach (string cardname in _SideDeckCardList)
            {
                output.Add(Database.MasterCardByName[cardname]);
            }
            return output;
        }
        public void AddMainDeckCard(string cardname)
        {
            _MainDeckCardList.Add(cardname);
        }
        public void AddExtraDeckCard(string cardname)
        {
            _ExtraDeckCardList.Add(cardname);
        }
        public void AddSideDeckCard(string cardname)
        {
            _SideDeckCardList.Add(cardname);
        }
        public void RemoveFromMainDeck(int index)
        {
            _MainDeckCardList.RemoveAt(index);
        }
        public void RemoveFromExtraDeck(int index)
        {
            _ExtraDeckCardList.RemoveAt(index);
        }
        public void RemoveFromSideDeck(int index)
        {
            _SideDeckCardList.RemoveAt(index);
        }

        #region Public Accessors
        public int ID { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public List<string> MainDeck { get { return _MainDeckCardList; } set { _MainDeckCardList = value; } }
        public List<string> ExtraDeck { get { return _ExtraDeckCardList; } set { _ExtraDeckCardList = value; } }
        public List<string> SideDeck { get { return _SideDeckCardList; } set { _SideDeckCardList = value; } }
        #endregion

        #region Private Data
        private int _Id;
        private string _Name;
        private string _Description;
        private List<string> _MainDeckCardList = new List<string>();
        private List<string> _ExtraDeckCardList = new List<string> ();
        private List<string> _SideDeckCardList = new List<string>();
        #endregion
    }
}
