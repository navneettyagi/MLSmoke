using NUnit.Framework;
using SRSAutoFramework.Base;
using SRSAutoFramework.Extensions;
using SRSAutoFramework.PageObjects;
using System;
using TechTalk.SpecFlow;
using RelevantCodes.ExtentReports;
using System.Threading;
using SRSAutoFramework.Helpers;

namespace SRSAutoFramework.Steps
{
    [Binding]
    public class SearchBy_FeatureSteps : TestBase
    {
        [Given(@"User Login successfully")]
        public void GivenUserLoginSuccessfully()
        {
            Utility.login("ALOKA_QA_BH", "password@2", "jhansi", "jhansi");
            Assert.IsTrue(DriverContext.Driver.FindElement(HomePage.MainContent_lblWelcome).Displayed);
            test.Log(LogStatus.Info, "Logged successfully");
        }

        [When(@"User select the Loan APP Number from the drop down")]
        public void WhenUserSelectTheLoanAPPNumberFromTheDropDown()
        {
            WebElementExtension.SelectDropDown(DriverContext.Driver.FindElement(HomePage.Qs_SearchBy), "Loan App Number");
        }
        
        [When(@"User enters valid APP number and Click Search")]
        public void WhenUserEntersValidAPPNumberAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "3596");
            WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Headerbutton_search));
            Thread.Sleep(20000);
            WebDriverExtension.WaitForPageLoad(DriverContext.Driver);
        }
        
        [When(@"User enters invalid APP number and Click Search")]
        public void WhenUserEntersInvalidAPPNumberAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "9680");
            
        }

        [When(@"User select the First Name from the drop down")]
        public void WhenUserSelectTheFirstNameFromTheDropDown()
        {
            WebElementExtension.SelectDropDown(DriverContext.Driver.FindElement(HomePage.Qs_SearchBy), "First Name");
        }
        
        [When(@"User enters valid first name and Click Search")]
        public void WhenUserEntersValidFirstNameAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "MARISOL");
            WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Headerbutton_search));
        }
        
        [When(@"User enters invalid first name and Click Search")]
        public void WhenUserEntersInvalidFirstNameAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "INVALID");
            WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Headerbutton_search));
        }
        
        [When(@"User select the Last Name from the drop down")]
        public void WhenUserSelectTheLastNameFromTheDropDown()
        {
            WebElementExtension.SelectDropDown(DriverContext.Driver.FindElement(HomePage.Qs_SearchBy), "Last Name");

        }

        [When(@"User enters valid lasst name and Click Search")]
        public void WhenUserEntersValidLasstNameAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "TESTCASE");
            WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Headerbutton_search));

        }

        [When(@"User enters invalid last name and Click Search")]
        public void WhenUserEntersInvalidLastNameAndClickSearch()
        {
            WebElementExtension.EnterText(DriverContext.Driver.FindElement(HomePage.Qs_txtQuickLoanNumber), "INVALID");
            

        }

        [Then(@"Same APP number should be displayed in the loaded Application")]
        public void ThenSameAPPNumberShouldBeDisplayedInTheLoadedApplication()
        {
            WebElementExtension.AssertTagText(DriverContext.Driver.FindElement(LoanPage.Sb_LoanNumber), "3596");
        }
        
        [Then(@"Pop up should be displayed as No Results found")]
        public void ThenPopUpShouldBeDisplayedAsNoResultsFound()
        {
            PopUpHelper.AlertTextVerify(DriverContext.Driver.FindElement(HomePage.Headerbutton_search), "No results found");
            //WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Qs_ibtnLogout));
        }
        
        [Then(@"Same first name APP should be displayed in the name column of the results found")]
        public void ThenSameFirstNameAPPShouldBeDisplayedInTheNameColumnOfTheResultsFound()
        {
            WebElementExtension.AssertTagText(DriverContext.Driver.FindElement(LoanPage.Sa_FName), "MARISOL");
        }

        [Then(@"Same last name APP should be displayed in the name column of the results found")]
        public void ThenSameLastNameAPPShouldBeDisplayedInTheNameColumnOfTheResultsFound()
        {
            WebElementExtension.AssertTagText(DriverContext.Driver.FindElement(LoanPage.Sa_LName), "TESTCASE");
        }
    }
}
