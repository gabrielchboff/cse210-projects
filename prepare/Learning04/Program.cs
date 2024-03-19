using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "1.3", "8-19");
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());
            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "The Causes of World War II" ,"European History");
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
            
        }
    }
}
