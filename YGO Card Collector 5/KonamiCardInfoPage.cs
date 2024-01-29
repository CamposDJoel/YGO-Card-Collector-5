using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class KonamiCardInfoPage
    {
        public static string Xpath_CardNameBanner = "//div[@id=\"cardname\"]/h1";
        public static string Xpath_SetsContainer = "//div[@id=\"update_list\"]";
        public static string Xpath_SetsRows = "//div[@id=\"update_list\"]/div[2]/div[@class='t_row']";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_CardNameBanner);
            Element.WaitUntilElementIsVisble(Xpath_SetsContainer);
        }

        //base info getters

        //"Specie" more like Monster/Spell/Trap type ex. "Warrior/Fusion/Effect"
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
            return Element.GetText("//div[@id=\"CardTextSet\"]/div[@class=\"CardText\"][1]/div[@class=\"frame imgset\"]/div[2]/span[2]");
        }
        public static string GetAttack()
        {
            return Element.GetText("//div[@id=\"CardTextSet\"]/div[@class=\"CardText\"][1]/div[2]/div[1]/span[2]");
        }
        public static string GetDefense()
        {
            return Element.GetText("//div[@id=\"CardTextSet\"]/div[@class=\"CardText\"][1]/div[2]/div[2]/span[2]");
        }
        public static string GetAttribute()
        {
            return Element.GetText("//div[@id=\"CardTextSet\"]/div[@class=\"CardText\"][1]/div[1]/div[1]/span[2]");
        }
        public static string GetPendulum()
        {
            string pendulum = "0";

            if (Element.ElementExist("//span[contains(text(), \"Pendulum Scale\")]"))
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
            return Element.GetText("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row\"][" + index + "]//div[@class=\"card_number\"]");
        }
        public static string GetSetName(int index)
        {
            return Element.GetText("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row\"][" + index + "]//div[@class=\"pack_name flex_1\"]");
        }
        public static string GetRarity(int index)
        {
            //return Element.GetText("//div[@id=\"update_list\"]/div[@class=\"t_body\"]/div[" + index + "]//span");

            bool HasNonCommonLabel = Element.ElementExist("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row\"][" + index + "]//div[3]/div");

            if (HasNonCommonLabel)
            {
                string attribute = Element.GetElementAttribute("//div[@id=\"update_list\"]//div[@class=\"t_body\"]/div[@class=\"t_row\"][" + index + "]//div[3]/div", "class");

                switch (attribute)
                {
                    case "lr_icon rid_1": return "Common";
                    case "lr_icon rid_2": return "Rare";
                    case "lr_icon rid_3": return "Super Rare";
                    case "lr_icon rid_4": return "Ultra Rare";
                    case "lr_icon rid_5": return "Secret Rare";
                    case "lr_icon rid_6": return "Ultimate Rare";
                    case "lr_icon rid_7": return "Ghost Rare";
                    case "lr_icon rid_8": return "Gold Rare";
                    case "lr_icon rid_9": return "Hobby";
                    case "lr_icon rid_14": return "Gold Secret";
                    case "lr_icon rid_15": return "Platinum Secret Rare";
                    case "lr_icon rid_16": return "COLLECTOR'S RARE";
                    case "lr_icon rid_17": return "Platinum Rare";
                    case "lr_icon rid_18": return "Starfoil";
                    case "lr_icon rid_19": return "Mosaic Rare";
                    case "lr_icon rid_20": return "Shattefoil";
                    case "lr_icon rid_36": return "Prismatic Secret Rare";
                    case "lr_icon rid_37": return "10000 SECRET RARE";
                    case "lr_icon rid_38": return "Ultra Rare (Pharaoh's Rare)";
                    case "lr_icon rid_51": return "Quarter Century Secret Rare";
                    case "lr_icon rid_44": return "Ultra Rare (Pharaoh's Rare)";
                    case "lr_icon rid_45": return "Ultra Rare（Hobby League Version)";
                    case "lr_icon rid_46": return "Ultra Rare (Duelist Saga Version)";
                    case "lr_icon rid_47": return "Starlight Rare";
                    default: return "?";
                }
            }
            else
            {
                return "Common";
            }
        }
    }
}
