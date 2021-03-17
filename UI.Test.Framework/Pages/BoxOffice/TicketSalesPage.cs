using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UI.Test.Framework.Components.BoxOffice;

namespace UI.Test.Framework.Pages.BoxOffice
{
    public class TicketSalesPage: BasePage
    {
        By defaultTicket => By.Id(FrameworkConstants.Ticket.DEFAULT_TICKETCODE);
        CheckoutComponent checkoutComponent;
        PaymentComponent paymentComponent;
        CardOperationComponent cardOperationComponent;
        TicketQrCodeComponent ticketQrCodeComponent;

        public TicketSalesPage()
        {
            checkoutComponent = new CheckoutComponent();
            paymentComponent = new PaymentComponent();
            cardOperationComponent = new CardOperationComponent();
            ticketQrCodeComponent = new TicketQrCodeComponent();
            path = "/boxoffice/pos/ticket-sales";
        }

        public CheckoutComponent CheckoutComponent => checkoutComponent;
        public PaymentComponent PaymentComponent => paymentComponent;
        public CardOperationComponent CardOperationComponent => cardOperationComponent;
        public TicketQrCodeComponent TicketQrCodeComponent => ticketQrCodeComponent;

        public string TicketSalesMenuItem => "TicketSales";

        public void BuyDefaultTicketAndCheckout()
        {
            defaultTicket.SafeClick();
            checkoutComponent.Checkout();
            paymentComponent.PayByCash();
        }

        public bool IsPurchaseSuccess()
        {
            return ticketQrCodeComponent.IsShowReciept();
        }
    }
}
