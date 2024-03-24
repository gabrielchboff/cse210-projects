using System.Timers;

namespace MindfulnessProgram
{
    public class Activity
    {
        private string _name; // Name of the activity
        private string _description; // Description of the activity
        protected int _duration; // Duration of the activity in seconds

        // Constructor to initialize activity properties
        public Activity(string name, string description, int duration)
        {
            _name = name;
            _description = description;
            _duration = duration;
        }
        
        // Method to set the duration of the activity
        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        // Method to display the starting message of the activity
        public void DisplayStartingMassage()
        {
            Console.WriteLine($"Welcome to {_name}!");
            Console.WriteLine(_description);
        }

        // Method to display the ending message of the activity
        public void DisplayEndingMassage()
        {
            Console.WriteLine($"Well Done! You have completed another {_duration} seconds of the {_name} activity.");
            Console.WriteLine("Good job!");
            ShowSpinner(); // Display a spinner animation
            Console.Clear(); // Clear the console screen
        }

        // Method to display a spinner animation
        public void ShowSpinner(int custom_time = 40)
        {
            int counter = 0;
            char[] spinnerChars = { '|', '/', '-', '\\' };

            // Loop to display spinner animation
            while (counter < custom_time)
            {
                Console.Write(spinnerChars[counter % 4] + "\b"); // Write spinner character
                counter++;
                Thread.Sleep(100); // Pause for a short time (100 milliseconds)
            }
        }

        // Method to display a breathing animation
        static void BreathAnimation(string frame, int duration)
        {
            int numberOfFrames = 10; // Number of frames for animation
            int interval = duration / numberOfFrames;

            // Loop to display breathing animation frames
            for (int i = 0; i < numberOfFrames; i++)
            {
                Console.WriteLine(frame); // Write breathing animation frame
                Thread.Sleep(interval); // Pause for a short time (interval milliseconds)
            }
        }

        // Method to show a countdown for breathing activity
        public void ShowCountdown()
        {
            int time = 0;
            int counter = _duration;

            // Loop to display countdown for the activity
            while (counter > time)
            {
                Console.WriteLine("Breathing in...");
                BreathAnimation("     /\\     ", 4000); // Display inhale animation
                time += 4; // Increment time by 4 seconds
                Console.WriteLine("Hold...");
                Thread.Sleep(2000); // Hold breath for 2 seconds
                time += 2; // Increment time by 2 seconds
                Console.WriteLine("Breathing out...");
                BreathAnimation("     \\/     ", 4000); // Display exhale animation
                time += 4; // Increment time by 4 seconds
                counter--;
                Console.Clear(); // Clear the console screen
                Thread.Sleep(1000); // Pause for a short time (1 second)
            }
        }
    }
}


