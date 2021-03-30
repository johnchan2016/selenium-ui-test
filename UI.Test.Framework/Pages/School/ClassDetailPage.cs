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

        public bool HasLessonCreated()
        {
            return classLessonScheduleComponent.HasLessonsCreated();
        }

        public void CreateNewLessons(List<string> targetLessonCSSs)
        {
            foreach(var target in targetLessonCSSs)
            {
                var targetCSS = string.Format(target, (int)DateTime.Now.DayOfWeek + 1);
                classLessonScheduleComponent.CreateNewLesson(targetCSS);
            }

            classLessonScheduleComponent.SaveChange();
        }

        public void DeleteAllLessons(string targetLessonCSSs)
        {
            int lessonCount = 0;
            for(int i = 1; i <= lessonCount; i++)
            {

            }

            //foreach (var target in targetLessonCSSs)
            //{
            //    var targetCSS = string.Format(target, DateTime.Now.DayOfWeek + 1);
            //    classLessonScheduleComponent.CreateNewLesson(targetCSS);
            //}

            classLessonScheduleComponent.SaveChange();
        }
    }
}
