using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace GradeCalculator2
{
    class UserInterface
    {
        static void Main()
        {
            Persister<Course> savedCourses = new Persister<Course>("FallClasses");

            savedCourses.Load();

            if (savedCourses.SavedCourses.Count == 0)
            {
                OfferHelp();
                AddCourseLoop(savedCourses);
            }

            MenuLoop(savedCourses);


            // to do...
            // GPA



            ReadLine();
        }

        private static void DisplayHeader()
        {
            Clear();
            WriteLine("                 *** Welcome to Grade Checker 2.0 ***");
            WriteLine("                          A JDM Publication          ");
            WriteLine();
            WriteLine();
        }

        private static void PauseToRead()
        {
            Write("Press <enter> to continue...");
            ReadLine();
        }

        private static void OfferHelp()
        {
            DisplayHeader();

            Write("Do you want to see the help guide before starting? <y/n> ");

            if (ReadLine() == "y")
            {
                ShowAllHelp();
            }
        }

        private static void AddCourseLoop(Persister<Course> savedCourses)
        {
            string userInput = "";

            DisplayHeader();

            Write("Would You Like to Add a Course? <y/n>: ");
            userInput = ReadLine();
            DisplayHeader();

            if (userInput == "y")
            {
                while (userInput == "y")
                {
                    savedCourses.SavedCourses.Add(AddCourse());

                    DisplayHeader();

                    Write("Do you have another course to add? <y/n>: ");
                    userInput = ReadLine();
                    DisplayHeader();
                }
            }
        }

        private static void ShowHelp(string helpString)
        {
            DisplayHeader();
            WriteLine($"{helpString}");
            WriteLine();
            PauseToRead();
        }

        private static void ShowAllHelp()
        {
            ShowHelp(Help.overView);
            ShowHelp(Help.courseDescription);
            ShowHelp(Help.gradeDescription);
            ShowHelp(Help.enteringGrades);
            ShowHelp(Help.enteringScores);
            ShowHelp(Help.clearScores);
            ShowHelp(Help.deleteCourse);
            ShowHelp(Help.deleteAllCourses);
            ShowHelp(Help.displayGrades);
        }

        private static void MenuLoop(Persister<Course> savedCourses)
        {
            string userEntry = "";

            while (userEntry != "exit")
            {
                DisplayHeader();

                WriteLine("1: Add Scores to Existing Grade");
                WriteLine("2: Add Course to List");
                WriteLine("3: Clear Scores for Grade");
                WriteLine("4: Delete a Course");
                WriteLine("5: Delete All Courses");
                WriteLine("6: Display Grades");
                WriteLine("7: Display Help");
                WriteLine();

                Write("Please enter your selection or <exit> to leave: ");
                userEntry = ReadLine();

                switch (userEntry)
                {
                    case "1":
                        UpdateGrades(savedCourses.SavedCourses);
                        break;

                    case "2":
                        DisplayHeader();
                        savedCourses.SavedCourses.Add(AddCourse());
                        break;

                    case "3":
                        ClearGrades(savedCourses.SavedCourses);
                        break;

                    case "4":
                        RemoveCourse(savedCourses.SavedCourses);
                        break;

                    case "5":
                        ClearCourseList(savedCourses);
                        break;

                    case "6":
                        DisplayGrades(savedCourses.SavedCourses);
                        break;

                    case "7":
                        ShowAllHelp();
                        break;

                    case "exit":
                        DisplayHeader();
                        savedCourses.Save();
                        WriteLine("Goodbye!");
                        break;

                    default:
                        WriteLine("Sorry, that's not a valid option. Please choose again!");
                        break;
                }
            }
        }

        private static void DisplayGrades(List<Course> courses)
        {
            DisplayHeader();

            if (courses.Count <= 0)
            {
                WriteLine("You haven't added any courses yet--add from the menu to start seeing grade info!");
            }
            else
            {
                foreach (Course course in courses)
                {
                    if (course.CurrentGrade >= 0)
                    {

                        WriteLine(course.Name);
                        WriteLine();
                        foreach (Grade grade in course.GradesList)
                        {
                            WriteLine($"{grade.GradeType}s are worth {grade.Value} points and your current grade for {grade.GradeType}s is {grade.CurrentGrade:p0}; ");

                        }
                        WriteLine();
                        WriteLine($"The current overall grade is {course.CurrentGrade:p0}");
                        WriteLine();
                        WriteLine("*** ** * ** *** ** * ** *** ** * ** *** ** * ** *** ** * ** *** ** * ** ***");
                        WriteLine();

                    }
                    else
                    {
                        WriteLine();
                        WriteLine($"There is no grade info on {course.Name}. Add Scores from the Menu to get a grade!");

                    }
                }
            }

            WriteLine();
            PauseToRead();
        }

        private static void RemoveCourse(List<Course> courses)
        {
            DisplayHeader();

            if (courses.Count > 0)
            {
                courses.RemoveAt(ChooseCourse(courses));

                DisplayHeader();

                WriteLine("Course Has Been Removed.");
            }
            else
            {
                WriteLine("Looks like you don't have any courses--add one from the menu!");
                WriteLine();
            }
            PauseToRead();
            
        }

        private static void ClearCourseList(Persister<Course> savedCourses)
        {
            DisplayHeader();

            savedCourses.SavedCourses.Clear();
            WriteLine("Course List Has Been Cleared.");
            WriteLine();
            PauseToRead();
            Clear();

            AddCourseLoop(savedCourses);
        }

        private static void UpdateGrades(List<Course> courses)
        {
            int courseSelection = -1;
            int gradeSelection = -1;

            DisplayHeader();

            if (courses.Count > 0)
            {
                courseSelection = ChooseCourse(courses);

                if (courses[courseSelection].GradesList.Count > 0)
                {
                    gradeSelection = ChooseGrade(courses, courseSelection);

                    AddScores(courses[courseSelection].GradesList[gradeSelection]);
                }
                else
                {
                    WriteLine("Looks like you don't have any grades for this course--delete the course and recreate it with grades.");
                    WriteLine();
                    PauseToRead();
                }
            }
            else
            {
                WriteLine("Looks like you don't have any courses created--add one from the menu!");
                WriteLine();
                PauseToRead();
            }
            
        }

        private static int ChooseCourse(List<Course> courses)
        {
            int courseSelection = -1;

            DisplayHeader();

            WriteLine("These are your current courses. Please choose one to continue.");
            WriteLine();

            foreach (Course course in courses)
            {
                WriteLine($"{courses.IndexOf(course) + 1}: {course.Name}");
            }
            WriteLine();

            Write("Please enter the number of the course above: ");
            int.TryParse(ReadLine(), out courseSelection);

            return courseSelection - 1;

        }

        private static int ChooseGrade(List<Course> courses, int courseSelection)
        {
            int gradeSelection = -1;

            DisplayHeader();

            WriteLine("These are the current grade types in this course. Please choose one to continue.");
            WriteLine();

            foreach (Grade grade in courses[(courseSelection)].GradesList)
            {
                WriteLine($"{courses[(courseSelection)].GradesList.IndexOf(grade) + 1}: {grade.GradeType}");
            }
            WriteLine();

            Write("Please enter the number of the grade: ");
            int.TryParse(ReadLine(), out gradeSelection);

            return gradeSelection - 1;
        }

        private static void ClearScores(Grade grade)
        {
            grade.Scores.Clear();

            DisplayHeader();

            WriteLine($"All scores for {grade.GradeType} cleared.");

            Write("Do you want to enter new scores? <y/n>");

            if (ReadLine() == "y")
            {
                AddScores(grade);
            }

        }

        private static void ClearGrades(List<Course> courses)
        {
            int courseSelection = -1;
            int gradeSelection = -1;

            DisplayHeader();

            if (courses.Count > 0)
            {
                courseSelection = ChooseCourse(courses);

                if (courses[courseSelection].GradesList.Count > 0)
                {
                    gradeSelection = ChooseGrade(courses, courseSelection);

                    ClearScores(courses[courseSelection].GradesList[gradeSelection]);
                }
                else
                {
                    WriteLine("Looks like you don't have any grades for this course--delete the course and recreate it with grades.");
                    WriteLine();
                    PauseToRead();
                }
            }
            else
            {
                WriteLine("Looks like you don't have any courses created--add one from the menu!");
                WriteLine();
                PauseToRead();
            }
        }

        private static void AddScores(Grade grade)
        {
            double userEntry = 0;

            DisplayHeader();

            Write($"Please Enter Your Score for {grade.GradeType}: ");
            double.TryParse(ReadLine(), out userEntry);
            WriteLine();

            while (userEntry >= 0)
            {
                grade.Scores.Add(userEntry);
                Write($"Please Enter the Next Score for {grade.GradeType} or <-1> to exit: ");
                double.TryParse(ReadLine(), out userEntry);
                WriteLine();
            }
            WriteLine();
        }


        private static Course AddCourse()
        {
            Course newCourse = CreateCourse();
            string continueVariable = "";

            do
            {
                newCourse.GradesList.Add(AddGrade(GetGradeType(), GetScoreValue(), GetGroupWeight()));

                WriteLine();
                Write("Do you have another type of grade to enter? <y/n> ");
                continueVariable = ReadLine();

            } while (continueVariable == "y");

            WriteLine();


            return newCourse;

        }

        private static string GetGradeType()
        {
            string gradeType = "";

            Write("Please Enter the type of grade: ");
            gradeType = ReadLine();
            WriteLine();

            return gradeType;
        }

        private static double GetScoreValue()
        {
            double scoreValue;

            Write("Please enter the value of each score from your syllabus (100 for 100 points, or .2 for 20% of final grade): ");
            double.TryParse(ReadLine(), out scoreValue);
            WriteLine();

            return scoreValue;
        }

        private static bool GetGroupWeight()
        {
            Write("Do all scores in this grade type get weighted together (Ex, all quizzes averaged together are 15% of final grade)? <y/n> ");

            if (ReadLine() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Grade AddGrade(string gradeTypeIn, double scoreValueIn, bool groupWeight)
        {
            List<double> scoreList = new List<double>();

            return new Grade(scoreList, gradeTypeIn, scoreValueIn, groupWeight);
        }

        private static Course CreateCourse()
        {
            Course newCourse = new Course(CreateGradeList(), GetCourseName());

            return newCourse;
        }


        private static List<Grade> CreateGradeList()
        {
            List<Grade> grades = new List<Grade>();

            return grades;
        }

        private static string GetCourseName()
        {
            string courseName;

            Write("Please Enter the name of your course: ");
            courseName = ReadLine();
            WriteLine();

            return courseName;
        }
    }
}
