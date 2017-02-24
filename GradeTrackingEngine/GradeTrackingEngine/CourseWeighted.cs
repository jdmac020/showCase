using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public class CourseWeighted : Course
    {
        private double weightPossible;
        private double weightedTotal;
        public double WeightedTotal { get { return GetWeightedTotal(); } }
        public double WeightPossible { get { return GetWeightedPossible(); } }
        public CourseWeighted(string name, string number) : base(name, number)
        {

        }

        protected override void CalculateCurrentGrade()
        {
            currentGrade = (WeightedTotal/WeightPossible) * 100;
        }

        protected double GetWeightedTotal()
        {
            CalculateWeightedTotal();
            return weightedTotal;
        }

        protected void CalculateWeightedTotal()
        {
            foreach (WeightedGrade grade in GradeList)
            {
                weightedTotal += grade.WeightedTotal;
            }
        }

        protected double GetWeightedPossible()
        {
            CalculateWeightPossible();
            return weightPossible;
        }

        protected void CalculateWeightPossible()
        {
            double weightValues = 0;

            foreach (WeightedGrade grade in GradeList)
            {
                if (grade.PointsPossible != 0)
                {
                    weightValues += grade.WeightValue;
                }
                
            }

            weightPossible = weightValues*100;
        }
    }
}
