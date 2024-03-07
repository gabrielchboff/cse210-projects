
//This class represents the main entry point of the program.
class Program
{
    //The main program execution method.
    static void Main(string[] args)
    {
        // Create a list of menu options
        List<string> _choices = new List<string>() { "Write", "Display", "Load", "Save", "Save as JSON", "Quit" };

        // Create objects for journal and prompt generation
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        // Welcome message
        Console.WriteLine("\nWelcome to the Journal Program!");

        // Main program loop
        while (true)
        {
            // Display menu options
            Console.WriteLine("\nPlease select one of the following choices:");
            for (int i = 0; i < _choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_choices[i]}");
            }

            // Prompt user for input
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            // Create a new entry object
            Entry entry = new Entry();

            // Process user choice using a switch statement
            switch (choice)
            {
                // Case 1: Write a new entry
                case "1":
                    // Set entry date and prompt
                    DateTime today = DateTime.Now;
                    entry._date = today.ToString("MM/dd/yyyy");
                    entry._prompt = promptGenerator.GetRandomPrompt();

                    // Display prompt and get user input
                    Console.WriteLine(entry._prompt);
                    Console.Write("> ");
                    entry._entryText = Console.ReadLine();

                    // Add entry to journal
                    journal.AddEntry(entry);
                    break;

                // Case 2: Display all entries
                case "2":
                    journal.DisplayAll();
                    break;

                // Case 3: Load entries from file (implementation not shown)
                case "3":
                    journal.Load();
                    break;

                // Case 4: Save entries to file (implementation not shown)
                case "4":
                    journal.Save();
                    break;
                // Case 5: Save entries to JSON file
                case "5":
                    journal.SaveAsJSON();
                    break;

                // Case 5: Quit the program
                case "6":
                    Environment.Exit(0);
                    break;

                // Default: Invalid choice message
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}


