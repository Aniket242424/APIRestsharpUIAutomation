using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.Pages
{
    class HomePage
    {
        public By homeLink = By.XPath("//a[text()='Home']");

        public By infectedText = By.XPath("//p[text()='Infected']//following-sibling::h2/span");

        public By deathNumbersText= By.XPath("//p[text()='Deaths']//following-sibling::h2/span");

        public By selectCountry = By.CssSelector(".MuiNativeSelect-root");


        public By getTabLink(string tabName)
        {
            return By.XPath("//a[text()='" + tabName + "']");
        }
    }
}
