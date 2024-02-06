//Joel Campos
//1/29/2024
//Driver Class

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOM;
using OpenQA.Selenium.DevTools.V119.Storage;
using System;
using System.Collections.Generic;

namespace YGO_Card_Collector_5
{
    public static  class Driver
    {
        public static IWebDriver ChromeDriver;

        #region Private Data
        private static string KonamiSearchPageURL = "https://www.db.yugioh-card.com/yugiohdb/card_search.action";
        private static string Prodeck_URL = "https://ygoprodeck.com/card-database/?&num=24&offset=0";
        private static List<string> FullLog = new List<string>();
        private static List<string> UpdatesLog = new List<string>();
        private static int GoToCounter = 0;
        private static int GoToThreshold = 250;
        #endregion

        #region Browser Public Methods
        public static void OpenBrowser()
        {
            //Set the browser options [Maximazed at high reso and Headless if the setting is On)
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--start-maximized");            
            options.AddArgument("no-sandbox");
            if(SettingsData.AutomationHeadless)
            {
                options.AddArgument("headless");
            }

            ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            drv.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));

            ChromeDriver = drv;

        }
        public static void GoToURL(string url)
        {
            if(GoToCounter == GoToThreshold)
            {
                //Log.Add("[Chrome Driver Go To Threshold Reached, Reopening Driver to free memory]");
                //Dispose ChromeDriver just shut it down
                CloseDriver();
                OpenBrowser();
                GoToCounter = 0;               
            }

            ChromeDriver.Navigate().GoToUrl(url);
            GoToCounter++;

            //Go To the URL
            /*try
            {
                ChromeDriver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                ChromeDriver.Navigate().Refresh();
                throw new SystemException("Go TO URL Failed...");
            }*/

            /*
            try
            {
                ChromeDriver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                ChromeDriver.Quit();
                OpenBrowser();
                ChromeDriver.Navigate().GoToUrl(url);
            }*/

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
            ChromeDriver.Dispose();     
        }
        public static void ClearLogs()
        {
            FullLog.Clear();
            UpdatesLog.Clear();
        }
        #endregion

        #region Logs Public Methods
        public static List<string> GetFullLogs() 
        {
            return FullLog;
        }
        public static List<string> GetUpdateLogs()
        {
            return UpdatesLog;
        }
        public static void AddToFullLog(string log)
        {
            FullLog.Add(log);
        }
        public static void AddToUpdatesLog(string log)
        {
            UpdatesLog.Add(log);
        }
        #endregion
    }
}
