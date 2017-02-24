using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static PolynomialDivider.Calculator;
using static PolynomialDivider.EnumExtensions;

namespace PolynomialDivider
{
    class Polynomial
    {
        public enum Exponents
        {
            [Description("x")]
            POWER1 = 1,

            [Description("x^2")]
            SQUARED = 2,

            [Description("x^3")]
            CUBED = 3,

            [Description("x^4")]
            POWER4 = 4,

            [Description("x^5")]
            POWER5 = 5,

            [Description("x^6")]
            POWER6 = 6,

            [Description("x^7")]
            POWER7 = 7,

            [Description("x^8")]
            POWER8 = 8,

            [Description("x^9")]
            POWER9 = 9,

            [Description("x^10")]
            POWER10 = 10,
        }

        public double[] Coefficients { get; }

        public int Degree { get; }
        public int TotalTerms { get { return Degree + 1; } }
        public StringBuilder DisplayString { get { return BuildDisplayString(); } }

        public Polynomial()
        {

        }

        public Polynomial(int degreeIn)
        {
            Degree = degreeIn;
            Coefficients = new double[TotalTerms];
        }

        public Polynomial(int degreeIn, double[] remainderCoefficients)
        {
            Degree = degreeIn;
            Coefficients = remainderCoefficients;
        }

        public void LoadTerms()
        {
            for (int d = Degree; d > -1; d--)
            {
                if (d != 0)
                {
                    Coefficients[d] = GetDouble(CheckFraction($"coefficient for the {d} degree term"));
                }
                else
                {
                    Coefficients[d] = GetDouble(CheckFraction("the constant term"));
                }
            }
        }
        
        protected virtual StringBuilder BuildDisplayString()
        {
            StringBuilder displayString = new StringBuilder();

            for (int term = Degree; term > -1; term--)
            {
                Exponents exponent = (Exponents)term;

                string exponentNotation = exponent.GetDescription();

                if (Coefficients[term] != 0 && term == Degree)
                {
                    if (Coefficients[term] == 1)
                    {
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    else
                    {
                        displayString.Append(Coefficients[term]);
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    
                }
                else if (Coefficients[term] > 0 && term == 0)
                {
                    displayString.Append("+");
                    displayString.Append(Coefficients[term]);
                }
                else if (Coefficients[term] < 0 && term == 0)
                {
                    displayString.Append(Coefficients[term]);
                }
                else if (Coefficients[term] > 0)
                {
                    if (Coefficients[term] == 1)
                    {
                        displayString.Append("+");
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    else
                    {
                        displayString.Append("+");
                        displayString.Append(Coefficients[term]);
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    
                }
                else if (Coefficients[term] < 0)
                {
                    if (Coefficients[term] == -1)
                    {
                        displayString.Append("-");
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    else
                    {
                        displayString.Append(Coefficients[term]);
                        displayString.Append(exponentNotation);
                        displayString.Append(" ");
                    }
                    
                }

                else
                {

                }
                /*
                if (Coefficients[term] >= 0 && term != Degree)
                {
                    displayString.Append("+");
                    displayString.Append(Coefficients[term]);
                    displayString.Append(exponentNotation);
                }
                else if (Coefficients[term] >= 0 && term == 0)
                {
                    displayString.Append("+");
                    displayString.Append(Coefficients[term]);
                }
                else if (Coefficients[term] <= 0 && term == 0)
                {
                    displayString.Append(Coefficients[term]);
                }
                else
                {
                    displayString.Append(Coefficients[term]);
                    displayString.Append(exponentNotation);
                }
                */
            }
            return displayString;
        }

    }
}
