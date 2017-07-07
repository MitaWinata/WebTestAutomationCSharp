using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.PageObjects;

namespace LastSearchWorkflows.Pages
{
    public class AbstractPage
    {
        protected IWebDriver driver;
        private const string robotStr = "Robot";

        public AbstractPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(
                    this,
                    new RetryingElementLocator(
                        driver, TimeSpan.FromSeconds(10)));
        }

        public bool IsRobotVerificationExist()
        {
            return driver.Title.Contains(robotStr);
        }
    }
}
