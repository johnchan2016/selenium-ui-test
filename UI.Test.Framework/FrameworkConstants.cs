using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework
{
    public class FrameworkConstants
    {
        public class Ticket
        {
            public const string DEFAULT_TICKETCODE = "$00000";
        }

        #region Pages
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

        public class BoxOfficeStartSessionPage
        {
            public const string OPEN_AMOUNT_INPUT_ID = "openingAmountInput";
            public const string START_CASHIER_SESSTION_BUTTON_ID = "startCashierSessionBtn";
            public const string START_SESSTION_SECTION_ID = "startSessionSection";
        }
        #endregion

        #region Components
        public class NumpadComponent
        {
            public const string DIGIT_CLEAR_ID = "btnClear";
            public const string DIGIT_RETURN_ID = "btnReturn";
        }

        public class CardOperationComponent
        {
            public const string FINALSTEP_CSS = "mat-horizontal-stepper div.mat-horizontal-stepper-content:last-child";
            public const string FINALSTEP_MESSAGEBOX_XPATH = "//*[@id='finalStepMsgBox']";
            public const string SUCCESS_BUTTON_XPATH = "//button[@id='successBtn']";
            public const string FAILURE_BUTTON_XPATH = "//button[@id='failureBtn']";
            public const string SUCCESS_MESSAGE = "success";
        }

        public class ClassListingComponent
        {
            public const string ADD_CLASS_BUTTON_ID = "addClassBtn";
            public const string REFRESH_BUTTON_ID = "refreshClassBtn";
        }

        public class ClassDetailComponent
        {
            public const string COACH_INPUT_XPATH = "//input[@formControlName='coachId']";
            public const string CLASSTYPE_SELECT_XPATH = "//mat-select[@formcontrolname='classTypeId']";
            public const string SKILL_SELECT_XPATH = "//mat-select[@formcontrolname='skillLevelId']";
            public const string LANG_SELECT_XPATH = "//mat-select[@formcontrolname='language']";
            public const string DESC_INPUT_XPATH = "//input[@formControlName='description']";
            public const string CANCEL_CLASS_BUTTON_XPATH = "//button[@id='cancelClassBtn']";
            public const string SAVE_CLASS_BUTTON_XPATH = "//button[@id='saveClassBtn']";
            public const string SUBMIT_CLASS_BUTTON_XPATH = "//button[@id='submitClassBtn']";
            public const string CLEAR_CLASS_BUTTON_XPATH = "//button[@id='clearClassBtn']";
        }

        public class ClassLessonScheduleComponent
        {
            public const string CLASS_DETAIL_DIV_CLASSNAME = "class-detail-page";   
            public const string EDIT_SCHEDULE_BUTTON_ID = "editScheduleBtn";
            public const string SAVE_SCHEDULE_BUTTON_ID = "saveScheduleBtn";
            public const string CANCEL_SCHEDULE_BUTTON_ID = "cancelScheduleBtn";
            public const string REFRESH_SCHEDULE_BUTTON_ID = "refreshScheduleBtn";
            public const string MAIN_COACH_XPATH = "//div[@id='coach1']";
            public const string FIRST_LESSON_XPATH = "//div[@id='lesson1']";
        }

        public class LessonAppoinmentComponent
        {
            public const string CONFIRM_LESSON_BUTTON_XPATH = "//button[@id='confirmLessonBtn']";
            public const string CANCEL_LESSON_BUTTON_XPATH = "//button[@id='cancelLessonBtn']";
        }
        #endregion
    }
}
