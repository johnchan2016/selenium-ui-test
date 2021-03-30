using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Models
{
    public class AppConfig
    {
        public string BrowserType { get; set; }
        public string RMSBaseUrl { get; set; }
        public int WaitForTimeout { get; set; }
        public RegressionReportConfig Report { get; set; }
    }

    public class RegressionReportConfig
    {
        public string Environment { get; set; }
        public string DocumentTitle { get; set; }
        public string ReportName { get; set; }
    }
}
