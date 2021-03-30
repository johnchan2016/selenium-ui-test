using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RMS.UI.Test.TestData;
using RMSUI.Test;
using System;
using System.Dynamic;
using UI.Test.Framework;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;
using UI.Test.Framework.Pages;
using UI.Test.Framework.Pages.BoxOffice;

namespace RMSUI.Test.Tests.BoxOffice
{
    [TestFixture()]
    //[Parallelizable]
    public class TicketSalesTest: BaseTest
    {
        [Test]
        public void BuyDefaultTicket()
        {
            BoxOfficeStartSessionPage startSessionPage = new BoxOfficeStartSessionPage();
            TicketSalesPage ticketSalesPage = new TicketSalesPage();

            base.loginPage.ClickTargetMenu(ticketSalesPage.TargetMenuItem);

            if (startSessionPage.ValidateSessionEnabled()) 
                startSessionPage.StartCashierSession();

            ticketSalesPage.BuyDefaultTicketAndCheckout();

            //assert
            Assert.IsTrue(ticketSalesPage.CardOperationComponent.IsCheckoutSuccess());
        }
    }
}
