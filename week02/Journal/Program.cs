using System;

// Exceeds requirements:
// - Entries are date-stamped automatically using DateTime.Now.
// - The file format uses a custom "~|~" separator that is unlikely to
//   appear in normal journal text, isolated inside Entry.cs so the
//   storage format can be swapped out later without touching Journal.
// - Gracefully handled the error case where a user tries to load a file
//   that does not exist, displaying a friendly message instead of letting
//   the program crash with an unhandled exception.
// - Used private member variables in every class, exposed only through
//   public methods, to demonstrate abstraction — callers interact with
//   simple method calls without needing to know how data is stored
//   internally.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Not a valid option, please try again.");
                    break;
            }
        }
    }
}
