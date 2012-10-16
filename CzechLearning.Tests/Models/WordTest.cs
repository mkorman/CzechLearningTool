using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Models;

namespace CzechLearning.Tests.Models
{
    [TestClass]
    public class WordTest
    {
        [TestMethod]
        // Test that we got a default constructor
        public void Model_Word_Creation()
        {
            // Arrange
            var word = new Word();

            // Assert
            Assert.IsNotNull(word);
        }

        [TestMethod]
        // Test that we got two well-known properties
        public void Model_Word_Properties()
        {
            // Arrange
            var word = new Word();

            // Act
            word.English = "Two";
            word.Czech = "Dva";

            // Assert
            Assert.AreEqual(word.English, "Two");
            Assert.AreEqual(word.Czech, "Dva");
        }
    }
}
