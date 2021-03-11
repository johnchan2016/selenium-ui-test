using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Components
{
    public class BaseComponent
    {
        public IWebDriver Driver => Browser.Driver;
    }
}
