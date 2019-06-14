using Enigmatry.Selenium.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SRSAutoFramework.Config;
using SRSAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.Base
{
    public class ExtentReportBase
    {

        public static ExtentReports extent;
        public static ExtentTest test;

        //Getting the Project Path
        public string ProjectPath
        {
            get
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                return projectPath;
            }
        }

        //Getting the Report Path
        public string ReportName
        {
            get
            {
                string SRSEHRBuildVersion = Settings.SRSEHRBuildVersion;
                string SRSMobileBuildVersion = Settings.SRSMobileBuildVersion;
                string TestReportName = Settings.TestReportName;
                string scriptName = this.GetType().Name;
                string reportPath = ProjectPath + TestReportName + "_" + scriptName + "_EHRVersion_" + SRSEHRBuildVersion + "_MobileVersion_" + SRSMobileBuildVersion + ".html";
                return reportPath;
            }
        }

        //Generating Extent Report
        public void StartReport()
        {
            // False flag append the same report, True flag generates new fresh report & overwrites the existing report
            extent = new ExtentReports(ReportName, Settings.ReplaceExistingTestResult, DisplayOrder.OldestFirst);
            extent.AddSystemInfo("Module Name", this.GetType().Name);
            extent.AddSystemInfo("SRS EHR Version", Settings.SRSEHRBuildVersion);
            extent.AddSystemInfo("SRS Mobile Version", Settings.SRSMobileBuildVersion);
            extent.AddSystemInfo("IE Version", Settings.IEVersion);
            extent.AddSystemInfo("Firefox Version", Settings.FFVersion);
            extent.AddSystemInfo("Chrome Version", Settings.ChromeVersion);
            extent.LoadConfig(ProjectPath + "extentreport_config.xml");
        }


        public void StopReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stepname = TestContext.CurrentContext.Test.Name;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, stepname, "Test ended with " + logstatus + stacktrace + errorMessage);

            extent.EndTest(test);
            extent.Flush();

        }


        public static string TakeScreenShot()
        {
            //**Me Make comment

            try
             {
                 Screenshot ss = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();
                 string stepName = TestContext.CurrentContext.Test.Name;
                 string imagePath = Settings.ScreenShotLocation + stepName + ".jpeg";
                //**Me Make comment
                //ss.SaveAsFile(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //**Me Added
                ss.SaveAsFile(imagePath);

                return imagePath;
             }
             catch (Exception e)
             {
                 LogHelper.LogException(e);
                 throw;
             }
            
        }


        public void EmailReport()
        {
            try
            {
                if (Settings.SendEmailReport)
                {
                    SmtpClient mailClient = new SmtpClient();
                    mailClient.Port = Settings.SMTPPort;
                    mailClient.Host = Settings.SMTPHost;
                    mailClient.EnableSsl = Settings.SMTPEnableSSL;
                    mailClient.Timeout = Settings.SMTPTimeout;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = new System.Net.NetworkCredential(Settings.SMTPUserName, Settings.SMTPPassword);
                    MailMessage mail = new MailMessage(Settings.EmailFrom, Settings.EmailGroup);
                    mail.Subject = Settings.EmailSubject;
                    mail.Attachments.Add(new System.Net.Mail.Attachment(ReportName));
                    mail.Body = Settings.EmailBody;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mailClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }

        }
    }
}
