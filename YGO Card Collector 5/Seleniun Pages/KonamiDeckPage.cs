//Joel Campos
//3/13/2024
//KonamiDeckPage Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public class KonamiDeckPage
    {
        public static string Xpath_DeckName = "//header[@id=\"broad_title\"]//h1";
        public static string Xpath_CommentSection = "//dl[@class=\"tab_mh100\"]/dd[@class=\"text_set\"]/span[@class=\"biko\"]";
        public static string Xpath_MainDeckCardLink = "//div[@id=\"main\"]//div[@class=\"image_set\"]/a";
        public static string Xpath_ExtraDeckCardLink = "//div[@id=\"extra\"]//div[@class=\"image_set\"]/a";
        public static string Xpath_SideDeckCardLink = "//div[@id=\"side\"]//div[@class=\"image_set\"]/a";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_DeckName);
            Element.WaitUntilElementIsVisble(Xpath_MainDeckCardLink);
            Element.WaitUntilElementIsVisble(Xpath_ExtraDeckCardLink);
            Element.WaitUntilElementIsVisble(Xpath_SideDeckCardLink);
            Thread.Sleep(5000);
        }

        public static string GetDeckName()
        {
            return Element.GetText(Xpath_DeckName);
        }

        public static string GetDeckDescription()
        {
            return Element.GetText(Xpath_CommentSection);
        }

        public static List<string> GetMainDeckCardList()
        {
            List<string> list = new List<string>();

            int cardcount = Element.GetElementCount(Xpath_MainDeckCardLink);
            for (int i = 1; i <= cardcount; i++)
            {
                string cardname = Element.GetElementAttribute(Xpath_MainDeckCardLink + "[" + i + "]" + "//img", "title");
                list.Add(cardname);
            }

            return list;
        }

        public static List<string> GetExtraDeckCardList()
        {
            List<string> list = new List<string>();

            int cardcount = Element.GetElementCount(Xpath_ExtraDeckCardLink);
            for (int i = 1; i <= cardcount; i++)
            {
                string cardname = Element.GetElementAttribute(Xpath_ExtraDeckCardLink + "[" + i + "]" + "//img", "title");
                list.Add(cardname);
            }

            return list;
        }

        public static List<string> GetSideDeckCardList()
        {
            List<string> list = new List<string>();

            int cardcount = Element.GetElementCount(Xpath_SideDeckCardLink);
            for (int i = 1; i <= cardcount; i++)
            {
                string cardname = Element.GetElementAttribute(Xpath_SideDeckCardLink + "[" + i + "]" + "//img", "title");
                list.Add(cardname);
            }

            return list;
        }
    }
}
