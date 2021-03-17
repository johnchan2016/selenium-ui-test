using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UI.Test.Framework.Components.BoxOffice
{
    public class CardOperationComponent: BaseComponent
    {
        By finalStep => By.CssSelector(FrameworkConstants.CardOperationComponent.FINALSTEP_CSS);
        By successMsgBox => By.XPath($"//*[contains(text(), '{FrameworkConstants.CardOperationComponent.SUCCESS_MESSAGE}')]");

        public bool IsCheckoutSuccess()
        {
            var isSuccess = successMsgBox.IsDisplay();

            Debug.WriteLine($"isSuccess: {isSuccess}");

            return isSuccess;

            //Debug.WriteLine($"isFinalStep: {isFinalStep}");

            //if (isFinalStep)
            //{
            //    var isSuccess = finalStepMsgBox.IsClickable();

            //    Debug.WriteLine($"isSuccess: {isSuccess}");

            //    if (isSuccess) successButton.SafeClick();
            //}
        }
    }
}
