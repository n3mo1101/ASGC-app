using System;
using System.Linq;

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



class ASGC
{

    static void Main(string[] args)
    {
        Dictionary<string, StudentRecord> Grades = new Dictionary<string, StudentRecord>();

        Console.WriteLine("Enter student's name");
        string name = Console.ReadLine();

        Console.WriteLine("How many assingments to compute?");
        int Assnum = int.Parse(Console.ReadLine());

        List<int> assignment = new List<int>();
        for (int i = 1; i <= Assnum; i++)
        {
            Console.WriteLine($"Enter score for Assignment no.{i}: ");
            assignment.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("How many quizzes to compute?");
        int Quiznum = int.Parse(Console.ReadLine());

        List<int> quizzes = new List<int>();
        for (int i = 1; i <= Quiznum; i++)
        {
            Console.WriteLine($"Enter score for Quiz no.{i}: ");
            quizzes.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("Enter score for Final Exam: ");
        int Final_Exam = int.Parse(Console.ReadLine());

        StudentRecord student = new StudentRecord(assignment, quizzes, Final_Exam);
        Grades[name] = student;

    }

    static double Calculate_Average(StudentRecord student_Grade)
    {
        double AssingmentWeight = student_Grade.Assignment.Average() * 0.3;
        double QuizWeight = student_Grade.Quizzes.Average() * 0.3;
        double FinalExam_Weight = student_Grade.FinalExam * 0.4;

        double weighted_Average = AssingmentWeight + QuizWeight + FinalExam_Weight;
        return weighted_Average;
    }
}
