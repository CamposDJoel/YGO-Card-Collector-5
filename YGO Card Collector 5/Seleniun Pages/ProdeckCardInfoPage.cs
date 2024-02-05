using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class ProdeckCardInfoPage
    {
        public static string Xpath_Cardimage = "//div[@class=\"card-image\"]";
        public static string Xpath_CardInfo = "//ul[@class=\"card-data-info\"]";
        public static string Xpath_TCGPricesContainer = "//div[@class=\"card-sets-tcgplayer-small\"]";
        public static string Xpath_ViewMoreLink = "//div[@class=\"card-sets-tcgplayer-small\"]//a[.='View More']";
        public static string Xpath_ViewMoreLinksContainer = "//div[@class=\"modal-body tcgplayer-modal\"]";
        public static string Xpath_PricesInPage = "//div[@class=\"card-sets-tcgplayer-small\"]/div";
        public static string Xpath_PricesInViewMore = "//div[@class=\"card-sets-tcgplayer\"]/li";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_Cardimage);
            Element.WaitUntilElementIsVisble(Xpath_CardInfo);
        }
        public static bool IsPageValid()
        {
            return Element.ElementExist(Xpath_Cardimage);
        }
        public static int GetCardID()
        {
            string cardImageURL = Element.GetElementAttribute("//img[@class=\"zoom\"]", "src");
            string id = cardImageURL.Replace(".jpg", "");
            id = id.Replace("https://images.ygoprodeck.com/images/cards/", "");
            return Convert.ToInt32(id);
        }
        public static bool PageContainsTCGPrices()
        {
            return Element.ElementExist(Xpath_TCGPricesContainer);
        }
        public static bool TCGPricesHasViewMore()
        {
            return Element.ElementExist(Xpath_ViewMoreLink);
        }
        public static List<string> GetPricesURLsFromPage()
        {
            //Get the amount of links available
            int linksAvailable = Element.GetElementCount(Xpath_PricesInPage);
           
            //Extract each link and add it to the list
            List<string> urls = new List<string>();
            for (int i = 1; i <= linksAvailable; i++)
            {
                string url = Element.GetElementAttribute("//div[@class=\"card-sets-tcgplayer-small\"]/div[" + i + "]/a", "href");
                urls.Add(url);
            }

            return urls;
        }
        public static void ClickViewMore()
        {
            Element.ScrollToView(Xpath_ViewMoreLink);
            Element.ClickByXpath(Xpath_ViewMoreLink);
            Element.WaitUntilElementIsVisble(Xpath_ViewMoreLinksContainer);
        }
        public static List<string> GetPricesURLsViewMore(string setname)
        {
            //Get the amount of links available
            int linksAvailable = Element.GetElementCount(Xpath_PricesInViewMore);

            //Test Section: Get only the urls that match the set name, if none, extract all.
            List<string> matchurls = new List<string>();
            List<string> allurls = new List<string>();
            for (int i = 1; i <= linksAvailable; i++)
            {
                string linkSetName = Element.GetText("//div[@class=\"card-sets-tcgplayer\"]/li[" + i + "]/div/a");
                string urlextracted = Element.GetElementAttribute("//div[@class=\"card-sets-tcgplayer\"]/li[" + i + "]/span/a", "href");
                if (Tools.CompareInLowerCase(setname, linkSetName))
                {
                    matchurls.Add(urlextracted);
                }
                allurls.Add(urlextracted);
            }

            if (matchurls.Count == 0)
            {
                return allurls;
            }
            else
            {
                return matchurls;
            }
        }
    }
}