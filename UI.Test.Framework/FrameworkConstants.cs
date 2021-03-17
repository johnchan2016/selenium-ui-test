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

        public class Numpad
        {
            public const string DIGIT_CLEAR_ID = "btnClear";
            public const string DIGIT_RETURN_ID = "btnReturn";
        }

        public class CardOperationComponent
        {
            public const string FINALSTEP_CSS = "mat-horizontal-stepper div.mat-horizontal-stepper-content:last-child";
            public const string FINALSTEP_MESSAGEBOX_XPATH = "//*[@id='finalStepMsgBox']";
            public const string SUCCESS_BUTTON_CSS = "button#successBtn";
            public const string FAILURE_BUTTON_CSS = "button#failureBtn";
            public const string SUCCESS_MESSAGE = "success";
        }

        public class BoxOfficeStartSessionPage
        {
            public const string OPEN_AMOUNT_INPUT_ID = "openingAmountInput";
            public const string START_CASHIER_SESSTION_BUTTON_ID = "startCashierSessionBtn";
            public const string START__SESSTION_SECTION_ID = "startSessionSection";
        }
    }
}
