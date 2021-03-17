using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Components;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class PaymentComponent: BaseComponent
    {
        By cashPayment => By.Id("C00001");
        By discardButton => By.Id("discardBtn");
        By checkoutButton => By.Id("checkoutbtn");
        By refundButton => By.Id("refundBtn");

        public void PayByCash()
        {
            cashPayment.ScrollAndClick();
            checkoutButton.ScrollAndClick();
        }
    }
}
