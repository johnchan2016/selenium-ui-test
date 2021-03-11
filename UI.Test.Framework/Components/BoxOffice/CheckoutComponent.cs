using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using UI.Test.Framework.Components;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class CheckoutComponent: BaseComponent
    {
        IWebElement checkoutButton => Driver.FindElement(By.Id("checkoutBtn"));
        IWebElement voidButton => Driver.FindElement(By.Id("voidBtn"));
        IWebElement refundButton => Driver.FindElement(By.Id("refundBtn"));
        IWebElement posCheckoutRemarkInput => Driver.FindElement(By.Id("posCheckoutRemarkInput"));
        IWebElement posVoidRemarkInput => Driver.FindElement(By.Id("posVoidRemarkInput"));

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
