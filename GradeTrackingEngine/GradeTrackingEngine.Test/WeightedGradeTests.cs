using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GradeTrackingEngine.Test
{
    [TestFixture]
    class WeightedGradeTests
    {
        [Test]
        public void CorrectlyWeighted100()
        {
            WeightedGrade grade = new WeightedGrade("Test", 1, 100, .2);

            grade.Scores[0].UpdatePoints(DateTime.Today, 100);

           // grade.RefreshTotals();

            Assert.That(grade.WeightedTotal, Is.EqualTo(20));
        }

        [Test]
        public void CorrectlyWeighted82()
        {
            WeightedGrade grade = new WeightedGrade("Test", 1, 100, .2);

            grade.Scores[0].UpdatePoints(DateTime.Today, 82);

          //  grade.RefreshTotals();

            Assert.That(grade.WeightedTotal, Is.EqualTo(16.4).Within(0.1));
        }

        [Test]
        public void DroppingOneWeightedScore()
        {
            WeightedGradeDroppingScores grade = new WeightedGradeDroppingScores("Lab", 7, 100, 1, .15);

            for (int i = 0; i < 6; i++)
            {
                grade.Scores[i].UpdatePoints(DateTime.Today, 100);
            }

            grade.Scores[6].UpdatePoints(DateTime.Today, 95);

          //  grade.RefreshTotals();

            //Assert.That(grade.PointsPossible, Is.EqualTo(600)); // null object
            Assert.That(grade.PointsEarned, Is.EqualTo(600));
            //Assert.That(grade.CurrentGrade, Is.EqualTo(100));
        }

        [Test]
        public void DroppingOneWeightedScoreWeighted()
        {
            WeightedGradeDroppingScores grade = new WeightedGradeDroppingScores("Lab", 7, 100, 1, .15);

            for (int i = 0; i < 6; i++)
            {
                grade.Scores[i].UpdatePoints(DateTime.Today, 100);
            }

            grade.Scores[6].UpdatePoints(DateTime.Today, 95);

          //  grade.RefreshTotals();

            Assert.That(grade.WeightedTotal, Is.EqualTo(15));
            Assert.That(grade.CurrentGrade, Is.EqualTo(100));
            //Assert.That(grade.WeightValue, Is.EqualTo(0.15));
        }

        [Test]
        public void TestingLiveGrades()
        {
            WeightedGradeDroppingScores grade = new WeightedGradeDroppingScores("Lab", 7, 100, 1, .15);

            for (int i = 0; i < 7; i++)
            {
                double score = 0;

                switch (i)
                {
                    case 0:
                        score = 88;
                        break;
                    case 1:
                        score = 83;
                        break;
                    case 2:
                        score = 34;
                        break;
                    case 3:
                        score = 100;
                        break;
                    case 4:
                        score = 100;
                        break;
                    case 5:
                        score = 61;
                        break;
                    case 6:
                        score = 100;
                        break;
                }

                grade.Scores[i].UpdatePoints(DateTime.Today, score);
            }

         //   grade.RefreshTotals();

            Assert.That(grade.CountedScores.Count, Is.EqualTo(6));
            Assert.That(grade.CountedScores[2].PointsEarned, Is.EqualTo(100));
            Assert.That(grade.CurrentGrade, Is.EqualTo(88.7).Within(0.1));
            Assert.That(grade.WeightedTotal, Is.EqualTo(13.3));
        }
    }
}
