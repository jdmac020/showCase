using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public class Course : ICourse
    {
        protected double pointsPossible;
        protected double pointsEarned;
        protected double currentGrade;
        private List<GradeType> gradeDisplayList;
        public string CourseName { get; }
        public string CourseNumber { get; }
        public double PointsPossible { get {return GetPointsPossible();} }
        public double PointsEarned { get {return GetPointsEarned();} }
        public double CurrentGrade { get {return GetCurrentGrade();} }
        public List<GradeType> GradesDisplayList { get { return GetGradesDisplayList();} }
        protected List<GradeType> GradeList { get; set; }

        public Course(string name, string number)
        {
            CourseName = name;
            CourseNumber = number;
            GradeList = new List<GradeType>();
        }

        protected double GetPointsPossible()
        {
            CalculatePointsPossible();
            return pointsPossible;
        }

        protected void CalculatePointsPossible()
        {
            foreach (GradeType grade in GradeList)
            {
                pointsPossible += grade.PointsPossible;
            }
        }

        protected double GetPointsEarned()
        {
            CalculatePointsEarned();
            return pointsEarned;
        }

        protected void CalculatePointsEarned()
        {
            foreach (GradeType grade in GradeList)
            {
                pointsEarned += grade.PointsEarned;
            }
        }

        protected double GetCurrentGrade()
        {
            CalculateCurrentGrade();
            return currentGrade;
        }

        protected virtual void CalculateCurrentGrade()
        {
            currentGrade = (PointsEarned / PointsPossible) * 100;
        }

        public void AddGrade(GradeType grade)
        {
            GradeList.Add(grade);
        }

        public string GetGradeType(int gradeIndex)
        {
            return GradesDisplayList[gradeIndex].GradeName;
        }

        public double GetGradeScore(int gradeIndex)
        {
            return GradesDisplayList[gradeIndex].CurrentGrade;
        }

        protected List<GradeType> GetGradesDisplayList()
        {
            GenerateDisplayList();
            return gradeDisplayList;
        }

        protected void GenerateDisplayList()
        {
            List<GradeType> gradesDisplayListNew = GradeList;

            gradeDisplayList = gradesDisplayListNew;
        }
    }
}
