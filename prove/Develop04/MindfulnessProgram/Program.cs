
using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store menu options
            Dictionary<int, string> _options = new Dictionary<int, string>()
            {
                [1] = "Start breathing activity",
                [2] = "Start reflecting activity",
                [3] = "Start listing activity",
                [4] = "Quit",
            };

            // Loop to display menu options and handle user input
            while (true)
            {
                // Display menu options
                Console.WriteLine("Menu Options:");
                foreach (KeyValuePair<int, string> option in _options)
                {
                    Console.WriteLine($" {option.Key}. {option.Value}");
                }

                // Prompt user for choice
                Console.Write("Select a choice from the menu: ");

                // Read user input
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                // Switch statement to execute user's choice
                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        // Start BreathingActivity
                        BreathingActivity breathe = new BreathingActivity(
                            "Breathing Activity",
                            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                            0
                        );
                        breathe.DisplayStartingMassage();
                        Console.Write("How long, in seconds, would you like for your session? ");
                        int duration = int.Parse(Console.ReadLine());
                        breathe.SetDuration(duration);
                        breathe.Run();
                        break;

                    case 2:
                        Console.Clear();

                        // Start ReflectingActivity
                        ReflectingActivity reflecting = new ReflectingActivity(
                            "Reflecting Activity",
                            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the points in your life where you need to develop your resilience.",
                            0
                        );
                        reflecting.DisplayStartingMassage();
                        Console.Write("How long, in seconds, would you like for your session? ");
                        int duration2 = int.Parse(Console.ReadLine());
                        reflecting.SetDuration(duration2);
                        reflecting.Run();
                        break;

                    case 3:
                        // Start ListingActivity
                        ListingActivity list = new ListingActivity(
                            "Listing Activity",
                            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                            0
                        );
                        list.DisplayStartingMassage();
                        Console.Write("How long, in seconds, would you like for your session? ");
                        int duration3 = int.Parse(Console.ReadLine());
                        list.SetDuration(duration3);
                        list.Run();
                        break;

                    case 4:
                        // Exit the program
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        // Invalid option selected
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }
        }
    }
}

