using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public abstract class GradeType : IGrade
    {
        protected double pointsPossible;
        protected double pointsEarned;
        protected double currentGrade;
        public string GradeName { get; set; }
        public int TotalScores { get; set; }
        public double ValuePerScore { get;  set; }
        public double PointsPossible { get { return GetPointsPossible(); } }
        public double PointsEarned { get { return GetPointsEarned(); } }
        public double CurrentGrade { get { return GetCurrentGrade(); } }
        public List<Score> Scores { get; }

        protected GradeType(string gradeName, int totalScores, double valuePerScore)
        {
            GradeName = gradeName;
            TotalScores = totalScores;
            ValuePerScore = valuePerScore;

            Scores = CreateScoresList();
        }

        /// <summary>
        /// Must Be Called Prior to Displaying Grade Properties to Receive Accurate Data.
        /// <para>Should include CalculatePointsPossible(), CalculatePointsEarned() at minimum for non-dropping grades, 
        /// andGenerateCountedScores() for dropping grades.</para>
        /// </summary>
        protected virtual void RefreshTotals()
        {
            //CalculatePointsPossible();
            //CalculatePointsEarned();
            //CalculateCurrentGrade();
        }

        protected double GetPointsPossible()
        {
            CalculatePointsPossible();
            return pointsPossible;
        }

        protected double GetPointsEarned()
        {
            CalculatePointsEarned();
            return pointsEarned;
        }

        protected double GetCurrentGrade()
        {
            CalculateCurrentGrade();
            return currentGrade;
        }

        /// <summary>
        /// Allows user to access and edit Score data.
        /// </summary>
        public abstract void EditScore();

        /// <summary>
        /// Internal method used to update the property prior to display/use.
        /// </summary>
        protected virtual void CalculatePointsPossible()
        {
            int scoresGraded = 0;

            foreach (Score score in Scores)
            {
                if (score.DateGraded != default(DateTime))
                {
                    scoresGraded += 1;
                }
            }

            pointsPossible = ValuePerScore * scoresGraded;
        }

        /// <summary>
        /// Internal method used to update the property prior to display/use.
        /// </summary>
        protected virtual void CalculatePointsEarned()
        {
            foreach (Score score in Scores)
            {
                pointsEarned += score.PointsEarned;

            }
        }

        /// <summary>
        /// Internal method used to create the list of scores based on the TotalScores property.
        /// </summary>
        /// <returns></returns>
        protected List<Score> CreateScoresList()
        {
            List<Score> scores = new List<Score>();

            for (int i = 0; i < TotalScores; i++)
            {
                scores.Add(new Score(ValuePerScore));
            }

            return scores;
        }
        
        /// <summary>
        /// Internal method used to update the current grade 
        /// </summary>
        /// <returns></returns>
        protected virtual void CalculateCurrentGrade()
        {

            double grade = (PointsEarned / PointsPossible) * 100;

            if (grade > 0)
            {
                currentGrade = grade;
            }
            else
            {
                currentGrade = 0.0001;
            }
        }
    }
}
