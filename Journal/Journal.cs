
using System.Text.Json;

// This class represents a journal to store and manage journal entries.
public class Journal
{
    // A list to store all the journal entries.
    public List<Entry> _entries = new List<Entry>();

    // Adds a new entry to the journal.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);

    }
    // Displays all entries currently present in the journal.
    public void DisplayAll()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Display();
        }
    }
    // Saves all journal entries to a text file.
    public void Save()
    {
        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();
        string filePath = fileName + ".txt";

        // Use a StreamWriter to write to the file in a safe manner
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {

                // Save each entry's data in a comma-separated format
                outputFile.WriteLine($"{entry._date},{entry._prompt},{entry._entryText}");
            }
        }


    }

    public void SaveAsJSON()
    {
        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();
        string filePath = fileName + ".json";
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            // Save each entry's data in a comma-separated format
            foreach (Entry entry in _entries)
            {
                string json = JsonSerializer.Serialize(entry);
                outputFile.WriteLine(json);
            }

        }
    }
    // Loads journal entries from a text file.
    public void Load()
    {
        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();
        string filePath = fileName + ".txt";
        // Read all lines from the file
        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            // Split each line by comma to separate entry data
            string[] parts = line.Split(',');
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._entryText = parts[2];
            _entries.Add(entry);
        }


    }
}

