using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class KonamiSetPacksPage
    {
        //Common element IDs
        private static string Xpath_ProductsTab = "//div[@class=\"tablink\"]//span[.='Products']";
        private static string Xpath_PerksTab = "//div[@class=\"tablink\"]//span[.='Perks/Bundles']";


        private static string Xpath_BoosterPacksContainer = "//div[@id=\"list_title_1\"]";
        private static string Xpath_SpEditionBoxesContainer = "//div[@id=\"list_title_2\"]";
        private static string Xpath_StarterDecksContainer = "//div[@id=\"list_title_3\"]";
        private static string Xpath_StructureDecksContainer = "//div[@id=\"list_title_4\"]";
        private static string Xpath_TinsContainer = "//div[@id=\"list_title_5\"]";
        private static string Xpath_SpeedDuelContainer = "//div[@id=\"list_title_20\"]";
        private static string Xpath_DuelistPackContainer = "//div[@id=\"list_title_60\"]";
        private static string Xpath_DuelTerminalContainer = "//div[@id=\"list_title_70\"]";
        private static string Xpath_OtherContainer = "//div[@id=\"list_title_80\"]";

        private static string Xpath_MBCContainer = "//div[@id=\"list_title_11\"]";
        private static string Xpath_TournamentsContainer = "//div[@id=\"list_title_12\"]";
        private static string Xpath_PromosContainer = "//div[@id=\"list_title_13\"]";
        private static string Xpath_VGsContainer = "//div[@id=\"list_title_14\"]";

        private static string YearPath = "/div[@class=\"list_body\"]/div[@class=\"pack_m open\"]";
        private static string YearSetListPack = "/div[@class=\"list_body\"]/div[@class=\"toggle\"]";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_ProductsTab);
        }
        public static void ClickProductsTab()
        {
            Element.ClickByXpath(Xpath_ProductsTab);
            Element.WaitUntilElementIsVisble(Xpath_BoosterPacksContainer);
        }
        public static void ClickPerksTab()
        {
            Element.ClickByXpath(Xpath_PerksTab);
            Element.WaitUntilElementIsVisble(Xpath_MBCContainer);
        }

        public static List<string> GetGroupSetPacks(string group)
        {
            string BaseXPATH = "";
            switch(group)
            {
                case "Booster Packs": BaseXPATH = Xpath_BoosterPacksContainer; break;
                case "Sp. Edition Boxes": BaseXPATH = Xpath_SpEditionBoxesContainer; break;
                case "Starter Decks": BaseXPATH = Xpath_StarterDecksContainer; break;
                case "Structure Decks": BaseXPATH = Xpath_StructureDecksContainer; break;
                case "Tins": BaseXPATH = Xpath_TinsContainer; break;
                case "Speed Duel": BaseXPATH = Xpath_SpeedDuelContainer; break;
                case "Duelist Packs": BaseXPATH = Xpath_DuelistPackContainer; break;
                case "Duel Terminal": BaseXPATH = Xpath_DuelTerminalContainer; break;
                case "Others": BaseXPATH = Xpath_OtherContainer; break;

                case "MBC": BaseXPATH = Xpath_MBCContainer; break;
                case "Tournaments": BaseXPATH = Xpath_TournamentsContainer; break;
                case "Promos": BaseXPATH = Xpath_PromosContainer; break;
                case "Video Games": BaseXPATH = Xpath_VGsContainer; break;
            }

            List<string> output = new List<string>();

            int yearcount = Element.GetElementCount(BaseXPATH + YearPath);

            for (int x = 1; x <= yearcount; x++)
            {
                //Set the year
                string year = Element.GetText(string.Format("{0}{1}[{2}]/p", BaseXPATH, YearPath, x));

                //Extract the card list of that year
                int setsInYear = Element.GetElementCount(string.Format("{0}{1}[{2}]/div", BaseXPATH, YearSetListPack, x));
                for (int y = 1; y <= setsInYear; y++)
                {
                    string setName = Element.GetText(string.Format("{0}{1}[{2}]/div[{3}]/p", BaseXPATH, YearSetListPack, x, y));
                    if (setName != "")
                    {
                        string setPackLink = Element.GetElementAttribute(string.Format("{0}{1}[{2}]/div[{3}]/input", BaseXPATH, YearSetListPack, x, y), "value");
                        string setPackURL = "https://www.db.yugioh-card.com" + setPackLink;
                        output.Add(string.Format("{0}|{1}|{2}|{3}",group, year, setName, setPackURL));
                    }
                }
            }

            return output;
        }
    }
}
