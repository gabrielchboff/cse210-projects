using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        Console.WriteLine($"Hello, {userName}!");
        Console.WriteLine("What is your favorite number?");
        int favNum = int.Parse(Console.ReadLine());
        int favNumSquared = favNum * favNum;
        Console.WriteLine($"Your favorite number squared is {favNumSquared}");
    }
}
