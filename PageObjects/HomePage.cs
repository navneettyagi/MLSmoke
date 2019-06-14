using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.PageObjects
{
    class HomePage
    {
        public static By MainContent_lblWelcome = By.Id("ctl00_MainContent_lblWelcome");

        public static By Qs_txtQuickLoanNumber = By.Id("ctl00_h_ctl00_qs_txtQuickLoanNumber");

        public static By Headerbutton_search = By.XPath(".//img[contains(@src,'/headerbutton_search.gif')]");

        public static By Qs_SearchBy = By.Id("ctl00_h_ctl00_qs_SearchBy");

        public static By Qs_ibtnLogout = By.XPath(".//*[contains(@id,'ibtnLogout')]");
    }
}
