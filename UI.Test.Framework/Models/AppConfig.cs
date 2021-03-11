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
    }
}
