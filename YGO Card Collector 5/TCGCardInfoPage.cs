using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static  class TCGCardInfoPage
    {
        public static string Xpath_CardNameBanner = "//h1[@class=\"product-details__name\"]";
        public static string Xpath_ProductDetailsContainer = "//div[@class=\"product__item-details__description\"]";
        public static string Xpath_PricesHeader = "//tr[@class=\"price-points__header\"]";

        public static string Xpath_Code = "//ul[@class=\"product__item-details__attributes\"]/li[1]//span";
        public static string Xpath_Rarity = "//ul[@class=\"product__item-details__attributes\"]/li[2]//span";
        public static string Xpath_MarketPrice = "//section[@class=\"price-points price-guide__points\"]/table/tr[2]/td[2]/span";
        public static string Xpath_MediamPrice = "//section[@class=\"price-points price-guide__points\"]/table/tr[4]/td[2]/span";
        public static string Xpath_ReadMore = "//div[@class=\"product__item-details__toggle masked\"]";

        public static string Xpath_InvalidPage = "//span[.='Sorry but that page does not exist on our site!']";
        public static string Xpath_404Page = "//h1[.=' Sorry, we couldn’t find that page. ']";

        public static bool WaitUntilPageIsLoaded()
        {
            try
            {
                //Element.WaitUntilElementIsVisble(Xpath_CardNameBanner);
                //Element.WaitUntilElementIsVisble(Xpath_ProductDetailsContainer);
                Element.WaitUntilElementIsVisble(Xpath_PricesHeader);

                
                //Click 
                try
                {
                    if(Element.ElementExist(Xpath_ReadMore))
                    {
                        Element.ClickByXpath(Xpath_ReadMore);
                        Tools.WaitNSeconds(1000);
                    }                   
                }
                catch(Exception)
                {
                    //DO nothing
                }          
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsAValidPage()
        {
            bool badpage = Element.ElementExist(Xpath_InvalidPage) || Element.ElementExist(Xpath_404Page);
            return !badpage;
        }

        public static string GetCode()
        {
            return Element.GetText(Xpath_Code);
        }
        public static string GetRarity()
        {
            return Element.GetText(Xpath_Rarity);
        }
        public static string GetMarketPrice()
        {
            string price = Element.GetText(Xpath_MarketPrice);
            if (price == "-" || price == "") { price = "$0.00"; }
            return price;
        }
        public static string GetMediamPrice()
        {
            string price = Element.GetText(Xpath_MediamPrice);
            if (price == "-" || price == "") { price = "$0.00"; }
            return price;
        }
    }
}
