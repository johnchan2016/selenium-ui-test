using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Components.Widget
{
    public class NumpadComponent
    {
        By digitClearBtn => By.Id(FrameworkConstants.Numpad.DIGIT_CLEAR_ID);
        By digitReturnBtn => By.Id(FrameworkConstants.Numpad.DIGIT_RETURN_ID);

        public void ClickClearButton() => digitClearBtn.SafeClick();
        public void ClickReturnButton() => digitReturnBtn.SafeClick();
    }
}
