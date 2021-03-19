using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UI.Test.Framework.Components.School
{
    public class ClassScheduleComponent
    {
        //By time_0900 => By.CssSelector(".dx-scheduler-date-table tr:nth-child(5) td:nth-child(2)");
        //By targetTimeslot = By.CssSelector(".dx-scheduler-date-table tr:nth-child(5) td:nth-child(2) div.cell-with-classes");

        public bool HasLesson(string timeslot_css, string targetDateslot_css)
        {
            By time_0900 = By.CssSelector(timeslot_css);
            By targetTimeslot = By.CssSelector(targetDateslot_css);

            var isShown = time_0900.IsDisplay(10);

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
