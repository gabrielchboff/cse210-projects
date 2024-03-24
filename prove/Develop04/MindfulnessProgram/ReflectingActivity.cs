namespace MindfulnessProgram
{
    // Class for representing a Reflecting Activity, which inherits from the Activity class
    public class ReflectingActivity : Activity
    {
        // List of prompts to stimulate reflection
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // List of questions to guide reflection
        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Constructor to initialize ReflectingActivity properties using base class constructor
        public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
        {
            // No additional initialization required in this constructor
        }
        
        // Method to start the ReflectingActivity
        public void Run()
        {
            // Display a message to prepare for the activity
            Console.WriteLine("Get ready...");
            
            // Display a spinner animation to indicate activity is starting
            ShowSpinner();

            int time = 0;
            Console.WriteLine("Consider the following prompt:");
            
            // Display a randomly selected prompt to stimulate reflection
            DisplayPrompt();
            
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");

            // Loop to display questions for reflection
            while (time < _duration)
            {
                // Display a spinner animation
                ShowSpinner();
                
                // Display a randomly selected question to guide reflection
                DisplayQuestion();
                
                // Display a spinner animation for the duration of the activity
                ShowSpinner(custom_time: _duration);
                
                time += 5; // Increment time by 5 seconds for each question
            }
            
            // Display the ending message of the activity
            DisplayEndingMassage();
        }

        // Method to get a random prompt from the list
        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(0, _prompts.Count);
            return _prompts[index];
        }

        // Method to get a random question from the list
        public string GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(0, _questions.Count);
            return _questions[index];
        }

        // Method to display a randomly selected prompt
        public void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine($"------ {prompt} ------");
        }

        // Method to display a randomly selected question
        public void DisplayQuestion()
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"> {question}");
        }
    }
}


