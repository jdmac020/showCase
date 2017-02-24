using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackingEngine
{
    public class Score : IComparable
    {
        public DateTime  DateGraded { get; private set; }
        public double PointsPossible { get; private set; }
        public double PointsEarned { get; private set; }
        public double GradePercent { get { return (PointsEarned/PointsPossible) * 100; } }

        public Score(double pointsPossible)
        {
            PointsPossible = pointsPossible;
        }

        public void UpdatePoints(DateTime dateGraded, double pointsEarned)
        {
            DateGraded = dateGraded;

            if (pointsEarned >= 0 && pointsEarned <= PointsPossible)
            {
                PointsEarned = pointsEarned;
            }
            else
            {
                throw new ArgumentOutOfRangeException("New Point Total Must Be Between 0 and " + this.PointsPossible);
            }
            
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Score otherScore = obj as Score;
            if (otherScore != null)
                return this.PointsEarned.CompareTo(otherScore.PointsEarned);
            else
                throw new ArgumentException("Object is not a Score");
        }
    }
}
