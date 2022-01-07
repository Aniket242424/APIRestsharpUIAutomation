using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace SpecFlowProject1.Utility
{
    class WaitMethods : Base
    {
       

        public static IWebElement NGFIndElement(By by, int timeout = 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return result;
        }

        
        public static bool ElementExist(By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                var element = driver.FindElement(by);
                return element != null;
            }
            catch (WebDriverException)
            {
                return false;
            }

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


        public static void waitUntilPageReady()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => js.ExecuteScript("return window.document.hasHomeMounted"));
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

    }
}
