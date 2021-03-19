using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Components.School;

namespace UI.Test.Framework.Pages.School
{
    public class ClassMaintenancePage: BasePage
    {
        ClassListingComponent classListingComponent;
        ClassScheduleComponent classScheduleComponent;

        public ClassMaintenancePage()
        {
            classListingComponent = new ClassListingComponent();
            classScheduleComponent = new ClassScheduleComponent();
        }

        public string TargetMenuItem => "ClassMaintenance";
        public ClassListingComponent ClassListingComponent => classListingComponent;
        public ClassScheduleComponent ClassScheduleComponent => classScheduleComponent;
    }
}
