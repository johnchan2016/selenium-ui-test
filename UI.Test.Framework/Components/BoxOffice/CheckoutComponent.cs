using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using UI.Test.Framework.Components;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class CheckoutComponent: BaseComponent
    {
        By checkoutButton => By.Id("checkoutBtn");
        By voidButton => By.Id("voidBtn");
        By refundButton => By.Id("refundBtn");
        By posCheckoutRemarkInput => By.Id("posCheckoutRemarkInput");
        By posVoidRemarkInput => By.Id("posVoidRemarkInput");

        public void Checkout()
        {
            checkoutButton.SafeClick();
        }

        public void Void()
        {
            voidButton.SafeClick();
        }

        public void Refund()
        {
            refundButton.SafeClick();
        }
    }
}
