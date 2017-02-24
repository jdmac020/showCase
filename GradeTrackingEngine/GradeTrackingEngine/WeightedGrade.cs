using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public class WeightedGrade : GradeType
    {
        private double weightedTotal;
        public double WeightValue { get; }
        public double WeightedTotal { get { return GetWeightedTotal(); }  }

        public WeightedGrade(string gradeName, int totalScores, double valuePerScore, double weightValue) : base(gradeName, totalScores, valuePerScore)
        {
            WeightValue = weightValue;
        }

        protected virtual void CalculateWeightedTotal()
        {
            if (CurrentGrade != 0.0001)
            {
                weightedTotal = currentGrade * WeightValue;
            }
            else
            {
                weightedTotal = 0.0001;
            }
        }

        protected double GetWeightedTotal()
        {
            CalculateWeightedTotal();
            return weightedTotal;
        }

        public override void EditScore()
        {
            // Does Nothing Yet
        }
    }
}
