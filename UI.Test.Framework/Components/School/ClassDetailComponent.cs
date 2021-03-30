using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI.Test.Framework.Models;

namespace UI.Test.Framework.Components.School
{
    public class ClassDetailComponent: BaseComponent
    {
        By coachInput => By.XPath(FrameworkConstants.ClassDetailComponent.COACH_INPUT_XPATH);
        By classTypeSelect => By.XPath(FrameworkConstants.ClassDetailComponent.CLASSTYPE_SELECT_XPATH);
        By skillSelect => By.XPath(FrameworkConstants.ClassDetailComponent.SKILL_SELECT_XPATH);
        By langSelect => By.XPath(FrameworkConstants.ClassDetailComponent.LANG_SELECT_XPATH);
        By descInput => By.XPath(FrameworkConstants.ClassDetailComponent.DESC_INPUT_XPATH);
        By saveButton => By.XPath(FrameworkConstants.ClassDetailComponent.SAVE_CLASS_BUTTON_XPATH);
        By cancelButton => By.XPath(FrameworkConstants.ClassDetailComponent.CANCEL_CLASS_BUTTON_XPATH);
        By submitButton => By.XPath(FrameworkConstants.ClassDetailComponent.SUBMIT_CLASS_BUTTON_XPATH);
        By clearButton => By.XPath(FrameworkConstants.ClassDetailComponent.CLEAR_CLASS_BUTTON_XPATH);

        public void FillInClassDetails(ClassInfo classInfo)
        {
            coachInput.SafeSendKey(classInfo.CoachNo);
            Browser.SelectByTextByXPath(classInfo.CoachNo);

            classTypeSelect.SafeClick();
            Browser.SelectByTextByXPath(classInfo.ClassType);

            skillSelect.SafeClick();
            Browser.SelectByTextByXPath(classInfo.Skill);

            langSelect.SafeClick();
            Browser.MultipleSelectByText(classInfo.Languages);
            Browser.ClickCustomKey(Keys.Escape);

            submitButton.SafeClick();
        }
    }
}
