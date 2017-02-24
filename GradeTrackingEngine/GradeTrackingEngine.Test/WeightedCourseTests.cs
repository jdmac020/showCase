using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GradeTrackingEngine.Test
{
    [TestFixture]
    class WeightedCourseTests
    {
        [Test]
        public void WeightedGradeTotal()
        {
            CourseWeighted course = new CourseWeighted("C#", "CSCI1630");

            WeightedGrade test = new WeightedGrade("Test", 1, 100, .2);
            WeightedGrade midTerm = new WeightedGrade("Midterm", 1, 100, .2);
            WeightedGrade lab = new WeightedGrade("Lab", 1, 100, .2);
            WeightedGrade final = new WeightedGrade("Final", 1, 100, .25);
            WeightedGrade quiz = new WeightedGrade("Quiz", 1, 100, .15);

            course.AddGrade(test);
            course.AddGrade(midTerm);
            course.AddGrade(lab);
            course.AddGrade(final);
            course.AddGrade(quiz);

            test.Scores[0].UpdatePoints(DateTime.Today, 100);
            midTerm.Scores[0].UpdatePoints(DateTime.Today, 100);
            lab.Scores[0].UpdatePoints(DateTime.Today, 100);
            final.Scores[0].UpdatePoints(DateTime.Today, 100);
            quiz.Scores[0].UpdatePoints(DateTime.Today, 100);

            Assert.That(course.CurrentGrade, Is.EqualTo(100));
        }

        [Test]
        public void WeightedGradeTotalProgressCheck()
        {
            CourseWeighted course = new CourseWeighted("C#", "CSCI1630");

            WeightedGrade test = new WeightedGrade("Test", 1, 100, .2);
            WeightedGrade midTerm = new WeightedGrade("Midterm", 1, 100, .2);
            WeightedGrade lab = new WeightedGrade("Lab", 1, 100, .2);
            WeightedGrade final = new WeightedGrade("Final", 1, 100, .25);
            WeightedGrade quiz = new WeightedGrade("Quiz", 1, 100, .15);

            course.AddGrade(test);
            course.AddGrade(midTerm);
            course.AddGrade(lab);
            course.AddGrade(final);
            course.AddGrade(quiz);

            test.Scores[0].UpdatePoints(DateTime.Today, 100);
            midTerm.Scores[0].UpdatePoints(DateTime.Today, 100);
            lab.Scores[0].UpdatePoints(DateTime.Today, 100);
            final.Scores[0].UpdatePoints(DateTime.Today, 100);
            //quiz.Scores[0].UpdatePoints(DateTime.Today, 100);

            Assert.That(course.CurrentGrade, Is.EqualTo(100).Within(0.1));
        }

        [Test]
        public void WeightedGradeMultipleGradesStatusCheck()
        {
            CourseWeighted course = new CourseWeighted("C#", "CSCI1630");

            WeightedGrade test = new WeightedGrade("Test", 1, 100, .2);
            WeightedGrade midTerm = new WeightedGrade("Midterm", 1, 100, .2);
            WeightedGrade lab = new WeightedGrade("Lab", 3, 100, .2);
            WeightedGrade final = new WeightedGrade("Final", 1, 100, .25);
            WeightedGrade quiz = new WeightedGrade("Quiz", 4, 100, .15);

            course.AddGrade(test);
            course.AddGrade(midTerm);
            course.AddGrade(lab);
            course.AddGrade(final);
            course.AddGrade(quiz);

            test.Scores[0].UpdatePoints(DateTime.Today, 90);
            midTerm.Scores[0].UpdatePoints(DateTime.Today, 85);
            lab.Scores[0].UpdatePoints(DateTime.Today, 92);
            lab.Scores[1].UpdatePoints(DateTime.Today, 95);
            lab.Scores[2].UpdatePoints(DateTime.Today, 93);
            //final.Scores[0].UpdatePoints(DateTime.Today, 100);
            quiz.Scores[0].UpdatePoints(DateTime.Today, 75);
            quiz.Scores[1].UpdatePoints(DateTime.Today, 85);
            quiz.Scores[2].UpdatePoints(DateTime.Today, 86);


            Assert.That(course.CurrentGrade, Is.EqualTo(88).Within(0.1));
        }
    }
}
