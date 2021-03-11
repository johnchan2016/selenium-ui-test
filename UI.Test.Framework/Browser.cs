using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework
{
    public static class Browser
    {
        private static IWebDriver _driver;
        private static int _waitTimeout = 30;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    var browserType = "chrome";

                    switch (browserType)
                    {
                        default:
                        case "chrome": // Chrome
                            ChromeOptions options = new ChromeOptions();
                            options.AddArgument("--incognito");
                            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
                            break;
                    }

                    _driver.Manage().Window.Maximize();
                }

                return _driver;
            }

            set { _driver = value; }
        }



        public static void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoaded();
        }

        public static void WaitForPageLoaded()
        {
            WaitForBusyBlock();
        }

        public static void WaitForElementVisible(IWebElement element)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => element.Displayed);
        }

        public static void WaitForElementVisible(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => driver.FindElements(by).Count > 0);
        }

        public static void WaitForElementInvisible(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => driver.FindElements(by).Count == 0);
        }

        public static bool IsDisplay(this By by)
        {
            var element = Driver.FindElement(by);
            return element.Displayed;
        }

        public static void SafeSendKey(this IWebElement element , string text)
        {
            element.SendKeys(text);
            WaitForPageLoaded();
        }

        public static void SafeSendKey(this By by, string text)
        {
            by.ScrollTo();

            var element = Driver.FindElement(by);
            element.SendKeys(text);
            WaitForPageLoaded();
        }

        public static void SafeClick(this IWebElement element)
        {

            element.Click();
            WaitForPageLoaded();
        }

        public static void SafeClick(this By by)
        {
            by.ScrollTo();

            var element = Driver.FindElement(by);
            element.Click();
            WaitForPageLoaded();
        }

        public static void ScrollTo(this By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => driver.FindElements(by).Count > 0);

            var element = Driver.FindElement(by);
            var actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void Destroy()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

        private static void WaitForBusyBlock()
        {
            WaitForElementInvisible(By.ClassName("mat-progress-spinner"));
        }

    }
}
