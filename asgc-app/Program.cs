using System;
using System.Linq;

namespace ASGC_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, StudentRecord> Records = new Dictionary<string, StudentRecord>();

            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            Console.Write("\nNumber of assignments to compute? ");
            int assignNumber = int.Parse(Console.ReadLine());

            List<int> assignment = new List<int>();
            for (int i = 1; i <= assignNumber; i++)
            {
                Console.Write($"Score for Assignment No.{i}: ");
                assignment.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("\nNumber of quizzes to compute? ");
            int quizNumber = int.Parse(Console.ReadLine());

            List<int> quizzes = new List<int>();
            for (int i = 1; i <= quizNumber; i++)
            {
                Console.Write($"Score for Quiz No.{i}: ");
                quizzes.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("\nScore for Final Exam: ");
            int Final_Exam = int.Parse(Console.ReadLine());

            StudentRecord student = new StudentRecord(assignment, quizzes, Final_Exam);
            Records[studentName] = student;

            DisplayReport(Records, studentName);

            Console.ReadKey();
        }

        class StudentRecord
        {
            public List<int> Assignment = new List<int>();
            public List<int> Quizzes = new List<int>();
            public int FinalExam = new int();

            public StudentRecord(List<int> assignment, List<int> quizzes, int finalExam)
            {
                Assignment = assignment;
                Quizzes = quizzes;
                FinalExam = finalExam;
            }
        }

        static double Calculate_Average(StudentRecord studentScores)
        {
            double assignAverage = studentScores.Assignment.Average() * 0.3;
            double quizAverage = studentScores.Quizzes.Average() * 0.3;
            double finalAverage = studentScores.FinalExam * 0.4;

            double weighted_Average = assignAverage + quizAverage + finalAverage;
            return weighted_Average;
        }

        static char GetGrade(double average)
        {
            if (average >= 90)
                    return 'A';
                else if (average >= 80)
                    return 'B';
                else if (average >= 70)
                    return 'C';
                else if (average >= 60)
                    return 'D';
                else
                    return 'F';
        }

        static void DisplayReport(Dictionary<string, StudentRecord> Records, string studentName)
        {
                StudentRecord student = Records[studentName];
                double average = Calculate_Average(student);
                char grade = GetGrade(average);

                Console.WriteLine("\n---[Student Report Card]---");
                Console.WriteLine($"\nStudent Name: {studentName}");

                Console.WriteLine("\nList of Scores | Assignments");

                int i = 1, j = 1;
                foreach (var score in student.Assignment)
                    Console.WriteLine($"Assignment No.{i}: {score}", i++);

                Console.WriteLine("\nList of Scores | Quizzes");

                foreach (var score in student.Quizzes)
                    Console.WriteLine($"Quiz No.{j} : {score}", j++);

                Console.WriteLine($"\nFinal Exam: {student.FinalExam}");
                Console.WriteLine($"Weighted Average: {Math.Round(average, 2)}");

                Console.WriteLine($"\nGrade: {grade}");
        }
    }
}
