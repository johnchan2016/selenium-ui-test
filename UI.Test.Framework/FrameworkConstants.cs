using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework
{
    public class FrameworkConstants
    {
        public class LandingPage
        {
            public const string CARD_LOGIN_BUTTON_ID = "cardLoginBtn";
            public const string USERNAME_PASSWORD_LOGIN_BUTTON_ID = "userNamePasswordLoginBtn";
        }

        public class LoginPage
        {
            public const string USERNAME_INPUT_ID = "Username";
            public const string PASSWORD_INPUT_ID = "Password";
            public const string LOGIN_BUTTON_XPATH = "//button[@value='login']";
        }

        public class DashboardPage
        {
            public const string DASHBOARD_TITLE_CSS = "div.dashboard-title";
        }

        public class Ticket
        {
            public const string DEFAULT_TICKETCODE = "$00000";
        }
    }
}
