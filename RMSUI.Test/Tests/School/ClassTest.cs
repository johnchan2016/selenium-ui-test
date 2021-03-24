using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RMS.UI.Test.TestData;
using UI.Test.Framework;
using UI.Test.Framework.Helpers;
using UI.Test.Framework.Models;
using UI.Test.Framework.Pages;
using UI.Test.Framework.Pages.School;

namespace RMSUI.Test.Tests.School
{
    [TestFixture()]
    public class ClassTest: BaseTest
    {
        ClassMaintenancePage classMaintenancePage;
        ClassDetailPage classDetailPage;

        public ClassTest()
        {
            classMaintenancePage = new ClassMaintenancePage();
            classDetailPage = new ClassDetailPage();
        }

        [TestCaseSource("ValidateLessonData")]
        public void Has_Lesson_Created(ValidateLesson validateLesson)
        {
            classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

            var hasCreated = classMaintenancePage.ClassScheduleComponent.HasLesson(validateLesson.Timeslot_css, validateLesson.TargetDateslot_css);

            //assert
            Assert.AreEqual(hasCreated, validateLesson.Expected);
        }

        [TestCaseSource("ClassDetailData")]
        public void Create_Class(ClassDetail classDetail)
        {
            classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

            classMaintenancePage.ClassListingComponent.CreateClass(classDetail);

            //assert
            var isClassDetailPage = classDetailPage.IsClassDetailPage();
            Assert.IsTrue(isClassDetailPage);
        }


        private static IEnumerable<ValidateLesson> ValidateLessonData => FileHelper.LoadJsonToList<ValidateLesson>(@$"{AppDomain.CurrentDomain.BaseDirectory}\TestData\ValidateLesson.json");
        private static IEnumerable<ClassDetail> ClassDetailData => FileHelper.LoadJsonToList<ClassDetail>(@$"{AppDomain.CurrentDomain.BaseDirectory}\TestData\ClassDetail.json");
    }
}
