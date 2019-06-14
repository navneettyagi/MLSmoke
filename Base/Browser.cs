using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }


       // public BrowserType Type { get; set; }

       // public void GoToUrl(string url)
        //{
          //  DriverContext.Driver.Url = url;
        //}

    }

    public enum BrowserType
    {
        IE,
        Firefox,
        Chrome,
        Safari,
        Edge,
        Opera
    }

    
}
