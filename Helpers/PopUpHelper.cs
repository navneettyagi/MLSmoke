using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SRSAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace SRSAutoFramework.Helpers
{
    
    public static class PopUpHelper
    {           
            public static void DismissAlert(this IWebElement element)
            {
                element.Click();
                var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
                IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                if (alert != null)
                {
                    DriverContext.Driver.SwitchTo().Alert();
                    Console.WriteLine(alert.Text);
                    Thread.Sleep(3000);
                    alert.Dismiss();
                }
                
            }

            public static void AcceptAlert(this IWebElement element)
            {
                element.Click();
                var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
                IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                if (alert != null)
                {
                    DriverContext.Driver.SwitchTo().Alert();
                    Console.WriteLine(alert.Text);
                    Thread.Sleep(3000);
                    alert.Accept();
                }                               

            }

            public static void ClosePopUp(this IWebElement element)
            {
            // Get the current window handle so you can switch back later.
            string currentHandle = DriverContext.Driver.CurrentWindowHandle;

            // Find the element that triggers the popup when clicked on.
             element = DriverContext.Driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']"));

            // The Click method of the PopupWindowFinder class will click
            // the desired element, wait for the popup to appear, and return
            // the window handle to the popped-up browser window. Note that
            // you still need to switch to the window to manipulate the page
            // displayed by the popup window.
            PopupWindowFinder finder = new PopupWindowFinder(DriverContext.Driver);
            string popupWindowHandle = finder.Click(element);

            DriverContext.Driver.SwitchTo().Window(popupWindowHandle);

            // Do whatever you need to on the popup browser, then...
            DriverContext.Driver.Close();
            DriverContext.Driver.SwitchTo().Window(currentHandle);

             }

        public static void AlertTextVerify(this IWebElement element, string text)
        {
            Console.WriteLine("Alert Pop Up InSide:");
            element.Click();
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                DriverContext.Driver.SwitchTo().Alert();
                Thread.Sleep(2000);
                Console.WriteLine("Text: " + alert.Text);
                Assert.IsTrue(alert.Text.Contains(text));
                alert.Accept();
            }
            
        }

        public static void isDialogPresent(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            if (alert != null)
            {
                DriverContext.Driver.SwitchTo().Alert();
                alert.Accept();
            }
           
        }


    }

}


