using SRSAutoFramework.Config;
using SRSAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SRSAutoFramework.Base
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public static ExtentReportBase objExtentReportBase = new ExtentReportBase();
        public static TestBase objTestBase = new TestBase();

        [BeforeTestRun]
        public static void InitialSetUp()
        {
            objExtentReportBase.StartReport();
            LogHelper.CreateLogFile("ABC");
            objTestBase.StartTestExecution("IE");
            objTestBase.NavigateToURL();

            //ngDriver = new NgWebDriver(DriverContext.Driver);
            //ngDriver.IgnoreSynchronization = true;

            objTestBase.MaximizeBrowser();
        }

        [BeforeScenario]
        public void createTestSetUp()
        {
            var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            var scrnarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            test = extent.StartTest(scrnarioTitle + "_" + "IE");
        }


        [AfterScenario]
        public void cleanUpTest()
        {
            StopReport();
        }


        [AfterTestRun]
        public static void Teardown()
        {
            DriverContext.Driver.Close();
        }

    }
}
