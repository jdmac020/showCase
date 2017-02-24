using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PolynomialDivider
{
    class Calculator
    {
        
        static void Main()
        {
            string exit = "";

            DisplayHeader();

            Write("Are you doing single division or testing multiple zeroes?\n<single><multiple><exit>: ");
            exit = ReadLine();

            while (exit != "exit")
            {
                if (exit == "single")
                {
                    DisplayHeader();
                    Polynomial dividend = CreateDividend();
                    dividend.LoadTerms();

                    SingleDivision divisor = CreateDivisor();

                    divisor.DivideOnce(dividend);

                    Quotient quotient = CreateQuotient(divisor);

                    WriteLine(dividend.DisplayString + " divided by " + divisor.Divisor + "has a remainder of " + quotient.Remainder);
                    WriteLine();
                    WriteLine("The quotient polynomial is: " + quotient.DisplayString);

                    WriteLine();
                    WriteLine();

                    ReadLine();
                }
                else if (exit == "multiple")
                {
                    DisplayHeader();
                    Polynomial dividend = CreateDividend();
                    dividend.LoadTerms();

                    MultipleDivision divisorList = new MultipleDivision(GetInt(CheckFraction("number of zeroes")));

                    divisorList.LoadDivisors();

                    int count = 0;

                    foreach (double divisor in divisorList.Divisors)
                    {
                        
                        if (divisor == 0)
                        {
                            WriteLine($"Divisor {divisor} is a zero of {dividend.DisplayString}.");
                        }
                        else
                        {
                            WriteLine($"{dividend.DisplayString} divided by {divisor} has a remainder of {divisorList.Remainders[count]}");
                        }
                        count++;
                    }

                    ReadLine();
                }
                else
                {
                    DisplayHeader();
                    WriteLine("Sorry, that didn't come thru--try typing again!");
                    WriteLine();
                }

                DisplayHeader();
                Write("Are you doing single division or testing multiple zeroes?\n<single><multiple><exit>: ");
                exit = ReadLine();
            }
        }

        private static Quotient CreateQuotient(SingleDivision divisor)
        {
            return new Quotient(divisor);
        }

        private static SingleDivision CreateDivisor()
        {
            return new SingleDivision(GetInt(CheckFraction("divisor")));
        }

        private static Polynomial CreateDividend()
        {
            WriteLine("Please follow the directions to create your dividend polynomial!");

            return new Polynomial(GetInt(CheckFraction("dividend polynomial's degree")));
        }

        public static double GetDouble(string fractionCheck)
        {
            double doubleEntry;

            if (fractionCheck == "/")
            {
                double numerator;
                double denominator;

                Write($"Enter numerator: ");
                double.TryParse(ReadLine(), out numerator);
                Write($"Enter denominator: ");
                double.TryParse(ReadLine(), out denominator);

                doubleEntry = numerator / denominator;
            }

            double.TryParse(fractionCheck, out doubleEntry);

            return doubleEntry;
        }

        public static int GetInt(string fractionCheck)
        {
            int intEntry;

            if (fractionCheck == "/")
            {
                int numerator;
                int denominator;

                Write($"Enter numerator: ");
                int.TryParse(ReadLine(), out numerator);
                Write($"Enter denominator: ");
                int.TryParse(ReadLine(), out denominator);

                intEntry = numerator / denominator;
            }

            int.TryParse(fractionCheck, out intEntry);

            return intEntry;
        }

        public static string CheckFraction(string termType)
        {
            DisplayHeader();

            Write($"Enter your {termType}, or </> to enter a fraction: ");
            return ReadLine();
        }
        

        private static void DisplayHeader()
        {
            Clear();
            WriteLine("*** ** * ** *** Polynomial Divider 2.1 *** ** * ** ***");
            WriteLine("                   Synthetic Division                 ");
            WriteLine("                     JDM Publication                  ");
            WriteLine();
            WriteLine();
        }
    }
}
