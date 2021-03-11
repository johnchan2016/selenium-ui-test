using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class CardOperationComponent: BaseComponent
    {
        IWebElement successButton => Driver.FindElement(By.Id("successBtn"));
        IWebElement failureButton => Driver.FindElement(By.Id("failureBtn"));

        public void CheckoutSuccess()
        {
            successButton.SafeClick();
        }

        public void CheckoutFailure()
        {
            failureButton.SafeClick();
        }
    }
}
