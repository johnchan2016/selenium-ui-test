using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Test.Framework
{
    public class RmsMenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public List<string> Role { get; set; }
        public bool Not { get; set; }
    }
}
