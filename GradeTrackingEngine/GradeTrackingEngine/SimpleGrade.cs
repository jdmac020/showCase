using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeTrackingEngine
{
    public class SimpleGrade : GradeType
    {

        public SimpleGrade(string gradeName, int totalScores, double valuePerScore) : base(gradeName, totalScores, valuePerScore)
        {

        }

        public override void EditScore()
        {
            // Does nothing yet...
        }
    }
}
