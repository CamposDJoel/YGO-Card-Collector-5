using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YGO_Card_Collector_5
{
    public static class ProDeckCardSearchPage
    {
        public static string Xpath_SearchTextbox = "//input[@type=\"search\"]";
        public static string Xpath_FuzzySearch = "//label[@for=\"fuzzySearch\"]";
        public static string Xpath_ResultsArea = "//div[@id=\"api-area\"]";

        public static string Xpath_ResultsAmountDD = "//select[@id=\"filter-limit\"]";
        public static string Xpath_NoResultsBanner = "//h1[.='No Results Found.']";
        public static string Xpath_OneResult = "//span[@class=\"api-paging-total-cards\"][.='1']";
        public static string Xpath_SingleResultLink = "//div[@id=\"api-area-results\"]/a";

        public static void WaitUntilPageIsLoaded()
        {
            Element.WaitUntilElementIsVisble(Xpath_SearchTextbox);
            Element.WaitUntilElementIsVisble(Xpath_FuzzySearch);
            Element.WaitUntilElementIsVisble(Xpath_ResultsArea);
            Element.WaitUntilElementIsVisble(Xpath_ResultsAmountDD);
        }

        public static bool SearchCard(string name)
        {
            //Change the Results displayed to 100
            Element.ClickByXpath(Xpath_ResultsAmountDD);
            Element.ClickByXpath(Xpath_ResultsAmountDD + "/option[.='Limit 100']");
            //Element.ClickByXpath("//i[@title=\"List View\"]");

            //Disable the "fuzzy" search
            string fuzzyStatus = Element.GetElementAttribute(Xpath_FuzzySearch, "checked");
            if (fuzzyStatus == "true")
            {
                //Thread.Sleep(3000);
                Element.ClickByXpath(Xpath_FuzzySearch);
            }

            //Input the card name
            Element.InputText(Xpath_SearchTextbox, name);
            Thread.Sleep(3000);

            //Validate if the search returned results
            bool NoResults = Element.ElementExist(Xpath_NoResultsBanner);

            if (NoResults)
            {
                return false;
            }
            else
            {
                //Select the card from the result
                bool OnlyOneCardReturned = Element.ElementExist(Xpath_OneResult);

                if (OnlyOneCardReturned)
                {
                    //Click the single result link
                    Element.ClickByXpath(Xpath_SingleResultLink);
                    ProdeckCardInfoPage.WaitUntilPageIsLoaded();
                    return true;
                }
                else
                {
                    //click the result that matches the name
                    string resultXpath = "//div[@title=\"" + name + "\"]";
                    bool ResultMatchFound = Element.ElementExist(resultXpath);
                    if (ResultMatchFound)
                    {
                        Element.ScrollToView(resultXpath);
                        Element.ClickByXpath(resultXpath);


                        try
                        {
                            ProdeckCardInfoPage.WaitUntilPageIsLoaded();
                            return true;
                        }
                        catch (Exception)
                        {
                            Driver.ChromeDriver.Navigate().Refresh();
                            Element.ScrollToView(resultXpath);
                            Element.ClickByXpath(resultXpath);

                            try
                            {
                                ProdeckCardInfoPage.WaitUntilPageIsLoaded();
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //Search failed
                        return false;
                    }
                }
            }
        }
    }
}
