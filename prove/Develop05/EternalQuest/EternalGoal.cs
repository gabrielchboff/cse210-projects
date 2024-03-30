
namespace EternalQuest
{
    // Inherits from the base Goal class
    public class EternalGoal : Goal
    {
        // Constructor to initialize EternalGoal properties
        public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
        {
            // No additional initialization needed
        }

        // Override method to record an event for EternalGoal
        public override void RecordEvent()
        {
            // Prints a message indicating the points earned
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }

        // Override method to check if EternalGoal is complete
        public override bool isComplete()
        {
            // For an EternalGoal, it's never complete (returns false)
            return false;
        }

        // Override method to get the string representation of EternalGoal
        public override string GetStringRepresentation()
        {
            // Returns a string representation indicating the goal is incomplete
            return $"[ ] {_shortName}";
        }
    }
}

