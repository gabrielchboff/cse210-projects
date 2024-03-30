namespace EternalQuest
{
    public class Goal
    {
        // Properties for storing goal details
        protected string _shortName { get; set; }
        protected string _description { get; set; }
        protected int _points { get; set; }

        // Constructor to initialize goal properties
        public Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        // Method to get the description of the goal
        public string GetDescription()
        {
            return _description;
        }

        // Method to get the points associated with the goal
        public int GetPoints()
        {
            return _points;
        }

        // Method to get the short name of the goal
        public string GetShortName()
        {
            return _shortName;
        }

        // Virtual method to record an event for the goal (to be overridden in derived classes)
        public virtual void RecordEvent()
        {
            // Placeholder implementation, to be overridden in derived classes
        }

        // Virtual method to check if the goal is complete (to be overridden in derived classes)
        public virtual bool isComplete()
        {
            return false; // Placeholder implementation, to be overridden in derived classes
        }

        // Virtual method to get the details of the goal as a string (to be overridden in derived classes)
        public virtual string GetDetailsString()
        {
            return $"{_shortName}, {_description}, {_points}"; // Placeholder implementation, to be overridden in derived classes
        }

        // Virtual method to get the string representation of the goal (to be overridden in derived classes)
        public virtual string GetStringRepresentation()
        {
            return ""; // Placeholder implementation, to be overridden in derived classes
        }
    }
}


