using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a full scripture: a Reference plus the list of Words
    /// that make up its text. Responsible for hiding random words and
    /// producing the text that should be displayed to the user.
    /// </summary>
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private static readonly Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;

            // Split the raw scripture text into individual Word objects.
            _words = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w))
                .ToList();
        }

        /// <summary>
        /// Hides up to numberToHide words at random. Per the stretch
        /// requirement, words are chosen only from those not already
        /// hidden, so the same word is never "wasted" on repeated hides.
        /// If fewer than numberToHide words remain visible, all of them
        /// are hidden.
        /// </summary>
        public void HideRandomWords(int numberToHide)
        {
            List<Word> hidableWords = _words.Where(w => !w.IsHidden()).ToList();

            int countToHide = Math.Min(numberToHide, hidableWords.Count);

            for (int i = 0; i < countToHide; i++)
            {
                int index = _random.Next(hidableWords.Count);
                hidableWords[index].Hide();
                hidableWords.RemoveAt(index);
            }
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public string GetDisplayText()
        {
            string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}  {wordsText}";
        }
    }
}
