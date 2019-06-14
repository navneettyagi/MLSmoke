using NUnit.Framework;
using SRSAutoFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.Base
{
    class Utility : TestBase
    {
        public static void login(string userName, string password, string answer1, string answer2)
        {
           
            DriverContext.Driver.FindElement(LoginPage.LoginMain_txtLogin).SendKeys(userName);

            DriverContext.Driver.FindElement(LoginPage.LoginMain_btnLogin).Click();

            element = DriverContext.Driver.FindElements(LoginPage.MFLQuestions_Answer1);

            if (element.Count > 0)
            {
                
                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_Answer1).SendKeys(answer1);

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_Answer2).SendKeys(answer2);

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_RegisterComputer_Yes).Click();

                DriverContext.Driver.FindElement(LoginPage.MFLQuestions_btnContinue).Click();

            }

            DriverContext.Driver.FindElement(LoginPage.MFLPasswordPrompt_Password).SendKeys(password);

            DriverContext.Driver.FindElement(LoginPage.MFLPasswordPrompt_btnSignIn).Click();

            Assert.IsTrue(DriverContext.Driver.FindElement(HomePage.MainContent_lblWelcome).Displayed);
        }
    }
}
