using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UI.Test.Framework.Components.School
{
    public class ClassScheduleComponent
    {
        public bool HasLesson(string timeslot_css, string targetDateslot_css)
        {
            By timeslot = By.CssSelector(timeslot_css);
            By targetTimeslot = By.CssSelector(targetDateslot_css);

            var isShown = timeslot.IsDisplay(10);

            Debug.WriteLine($"isShown: {isShown}");

            if (isShown)
            {
                var hasLesson = targetTimeslot.IsDisplay(5);

                Debug.WriteLine($"hasLesson: {hasLesson}");

                return hasLesson;
            }

            return isShown;
        }
    }
}
