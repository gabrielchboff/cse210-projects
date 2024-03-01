using System;
using System.Collections.Generic;

class Program
{

    static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }


    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        Console.WriteLine("Sum: " + Sum(numbers));
        Console.WriteLine("Average: " + Sum(numbers) / numbers.Count);
        Console.WriteLine("The largest number is: " + numbers.Max());
    }
}

