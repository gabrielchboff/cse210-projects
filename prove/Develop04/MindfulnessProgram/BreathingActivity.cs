namespace MindfulnessProgram
{
    // Class for representing a Breathing Activity, which inherits from the Activity class
    public class BreathingActivity : Activity
    {
        // Constructor to initialize BreathingActivity properties using base class constructor
        public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
        {
            // No additional initialization required in this constructor
        }

        // Method to start the BreathingActivity
        public void Run()
        {
            // Display a message to prepare for the activity
            Console.WriteLine("Get ready...");
            
            // Display a spinner animation to indicate activity is starting
            ShowSpinner();
            
            // Show a countdown for the BreathingActivity
            ShowCountdown();
            
            // Display the ending message of the activity
            DisplayEndingMassage();
            
            // Display a spinner animation to indicate activity has ended
            ShowSpinner();
        }
    }
}


