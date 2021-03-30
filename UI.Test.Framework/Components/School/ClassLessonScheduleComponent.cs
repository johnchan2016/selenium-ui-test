using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Components.School
{
    public class ClassLessonScheduleComponent
    {
        By saveButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.SAVE_SCHEDULE_BUTTON_ID);
        By cancelButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.CANCEL_SCHEDULE_BUTTON_ID);
        By editButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.EDIT_SCHEDULE_BUTTON_ID);
        By refreshButton => By.Id(FrameworkConstants.ClassLessonScheduleComponent.REFRESH_SCHEDULE_BUTTON_ID);
        //By coachList => By.Id("coachList");
        By mainCoach => By.XPath(FrameworkConstants.ClassLessonScheduleComponent.MAIN_COACH_XPATH);
        //By lessonList => By.Id("lessonList");
        By firstLesson => By.XPath(FrameworkConstants.ClassLessonScheduleComponent.FIRST_LESSON_XPATH);

        LessonAppointmentComponent lessonAppointmentComponent;

        public ClassLessonScheduleComponent()
        {
            lessonAppointmentComponent = new LessonAppointmentComponent();
        }

        public LessonAppointmentComponent LessonAppointmentComponent => lessonAppointmentComponent;

        public void CreateNewLesson(string targetCSS)
        {
            var isEnabled = editButton.IsEnabled(5);
            if (isEnabled)
            {
                editButton.SafeClick();

                By target = By.CssSelector(targetCSS);
                mainCoach.DragAndDrop(target);

                lessonAppointmentComponent.ConfirmLesson();
            }
        }

        public void SaveChange()
        {
            saveButton.SafeClick();
        }

        public bool HasLessonsCreated()
        {
            return firstLesson.IsDisplay(10);
        }
    }
}
