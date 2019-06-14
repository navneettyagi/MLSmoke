using NUnit.Framework;
using OpenQA.Selenium;
using Protractor;
using RelevantCodes.ExtentReports;
using SRSAutoFramework.Base;
using SRSAutoFramework.Extensions;
using SRSAutoFramework.PageObjects;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SRSAutoFramework.Steps
{
    [Binding]
    public class Login_FeatureSteps : TestBase
    {
        string userName = "ALOKA_QA_BH";
        string answer1 = "jhansi";
        string answer2 = "jhansi";
        string password = "password@2";

        [Given(@"User is on Home Page")]
        public void GivenUserIsOnHomePage()
        {
            //**Me Added
            //WebDriverExtension.WaitForPageLoad(ngDriver);

            Assert.IsTrue(DriverContext.Driver.FindElement(LoginPage.Lender_login_banner).Displayed);
            
        }

        [When(@"User enters UserName and Click Login")]
        public void WhenUserEntersUserNameAndClickLogin()
        {
            DriverContext.Driver.FindElement(LoginPage.LoginMain_txtLogin).SendKeys(userName);

            DriverContext.Driver.FindElement(LoginPage.LoginMain_btnLogin).Click();
        }
        
        [When(@"User enters correct answer for given questions and click Continue")]
        public void WhenUserEntersCorrectAnswerForGivenQuestionsAndClickContinue()
        {
            element = DriverContext.Driver.FindElements(LoginPage.MFLQuestions_Answer1);
            
            if (element.Count > 0)
            {
                Assert.IsTrue(DriverContext.Driver.FindElement(LoginPage.MFLQuestions_lblLogin).GetText().Equals(userName, StringComparison.CurrentCultureIgnoreCase));

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_Answer1).SendKeys(answer1);

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_Answer2).SendKeys(answer2);

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_RegisterComputer_Yes).Click();

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_btnContinue).Click();
                
            }
        }
        
        [When(@"User enters Password and Click SignIn")]
        public void WhenUserEntersPasswordAndClickSignIn()
        {
            Assert.IsTrue(DriverContext.Driver.FindElement(LoginPage.MFLPasswordPrompt_Image).Displayed);

            DriverContext.Driver.FindElement(LoginPage.MFLPasswordPrompt_Password).SendKeys(password);

            DriverContext.Driver.FindElement(LoginPage.MFLPasswordPrompt_btnSignIn).Click();
        }
        
        [Then(@"User's Home page will display with Welcome UserName message")]
        public void ThenUserSHomePageWillDisplayWithWelcomeUserNameMessage()
        {
            Assert.IsTrue(DriverContext.Driver.FindElement(HomePage.MainContent_lblWelcome).Displayed);
            WebElementExtension.Click(DriverContext.Driver.FindElement(HomePage.Qs_ibtnLogout));
        }
    }
}
