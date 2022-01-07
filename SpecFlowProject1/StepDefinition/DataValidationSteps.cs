using NUnit.Framework;
using SpecFlowProject1.API;
using SpecFlowProject1.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinition
{
    [Binding]
    public class DataValidationSteps
    {
        string url = "https://aniket242424.github.io/Corona-Virus-Live-Data/";
        static string actualInfected = "";
        static string expectedInfected = "";

        static string actualDeaths = "";
        static string expectedDeaths = "";


        Utils utils;
        APIDataUtil aPIDataUtil;
        public DataValidationSteps()
        {
            utils = new Utils();
            aPIDataUtil = new APIDataUtil();
        }

        [Given(@"I open Covid live data WebApp")]
        public void GivenIOpenCovidLiveDataWebApp()
        {
            utils.Navigate(url);
        }

        [When(@"I click on '(.*)' Tab")]
        public void WhenIClickOnTab(string tabName)
        {
            utils.ClickTab(tabName);
        }


        [When(@"get request is made to api for '(.*)' cases")]
        public void WhenGetRequestIsMadeToApiFor(string caseType)
        {
            switch (caseType)
            {
                case "Infected":
                    expectedInfected = aPIDataUtil.GetInfectedCases();
                    actualInfected = utils.getInfectedNumbers().Replace(",", "");
                    break;
                case "Deaths":
                    expectedDeaths = aPIDataUtil.GetDeathsCases();
                    actualDeaths = utils.getDeathsNumbers().Replace(",", "");
                    break;

            }

        }



        [Then(@"the '(.*)' cases data from UI is same as from API")]
        public void ThenTheCasesDataFromUIIsSameAsFromAPI(string caseType)
        {
            switch (caseType)
            {
                case "Infected":
                    Assert.AreEqual(expectedInfected, actualInfected);
                    break;
                case "Deaths":
                    Assert.AreEqual(expectedDeaths, actualDeaths);
                    break;
            }
            utils.CloseDriver();
        }

        [When(@"I select ""(.*)"" from dropdown")]
        public void WhenISelectFromDropdown(string country)
        {
            utils.SelectCountry(country);
        }


        [Then(@"the '(.*)' cases data of ""(.*)"" from UI is same as from API")]
        public void ThenTheCasesDataOfFromUIIsSameAsFromAPI(string caseType, string country)
        {

            switch (caseType)
            {
                case "Infected":
                    expectedInfected = aPIDataUtil.GetCountryWiseInfectedCases(country);
                    actualInfected = utils.getInfectedNumbers().Replace(",", "");
                    Assert.AreEqual(expectedInfected, actualInfected);
                    break;
            }
            utils.CloseDriver();

        }


    }
}
