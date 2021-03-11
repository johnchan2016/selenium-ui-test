using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace UI.Test.Framework.Pages
{
    public class ChannelPage: BasePage
    {
        IWebElement cardLoginButton => Driver.FindElement(By.Id(FrameworkConstants.LandingPage.CARD_LOGIN_BUTTON_ID));
        IWebElement usernamePasswordLoginButton => Driver.FindElement(By.Id(FrameworkConstants.LandingPage.USERNAME_PASSWORD_LOGIN_BUTTON_ID));

        public void ChooseAndClick(string loginType)
        {
            switch (loginType)
            {
                case "cardLogin":
                    cardLoginButton.SafeClick();
                    break;

                default:
                    usernamePasswordLoginButton.SafeClick();
                    break;
            }
        }
    }
}
