using System;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    // Turns this entry into one line of text for saving to a file.
    public string ToFileString(string separator)
    {
        return $"{_date}{separator}{_promptText}{separator}{_entryText}";
    }

    // Rebuilds an Entry from one line of text read from a file.
    public static Entry FromFileString(string line, string separator)
    {
        string[] parts = line.Split(separator);
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
