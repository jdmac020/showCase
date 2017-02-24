using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator2
{
    [Serializable]
    public class Course
    {
        public List<Grade> GradesList { get; set; }
        public string Name { get; set; }
        public double CurrentGrade { get { return (PointsEarned / PointsPossible); } set { } }
        public double PointsPossible { get { return CalculatePointsPossible(); } set { } }
        public double PointsEarned { get { return CalculatePointsEarned(); } set { } }

        public Course()
        {

        }

        public Course(List<Grade> grades, string name)
        {
            Name = name;
            GradesList = grades;
        }

        private double CalculatePointsPossible()
        {
            double pointsPossible = 0;

            foreach (Grade grade in GradesList)
            {
                pointsPossible += grade.PointsPossible;
            }

            return pointsPossible;
        }

        private double CalculatePointsEarned()
        {
            double pointsEarned = 0;

            foreach (Grade grade in GradesList)
            {
                pointsEarned += grade.PointsEarned;
            }

            return pointsEarned;
        }
    }
}
