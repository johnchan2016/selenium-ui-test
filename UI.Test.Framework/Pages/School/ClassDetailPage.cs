using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Pages.School
{
    public class ClassDetailPage: BasePage
    {
        By classDetailDiv => By.ClassName("class-detail-page");

        public bool IsClassDetailPage()
        {
            return classDetailDiv.IsDisplay();
        }
    }
}
