using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Components;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class PaymentComponent: BaseComponent
    {
        IWebElement cashPayment => Driver.FindElement(By.Id("C00001"));
        IWebElement discardButton => Driver.FindElement(By.Id("discardBtn"));
        IWebElement checkoutButton => Driver.FindElement(By.Id("checkoutbtn"));
        IWebElement refundButton => Driver.FindElement(By.Id("refundBtn"));

        public void PayByCash()
        {
            cashPayment.SafeClick();
            checkoutButton.SafeClick();
        }
    }
}
