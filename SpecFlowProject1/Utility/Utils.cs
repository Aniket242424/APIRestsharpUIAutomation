using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowProject1.Utility
{
    class Utils : Base
    {
        IJavaScriptExecutor executor;
        HomePage homePage;
        public Utils()
        {
            homePage = new HomePage();
            executor = (IJavaScriptExecutor)driver;
        }

        public void Navigate(string url)
        {
            InitializeDriver();
            driver.Navigate().GoToUrl(url);
        }

        public void ClickTab(string tabName)
        {
            JavaScriptClick(homePage.getTabLink(tabName));
        }


        public string getInfectedNumbers()
        {
            WaitForJavaScript();
            ElementClickable(homePage.infectedText);
            return driver.FindElement(homePage.infectedText).Text;
        }

        public string getDeathsNumbers()
        {
            WaitForJavaScript();
            ElementClickable(homePage.deathNumbersText);
            return driver.FindElement(homePage.deathNumbersText).Text;
        }


        public void SelectCountry(string countryName)
        {
            WaitForJavaScript();
            IWebElement element = driver.FindElement(homePage.selectCountry);
            //create select element object 
            var selectElement = new SelectElement(element);
            //select by text
            selectElement.SelectByText(countryName);

        }


        internal void JavaScriptClick(By element)
        {
           IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(element));
        }


        internal void JavaScriptClick(IWebElement element)
        {
            executor.ExecuteScript("arguments[0].click();", element);
        }



        public static bool ElementClickable(By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                var element = driver.FindElement(by);
                return element != null;
            }
            catch (WebDriverException)
            {
                return false;
            }

        }



        public static void WaitForJavaScript()
        {
            double maxWaitMills = 8000;
            double startTime = (int)(CurrentTimeMills());
            while ((int)(CurrentTimeMills()) < startTime + maxWaitMills)
            {
                string prevState = driver.PageSource;
                Thread.Sleep(100);
                if (prevState.Equals(driver.PageSource))
                {
                    return;
                }

            }
        }

        public static long CurrentTimeMills()
        {
            DateTime dt1970 = new DateTime(1970, 1, 1);
            DateTime current = DateTime.Now;//DateTime.UtcNow for unix timestamp
            TimeSpan span = current - dt1970;
            return (long)span.TotalMilliseconds;
        }



        public void CloseDriver()
        {
            driver.Close();
        }

    }
}
