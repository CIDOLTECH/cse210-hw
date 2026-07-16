using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    /// <summary>
    /// EXCEEDS REQUIREMENTS: Holds a library of multiple scriptures and
    /// can hand back a random one each time the program runs, rather than
    /// always practicing the same single verse. See Program.cs for a
    /// summary of all the ways this project exceeds the core requirements.
    /// </summary>
    public class ScriptureLibrary
    {
        private readonly List<Scripture> _scriptures;
        private static readonly Random _random = new Random();

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
        }

        public void Add(Scripture scripture)
        {
            _scriptures.Add(scripture);
        }

        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
            {
                throw new InvalidOperationException("The scripture library is empty.");
            }

            int index = _random.Next(_scriptures.Count);
            return _scriptures[index];
        }
    }
}
