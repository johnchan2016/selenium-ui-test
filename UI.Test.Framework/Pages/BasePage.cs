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
        internal IEnumerable<RmsMenuItem> rmsMenuItems;
        internal string path = "/channel";
        By MainMenu => By.Id("MainMenuButton");
        internal By LoadingIndicator => By.ClassName("mat-progress-spinner");

        public BasePage()
        {
            rmsMenuItems = FileHelper.LoadJsonToList<RmsMenuItem>($@"{AppDomain.CurrentDomain.BaseDirectory}\RmsMenuItem.json");
        }

        public string Path => path;

        public IWebDriver Driver => Browser.Driver;

        public void GoTo(string url) => Browser.GoToUrl(url);

        public void ClickTargetMenu(string targetMenuItem)
        {
            var menuItemNames = rmsMenuItems.GetRmsMenuItems(targetMenuItem, null);

            MainMenu.SafeClick();

            foreach (var name in menuItemNames)
            {
                By menuItemBy = By.Id($"{rmsMenu_prefix}{name}");
                menuItemBy.ScrollAndClick();                
            }
        }
    }
}
