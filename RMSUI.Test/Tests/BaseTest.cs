using NUnit.Framework;
using RMS.UI.Test.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework;
using UI.Test.Framework.Pages;

namespace RMSUI.Test.Tests
{
    [TestFixture()]
    public class BaseTest
    {
        protected ChannelPage channelPage;
        protected LoginPage loginPage;

        public BaseTest()
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
        }

        [TearDown]
        public void Destroy()
        {
            Browser.Destroy();
        }

    }
}
