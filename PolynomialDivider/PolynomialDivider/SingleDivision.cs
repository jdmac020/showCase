using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialDivider
{
    class SingleDivision
    {
        public double Divisor { get; }
        public double Remainder { get; private set; }
        public double[] RemainderCoefficients { get; private set; }

        public SingleDivision(double divisorIn)
        {
            Divisor = divisorIn;
        }

        private void CreateRemainderArray(Polynomial dividend)
        {
            RemainderCoefficients = new double[dividend.Degree];
        }

        public void DivideOnce(Polynomial dividend)
        {
            int degree = dividend.Degree;
            double bottom = dividend.Coefficients[degree];
            double top = 0;

            CreateRemainderArray(dividend);

            int coefficientCount = RemainderCoefficients.Length - 1;

            RemainderCoefficients[coefficientCount] = bottom;

            for (int i = 1; i < dividend.TotalTerms; i++)
            {
                coefficientCount--;

                if (coefficientCount < 0)
                {
                    top = bottom * Divisor;
                    bottom = top + dividend.Coefficients[degree - i];
                    Remainder = bottom;
                }
                else
                {
                    top = bottom * Divisor;
                    bottom = top + dividend.Coefficients[degree - i];
                    RemainderCoefficients[coefficientCount] = bottom;
                }
                
            }
            
        }
    }
}
