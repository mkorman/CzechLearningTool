using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Models;
using System.Data.Entity;
using System.Linq;

namespace CzechLearning.Tests.Models
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void Model_DataContext_Creation()
        {
            // Arrange
            var myDataContext = new CzechLearningContext();

            // Act
            var words = myDataContext.Words;
            var word = words.ToList()[0];

            // Assert
            Assert.IsInstanceOfType(myDataContext, typeof(DbContext));
            Assert.IsNotNull(words);
            Assert.IsNotNull(word);
            Assert.IsInstanceOfType(word, typeof(Word));
        }
    }
}
