using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UI.Test.Framework.Pages
{
    public class DashboardPage: BasePage
    {
        IWebElement dashboardTitle => Driver.FindElement(By.CssSelector(FrameworkConstants.DashboardPage.DASHBOARD_TITLE_CSS));

        public DashboardPage()
        {
            path = "/landing";
        }

        public bool IsDashboardPage()
        {
            Thread.Sleep(3000);
            return dashboardTitle.Displayed;
        }
    }
}
