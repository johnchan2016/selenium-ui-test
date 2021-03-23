using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RMS.UI.Test.TestData;
using UI.Test.Framework;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;
using UI.Test.Framework.Pages;
using UI.Test.Framework.Pages.School;

namespace RMSUI.Test.Tests.School
{
    [TestFixture()]
    public class ClassTests
    {
        ChannelPage channelPage;
        LoginPage loginPage;
        ClassMaintenancePage classMaintenancePage;
        ClassDetailPage classDetailPage;

        public ClassTests()
        {
            channelPage = new ChannelPage();
            loginPage = new LoginPage();
            classMaintenancePage = new ClassMaintenancePage();
            classDetailPage = new ClassDetailPage();
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

        [TestCase(".dx-scheduler-date-table tr:nth-child(5) td:nth-child(2)", ".dx-scheduler-date-table tr:nth-child(5) td:nth-child(2) div.cell-with-classes", true)]
        [TestCase(".dx-scheduler-date-table tr:nth-child(5) td:nth-child(2)", ".dx-scheduler-date-table tr:nth-child(5) td:nth-child(1) div.cell-with-classes", false)]
        public void Has_Lesson_Created(string timeslot_css, string targetDateslot_css, bool expected)
        {
            classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

            var hasCreated = classMaintenancePage.ClassScheduleComponent.HasLesson(timeslot_css, targetDateslot_css);

            //assert
            Assert.AreEqual(hasCreated, expected);
        }

        [TestCaseSource("ClassDetailData")]
        public void Create_Class(ClassDetail classDetail)
        {
            classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

            classMaintenancePage.ClassListingComponent.CreateClass(classDetail);

            //assert
            var isClassDetailPage = classDetailPage.IsClassDetailPage();
            Assert.IsTrue(isClassDetailPage);
        }

        [TearDown]
        public void Destroy()
        {
            Browser.Destroy();
        }

        public static IEnumerable<ClassDetail> ClassDetailData => FileHelper.LoadJsonToList<ClassDetail>(@$"{AppDomain.CurrentDomain.BaseDirectory}\TestData\ClassDetail.json");
    }
}
