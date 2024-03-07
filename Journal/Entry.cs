public class Entry
{
    // The entry attributes
    public string _date {get; set;}
    public string _prompt {get; set;}
    public string _entryText {get; set;}

    // Displays the entry in a formatted way.
    public void Display()
    {
        Console.WriteLine($"Date: {_date} Prompt: {_prompt}\n{_entryText}\n");
    }
}
