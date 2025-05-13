using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YGO_Card_Collector_5
{
    public static class KonamiCardInfoPage
    {
        public static string Xpath_CardNameBanner = "//div[@id=\"cardname\"]/h1";
        public static string Xpath_SetsContainer = "//div[@id=\"update_list\"]";
        public static string Xpath_SetsRows = "//div[@id=\"update_list\"]/div[2]/div[@class='t_row ']";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_CardNameBanner);
            Element.WaitUntilElementIsVisble(Xpath_SetsContainer);
        }

        //base info getters

        //"Specie" more like Monster/Spell/Trap type ex. "Warrior/Fusion/Effect"//div[@id=\"CardTextSet\"]/div[@class=\"CardText\"]
        public static string GetSpecies()
        {
            if (IsThisPageNonMonster())
            {
                return Element.GetText("//div[@class=\"item_box t_center\"]/span[2]");
            }
            else
            {
                int speciesCount = Element.GetElementCount("//p[@class=\"species\"]/span");
                string specie = "";

                for (int i = 1; i <= speciesCount; i++)
                {
                    string speciepart = Element.GetText("//p[@class=\"species\"]/span[" + i + "]");
                    specie = specie + speciepart;
                }

                return specie;
            }
        }
        public static bool IsThisPageNonMonster()
        {
            return Element.GetElementCount("//span[@class=\"item_box_title\"]") == 1;
        }
        public static string GetLevelRankLink()
        {
            return Element.GetText("//div[@id=\"CardSet\"]//div[@class=\"CardText\"][1]/div[@class=\"frame imgset\"]/div[2]/span[2]");
        }
        public static string GetAttack()
        {
            return Element.GetText("//div[@id=\"CardSet\"]//div[@class=\"CardText\"][1]/div[2]/div[1]/span[2]");
        }
        public static string GetDefense()
        {
            return Element.GetText("//div[@id=\"CardSet\"]//div[@class=\"CardText\"][1]/div[2]/div[2]/span[2]");
        }
        public static string GetAttribute()
        {
            return Element.GetText("//div[@id=\"CardSet\"]//div[@class=\"CardText\"][1]/div[1]/div[1]/span[2]");
        }
        public static string GetPendulum()
        {
            string pendulum = "0";

            if (Element.ElementExist("//div[@class=\"CardText pen\"]//span[contains(text(), \"Pendulum Scale\")]"))
            {
                pendulum = Element.GetText("//div[@class=\"CardText pen\"]//div[@class=\"item_box t_center pen_s\"]/span[2]");
            }

            return pendulum;
        }

        //Sets info getters
        public static int GetSetsCount()
        {
            return Element.GetElementCount(Xpath_SetsRows);
        }
        public static string GetSetReleaseDate(int index)
        {
            return Element.GetText("//div[@class=\"t_body\"]/div[" + index + "]//div[@class=\"time\"]");
        }
        public static string GetSetCode(int index)
        {
            return Element.GetText("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row \"][" + index + "]//div[@class=\"card_number\"]");
        }
        public static string GetSetName(int index)
        {
            return Element.GetText("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row \"][" + index + "]//div[@class=\"pack_name flex_1\"]");
        }
        public static string GetRarity(int index)
        {
            Element.ScrollToView("//div[@id=\"update_list\"]/div[@class=\"t_body\"]/div[" + index + "]//div[@class=\"icon rarity\"]");
            Actions actions = new Actions(Driver.ChromeDriver);
            IWebElement rarityIcon = Driver.ChromeDriver.FindElement(By.XPath("//div[@id=\"update_list\"]/div[@class=\"t_body\"]/div[" + index + "]//div[@class=\"icon rarity\"]"));
            IWebElement setname = Driver.ChromeDriver.FindElement(By.XPath("//div[@id=\"update_list\"]/div[@class=\"t_body\"]/div[" + index + "]//div[@class=\"flex_1 contents \"]"));
            actions.MoveToElement(rarityIcon).Build().Perform();           

            string text = Element.GetText("//div[@id=\"update_list\"]/div[@class=\"t_body\"]/div[" + index + "]//span");

            //I need to "unhover" by hovering to a different element
            actions.MoveToElement(setname).Build().Perform();

            //div[@id="main980"]

            if (text != "")
            {
                return text;
            }
            else
            {
                return "Common";
            }
        }
    }
}
