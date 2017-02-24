using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GradeTrackingEngine;

namespace GradeTrackingEngine.Test
{
    [TestFixture]
    class CourseTests
    {
        Course course = new Course("Math", "Math1148");

        SimpleGrade simpleGrade = new SimpleGrade("Quiz", 3, 100);
        SimpleGradeDroppingScores simpleDropGrade = new SimpleGradeDroppingScores("Lab", 4, 100, 1);
        
        WeightedGrade weightedGrade = new WeightedGrade("Test", 3, 100, .15);
        WeightedGradeDroppingScores weightedDropGrade = new WeightedGradeDroppingScores("Report", 4, 100, 1, .15);

        [Test]
        public void CreateCourse()
        {
            Assert.That(course.CourseName, Is.EqualTo("Math"));
        }

        [Test]
        public void AddSimpleGrade()
        {
            course.AddGrade(simpleGrade);

            string gradeName = course.GetGradeType(1);

            Assert.That(gradeName, Is.EqualTo("Quiz"));
        }

        [Test]
        public void AddDroppingGrade()
        {
            course.AddGrade(simpleDropGrade);

            string gradeName = course.GetGradeType(0);

            Assert.That(gradeName, Is.EqualTo("Lab"));
        }

        [Test]
        public void GetCourseScoreOneGrade()
        {
            Course newCourse = new Course("Science", "Sci2000");

            SimpleGrade simpGrade = new SimpleGrade("Test", 2, 100);
            
            newCourse.AddGrade(simpGrade);

            simpGrade.Scores[0].UpdatePoints(DateTime.Today, 100);
            simpGrade.Scores[1].UpdatePoints(DateTime.Today, 90);

            Assert.That(newCourse.CurrentGrade, Is.EqualTo(95).Within(0.2));
        }

        [Test]
        public void GetGradeScore1Grade()
        {
            Course newCourse = new Course("Science", "Sci2000");

            SimpleGrade simpGrade = new SimpleGrade("Test", 2, 100);

            newCourse.AddGrade(simpGrade);

            simpGrade.Scores[0].UpdatePoints(DateTime.Today, 100);
            simpGrade.Scores[1].UpdatePoints(DateTime.Today, 90);

            Assert.That(newCourse.GetGradeScore(0), Is.EqualTo(95).Within(0.2));
        }

        [Test]
        public void GetCourseGrade2Simple1Dropping()
        {
            Course newCourse = new Course("Science", "Sci2000");

            SimpleGrade simpGrade = new SimpleGrade("Test", 2, 100);
            SimpleGrade simpGrade2 = new SimpleGrade("Quiz", 2, 50);
            SimpleGradeDroppingScores simpGrade3 = new SimpleGradeDroppingScores("Lab Report", 3, 25, 1);

            newCourse.AddGrade(simpGrade);
            newCourse.AddGrade(simpGrade2);
            newCourse.AddGrade(simpGrade3);

            simpGrade.Scores[0].UpdatePoints(DateTime.Today, 100);
            simpGrade.Scores[1].UpdatePoints(DateTime.Today, 90);

            simpGrade2.Scores[0].UpdatePoints(DateTime.Today, 50);
            simpGrade2.Scores[1].UpdatePoints(DateTime.Today, 45);

            simpGrade3.Scores[0].UpdatePoints(DateTime.Today, 25);
            simpGrade3.Scores[1].UpdatePoints(DateTime.Today, 25);
            simpGrade3.Scores[2].UpdatePoints(DateTime.Today, 20);

            Assert.That(newCourse.CurrentGrade, Is.EqualTo(96).Within(0.3));
        }

        [Test]
        public void GetCourseGrade2Simple()
        {
            Course newCourse = new Course("Science", "Sci2000");

            SimpleGrade simpGrade = new SimpleGrade("Test", 2, 100);
            SimpleGrade simpGrade2 = new SimpleGrade("Quiz", 2, 50);

            newCourse.AddGrade(simpGrade);
            newCourse.AddGrade(simpGrade2);

            simpGrade.Scores[0].UpdatePoints(DateTime.Today, 100);
            simpGrade.Scores[1].UpdatePoints(DateTime.Today, 90);

            simpGrade2.Scores[0].UpdatePoints(DateTime.Today, 50);
            simpGrade2.Scores[1].UpdatePoints(DateTime.Today, 45);

            Assert.That(newCourse.CurrentGrade, Is.EqualTo(95).Within(0.2));
        }

        [Test]
        public void LiveCourseTesting()
        {
            Course newCourse = new Course("Science", "Sci2000");

            SimpleGrade presentation = new SimpleGrade("Presentation", 13, 11.5);
            SimpleGrade test = new SimpleGrade("Test", 3, 100);
            SimpleGrade project = new SimpleGrade("Project", 1, 50);

            newCourse.AddGrade(presentation);
            newCourse.AddGrade(test);
            newCourse.AddGrade(project);


            for (int i = 0; i < 12; i++)
            {
                presentation.Scores[i].UpdatePoints(DateTime.Today, 11.5);
            }

            presentation.Scores[11].UpdatePoints(DateTime.Today, 0);
            presentation.Scores[12].UpdatePoints(DateTime.Today, 11);

            test.Scores[0].UpdatePoints(DateTime.Today, 88);
            test.Scores[1].UpdatePoints(DateTime.Today, 90);
            test.Scores[2].UpdatePoints(DateTime.Today, 82);

            project.Scores[0].UpdatePoints(DateTime.Today, 50);

            Assert.That(newCourse.CurrentGrade, Is.EqualTo(89.6).Within(0.1));

        }
    }
}
