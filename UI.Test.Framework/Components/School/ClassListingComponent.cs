using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Models;

namespace UI.Test.Framework.Components.School
{
    public class ClassListingComponent: BaseComponent
    {
        By addClassButton => By.Id(FrameworkConstants.ClassListingComponent.ADD_CLASS_BUTTON_ID);
        By refreshButton => By.Id(FrameworkConstants.ClassListingComponent.REFRESH_BUTTON_ID);
        ClassDetailComponent classDetailComponent;

        public ClassDetailComponent ClassDetailComponent => classDetailComponent;

        public ClassListingComponent()
        {
            classDetailComponent = new ClassDetailComponent();
        }

        public void CreateClass(ClassInfo classInfo)
        {
            addClassButton.IsDisplay();
            addClassButton.SafeClick();
            classDetailComponent.FillInClassDetails(classInfo);
        }
    }
}
