# ASGC-app
Automated Student Grade Calculator (ASGC) App

﻿using System;
using System.Reflection.PortableExecutable;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace PracticeArea
{
    class Program
    {
        private const int ASSIGNMENTS = 5;
        private const int QUIZZES = 5;

        static List<int> assignScores = new List<int>();
        static List<int> quizScores = new List<int>();

        static void Main(string[] args)
        {
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("\nEnter scores for assignments.");
            for (int i = 0; i < ASSIGNMENTS; i++)
            {
                Console.Write($"Assignment No.{i+1}: ");
                int score = int.Parse(Console.ReadLine());

                assignScores.Add(score);
            }

            Console.WriteLine("\nEnter scores for quizzes.");
            for (int i = 0; i < QUIZZES; i++)
            {
                Console.Write($"Quiz No.{i+1}: ");
                int score = int.Parse(Console.ReadLine());

                quizScores.Add(score);
            }

            Console.Write("\nFinal exam score: ");
            int finalExam = int.Parse(Console.ReadLine());

            DisplayReportCard(studentName, assignScores, quizScores, finalExam);

            Console.ReadKey();
        }

        static double GetAverage(List<int> assignments, List<int> quizzes, int finalExam)
        {
            double assignWeight = 0.3;
            double quizWeight = 0.4;
            double finalsWeight = 0.3;

            double weightedAverage = ((double)assignments.Average() * assignWeight)
                                    + (quizzes.Average() * quizWeight)
                                    + (finalExam * finalsWeight);

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

        static void DisplayReportCard(string studentName, List<int> assignments, List<int> quizzes, int finalExam)
        {
            double weightedAverage = GetAverage(assignments, quizzes, finalExam);
            char grade = GetGrade(weightedAverage);

            Console.WriteLine("\n---[Student Report Card]---");
            Console.WriteLine($"\nStudent Name: {studentName}");

            Console.WriteLine("\nList of Scores | Assignments");

            int i = 1, j = 1;
            foreach (int score in assignments)
                Console.WriteLine($"Assignment No.{i}: {score}", i++);

            Console.WriteLine("\nList of Scores | Quizzes");
            
            foreach (int score in quizzes)
                Console.WriteLine($"Quiz No.{j}: {score}", j++);
    
            Console.WriteLine($"\nFinal Exam: {finalExam}");
            Console.WriteLine($"Weighted Average: {Math.Round(weightedAverage, 2)}");

            Console.WriteLine($"\nGrade: {grade}");
        }
    }
}
