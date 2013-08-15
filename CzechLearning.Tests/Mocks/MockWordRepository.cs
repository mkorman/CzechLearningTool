using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CzechLearning.Models;

namespace CzechLearning.Tests.Mocks
{
    /// <summary>
    /// Mock for the Word repository class
    /// </summary>
    public class MockWordRepository : IWordRepository
    {
        protected IList<Word> wordList;

        public MockWordRepository ()
        {
            wordList = new List<Word>();
        }

        /// <summary>
        /// Returns all words
        /// </summary>
        public IDbSet<Word> Words
        {
            get { return new InMemoryDbSet<Word>(wordList); }
            set { wordList = value.ToList<Word>(); }
        }

        /// <summary>
        /// Finds a word by ID
        /// </summary>
        /// <param name="id">The ID of the word to find</param>
        /// <returns>The word found</returns>
        public Word Find(int id)
        {
            var w = (from word
                    in wordList
                     where word.WordId == id
                     select word).FirstOrDefault();
            return w;
        }

        /// <summary>
        /// Adds a word to the repository
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <returns>The word, with an updated ID</returns>
        public Word Create(Word word)
        {
            // Bypass if we already hold the word
            if (wordList.Contains (word))
            {
                return word;
            }

            // Add word to repo
            var ids = from w in wordList select w.WordId;

            // Set word id
            var id = (ids.Count() == 0) ? 0 : ids.Max() + 1;
            wordList.Add(word);
            return word;
        }

        /// <summary>
        /// Modifies an existing word
        /// </summary>
        /// <param name="word">The word to modify</param>
        /// <returns>The modified word</returns>
        public Word Edit(Word word)
        {
            var existingWord = Find(word.WordId);
            wordList.Remove(existingWord);
            wordList.Add(word);
            return word;
        }

        /// <summary>
        /// Removes a word from a repository
        /// </summary>
        /// <param name="word">The word to remove</param>
        /// <returns>An IDbSet representing the repository, without the word</returns>
        public IDbSet<Word> Remove(Word word)
        {
            wordList.Remove(word);
            return Words;
        }

        /// <summary>
        /// Removes a word by ID
        /// </summary>
        /// <param name="id">The ID of the word to remove</param>
        /// <returns>The set minus the removed word</returns>
        public IDbSet<Word> Remove(int id)
        {
            var word = Find(id);
            return Remove(word);
        }

        // Frees managed resources
        public void Dispose ()
        {
            // Nothing to do 
        }

    }
}
