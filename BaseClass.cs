using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Enigmatry.Selenium.Tools.Attributes;
using OpenQA.Selenium.Firefox;
using SRSAutoFramework.Base;
using Protractor;
using SRSAutoFramework.Extensions;
using RelevantCodes.ExtentReports;

namespace Enigmatry.Selenium.Tools
{
    
    [TestFixture]
    public class SampleTest : TestBase
    {
        string userName = "ALOKA_QA_BH";
        string answer1 = "jhansi";
        string answer2 = "jhansi";
        string password = "password@2";

        [OneTimeSetUp]
        public void InitialSetUp()
        {
            StartReport();
            StartTestExecution("IE");
        }
        
        [SetUp]
         public void TestSetUp()
        {
            var testname = TestContext.CurrentContext.Test.Name;
            test = extent.StartTest(testname + "_" + "IE");
            
        }

         /*[Test]
         public void LaunchUrl()
         {
            NavigateToURL();
            ngDriver = new NgWebDriver(DriverContext.Driver);
            ngDriver.IgnoreSynchronization = true;
            MaximizeBrowser();
            test.Log(LogStatus.Info, "Browser Opened");
            
            //**Me Added
            WebDriverExtension.WaitForPageLoad(ngDriver);

            Assert.IsTrue(ngDriver.FindElement(By.XPath(".//*[@src='/images/lender_login_banner.jpg']")).Displayed);
        }

        [Test]
        public void Login()
        {
            ngDriver.FindElement(By.Id("ctl00_bc_LoginMain_txtLogin")).SendKeys(userName);
            test.Log(LogStatus.Info, "User name entered");

            ngDriver.FindElement(By.Id("ctl00_bc_LoginMain_btnLogin")).Click();

            IReadOnlyCollection<IWebElement> element = ngDriver.FindElements(By.Id("ctl00_bc_MFLQuestions_Answer1"));

            if (element.Count>0)
            {

                Assert.IsTrue(ngDriver.FindElement(By.Id("ctl00_bc_MFLQuestions_lblLogin")).GetText().Equals(userName, StringComparison.CurrentCultureIgnoreCase));

                ngDriver.FindElement(By.Id("ctl00_bc_MFLQuestions_Answer1")).SendKeys(answer1);

                ngDriver.FindElement(By.Id("ctl00_bc_MFLQuestions_Answer2")).SendKeys(answer2);

                ngDriver.FindElement(By.Id("ctl00_bc_MFLQuestions_RegisterComputer_0")).Click();

                ngDriver.FindElement(By.Id("ctl00_bc_MFLQuestions_btnContinue")).Click();
            }

            Assert.IsTrue(ngDriver.FindElement(By.Id("ctl00_bc_MFLPasswordPrompt_Image")).Displayed);

            ngDriver.FindElement(By.Id("ctl00_bc_MFLPasswordPrompt_Password")).SendKeys(password);

            ngDriver.FindElement(By.Id("ctl00_bc_MFLPasswordPrompt_btnSignIn")).Click();

            Assert.IsTrue(ngDriver.FindElement(By.Id("ctl00_MainContent_lblWelcome")).Displayed);


        }*/

        [TearDown]
        public void cleanUp()
        {
            StopReport();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DriverContext.Driver.Close();
        }

        
    }



    //**Me Make comment
    //**Me Added

    
}
