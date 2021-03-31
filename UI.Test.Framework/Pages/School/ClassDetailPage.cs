using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Components.School;

namespace UI.Test.Framework.Pages.School
{
    public class ClassDetailPage: BasePage
    {
        By classDetailDiv => By.ClassName(FrameworkConstants.ClassLessonScheduleComponent.CLASS_DETAIL_DIV_CLASSNAME);

        ClassLessonScheduleComponent classLessonScheduleComponent;
        LessonAppointmentComponent lessonAppointmentComponent;
        public ClassDetailPage()
        {
            classLessonScheduleComponent = new ClassLessonScheduleComponent();
            lessonAppointmentComponent = new LessonAppointmentComponent();
        }

        public ClassLessonScheduleComponent ClassLessonScheduleComponent => classLessonScheduleComponent;

        public bool IsClassDetailPage()
        {
            return classDetailDiv.IsDisplay();
        }

        public bool IsLessonExist()
        {
            return classLessonScheduleComponent.IsLessonExist();
        }

        public void CreateNewLessons(List<string> targetLessonCSSs)
        {
            classLessonScheduleComponent.CreateNewLessons(targetLessonCSSs);
        }

        public void DeleteAllLessons()
        {
            classLessonScheduleComponent.DeleteAllLessons();
        }

        public bool HasNewLessonsCreated()
        {
            return classLessonScheduleComponent.IsLessonCreatedSuccess();
        }
    }
}
