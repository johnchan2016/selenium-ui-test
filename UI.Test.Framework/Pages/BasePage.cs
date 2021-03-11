using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Helpers;

namespace UI.Test.Framework.Pages
{
    public class BasePage
    {
        string rmsMenu_prefix = "RmsMenuItem_";
        IWebElement MainMenu => Driver.FindElement(By.Id("MainMenuButton"));
        internal RmsMenuItem RMSMenuItem;
        internal string path = "/channel";

        IWebElement BoxOfficeMenu => Driver.FindElement(By.Id($"{rmsMenu_prefix}BoxOffice"));
        IWebElement BoxOfficePosMenu => Driver.FindElement(By.Id($"{rmsMenu_prefix}BoxOfficePos"));
        IWebElement BoxOfficeTicketSalesMenu => Driver.FindElement(By.Id($"{rmsMenu_prefix}TicketSales"));

        public BasePage()
        {
            RMSMenuItem = FileHelper.LoadJson<RmsMenuItem>(@"RmsMenuItem.json");
        }

        public string Path => path;

        public IWebDriver Driver => Browser.Driver;

        public void GoTo(string url) => Browser.GoToUrl(url);

        public void ClickTicketSalesMenu()
        {
            BoxOfficeMenu.SafeClick();
            BoxOfficePosMenu.SafeClick();
            BoxOfficeTicketSalesMenu.SafeClick();
        }
    }
}
