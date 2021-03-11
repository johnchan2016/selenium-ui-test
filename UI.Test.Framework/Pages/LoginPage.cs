using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Pages
{
    public class LoginPage: BasePage
    {
        IWebElement userNameInput => Driver.FindElement(By.Id(FrameworkConstants.LoginPage.USERNAME_INPUT_ID));
        IWebElement passwordInput => Driver.FindElement(By.Id(FrameworkConstants.LoginPage.PASSWORD_INPUT_ID));
        IWebElement loginButton => Driver.FindElement(By.XPath(FrameworkConstants.LoginPage.LOGIN_BUTTON_XPATH));

        public void InputLoginName(string loginId)
        {
            userNameInput.SafeSendKey(loginId);
        }

        public void InputLoginPassword(string password)
        {
            passwordInput.SafeSendKey(password);
        }

        public void Login()
        {
            loginButton.SafeClick();
        }
    }
}
