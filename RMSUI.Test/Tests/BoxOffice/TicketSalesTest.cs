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
    public class TicketSalesTest
    {
        ChannelPage channelPage;
        LoginPage loginPage;

        public TicketSalesTest() 
        {
            channelPage = new ChannelPage();
            loginPage = new LoginPage();
        }

        [SetUp]
        public void Initialize()
        {
            channelPage.GoTo(Browser.AppConfig.RMSBaseUrl);
            channelPage.ChooseAndClick(BaseTestData.USERNAME_PASSWORD_LOGIN);

            loginPage.InputLoginName(BaseTestData.Admin.LOGIN_NAME);
            loginPage.InputLoginPassword(BaseTestData.Admin.LOGIN_PASSWORD);
            loginPage.Login();

            //assert
            DashboardPage dashboardPage = new DashboardPage();
            Assert.IsTrue(dashboardPage.IsDashboardPage());
        }

        [Test]
        public void BuyDefaultTicket()
        {
            BoxOfficeStartSessionPage startSessionPage = new BoxOfficeStartSessionPage();
            TicketSalesPage ticketSalesPage = new TicketSalesPage();

            loginPage.ClickTargetMenu(ticketSalesPage.TargetMenuItem);

            if (startSessionPage.ValidateSessionEnabled()) 
                startSessionPage.StartCashierSession();

            ticketSalesPage.BuyDefaultTicketAndCheckout();

            //assert
            Assert.IsTrue(ticketSalesPage.CardOperationComponent.IsCheckoutSuccess());
            Browser.CaptureScreen();
        }

        [TearDown]
        public void Destroy()
        {
            Browser.Destroy();
        }
    }
}
