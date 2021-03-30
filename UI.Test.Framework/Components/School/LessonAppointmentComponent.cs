using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Components.School
{
    public class LessonAppointmentComponent
    {
        By confirmButton => By.XPath(FrameworkConstants.LessonAppoinmentComponent.CONFIRM_LESSON_BUTTON_XPATH);
        By cancelButton => By.XPath(FrameworkConstants.LessonAppoinmentComponent.CANCEL_LESSON_BUTTON_XPATH);

        public void ConfirmLesson()
        {
            confirmButton.SafeClick();
        }
    }
}
