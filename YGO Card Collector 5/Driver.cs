//Joel Campos
//1/29/2024
//Driver Class

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public static  class Driver
    {
        public static IWebDriver ChromeDriver;

        private static string KonamiSearchPageURL = "https://www.db.yugioh-card.com/yugiohdb/card_search.action";
        private static string Prodeck_URL = "https://ygoprodeck.com/card-database/?&num=24&offset=0";

        public static List<string> Log = new List<string>();

        public static void OpenBrowser()
        {
            //this "option" will allow the browser to Maximize opun launching
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--start-maximized");
            options.AddArgument("headless");
            options.AddArgument("no-sandbox");

            ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            drv.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));

            ChromeDriver = drv;

        }
        public static void GoToURL(string url)
        {
            try
            {
                ChromeDriver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                ChromeDriver.Quit();
                OpenBrowser();
                ChromeDriver.Navigate().GoToUrl(url);
            }

        }
        public static void GoToKonamiSearchPage()
        {
            GoToURL(KonamiSearchPageURL);
        }
        public static void GoToProdeckSearchPage()
        {
            GoToURL(Prodeck_URL);
        }
        public static void CloseDriver()
        {
            ChromeDriver.Quit();           
        }
    }
}
