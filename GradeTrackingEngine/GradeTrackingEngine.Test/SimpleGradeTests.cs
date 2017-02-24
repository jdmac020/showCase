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
    public class SimpleGradeTests
    {


        [Test]
        public void GradeCreation()
        {
            SimpleGrade grade = new SimpleGrade("Quiz", 7, 100);

            Assert.That(grade.Scores.Count, Is.EqualTo(7));
        }

        [Test]
        public void NoScoreUpdate()
        {
            SimpleGrade grade = new SimpleGrade("Quiz", 7, 100);

            Assert.That(grade.CurrentGrade, Is.EqualTo(0).Within(0.001));
        }

        [Test]
        public void TwoScoresUpdated()
        {
            SimpleGrade grade = new SimpleGrade("Quiz", 7, 100);

            grade.Scores[0].UpdatePoints(DateTime.Today, 100);
            grade.Scores[1].UpdatePoints(DateTime.Today, 90);

           // grade.RefreshTotals();

            //Assert.That(grade.PointsPossible, Is.EqualTo(200));
            //Assert.That(grade.PointsEarned, Is.EqualTo(190));
            Assert.That(grade.CurrentGrade, Is.EqualTo(95));
        }

        [Test]
        public void TwoNonConcurrentScoresUpdated()
        {
            SimpleGrade grade = new SimpleGrade("Quiz", 7, 100);

            grade.Scores[0].UpdatePoints(DateTime.Today, 100);
            grade.Scores[6].UpdatePoints(DateTime.Today, 90);

          //  grade.RefreshTotals();

            Assert.That(grade.CurrentGrade, Is.EqualTo(95));
        }

        [Test]
        public void TwoZeroScoresUpdated()
        {
            SimpleGrade grade = new SimpleGrade("Quiz", 7, 100);

            grade.Scores[0].UpdatePoints(DateTime.Today, 0);
            grade.Scores[1].UpdatePoints(DateTime.Today, 0);

            Assert.That(grade.CurrentGrade, Is.EqualTo(0).Within(0.001));
        }

        [Test]
        public void DroppingOneScoreControl()
        {
            SimpleGradeDroppingScores grade = new SimpleGradeDroppingScores("Lab", 7, 100, 0);
            
            for (int i = 0; i < 6; i++)
            {
                grade.Scores[i].UpdatePoints(DateTime.Today, 100);
            }

            grade.Scores[6].UpdatePoints(DateTime.Today, 95);

          //  grade.RefreshTotals();

            Assert.That(grade.CurrentGrade, Is.EqualTo(99.28).Within(0.1));
        }

        [Test]
        public void DroppingOneScore()
        {
            SimpleGradeDroppingScores grade = new SimpleGradeDroppingScores("Lab", 7, 100, 1);

            for (int i = 0; i < 6; i++)
            {
                grade.Scores[i].UpdatePoints(DateTime.Today, 100);
            }

            grade.Scores[6].UpdatePoints(DateTime.Today, 95);

         //   grade.RefreshTotals();

            Assert.That(grade.CurrentGrade, Is.EqualTo(100));
        }

        [Test]
        public void LiveScoreTesting()
        {

            SimpleGrade grade = new SimpleGrade("Presentation", 13, 11.5);

            for (int i = 0; i < 13; i++)
            {
                double score = 0;

                switch (i)
                {
                    case 0:
                        score = 11.5;
                        break;
                    case 1:
                        score = 11.5;
                        break;
                    case 2:
                        score = 11.5;
                        break;
                    case 3:
                        score = 11.5;
                        break;
                    case 4:
                        score = 11;
                        break;
                    case 5:
                        score = 11.5;
                        break;
                    case 6:
                        score = 0;
                        break;
                    case 7:
                        score = 11.5;
                        break;
                    case 8:
                        score = 11.5;
                        break;
                    case 9:
                        score = 11.5;
                        break;
                    case 10:
                        score = 11.5;
                        break;
                    case 11:
                        score = 11.5;
                        break;
                    case 12:
                        score = 11.5;
                        break;
                }

                grade.Scores[i].UpdatePoints(DateTime.Today, score);
            }

         //   grade.RefreshTotals();
            
            //Assert.That(grade.PointsEarned, Is.EqualTo(137.5));
            //Assert.That(grade.PointsPossible, Is.EqualTo(149.5));
            Assert.That(grade.CurrentGrade, Is.EqualTo(92).Within(0.1));
        }

        [Test]
        public void TestDropWhenAllSameScore()
        {
            SimpleGradeDroppingScores grade = new SimpleGradeDroppingScores("Quiz", 3, 100, 1);

            grade.Scores[0].UpdatePoints(DateTime.Parse("12/03/16"), 100);
            grade.Scores[1].UpdatePoints(DateTime.Parse("12/04/16"), 100);
            grade.Scores[2].UpdatePoints(DateTime.Parse("12/05/16"), 100);

         //   grade.RefreshTotals();

            Assert.That(grade.CountedScores.Count, Is.EqualTo(2));
            //Assert.That(grade.Scores[1].DateGraded, Is.EqualTo(DateTime.Parse("12/04/16")));
        }
    }
}
