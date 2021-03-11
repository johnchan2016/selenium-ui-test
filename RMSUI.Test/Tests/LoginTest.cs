using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RMS.UI.Test.TestData;
using RMSUI.Test;
using System.Dynamic;
using System.Threading;
using UI.Test.Framework;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;
using UI.Test.Framework.Pages;

namespace RMS.UI.Test.Tests
{
    [TestFixture()]
    public class LoginTest
    {
        [Test]
        public void Login()
        {
            ChannelPage channelPage = new ChannelPage();
            LoginPage loginPage = new LoginPage();

            channelPage.GoTo(Browser.AppConfig.RMSBaseUrl);
            channelPage.ChooseAndClick(BaseTestData.USERNAME_PASSWORD_LOGIN);

            loginPage.InputLoginName(BaseTestData.Admin.LOGIN_NAME);
            loginPage.InputLoginPassword(BaseTestData.Admin.LOGIN_PASSWORD);
            loginPage.Login();

            //assert
            DashboardPage dashboardPage = new DashboardPage();
            Assert.IsTrue(dashboardPage.IsDashboardPage());
        }

        [TearDown]
        public void Destroy()
        {
            Browser.Destroy();
        }
    }
}
