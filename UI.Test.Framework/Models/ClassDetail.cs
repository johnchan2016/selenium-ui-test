using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Models
{
    public class ClassDetail
    {
        public ClassInfo ClassInfo { get; set; }
        public ValidateLesson ValidateLesson { get; set; }
    }

    public class ClassInfo
    {
        public ClassInfo()
        {
            Languages = new List<string>();
        }

        public string CoachNo { get; set; }
        public string ClassType { get; set; }
        public string Skill { get; set; }
        public List<string> Languages { get; set; }
        public List<string> TargetLessonCSSs { get; set; }
    }

    public class ValidateLesson
    {
        public string TimeslotCss { get; set; }
        public string TargetDateslotCss { get; set; }
        public string LessonTimeSlotCss { get; set; }
        public string CoachNo { get; set; }
    }
}
