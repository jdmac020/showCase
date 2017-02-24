using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator2
{
    class Help
    {
        public static string overView = "Overview of GradeCalculator 2.0:\n\nGradeCalculator 2.0 allows you to build any " +
            "number of courses that includes any number of grade types, and record scores " + 
            "to get an accurate snapshot of the\ncurrent grade in that course. This allows " +
            "you to stop guessing on where you\nstand and to figure out how much you need " +
            "to score on that final exam\nor project.";

        public static string courseDescription = "More on Courses:\n\nYou create a course by naming it (for instance, 'Science,' " +
            "'Math,' 'Bio,'\n'Programming 101') and telling GradeCalculator what kinds of " +
            "grades your\ninstructor uses to measure performance (like 'Test,' 'Quiz,' 'Lab,' or\n'Homework'). You also tell GradeCalculator how much each type of grade is\nworth.";
        
        public static string gradeDescription = "More on Grades:\n\nThe value of the grades can typically be found in your " +
            "syllabus, and is\nnormally either a point value or a percentage of the total course grade. " +
            "\n\nFor instance, a Science class with weighted grades might have 12 Labs worth "+
            "15% of the final grade, 6 Quizzes worth 10%, 3 tests worth 15% each, and a Final\nworth 30%. Final "+
            "grade is calculated by adding together the weighted value of\neach type of grade. \n\nA Math class "+
            "that uses a total points system might have Homework worth 3 points each, quizzes worth 50 points "+
            "grade is calculated by adding together all points earned and dividing it by all points possible.";

        public static string enteringGrades = "How to Enter Grades:\n\nYou decide what each grade is called--you can call a grade called Homework 'HW' or 'homework' or 'hOmEwOrK' and it's all the same to GradeCalculator." +
            "\n\nOnce you enter the grade's name, you enter the value of each score you get--\nif it's a point value, such as 3 or 25 or 100, enter the number. If it's a\npercent of your total" +
            " grade in that class, enter a decimal--.2 for 20%, .15 for\n15%, etc. Finally, GradeCalculator needs to know if this grade is weighted as a group--are all quizzes averaged together" +
            " as a single grade, or does each one\nget counted separately?";

        public static string enteringScores = "How to Enter Scores:\n\nOnce you've entered all the grades for a course, you can either create a new\ncourse or continue to the menu. Menu Option #1 is entering scores." +
            "\n\nYou'll see a list of your courses, and when you select a course you'll see the\ntypes of grades for that course. Pick the one you want to add a score to. Enter the grade you received" +
            " as it will be recorded--if your quizzes are all worth\n75 points, record the actual number of points you earned. If your quizzes are\nweighted, record the percent.";

        public static string clearScores = "Clearing Scores:\n\nIf you enter scores incorrectly, or want to run a what-if on your grade, you\ncan clear all score entries. This wipes out all entries for your chosen" +
            " grade\ntypeand will throw off your current grade, so don't do it unless you plan to\nadd more scores back in.";

        public static string deleteCourse = "Deleting a Course:\n\nIf you don't need a course, or if you need to change how a course is graded\n(like if you find out there's a change to what the final is worth) you can" +
            " wipe out the entire course and start over.";

        public static string deleteAllCourses = "Deleting ALL Courses:\n\nIf you're at the end of the semester and you never want to even think about\nScience and Math and Programming 101 again, you can delete all the courses" +
            " in\nyour list at one fell swoop. Just be sure you *actually* want to do that!";

        public static string displayGrades = "Displaying Grades:\n\nThis option is why you're here--it shows you see your current grades in your\nsaved courses, including break down by grade type. This way, you can see if\nyour Lab grade is" +
            "bringing you down or if you can slack on the next couple\nhomework assignments in Math.";
    }
}
