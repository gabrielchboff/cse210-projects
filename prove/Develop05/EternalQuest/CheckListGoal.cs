namespace EternalQuest
{
    // Inherits from the base Goal class
    public class CheckListGoal : Goal
    {
        // Additional properties specific to CheckListGoal
        private int _amountCompleted = 0;
        private int _target = 0;
        private int _bonus = 0;

        // Constructor to initialize CheckListGoal properties
        public CheckListGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
        {
            _target = target;
            _bonus = bonus;
        }

        // Override method to record an event for CheckListGoal
        public override void RecordEvent()
        {
            _amountCompleted++; // Increment the amount completed
            if (isComplete()) // Check if the goal is complete
            {
                Console.WriteLine($"Congratulations! You have earned {_bonus} bonus points!");
                _points += _bonus; // Add bonus points if goal is complete
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {_points} points!");
            }
        }

        // Method to set the amount of completion for the goal
        public void SetAmountCompleted(int amountCompleted)
        {
            _amountCompleted = amountCompleted;
        }

        // Override method to check if CheckListGoal is complete
        public override bool isComplete()
        {
            return _amountCompleted >= _target; // Check if amount completed is equal to or greater than target
        }

        // Override method to get the string representation of CheckListGoal
        public override string GetStringRepresentation()
        {
            // Returns a string representation indicating the goal's completion status and progress
            return $"[ ] {_shortName} ({_description}) --- ({_amountCompleted}/{_target})";
        }

        // Override method to get the details of CheckListGoal as a string
        public override string GetDetailsString()
        {
            // Returns a string containing all details of the goal
            return $"{_shortName}, {_description}, {_points}, {_target}, {_bonus}, {_amountCompleted}";
        }
    }
}

