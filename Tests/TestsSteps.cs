using System;
using TechTalk.SpecFlow;
using SupportLibraries;
using LastSearchWorkflows.Pages;
using NUnit.Framework;
using System.Net.NetworkInformation;

namespace LastSearchWorkflows
{
    [Binding]
    public class KoopSteps
    {
        HomePage homepage = new HomePage(Hooks.driverChrome);
        
        [Given(@"browser local data is cleared")]
        public void GivenBrowserLocalDataIsCleared()
        {
            Helpers.ClearChromeLocalData();
        }
        [Given(@"there is internet connection")]
        public void GivenThereIsInternetConnection()
        {
           Assert.IsTrue( NetworkInterface.GetIsNetworkAvailable() ,
                          "No internet connection");
        }

        [Given(@"funda website is opened")]
        [When(@"I go to funda homepage")]
        public void GivenFundaWebsiteIsOpened()
        {
            homepage.OpenHomeURL();
            Assert.IsTrue(homepage.IsHomepageOpen(),
                          "Homepage is not loaded");
        }
        
        [When(@"I go to funda homepage on ""(.*)"" tab")]
        [Given(@"funda website is opened on ""(.*)"" tab")]
        public void GivenFundaWebsiteIsOpenedOnTab(string tab)
        {
            homepage.OpenHomeURLonTab(tab);
            Assert.IsTrue(homepage.IsHomepageOpen(),
                          "Homepage is not loaded");
        }
        
        [When(@"I fill in ""(.*)"" search form ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIFillInSearchFormInSearchForm(
            string tab, string city, string radius,
            string fromPrice="", string toPrice="")
        {
            homepage.FillInSearchBar(tab, city, radius, fromPrice, toPrice);
        }

        [When(@"I fill in ""(.*)"" search form ""(.*)"" and ""(.*)""")]
        public void WhenIFillInSearchFormAnd(string tab, string city, string radius) {
            homepage.FillInSearchBar(tab, city, radius);
        }

        [When(@"I click Search")]
        public void WhenIClickSearch()
        {
            homepage.ClickSearch();
        }


       [Then(@"the page title will show the search result for ""(.*)""")]
        public void ThenThePageTitleWillShowTheSearchResultFor(string city)
        {
             Assert.IsTrue(
                homepage.IsSearchExecuted(city),
                "Search result is not displayed correctly."
             );
        }

        [Then(@"I see last search as ""(.*)""")]
        public void ThenISeeLastSearchAs(string lastSearchTxt)
        {
            Assert.AreEqual(
                homepage.GetLastSearchTxt(),
                lastSearchTxt,
                "Last search is not displayed correctly."
            );
        }

    }
}
