﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;

namespace UI.Test.Framework
{
    public static class Browser
    {
        private static IWebDriver _driver;
        private static int _waitTimeout = 30;
        private static AppConfig _config;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _config = FileHelper.LoadJson<AppConfig>(@"appsettings.json");
                    _waitTimeout = _config.WaitForTimeout;

                    switch (_config.BrowserType)
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

        public static AppConfig AppConfig
        {
            get { 
                if (_config == null) _config = FileHelper.LoadJson<AppConfig>(@"appsettings.json");
                return _config;
            }
            set { _config = value; }
        }

        public static void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoaded();
        }

        public static void ExplicitWait(int overridenWaitTime = -1)
        {
            int waitTime = overridenWaitTime == -1 ? _waitTimeout : overridenWaitTime;

            new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime)).IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public static void WaitForPageLoaded(int overrideWaitTime = -1)
        {
            WaitForElementInvisible(By.ClassName("mat-progress-spinner"), overrideWaitTime);
            //WaitForElementInvisible(By.ClassName("dx-state-invisible"));
        }

        public static void WaitForElementVisible(By by, int overridenWaitTime = -1)
        {
            int waitTime = overridenWaitTime == -1 ? _waitTimeout : overridenWaitTime;

            new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime))
                .Until(driver => driver.FindElements(by).Count > 0);
        }

        public static void WaitForElementInvisible(By by, int overridenWaitTime = -1)
        {
            int waitTime = overridenWaitTime == -1 ? _waitTimeout : overridenWaitTime;

            new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime))
                .Until(driver => driver.FindElements(by).Count == 0);
        }

        public static bool IsDisplay(this By by, int overridenWaitTime = -1)
        {
            try
            {
                int waitTime = overridenWaitTime == -1 ? _waitTimeout : overridenWaitTime;

                WaitForElementVisible(by, waitTime);

                var element = Driver.FindElement(by);

                var isShow = element.Displayed || element.GetCssValue("visibility") == "visible";
                return isShow;
            }
            catch (Exception e)
            {
                return false;
            }
            finally { }
        }

        public static bool IsEnabled(this By by)
        {
            WaitForElementVisible(by);

            var element = Driver.FindElement(by);
            return element.Enabled;
        }

        public static void SafeSendKey(this By by, string text)
        {
            by.ScrollTo();

            var element = Driver.FindElement(by);
            element.SendKeys(text);
        }

        public static void SafeClick(this By by)
        {
            WaitForElementVisible(by);

            var element = Driver.FindElement(by);
            element.Click();
        }

        public static void ScrollAndClick(this By by)
        {
            by.ScrollTo();

            var element = Driver.FindElement(by);
            element.Click();
        }

        public static string GetText(this By by)
        {
            WaitForElementVisible(by);

            var element = Driver.FindElement(by);

            Debug.WriteLine($"GetText: {element.Text}");
            return element.Text;
        }

        public static void ScrollTo(this By by)
        {
            WaitForElementVisible(by);

            var element = Driver.FindElement(by);
            var actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void CaptureScreen()
        {
            Driver.TakeScreenshot();
        }

        public static void Destroy()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
