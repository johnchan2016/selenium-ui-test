using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Test.Framework.Pages.BoxOffice
{
    public class BoxOfficeStartSessionPage: BasePage
    {
        By openingAmountInput => By.Id("openingAmountInput");
        By startCashierSesstionButton => By.Id("startCashierSessionBtn");


        public void StartCashierSession()
        {
            openingAmountInput.SafeSendKey("0");
            startCashierSesstionButton.SafeClick();
        }
    }
}
