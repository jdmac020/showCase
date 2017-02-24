using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator2
{
    [Serializable]
    public class Grade
    {
        public List<double> Scores { get; set; }
        public string GradeType { get; set; }
        // flag if weighted as a single grade
        public bool WeightedAsSingle { get; set; }
        // decimal for weighted, integer for nonweighted
        public double Value { get; set; }
        public double PointsPossible { get { return CalculatePointsPossible(); } set { } }
        public double PointsEarned { get { return CalculuatePointsEarned(); } set { } }
        public double CurrentGrade { get { return (PointsEarned / PointsPossible); } set { } }
        
       
        public  Grade()
        {

        }

        public Grade(List<double> scores, string gradeType, double scoreValue, bool asSingle)
        {
            GradeType = gradeType;
            Scores = scores;
            WeightedAsSingle = asSingle;
            Value = scoreValue;
        }

        private double CalculatePointsPossible()
        {
            // if Value is greater than 1, it's not weighted--use count of scores * Value
            if (Value >= 1)
            {
                return Scores.Count * Value;
            }
            // if Value is less than 1, it's weighted--check to see if weighted as group
            else
            { 
                // if weighted as a single group, Value * 100 is points possible
                if (WeightedAsSingle == true)
                {
                    return Value * 100;
                }
                // if not weighted as single, the count of the scores * the Value, * 100 is points possible
                else
                {
                    return (Scores.Count * Value) * 100;
                }
            }
        }

        private double CalculuatePointsEarned()
        {
            // if Value is greater than 1, it's not weighted--use the sum of scores
            if (Value >= 1)
            {
                return Scores.Sum();
            }
            // if the value is less than 1, it's a weight--check if it's weighted as a single score
            else
            {
                // If it's weighted as a single score, average the scores and multiply by Value
                if (WeightedAsSingle == true)
                {
                    return (Scores.Sum() / Scores.Count) * Value;

                }
                // If not weighted individually, multiply sum of scores by the value
                else
                {
                    return Scores.Sum() * Value;
                }
            }
        }

    }
}
