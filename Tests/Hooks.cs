using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SupportLibraries;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LastSearchWorkflows
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driverChrome;
        private static string chromeDriverPath = 
            Path.Combine( Helpers.GetTestBinaryAbsolutePath() +
                          @"/../../../../Drivers");

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Helpers.KillProcess("chrome");
            ChromeOptions cOptions = new ChromeOptions();

            driverChrome = new ChromeDriver(chromeDriverPath, cOptions);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if( ScenarioContext.Current.TestError != null )
            { 
               string imagePath = Path.Combine(
                   Helpers.GetTestResultFolder(),
                   "result_"
                   + FeatureContext.Current.FeatureInfo.Title.Trim()
                   + "_"
                   + ScenarioContext.Current.ScenarioInfo.Title.Trim()
                   + ".jpeg"
           );
           Helpers.TakeScreenshot(driverChrome, imagePath);
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driverChrome.Dispose();
            Helpers.KillProcess("chromedriver");
        }
    }
}
