using System;
using System.Collections.Generic;

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

            List<(int score, int maxScore)> assignments = new List<(int, int)>();
            for (int i = 1; i <= assignNumber; i++)
            {
                Console.Write($"Assign no.{i} score: ");
                int score = int.Parse(Console.ReadLine());

                Console.Write($"Assign no.{i} max score: ");
                int maxScore = int.Parse(Console.ReadLine());

                assignments.Add((score, maxScore));
            }

            Console.Write("\nNumber of quizzes to compute? ");
            int quizNumber = int.Parse(Console.ReadLine());

            List<(int score, int maxScore)> quizzes = new List<(int, int)>();
            for (int i = 1; i <= quizNumber; i++)
            {
                Console.Write($"Quiz no.{i} score: ");
                int score = int.Parse(Console.ReadLine());

                Console.Write($"Quiz no.{i} max score: ");
                int maxScore = int.Parse(Console.ReadLine());

                quizzes.Add((score, maxScore));
            }

            Console.Write("\nScore for Final Exam: ");
            int finalExamScore = int.Parse(Console.ReadLine());

            Console.Write("Max score for Final Exam: ");
            int maxFinalExamScore = int.Parse(Console.ReadLine());

            StudentRecord student = new StudentRecord(assignments, quizzes, finalExamScore, maxFinalExamScore);
            Records[studentName] = student;

            DisplayReport(Records, studentName);

            Console.ReadKey();
        }

        class StudentRecord
        {
            public List<(int score, int maxScore)> Assignments;
            public List<(int score, int maxScore)> Quizzes;
            public int FinalExam;
            public int MaxFinalExam;

            public StudentRecord(List<(int score, int maxScore)> assignments, List<(int score, int maxScore)> quizzes, int finalExam, int maxFinalExam)
            {
                Assignments = assignments;
                Quizzes = quizzes;
                FinalExam = finalExam;
                MaxFinalExam = maxFinalExam;
            }
        }

        static double Calculate_Average(StudentRecord studentScores)
        {

            double totalAssignmentScore = 0;
            foreach (var assignment in studentScores.Assignments)
            {
                totalAssignmentScore += (double)assignment.score / assignment.maxScore;
            }
            double assignmentAverage = (totalAssignmentScore / studentScores.Assignments.Count) * 0.3;


            double totalQuizScore = 0;
            foreach (var quiz in studentScores.Quizzes)
            {
                totalQuizScore += (double)quiz.score / quiz.maxScore;
            }
            double quizAverage = (totalQuizScore / studentScores.Quizzes.Count) * 0.3;

            double finalExamPercentage = (double)studentScores.FinalExam / studentScores.MaxFinalExam * 0.4;

         
            double weightedAverage = (assignmentAverage + quizAverage + finalExamPercentage) * 100;

            return weightedAverage;
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
            int i = 1;
            foreach (var assignment in student.Assignments)
            {
                Console.WriteLine($"Assignment No.{i++}: {assignment.score}/{assignment.maxScore}");
            }

            Console.WriteLine("\nList of Scores | Quizzes");
            int j = 1;
            foreach (var quiz in student.Quizzes)
            {
                Console.WriteLine($"Quiz No.{j++}: {quiz.score}/{quiz.maxScore}");
            }

            Console.WriteLine($"\nFinal Exam: {student.FinalExam}/{student.MaxFinalExam}");
            Console.WriteLine($"Weighted Average: {Math.Round(average, 2)}");
            Console.WriteLine($"\nGrade: {grade}");
        }
    }
}
