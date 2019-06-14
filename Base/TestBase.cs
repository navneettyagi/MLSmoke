using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using SRSAutoFramework.Config;
using SRSAutoFramework.Extensions;
using SRSAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Protractor;

namespace SRSAutoFramework.Base
{
    public class TestBase : ExtentReportBase //UnitTestBase
    {
        public NgWebDriver ngDriver;
        public static IReadOnlyCollection<IWebElement> element;

        private static string _SnapShotFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        IEnumerable<int> _browserInstance;
        public BasePage CurrentPage { get; set; }
        public string CurrentBrowser { get; set; }

        private IWebDriver _driver { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        private void zOpenBrowser(String Browser)//we dont want user to invoke browser 
        {
            Console.WriteLine("zOpenBrowser 1");
            switch (Browser.ToUpper())//To hadle any case mistmatch
            {
                //case BrowserType.IE:
                case "IE":
                    // http://stackoverflow.com/questions/14952348/not-able-to-launch-ie-browser-using-selenium2-webdriver-with-java
                    //Please follow above instructions above to setup IE 

                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                // case BrowserType.Firefox:
                case "FIREFOX":
                    Console.WriteLine("zOpenBrowser 2");
                    DriverContext.Driver = new FirefoxDriver();
                    Console.WriteLine("zOpenBrowser 3");
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    Console.WriteLine("zOpenBrowser 4");
                    break;
                //case BrowserType.Chrome:
                case "CHROME":
                    //open Chrome in incognito mode.                    
                    //var options = new ChromeOptions();
                    //options.AddArgument("incognito");
                    //options.AddArgument("--start-maximized");
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                //case BrowserType.Safari:
                case "SAFARI":
                    DriverContext.Driver = new SafariDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                //case BrowserType.Edge:
                case "EDGE":
                    DriverContext.Driver = new EdgeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                //case BrowserType.Opera:
                case "OPERA":
                    DriverContext.Driver = new OperaDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public void TakeScreenshot(string ImageFileName)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();

                //**Me Make comment
                //ss.SaveAsFile(Settings.ScreenShotLocation + ImageFileName + "_" + _SnapShotFileName + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //**Me Added
                ss.SaveAsFile(Settings.ScreenShotLocation + ImageFileName + "_" + _SnapShotFileName + ".jpeg");
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }

        public void TestSetUp(string TestScriptName, bool useTestData = true)
        {
            try
            {
                Helpers.DataBaseHelper.ManageDBSnapshot(true);
                //StartUp(UnitTestDBName);
                string testDatafileName = string.Empty;
                if (useTestData)
                {
                    PopulateExcelData(TestScriptName);
                    StartReport();
                }
                LogHelper.CreateLogFile(TestScriptName);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }

        public void TestFinalize()
        {
            EmailReport();
            DataBaseHelper.ManageDBSnapshot(false);
        }
        public void StartTestExecution(String Browser)
        {
            try
            {
                CurrentBrowser = Browser;
                _browserInstance = zGetCurrentBrowserInstances(Browser);

                //**Me Make comment
                //var testname = TestContext.CurrentContext.Test.Name;
                //test = extent.StartTest(testname + "_" + Browser);

                zOpenBrowser(Browser);
                //test.Log(LogStatus.Info, "Browser Opened");

                //MaximizeBrowser();

                //**Me Make comment
                //DeleteAllCookies();
                //WebDriverExtension.WaitForPageLoad(DriverContext.Driver);

            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw;
            }
        }

        public void TestCleanUp()
        {
            try
            {
                DeleteAllCookies();
                // Cleanup(UnitTestDBName);
                if (DriverContext.Driver != null)
                {
                    StopReport();
                    Process[] FirefoxDriverProcesses = Process.GetProcessesByName("firefox");

                    foreach (var FirefoxDriverProcess in FirefoxDriverProcesses)
                    {
                        FirefoxDriverProcess.Kill();
                    }
                    DriverContext.Driver.Quit();


                    // zCloseBrowser(CurrentBrowser);
                }
                // DriverContext.Driver.Dispose();
                LogHelper.Write("Closed the Browser");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        private void zCloseBrowser(string browser)
        {
            IEnumerable<int> currentInstance;
            var currentBrowserInstances = zGetCurrentBrowserInstances(browser);
            if (_browserInstance != null && _browserInstance.Any())
            {
                currentInstance = currentBrowserInstances.Except(_browserInstance);
            }
            else
            {
                currentInstance = currentBrowserInstances;
            }

            foreach (int instance in currentInstance)
            {
                Process.GetProcessById(instance).Kill();
                DriverContext.Driver.Dispose();
            }
        }

        private IEnumerable<int> zGetCurrentBrowserInstances(string browser)
        {
            Console.WriteLine(browser);
            string processName = string.Empty;
            List<int> pIdList = null;
            switch (browser.ToUpper())
            {
                case "IE":
                    processName = "iexplore";
                    break;
                case "CHROME":
                    processName = "Chrome";
                    break;
                case "FIREFOX":
                    processName = "Firefox";
                    break;

            }
            if (!string.IsNullOrEmpty(processName))
            {
                Process[] processArray = Process.GetProcessesByName(processName);
                if (processArray != null && processArray.Length > 0)
                {
                    pIdList = new List<int>();
                    foreach (Process p in processArray)
                    {
                        pIdList.Add(p.Id);
                    }
                }
            }
            Console.WriteLine("pIdList:"+pIdList);
            return pIdList;
        }

        public void ClearIECache()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            DriverContext.Driver = new InternetExplorerDriver(options);
        }

        public void NavigateToURL()
        {
            string URL = "https://beta.loanspq.com/login.aspx?enc2=36aNbmudSLCCMdjJoYQn6iT9nG7GRjqBbkIAMYcy9aM";
            //**Me Make comment

            /*string AbsoluteURL = Settings.AbsoluteURL;
            string URL = Settings.AUT;
            string MachineName = System.Environment.MachineName;
            URL = "http://" + MachineName + URL;
            if ((!String.IsNullOrEmpty(AbsoluteURL)))
            {
                DriverContext.Driver.Navigate().GoToUrl(AbsoluteURL);
            }

            else
            {
                DriverContext.Driver.Navigate().GoToUrl(URL);
            }*/


            DriverContext.Driver.Navigate().GoToUrl(URL);

            //LogHelper.Write("Navigated to the URL");
        }

        public static IEnumerable<String> BrowserToRunWith()
        {

            String[] browsers = null;
            if (Settings.ExecutingBrowser == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            browsers = Settings.ExecutingBrowser.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }
        }

        public void NavigateForward()
        {
            DriverContext.Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            DriverContext.Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            DriverContext.Driver.Navigate().Refresh();
        }

        public void MaximizeBrowser()
        {
            //**Me Make comment
            DriverContext.Driver.Manage().Window.Maximize();

            //**Me Added
            //ngDriver.Manage().Window.Maximize();
        }

        public void DeleteAllCookies()
        {
            DriverContext.Driver.Manage().Cookies.DeleteAllCookies();
        }

        //Apple tab size
        public void ResizeBrowserToTabSize()
        {
            //DriverContext.Driver.Manage().Window.Size = new Size(960, 640);
            ResizeBrowser(960, 640);
        }


        public void PopulateExcelData(string testScripName)
        {
            string testDatafileName = Settings.TestDataPath + testScripName + ".xlsx";
            ExcelHelper.PopulateInCollection(testDatafileName);
        }

        public void ResizeBrowser(int width, int height)
        {
            DriverContext.Driver.Manage().Window.Size = new System.Drawing.Size(width, height);
        }

        internal class ExtentManager
        {
            private static readonly ExtentReports _instance =
                new ExtentReports("Extent.Net.html", DisplayOrder.OldestFirst);

            static ExtentManager() { }

            private ExtentManager() { }

            public static ExtentReports Instance
            {
                get
                {
                    return _instance;
                }
            }
        }
    }
}





