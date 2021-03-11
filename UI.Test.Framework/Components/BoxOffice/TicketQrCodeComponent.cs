using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class TicketQrCodeComponent : BaseComponent
    {
        IWebElement receiptSection => Driver.FindElement(By.Id("divReceipt"));
        IWebElement closeButton => Driver.FindElement(By.Id("closeBtn"));

        public bool IsShowReciept()
        {
            return receiptSection.Displayed;
        }

        public void Close()
        {
            closeButton.SafeClick();
        }
    }
}
