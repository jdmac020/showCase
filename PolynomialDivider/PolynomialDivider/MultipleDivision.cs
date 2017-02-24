using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PolynomialDivider.Calculator;

namespace PolynomialDivider
{
    class MultipleDivision 
    {
        public int ListSize { get; }
        public double[] Divisors { get; private set; }

        public double[] Remainders { get; private set; }

        public MultipleDivision(int listIn)
        {
            ListSize = listIn;
            Divisors = new double[ListSize];
            Remainders = new double[ListSize];
        }

        public void LoadDivisors()
        {
            int zero = 0;
            for (int d = 0; d <= ListSize -1; d++)
            {
                zero++;

                Divisors[d] = GetDouble(CheckFraction($"zero #{zero}"));
                
            }
        }

        public void DivideList(Polynomial dividend)
        {
            int degree = dividend.Degree;

            foreach (double divisor in Divisors)
            {
                double bottom = dividend.Coefficients[degree];
                double top = 0;
                int divisorCount = 0;

                for (int i = 1; i < dividend.TotalTerms; i++)
                {
                    top = bottom * divisor;
                    bottom = top + dividend.Coefficients[degree - i];
                }

                Remainders[divisorCount] = bottom;
                divisorCount++;
            }
        }

        
    }
}
