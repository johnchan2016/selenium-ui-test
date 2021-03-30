using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RMS.UI.Test.TestData;
using RMSUI.Test;
using RMSUI.Test.Tests;
using System.Dynamic;
using System.Threading;
using UI.Test.Framework;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;
using UI.Test.Framework.Pages;

namespace RMS.UI.Test.Tests
{
    [TestFixture()]
    //[Parallelizable]
    public class LoginTest: BaseTest
    {
        [Test]
        public void Login()
        {
            //assert
            DashboardPage dashboardPage = new DashboardPage();
            Assert.IsTrue(dashboardPage.IsDashboardPage());
        }
    }
}
