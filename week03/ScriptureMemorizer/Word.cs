using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a single word within a scripture. A word knows how to
    /// hide itself (display as underscores) and show itself (display its
    /// original text).
    /// </summary>
    public class Word
    {
        private readonly string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        /// <summary>
        /// Returns the word's original text, or an underscore-mask of the
        /// same length as the word if it is currently hidden. Punctuation
        /// attached to the word (e.g. "God," or "sin.") is preserved as
        /// part of the underscore count, matching what the assignment
        /// describes: "the number of underscores should match the number
        /// of letters in that word."
        /// </summary>
        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }
}
