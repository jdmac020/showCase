using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public class WeightedGradeDroppingScores : WeightedGrade
    {
        private List<Score> countedScores;
        public int ScoresDropped { get; }
        public List<Score> CountedScores { get {return GetCountedScores();} }

        public WeightedGradeDroppingScores(string gradeName, int totalScores, double valuePerScore, int scoresDropped, double weightedValue) : 
            base(gradeName, totalScores, valuePerScore, weightedValue)
        {
            ScoresDropped = scoresDropped;
        }

        protected void CalculateCountedScores()
        {

            if (countedScores == null)
            {
                List<Score> countedScoresNew = Scores;

                for (int i = 0; i < ScoresDropped; i++)
                {
                    Score lowScore = Scores.Min();
                    countedScoresNew.Remove(lowScore);
                }

                countedScores = countedScoresNew;
            }
        }

        protected List<Score> GetCountedScores()
        {
            CalculateCountedScores();
            return countedScores;
        }

        //protected override void RefreshTotals()
        //{
        //    CountedScores = CalculateCountedScores();
        //    CalculatePointsPossible();
        //    CalculatePointsEarned();
        //    CalculateCurrentGrade();
        //}

        protected override void CalculatePointsPossible()
        {
            int scoresGraded = 0;

            foreach (Score score in CountedScores)
            {
                if (score.DateGraded != default(DateTime))
                {
                    scoresGraded += 1;
                }
            }

            pointsPossible = ValuePerScore * scoresGraded;
        }

        protected override void CalculatePointsEarned()
        {
            double pointsEarnedNow = 0;

            foreach (Score score in CountedScores)
            {
                pointsEarnedNow += score.PointsEarned;
            }

            pointsEarned = pointsEarnedNow;
        }
    }
}
