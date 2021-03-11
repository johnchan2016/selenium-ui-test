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

namespace RMSUI.Test.Tests
{
    [TestFixture()]
    public class TicketSalesTest
    {
        //IContainer container;
        //ILifetimeScope scope;

        public TicketSalesTest() { }

        [OneTimeSetUp]
        public void Setup()
        {
            //container = Initializer.Initialize();
            //scope = container.BeginLifetimeScope();
        }

        [SetUp]
        public void Initialize()
        {
            ChannelPage channelPage = new ChannelPage();
            LoginPage loginPage = new LoginPage();
            DashboardPage dashboardPage = new DashboardPage();

            var appConfig = FileHelper.LoadJson<AppConfig>(@"appsettings.json");
            channelPage.GoTo($"{appConfig.RMSBaseUrl}{channelPage.Path}");

            channelPage.ChooseAndClick(BaseTestData.USERNAME_PASSWORD_LOGIN);

            loginPage.InputLoginName(BaseTestData.Admin.LOGIN_NAME);
            loginPage.InputLoginPassword(BaseTestData.Admin.LOGIN_PASSWORD);
            loginPage.Login();

            //assert
            Assert.IsTrue(dashboardPage.IsDashboardPage());
        }

        [Test]
        public void BuyDefaultTicket()
        {
            TicketSalesPage ticketSalesPage = new TicketSalesPage();
            ticketSalesPage.Checkout();

            //assert
            Assert.IsTrue(ticketSalesPage.IsPurchaseSuccess());
        }

        [TearDown]
        public void Destroy()
        {
            Browser.Destroy();
        }
    }
}
