public class Reference
{
    private string _book; // Private field to store the name of the book
    private int _chapter; // Private field to store the chapter number
    private int _verse; // Private field to store the starting verse number
    private int _endVerse; // Private field to store the ending verse number (if applicable)

    // Constructor to initialize a new Reference object with a book, chapter, starting verse, and ending verse
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Constructor to initialize a new Reference object with a book, chapter, and starting verse (no ending verse)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    // Method to get the display text of the reference (including book, chapter, and verse range if applicable)
    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    // Getter methods to retrieve the book, chapter, starting verse, and ending verse
    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    // Setter methods to set the ending verse, starting verse, chapter, and book
    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }

    public void SetVerse(int verse)
    {
        _verse = verse;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public void SetBook(string book)
    {
        _book = book;
    }
}

