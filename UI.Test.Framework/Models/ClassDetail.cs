using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework.Models
{
    public class ClassDetail
    {
        public ClassDetail()
        {
            Languages = new List<string>();
        }

        public string CoachNo { get; set; }
        public string ClassType { get; set; }
        public string Skill { get; set; }
        public List<string> Languages { get; set; }
    }
}
