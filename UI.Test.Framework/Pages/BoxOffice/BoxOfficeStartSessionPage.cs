using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Test.Framework.Pages.BoxOffice
{
    public class BoxOfficeStartSessionPage: BasePage
    {
        IWebElement openingAmountInput => Driver.FindElement(By.Id("openingAmountInput"));
        IWebElement startCashierSesstionButton => Driver.FindElement(By.Id("startCashierSessionBtn"));


        public void StartCashierSession()
        {
            openingAmountInput.SafeSendKey("0");
            startCashierSesstionButton.SafeClick();
        }
    }
}
