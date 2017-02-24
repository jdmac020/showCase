using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public interface ICourse
    {
        string CourseName { get; }
        string CourseNumber { get;}
        double PointsPossible { get; }
        double PointsEarned { get; }
        double CurrentGrade { get; }
    }
}
