
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Method to generate scriptures from a file
    static List<Scripture> GenerateScripturesFromFile()
    {
        string filename = "scriptures_database.txt";
        List<Scripture> scriptures = new List<Scripture>();
        
        // Read from file
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            // Read each line in the file
            while ((line = sr.ReadLine()) != null)
            {
                // Split the line by '|'
                string[] allScriptures = line.Split('|');
                
                // Process each scripture in the line
                for (int i = 0; i < allScriptures.Length; i++)
                {
                    string current_reference = allScriptures[i].Split("#")[0];
                    List<Word> words = new List<Word>();
                    
                    // Split the scripture by ' '
                    string[] wordsInScripture = allScriptures[i].Split("#")[1].Split(" ");
                    
                    // Create Word objects for each word in the scripture
                    for (int j = 0; j < wordsInScripture.Length; j++)
                    {
                        words.Add(new Word(wordsInScripture[j]));
                    }
                    
                    // Split the current_reference to extract book, chapter, and verse information
                    string[] just_reference = current_reference.Split(" ");
                    string book = just_reference[0].ToString();
                    int chapter = int.Parse(just_reference[1].ToString().Split(":")[0]);
                    string[] verses = just_reference[2].ToString().Split("-");
                    
                    int verse = int.Parse(verses[0]);
                    int endVerse = verses.Length == 1 ? 0 : int.Parse(verses[1]);

                    // Create a Reference object
                    Reference reference = verses.Length == 1 ? new Reference(book, chapter, verse) : new Reference(book, chapter, verse, endVerse);

                    // Create a Scripture object and add it to the list
                    Scripture scripture = new Scripture(reference, words);
                    scriptures.Add(scripture);
                }
            }
        }
        return scriptures;
    }

    // Method to get a random scripture from a list
    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    // Method to display the current scripture
    static void DisplayCurrentScripture(Scripture scripture)
    {
        Random random = new Random();
        int numberToHide = random.Next(1, 4);
        scripture.HideRandomWords(numberToHide);
        scripture.GetDisplayText();
    }

    static void Main(string[] args)
    {
        // Generate scriptures from file
        List<Scripture> scriptures = GenerateScripturesFromFile();
        
        // Get a random scripture
        Scripture scripture = GetRandomScripture(scriptures);
        
        // Main loop
        do
        {
            Console.Clear();
            Console.WriteLine(scripture.IsCompletelyHidden());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            string option = Console.ReadLine();
            switch (option)
            {
                case "":
                    DisplayCurrentScripture(scripture);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!scripture.IsCompletelyHidden());
        
        // Final display
        Console.Clear();
        Console.WriteLine(scripture.IsCompletelyHidden());
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
        string opt = Console.ReadLine();
        switch (opt)
        {
            case "":
                Console.WriteLine("Thanks for playing");
                break;
            case "quit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}


