
namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete = false;
        
        public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
        {
            _isComplete = false;
        }


        public override void RecordEvent()
        { 
            _isComplete = true; 

            Console.WriteLine($"Congratulations! You have earned {_points} points!");

        }

        public void SetIsComplete(bool isComplete)
        {
            _isComplete = isComplete;
        }

        public override bool isComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            //Details string for simple goal
            return $"{_shortName}, {_description}, {_points}, {_isComplete}";
        }

        public override string GetStringRepresentation()
        {
            //String representation for simple goal
            //[ ] or [X]
            if (_isComplete)
            {
                return $"[X] {_shortName} ({_description})";
            }
            else 
            {
                return $"[ ] {_shortName} ({_description})";
            }
        }



    }
}
