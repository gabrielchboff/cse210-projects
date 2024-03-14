public class Scripture
{
    private Reference _reference; // Private field to store the reference associated with the scripture
    private List<Word> _words; // Private field to store the words in the scripture

    // Constructor to initialize a new Scripture object with a reference and a list of words
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    // Method to randomly hide a specified number of words in the scripture
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        // Count the number of already hidden words
        foreach (Word word in _words)
        {
            if (word.GetIsHidden())
            {
                hiddenCount++;
            }
        }

        // Hide all words if most of them are already hidden
        if (hiddenCount > _words.Count - 5)
        {
            foreach (Word word in _words)
            {
                word.Hide();
            }
            return;
        }

        // Hide the specified number of words randomly
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    // Method to retrieve the reference associated with the scripture
    public Reference GetReference()
    {
        return _reference;
    }

    // Method to get the display text of the scripture (including reference and words)
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText();
        foreach (Word word in _words)
        {
            displayText += " " + word.GetDisplayText();
        }
        return displayText;
    }

    // Method to check if all words in the scripture are completely hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.GetIsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

