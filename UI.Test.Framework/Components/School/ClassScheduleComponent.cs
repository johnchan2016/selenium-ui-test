using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UI.Test.Framework.Models;

namespace UI.Test.Framework.Components.School
{
    public class ClassScheduleComponent : BaseComponent
    {
        By lessonTimeSlotCssBy = null;

        public bool HasLesson(ClassDetail classDetail)
        {
            string timeslot_xpath = string.Format(classDetail.ValidateLesson.TargetTimeslotXPath, (int)DateTime.Now.DayOfWeek + 1);

            By timeslot = By.XPath(timeslot_xpath);

            var isShown = timeslot.IsDisplay(10);

            Debug.WriteLine($"isShown: {isShown}");

            if (isShown)
            {
                timeslot.SafeClick();

                string lessonTimeSlotXPath = string.Format(classDetail.ValidateLesson.ClassListXPath, classDetail.ClassInfo.CoachNo);
                lessonTimeSlotCssBy = By.XPath(lessonTimeSlotXPath);

                var hasCoachLesson = lessonTimeSlotCssBy.IsDisplay(10);

                Debug.WriteLine($"hasCoachLesson: {hasCoachLesson}");

                return hasCoachLesson;
            }

            return isShown;
        }

        public void ClickTargetLessonTimeslot()
        {
            if (lessonTimeSlotCssBy == null) return;

            lessonTimeSlotCssBy.SafeClick();
        }
    }
}
