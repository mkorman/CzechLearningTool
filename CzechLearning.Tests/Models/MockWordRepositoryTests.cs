using CzechLearning.Models;
using CzechLearning.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechLearning.Tests.Models
{
    [TestClass]
    public class MockWordRepositoryTests
    {
        protected MockWordRepository repo;

        [TestMethod]
        public void Model_MockRepo_TestRepoCreation ()
        {
            Assert.IsNotNull(repo.Words, "Expected non-null respository");
            Assert.AreEqual(repo.Words.Count(), 0, "Expected empty repository after creation");
        }

        [TestMethod]
        public void Model_MockRepo_TestRetrieve()
        {
            // Arrange
            var word = new Word() { English = "Day", Czech = "Day" };
            repo.Create(word);
            
            // Act
            var newWord = repo.Find(word.WordId);

            // Assert
            Assert.AreEqual(word, newWord, "Word retrieved from repo was different to the word added to it");
        }

        [TestMethod]
        public void Model_MockRepo_TestCount()
        {
            // Arrange
            for (int i = 0; i < 10; i++)
            {
                var word = new Word() { English = i.ToString(), Czech = "" };
                repo.Create(word);
            }

            // Assert
            Assert.AreEqual(repo.Words.Count(), 10, "Unexpected number of words in repo");
        }

        [TestMethod]
        public void Model_MockRepo_TestRemove ()
        {
            // Arrange
            var word = new Word();
            repo.Create(word);
            Assert.AreEqual(repo.Words.Count(), 1, "Expected repo with 1 word");
            
            // Act
            repo.Remove(word);
            Assert.AreEqual(repo.Words.Count(), 0, "Expected empty repo");
        }

        [TestMethod]
        public void Model_MockRepo_TestRepeatedInsert ()
        {
            // Arrange
            var word = new Word() { English = "Day", Czech = "Den" };

            // Act
            for (int i = 0; i <10 ; i++)
            {
                repo.Create(word);
            }

            // Assert
            Assert.AreEqual(repo.Words.Count(), 1, "Expected just 1 word after inserting same word repeatedly");
        }

        [TestInitialize]
        public void Initialize ()
        {
            repo = new MockWordRepository();
        }
    }
}
