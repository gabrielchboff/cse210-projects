namespace PasswordManager
{
    // Represents a menu for displaying options
    // And also is the exciding requirement
    public class Menu
    {
        // Properties
        private string _title { get; set; } // Title of the menu
        private string _description { get; set; } // Description of the menu
        private List<string> _options = new List<string>(); // List of options in the menu

        // Constructor to initialize menu properties
        public Menu(string title, string description, List<string> options)
        {
            _title = title;
            _description = description;
            _options = options;
        }

        // Method to display the menu
        public void Display()
        {
            // Print title and description
            Console.WriteLine(_title);
            Console.WriteLine(_description);
            Console.WriteLine("Menu Options");
            
            // Iterate through options and print them
            for (int i = 1; i <= _options.Count; i++)
            {
                Console.WriteLine($" {i}. {_options[i - 1]}"); // Print each option with its corresponding number
            }
        }

        // Method to get user's choice from the menu
        public int GetChoice()
        {
            int choice = int.Parse(Console.ReadLine()); // Read user input
            return choice; // Return the choice
        }
    }
}

