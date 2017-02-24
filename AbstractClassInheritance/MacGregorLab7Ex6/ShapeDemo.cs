using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ShapeDemo
{
    /* Author:   Johnathan MacGregor
     * Date:     10/20/16
     * Lab:      Lab7Ch10Ex6
     * Purposes: Have the user choose one of three shapes, then input dimensions necessary to return that shape's area.
     *           Program goal is to demonstrate inheritance from an abstract class.
     */
    class ShapeDemo
    {
        static void Main()
        {
            MenuLoop();
        }

        // Main loop for user interface, displays available shape options and loops until user chooses to exits.
        private static void MenuLoop()
        {
            string userEntry = "";

            while (userEntry != "exit")
            {
                DisplayHeader();

                userEntry = GetUserEntry();

                switch (userEntry)
                {
                    case "1":
                        DisplayShape(CreateTriangle());
                        break;

                    case "2":
                        DisplayShape(CreateRectangle());
                        break;

                    case "3":
                        DisplayShape(CreateSquare());
                        break;
                        
                    case "exit":
                        DisplayHeader();
                        WriteLine("Goodbye!");
                        PauseToRead();
                        break;
                        
                    default:
                        DisplayHeader();
                        WriteLine("Sorry, that's not a recognized option...please try again!");
                        PauseToRead();
                        break;
                }
            }
        }

        private static string GetUserEntry()
        {
            WriteLine("Please Choose The Type of Shape You'd Like to Form.");
            WriteLine();
            WriteLine("1: Triangle");
            WriteLine("2: Rectange");
            WriteLine("3: Square");
            WriteLine();
            Write("Enter Your Choice From Above or <exit> to Quit: ");

            return ReadLine();
        }

        // Clears the console and displays the header
        private static void DisplayHeader()
        {
            Clear();

            WriteLine("          *** *** *** Fun With Shapes *** *** ***");
            WriteLine("               A Learning Program for Fall16     ");
            WriteLine();
            WriteLine();
        }

        // Tacked on the end of outputs to allow user to read prior to continuing
        private static void PauseToRead()
        {
            WriteLine();
            Write("Press <enter> to Continue...");
            ReadLine();
        }

        // Displays information about the shape based, accepting the base class as parameter per assignment
        private static void DisplayShape(GeometricShape shape)
        {
            string type = shape.GetType().ToString(); // Originally inside the the string below, decided to separate for legibility
            type = type.Substring(10, type.Length - 10); // Split this off from the initialization above to create two simple thoughts instead of one long one

            DisplayHeader();

            WriteLine($"Your {type} has a height of {shape.Height} units and a width of {shape.Width} units.");
            WriteLine($"Total area is {shape.Area} units squared.");
            
            PauseToRead();
        }

        // Generic customizable method to get the measurements for shapes.
        private static double GetMeasurement(string measurement)
        {
            double measurementValue;

            DisplayHeader();

            Write($"Please enter the {measurement}: ");
            double.TryParse(ReadLine(), out measurementValue);

            return measurementValue;
        }

        // Creates instance of triangle class.
        private static Triangle CreateTriangle()
        {
            return new Triangle(GetMeasurement("height"), GetMeasurement("base"));
        }

        // Creates instance of rectangle class.
        private static Rectangle CreateRectangle()
        {
            return new Rectangle(GetMeasurement("height"), GetMeasurement("width"));
        }

        // Creates instance of square class.
        private static Square CreateSquare()
        {
            return new Square(GetMeasurement("length"));
        }

        
    }
}
