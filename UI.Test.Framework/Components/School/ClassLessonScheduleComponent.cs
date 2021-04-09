using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace UI.Test.Framework.Components.School
{
    public class ClassLessonScheduleComponent: BaseComponent
    {
        const string successLessonBackgroundColor = "rgba(67, 160, 71, 0.03)";

        By saveButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.SAVE_SCHEDULE_BUTTON_ID);
        By cancelButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.CANCEL_SCHEDULE_BUTTON_ID);
        By editButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.EDIT_SCHEDULE_BUTTON_ID);
        By refreshButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.REFRESH_SCHEDULE_BUTTON_ID);
        By mainCoach => By.XPath(FrameworkConstants.ClassLessonScheduleComponent.MAIN_COACH_XPATH);
        By firstSuccessLesson => By.XPath(string.Format(FrameworkConstants.ClassLessonScheduleComponent.FIRST_SUCCESS_LESSON_XPATH, successLessonBackgroundColor));
        By lessonItemList => By.XPath(FrameworkConstants.ClassLessonScheduleComponent.LESSON_ITEM_LIST_XPATH);
        By removeLessonButton => By.XPath(FrameworkConstants.ClassLessonScheduleComponent.REMOVE_LESSON_BUTTON_XPATH);

        LessonAppointmentComponent lessonAppointmentComponent;

        public ClassLessonScheduleComponent()
        {
            lessonAppointmentComponent = new LessonAppointmentComponent();
        }

        public LessonAppointmentComponent LessonAppointmentComponent => lessonAppointmentComponent;

        public void CreateNewLessons(List<string> targetLessonCSSs)
        {
            Thread.Sleep(1000);
            var isEnabled = editButton.IsEnabled(5);

            Debug.WriteLine($"CreateNewLessons/isEnabled: {isEnabled}");

            if (isEnabled)
            {
                editButton.SafeClick();

                foreach (var targetCss in targetLessonCSSs)
                {
                    var targetLessonCSS = string.Format(targetCss, (int)DateTime.Now.DayOfWeek + 1);
                    By target = By.CssSelector(targetLessonCSS);
                    mainCoach.DragAndDrop(target);

                    lessonAppointmentComponent.ConfirmLesson();
                }

                Browser.WaitForElementInvisible(LoadingIndicator);
                saveButton.SafeClick();
            }
        }

        public void DeleteAllLessons()
        {
            var isEnabled = editButton.IsEnabled(5);

            Debug.WriteLine($"DeleteAllLessons/isEnabled: {isEnabled}");

            if (isEnabled)
            {
                editButton.SafeClick();

                if(IsLessonExist())
                {
                    removeLessonButton.SafeClick();
                }

                Browser.WaitForElementInvisible(LoadingIndicator);
                saveButton.SafeClick();
            }
        }

        public bool IsLessonExist()
        {
           return lessonItemList.HasElement(5);
        }

        public bool IsLessonCreatedSuccess()
        {
            var isCreated = firstSuccessLesson.IsDisplay(5);
            Debug.WriteLine($"IsLessonCreatedSuccess/isCreated: {isCreated}");

            return isCreated;
        }
    }
}
