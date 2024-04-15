using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class KonamiSetCardListPage
    {
        //Common element IDs
        private static string Xpath_TitleHeader = "//header[@id=\"broad_title\"]";
        private static string Xpath_SneakPeakMessage = "//p[@id=\"previewed\"]";
        private static string Xpath_CardRow = "//div[@id=\"card_list\"]/div/div";
        private static string Xpath_ViewAsListTab = "//div[@id=\"mode_set\"]//span[.='View as List']";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_TitleHeader);
        }

        public static void ClickViewAsList()
        {
            Element.ClickByXpath(Xpath_ViewAsListTab);
            Element.WaitUntilElementIsVisble("//div[@id=\"card_list\"]/div/div[1]//div[@class=\"card_name flex_1\"]/span");
        }

        public static bool IsThisSetASneakPeakPreview()
        {
            string text = Element.GetText(Xpath_SneakPeakMessage);
            return text.Contains("Sneak preview of selected cards");
        }
        public static bool IsthiSSetComingSoon()
        {
            return Element.ElementExist("//div[@id=\"article_body\"]/div[@class=\"no_data\"]");
        }

        public static int GetCardCount()
        {
            return Element.GetElementCount(Xpath_CardRow);
        }

        public static string GetCardName(int index)
        {
            ////div[@id="card_list"]/div/div[3]//div[@class="card_name flex_1"]/span
            string cardname = Element.GetText("//div[@id=\"card_list\"]/div/div[" + index + "]//div[@class=\"card_name flex_1\"]/span");

            //Remove the "Update from" extra part if the card contains it
            if (cardname.Contains("Updated from:"))
            {
                int indexofPa = cardname.IndexOf("(");
                cardname = cardname.Substring(0, indexofPa - 1);
            }

            return cardname;
        }
        public static string GetCardURL(int index)
        {
            ////div[@id="card_list"]/div/div[${i}]//div[@class="card_name flex_1"]//input@value
            return Element.GetElementAttribute("//div[@id=\"card_list\"]/div/div[" + index + "]//div[@class=\"card_name flex_1\"]//input", "value");
        }
    }
}
