using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRSAutoFramework.Base
{
    public abstract class BasePage : TestBase
    {
        public BasePage()
        {

            PageFactory.InitElements(DriverContext.Driver, this);
        }

        public string Title()
        {
            return DriverContext.Driver.Title;
        }
    }
}
