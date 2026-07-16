using System;

namespace ScriptureMemorizer
{
    /*
     1. Scripture Library:
    Instead of hard-coding just one scripture, I decided to build a whole
    ScriptureLibrary with several verses in it (check out BuildLibrary
    below to see how I set that up). Every time the program runs, it
    picks one at RANDOM, so if you run it a few times, you'll get a
    different verse to practice each time. Felt more useful than
    memorizing the same line over and over.

    2. Smarter word-hiding:
    One thing that bugged me in the basic version was that it would
    sometimes "hide" a word that was already blank, which wasted a
    keypress and didn't feel like real progress. So I made
    HideRandomWords only pick from words that are still visible.
    That way every keypress actually reveals... well, hides... new
    progress instead of spinning its wheels on stuff already gone.
    (This was the stretch challenge from the assignment, by the way.)

    3. Adjustable difficulty:
    I didn't want the "how many words disappear per keypress" number
    buried somewhere in the logic, so I pulled it out into one named
    constant: NumberOfWordsToHidePerStep. Now if I want to make the
    game harder or easier, I just change that one value instead of
    hunting through the code.

    4. Keeping things clean with encapsulation:
    I tried to make sure each class only worries about its own job.
    Word handles how it displays itself, Reference takes care of
    formatting (whether it's a single verse or a range), Scripture
    just coordinates everything, and Program only runs the main loop.
    None of them reach in and mess with another class's private data—
    it keeps things easier to follow and change later.
     * ================================================================
     */
    public class Program
    {
        private const int NumberOfWordsToHidePerStep = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
            ScriptureLibrary library = BuildLibrary();
            Scripture scripture = library.GetRandomScripture();

            RunMemorizationLoop(scripture);
        }

        private static void RunMemorizationLoop(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("All words are hidden. Great job practicing!");
                    break;
                }

                Console.Write("Press Enter to continue, or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (string.Equals(input?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                scripture.HideRandomWords(NumberOfWordsToHidePerStep);
            }
        }

        private static ScriptureLibrary BuildLibrary()
        {
            var library = new ScriptureLibrary();

            library.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."));

            library.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."));

            library.Add(new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."));

            library.Add(new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, " +
                "neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."));

            return library;
        }
    }
}
