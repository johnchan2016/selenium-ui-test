using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class TicketQrCodeComponent : BaseComponent
    {
        By receiptSection => By.Id("divReceipt");
        By closeButton => By.Id("closeBtn");

        public bool IsShowReciept()
        {
            return receiptSection.IsDisplay(5);
        }

        public void Close()
        {
            closeButton.SafeClick();
        }
    }
}
