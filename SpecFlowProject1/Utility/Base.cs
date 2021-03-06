using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.Utility
{
    class Base
    {
        public static IWebDriver driver;

        public static void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver GetDriver()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }


        public IWebDriver GetWebDriver()
        {
            return driver;
        }

    }
}
