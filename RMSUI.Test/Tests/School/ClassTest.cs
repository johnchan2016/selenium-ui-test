﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    //[Parallelizable]
    public class ClassTest: BaseTest
    {
        ClassMaintenancePage classMaintenancePage;
        ClassDetailPage classDetailPage;

        public ClassTest()
        {
            classMaintenancePage = new ClassMaintenancePage();
            classDetailPage = new ClassDetailPage();
        }

        //[TestCaseSource("ValidateLessonData")]
        //public void Has_Lesson_Created(ValidateLesson validateLesson)
        //{
        //    classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

        //    var hasCreated = classMaintenancePage.ClassScheduleComponent.HasLesson(validateLesson.Timeslot_css, validateLesson.TargetDateslot_css);

        //    //assert
        //    Assert.AreEqual(hasCreated, validateLesson.Expected);
        //}

        /// <summary>Create_Class_With_Lesson
        /// 1. go to class maintenance page
        /// 2. check any lessons on specific timeslot
        /// 3a. if yes, skip create class ## end
        /// 3b. if no, create class, continue with step 4
        /// 4. create lessons - check whether the lesson is created
        /// a. if yes, remove
        /// b. if no, create new lessons
        /// ## end
        /// </summary>
        [TestCaseSource("ClassDetailData")]
        public void Create_Class_With_Lesson(ClassDetail classDetail)
        {
            bool hasNewLessonCreated = false;
            classMaintenancePage.ClickTargetMenu(classMaintenancePage.TargetMenuItem);

            var hasCreated = classMaintenancePage.ClassScheduleComponent.HasLesson(classDetail);
            Debug.WriteLine($"hasCreated: {hasCreated}");

            // click detail or create new class
            if (hasCreated)
            {
                classMaintenancePage.ClassScheduleComponent.ClickTargetLessonTimeslot();
            }
            else
            {
                classMaintenancePage.ClassListingComponent.CreateClass(classDetail.ClassInfo);
            }

            var isClassDetailPage = classDetailPage.IsClassDetailPage();
            if (isClassDetailPage)
            {
                //delete all existing lessons
                var IsLessonExist = classDetailPage.IsLessonExist();

                Debug.WriteLine($"IsLessonExist: {IsLessonExist}");

                if (IsLessonExist)
                {
                    classDetailPage.DeleteAllLessons();
                }

                //create new lessons
                classDetailPage.CreateNewLessons(classDetail.ClassInfo.TargetLessonCSSs);

                hasNewLessonCreated = classDetailPage.HasNewLessonsCreated();
                Debug.WriteLine($"hasNewLessonCreated: {hasNewLessonCreated}");
            }

            //assert
            Assert.IsTrue(hasNewLessonCreated);
        }

        // DataSource
        private static IEnumerable<ValidateLesson> ValidateLessonData => FileHelper.LoadJsonToList<ValidateLesson>(@$"{AppDomain.CurrentDomain.BaseDirectory}\TestData\ValidateLesson.json");
        private static IEnumerable<ClassDetail> ClassDetailData => FileHelper.LoadJsonToList<ClassDetail>(@$"{AppDomain.CurrentDomain.BaseDirectory}\TestData\ClassDetail.json");
    }
}
