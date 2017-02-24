using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public interface IGrade
    {
        string GradeName { get; set; }
        int TotalScores { get; set; }
        double ValuePerScore { get; set; }
        double PointsPossible { get; }
        double PointsEarned { get; }
        double CurrentGrade { get; }
        List<Score> Scores { get; }
    }
}
