using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UI.Test.Framework.Components.Widget;

namespace UI.Test.Framework.Pages.BoxOffice
{
    public class BoxOfficeStartSessionPage : BasePage
    {
        By openingAmountInput => By.Id(FrameworkConstants.BoxOfficeStartSessionPage.OPEN_AMOUNT_INPUT_ID);
        By startCashierSesstionButton => By.Id(FrameworkConstants.BoxOfficeStartSessionPage.START_CASHIER_SESSTION_BUTTON_ID);
        By startSessionSection => By.Id(FrameworkConstants.BoxOfficeStartSessionPage.START_SESSTION_SECTION_ID);
        NumpadComponent numpadComponent;

        public BoxOfficeStartSessionPage()
        {
            numpadComponent = new NumpadComponent();
            path = "/boxoffice/pos/cashier-session";
        }

        public bool ValidateSessionEnabled()
        {
            bool isInputExist = openingAmountInput.IsDisplay(6);

            return isInputExist;
        }

        public void StartCashierSession()
        {
            openingAmountInput.ScrollAndClick();
            openingAmountInput.SafeSendKey("0");
            numpadComponent.ClickReturnButton();
            startCashierSesstionButton.ScrollAndClick();
        }
    }
}
