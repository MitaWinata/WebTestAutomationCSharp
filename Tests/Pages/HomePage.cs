using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LastSearchWorkflows.Pages
{
    public class HomePage : AbstractPage
    {
        private static string url = @"http://www.funda.nl";
        private static string homeTitle = "[funda]";

        #region pageElements
        [FindsBy(How = How.Id, Using = "autocomplete-input")]
        private IWebElement cityInput;

        [FindsBy(How = How.Id, Using = "Afstand")]
        private IWebElement distanceInput;
        private SelectElement distanceDropdownElement
        {
            get { return new SelectElement(distanceInput); }
        }

        [FindsBy(How = How.Id, 
            Using = "range-filter-selector-select-filter_fundakoopprijsvan")]
        private IWebElement fromPriceKoopInput;
        private SelectElement fromPriceKoopDropdownElement
        {
            get { return new SelectElement(fromPriceKoopInput); }
        } 
       
        [FindsBy(How = How.Id, 
             Using = "range-filter-selector-select-filter_fundakoopprijstot")]
        private IWebElement toPriceKoopInput;
        private SelectElement toPriceKoopDropdownElement
        {
            get { return new SelectElement(toPriceKoopInput); }
        }

        [FindsBy(How = How.Id, 
            Using = "range-filter-selector-select-filter_fundahuurprijsvan")]
        private IWebElement fromPriceHuurInput;
        private SelectElement fromPriceHuurDropdownElement
        {
            get { return new SelectElement(fromPriceHuurInput); }
        } 
       
        [FindsBy(How = How.Id,
             Using = "range-filter-selector-select-filter_fundahuurprijstot")]
        private IWebElement toPriceHuurInput;
        private SelectElement toPriceHuurDropdownElement
        {
            get { return new SelectElement(toPriceHuurInput); }
        }

        [FindsBy(How = How.ClassName, Using = "search-block__submit")]
        private IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "  link-alternative")]
        private IWebElement lastSearch;

        [FindsBy(How = How.Id, Using = "Country")]
        private IWebElement europaCountry;
        private SelectElement europaCountryDropdownElement {
            get { return new SelectElement(europaCountry); }
        }
        #endregion

        #region pageActions
        /// <summary>
        /// Constructor : inherit from base class
        /// </summary>
        /// <param name="driver"></param>
        public HomePage(IWebDriver driver) : base(driver) { }
        /// <summary>
        /// Open HomeURL
        /// Reload once if there is robot verification
        /// </summary>
        public void OpenHomeURL()
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
            if (IsRobotVerificationExist())
            {
                driver.Navigate().GoToUrl(url);
            }
        }
        /// <summary>
        /// Open Url on tab
        /// </summary>
        /// <param name="searchTab">tab to choose</param>
        public void OpenHomeURLonTab(string searchTab)
        {
            driver.Navigate().GoToUrl(url + "/" + searchTab);
            Thread.Sleep(3000);
            if (IsRobotVerificationExist())
            {
                driver.Navigate().GoToUrl(url + "/" + searchTab);
            }
        }
        /// <summary>
        /// Verify if homepage is opened
        /// </summary>
        /// <returns></returns>
        public bool IsHomepageOpen()
        {
            return driver.Title.Contains(homeTitle);
        }
        /// <summary>
        /// Filled in Search Bar
        /// </summary>
        /// <param name="city">city input</param>
        /// <param name="radius">km distance from city</param>
        /// <param name="fromPrice">range price min</param>
        /// <param name="toPrice">range price max</param>
        public void FillInSearchBar(
            string tab,string city,string radius,
            string fromPrice="",string toPrice= ""
           ) {
            cityInput.SendKeys(city);
            distanceDropdownElement.SelectByText(radius);
            if (!String.IsNullOrEmpty(fromPrice)){
               if(tab.Equals("Koop"))
               {
                   fromPriceKoopDropdownElement.SelectByText(fromPrice);
               }else if (tab.Equals("Huur"))
               {
                   fromPriceHuurDropdownElement.SelectByText(fromPrice);
               }
            }
            if (!String.IsNullOrEmpty(toPrice)) {
               if(tab.Equals("Koop"))
               {
                   toPriceKoopDropdownElement.SelectByText(toPrice);
               }else if (tab.Equals("Huur"))
               {
                   toPriceHuurDropdownElement.SelectByText(toPrice);
               }
            }               
        }

        /// <summary>
        /// Click Search button
        /// </summary>
        public void ClickSearch()
        {
            searchButton.Click();
            Thread.Sleep(5000);
        }
        /// <summary>
        /// Check is search button get executed
        /// </summary>
        /// <param name="city">city to b search</param>
        /// <returns></returns>
        public bool IsSearchExecuted(string city)
        {
            return driver.Title.Contains(city);
        }
        /// <summary>
        /// Check last search functionality
        /// </summary>
        /// <param name="text">text to be verified</param>
        /// <param name="errorMessage">exception message</param>
        /// <returns></returns>
        public bool IsLastSearchOK(string text,
                                   out string errorMessage)
        {
            bool isOK = false;
            errorMessage = "";
            try
            {
                isOK = lastSearch.Equals(text);
            }
            catch(Exception e)
            {
                errorMessage = e.ToString(); 
                Console.WriteLine(e);
            }
            return isOK;
        }
        /// <summary>
        /// Get last search text
        /// </summary>
        /// <returns></returns>
        public string  GetLastSearchTxt()
        {
            return lastSearch.Text;
        }
        #endregion
    }
}