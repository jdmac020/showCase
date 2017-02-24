using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialDivider
{
    class Quotient : Polynomial
    {
        public double Remainder { get; }

        public double Divisor { get; }

        public string RemainderDisplay { get { return GetRemainderDisplay(); } }
        public string DivisorDisplay { get { return GetDivisorDisplay(); } }

        public Quotient(SingleDivision divisor) : base(divisor.RemainderCoefficients.Length - 1, divisor.RemainderCoefficients)
        {
            Divisor = divisor.Divisor;
            Remainder = divisor.Remainder;
        }

        private string GetDivisorDisplay()
        {
            if (Divisor > 0)
            {
                return $"(x - {Divisor}) * ";
            }
            else
            {
                return $"(x + {Divisor}) * ";
            }
        }

        private string GetRemainderDisplay()
        {
            return $" + ({Remainder})";
        }

        protected override StringBuilder BuildDisplayString()
        {
            StringBuilder displayString = new StringBuilder();

            displayString.Append(DivisorDisplay);
            displayString.Append("(");

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
                if (Coefficients[term] > 0 && term != Degree)
                {
                    displayString.Append("+");
                    displayString.Append(Coefficients[term]);
                    displayString.Append(exponentNotation);
                    displayString.Append(" ");
                }
                else if (Coefficients[term] >= 0 && term == 0)
                {
                    displayString.Append("+");
                    displayString.Append(Coefficients[term]);
                    displayString.Append(" ");
                }
                else if (Coefficients[term] <= 0 && term == 0)
                {
                    displayString.Append(Coefficients[term]);
                }
                else
                {
                    displayString.Append(Coefficients[term]);
                    displayString.Append(exponentNotation);
                    displayString.Append(" ");
                }
                */

            }

            if (Coefficients[0] == 0)
            {
                displayString.Remove(displayString.Length, -2);
            }

            displayString.Append(")");

            if (Remainder != 0)
            {
                displayString.Append(RemainderDisplay);
            }

            return displayString;
        }
    }
}
