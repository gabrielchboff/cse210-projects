public class Word
{
    private string _text; // Private field to store the text of the word
    private bool _isHidden; // Private field to indicate if the word is hidden

    // Constructor to initialize a new Word object with the specified text
    public Word(string text)
    {
        _text = text;
    }

    // Method to hide the word
    public void Hide()
    {
        if (!_isHidden) // Only hide if not already hidden
        {
            _isHidden = true;
        }
    }
    
    // Method to show the word (make it not hidden)
    public void Show()
    {
        _isHidden = false;
    }

    // Method to get the display text of the word (show underscores for hidden words)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenText = "";
            for (int i = 0; i < _text.Length; i++)
            {
                hiddenText += "_"; // Replace each character with an underscore
            }
            return hiddenText;
        }
        else
        {
            return _text; // Return the actual text if not hidden
        }
    }

    // Getter method to retrieve the text of the word
    public string GetText()
    {
        return _text;
    }

    // Setter method to set the text of the word
    public void SetText(string text)
    {
        _text = text;
    }

    // Getter method to check if the word is hidden
    public bool GetIsHidden()
    {
        return _isHidden;
    }

    // Setter method to set the hidden status of the word
    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }
}

