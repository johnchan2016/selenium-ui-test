using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UI.Test.Framework.Models;

namespace UI.Test.Framework.Components.School
{
    public class ClassScheduleComponent
    {
        By lessonTimeSlotCssBy = null;

        public bool HasLesson(ValidateLesson validateLesson)
        {
            string timeslot_css = string.Format(validateLesson.TimeslotCss, (int)DateTime.Now.DayOfWeek + 1);
            string targetDateslot_css = string.Format(validateLesson.TargetDateslotCss, (int)DateTime.Now.DayOfWeek + 1);

            By timeslot = By.CssSelector(timeslot_css);
            By targetTimeslot = By.CssSelector(targetDateslot_css);

            var isShown = timeslot.IsDisplay(10);

            Debug.WriteLine($"isShown: {isShown}");

            if (isShown)
            {
                var hasLesson = targetTimeslot.IsDisplay(8);

                Debug.WriteLine($"hasLesson: {hasLesson}");

                if (hasLesson)
                {
                    targetTimeslot.SafeClick();

                    string lessonTimeSlotCss = string.Format(validateLesson.LessonTimeSlotCss, validateLesson.CoachNo);
                    lessonTimeSlotCssBy = By.CssSelector(lessonTimeSlotCss);

                    var hasCoachLesson = lessonTimeSlotCssBy.HasElement(10);

                    return hasCoachLesson;
                } 

                return hasLesson;
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
