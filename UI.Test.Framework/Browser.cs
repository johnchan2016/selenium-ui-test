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

                            //_driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
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
            //WaitForAjax();

            WaitForBusyBlock();
        }

        public static void WaitForElementVisible(IWebElement element)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => element.Displayed);
        }

        public static void WaitForElementInvisible(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(drv => drv.FindElements(by).Count == 0);
        }

        public static void SafeSendKey(this IWebElement element , string text)
        {
            element.ScrollTo();
            element.SendKeys(text);
            WaitForPageLoaded();
        }

        public static void SafeClick(this IWebElement element)
        {
            element.ScrollTo();
            element.Click();
            WaitForPageLoaded();
        }

        public static void ScrollTo(this IWebElement element)
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();

            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => element.IsVisible());
        }

        public static bool IsVisible(this IWebElement element)
        {
            // Calculate the mid-point of element
            // Check if the element could be found at that point

            return Driver.ExecuteJavaScript<bool>(
                "var elem = arguments[0],                 " +
                "  box = elem.getBoundingClientRect(),    " +
                "  cx = box.left + box.width / 2,         " +
                "  cy = box.top + box.height / 2,         " +
                "  e = document.elementFromPoint(cx, cy); " +
                "for (; e; e = e.parentElement) {         " +
                "  if (e === elem)                        " +
                "    return true;                         " +
                "}                                        " +
                "return false;                            "
                , element);
        }

        public static void Destroy()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

        private static void WaitForAjax()
        {
            // jQuery and AngularJs both loaded
            var jQueryLoadedDefinition = "!!window.jQuery && window.jQuery.active == 0";

            var angularJsLoadedDefinition =
                "(typeof angular == 'undefined' || (typeof angular != 'undefined' && !!angular.element('body > div').injector() && angular.element('body > div').injector().get('$http') && angular.element('body > div').injector().get('$http').pendingRequests.length == 0))";

            new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeout))
                .Until(driver => (bool)((IJavaScriptExecutor)Driver)
                    .ExecuteScript("return document.readyState == 'complete' && " + jQueryLoadedDefinition + " && " +
                                   angularJsLoadedDefinition));
        }

        private static void WaitForBusyBlock()
        {
            WaitForElementInvisible(By.ClassName("mat-progress-spinner"));
        }

    }
}
