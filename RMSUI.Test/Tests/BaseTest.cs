using NUnit.Framework;
using RMS.UI.Test.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework;
using UI.Test.Framework.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace RMSUI.Test.Tests
{
    [TestFixture()]
    public class BaseTest
    {
        protected ChannelPage channelPage;
        protected LoginPage loginPage;
        AventStack.ExtentReports.ExtentReports _extent = null;
        ExtentV3HtmlReporter _reporter = null;
        ExtentTest _test = null;
        string _path;
        string _actualPath;
        string _projectPath;

        public BaseTest()
        {
            channelPage = new ChannelPage();
            loginPage = new LoginPage();

            _path = Assembly.GetCallingAssembly().CodeBase;
            _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string dateformat_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            _projectPath = $@"{new Uri(_actualPath).LocalPath}\Reports_{dateformat_yyyyMMdd}";
        }

        /*
        [OneTimeSetUp]
        public void StartReport()
        {
            //config report path
            if (!Directory.Exists(_projectPath)) Directory.CreateDirectory(_projectPath);

            var reportPath = $@"{_projectPath}\ExtentReport.html";

            _reporter = new ExtentV3HtmlReporter(reportPath);
            _reporter.Config.DocumentTitle = "Automation Testing Report";
            _reporter.Config.ReportName = "Regression Testing";
            _reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(_reporter);

            _extent.AddSystemInfo("Environment", "SIT");
            _extent.AddSystemInfo("Machine", Environment.MachineName);
            _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        */

        [SetUp]
        public void Initialize()
        {
            //_test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            channelPage.GoTo(Browser.AppConfig.RMSBaseUrl);
            channelPage.ChooseAndClick(BaseTestData.USERNAME_PASSWORD_LOGIN);

            loginPage.InputLoginName(BaseTestData.Admin.LOGIN_NAME);
            loginPage.InputLoginPassword(BaseTestData.Admin.LOGIN_PASSWORD);
            loginPage.Login();
        }

        [TearDown]
        public void Destroy()
        {
            /*
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("HHmmss") + ".png";
                    String screenShotPath = Capture(Browser.Driver, fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath($@"Screenshots\{fileName}"));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            */
            Browser.Destroy();
        }

        /*
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        private string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var screenshotPath = $@"{_projectPath}\Screenshots\{screenShotName}";
            var localpath = new Uri(screenshotPath).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return _projectPath;
        }
        */
    }
}
