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
        internal RmsMenuItem RMSMenuItem;
        internal string path = "/channel";
        By MainMenu => By.Id("MainMenuButton");

        By BoxOfficeMenu => By.Id($"{rmsMenu_prefix}BoxOffice");
        By BoxOfficePosMenu => By.Id($"{rmsMenu_prefix}BoxOfficePos");
        By BoxOfficeTicketSalesMenu => By.Id($"{rmsMenu_prefix}TicketSales");

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
