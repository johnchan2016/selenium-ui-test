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
        By saveButton => By.Id(FrameworkConstants.ClassDetailComponent.SAVE_CLASS_BUTTON_ID);
        By cancelButton => By.Id(FrameworkConstants.ClassDetailComponent.CANCEL_CLASS_BUTTON_ID);
        By submitButton => By.Id(FrameworkConstants.ClassDetailComponent.SUBMIT_CLASS_BUTTON_ID);
        By clearButton => By.Id(FrameworkConstants.ClassDetailComponent.CLEAR_CLASS_BUTTON_ID);

        public void FillInClassDetails(ClassDetail classDetail)
        {
            coachInput.SafeSendKey(classDetail.CoachNo);
            Browser.SelectByTextByXPath(classDetail.CoachNo);

            classTypeSelect.SafeClick();
            Browser.SelectByTextByXPath(classDetail.ClassType);

            skillSelect.SafeClick();
            Browser.SelectByTextByXPath(classDetail.Skill);

            langSelect.SafeClick();
            Browser.MultipleSelectByText(classDetail.Languages);
            Browser.ClickEsc();

            submitButton.SafeClick();
        }
    }
}
