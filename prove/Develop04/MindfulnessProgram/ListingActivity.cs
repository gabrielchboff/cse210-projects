using System.Diagnostics;

namespace MindfulnessProgram
{
    // Class for representing a Listing Activity, which inherits from the Activity class
    public class ListingActivity : Activity
    {
        // List of prompts to stimulate listing
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Constructor to initialize ListingActivity properties using base class constructor
        public ListingActivity(string name, string description, int duration) : base(name, description, duration)
        {
            // No additional initialization required in this constructor
        }

        // Method to start the ListingActivity
        public void Run()
        {
            Console.WriteLine("Get ready...");
            
            // Display a spinner animation to indicate activity is starting
            ShowSpinner();
            
            // Display a random prompt to stimulate listing
            GetRandomPrompt();
            
            // Get list from user input and write it to a text file
            ListToTxt(GetListFromUser());
            
            // Display the ending message of the activity
            DisplayEndingMassage();
        }
        
        // Method to display a random prompt to stimulate listing
        public void GetRandomPrompt()
        {
            Console.WriteLine("List as many responses as you can to the following prompt:");
            
            // Select a random prompt from the list
            Random random = new Random();
            int index = random.Next(0, _prompts.Count);
            Console.WriteLine($"--- {_prompts[index]} ---");
            
            Console.Write("You may begin in: ");
            int seconds = 0;
            while (seconds <= 3)
            {
                Console.Write(seconds);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                seconds++;
            }
        }

        // Method to write a list of strings to a text file
        public void ListToTxt(List<string> list)
        {
            using (StreamWriter outputFile = new StreamWriter("list.txt"))
            {
                foreach (string item in list)
                {
                    outputFile.WriteLine(item);
                }
            }
        }

        // Method to get a list of strings from user input
        public List<string> GetListFromUser()
        {
            List<string> list = new List<string>();

            // Start stopwatch before prompting for input
            Stopwatch stopwatch = new Stopwatch();
            
            while (_duration > stopwatch.Elapsed.TotalSeconds)
            {
                stopwatch.Start();
                Console.Write("\n> ");
                string input = Console.ReadLine();
                list.Add(input);
                stopwatch.Stop();
            }
            
            Console.WriteLine("You listed " + list.Count + " items.");
            return list; 
        }
    }
}


