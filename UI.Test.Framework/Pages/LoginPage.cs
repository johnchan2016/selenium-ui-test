using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Pages
{
    public class LoginPage: BasePage
    {
        By usernameInput = By.Id(FrameworkConstants.LoginPage.USERNAME_INPUT_ID);
        By passwordInput = By.Id(FrameworkConstants.LoginPage.PASSWORD_INPUT_ID);
        By loginBtn = By.XPath(FrameworkConstants.LoginPage.LOGIN_BUTTON_XPATH);

        public void InputLoginName(string loginId)
        {
            usernameInput.SafeSendKey(loginId);
        }

        public void InputLoginPassword(string password)
        {
            passwordInput.SafeSendKey(password);
        }

        public void Login()
        {
            loginBtn.SafeClick();
        }
    }
}
