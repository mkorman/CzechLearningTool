using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Models;
using System.Data.Entity;
using System.Linq;
using System.IO;

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
            var word = words.First();

            // Assert
            Assert.IsInstanceOfType(myDataContext, typeof(DbContext));
            Assert.IsNotNull(words);
            Assert.IsNotNull(word);
            Assert.IsInstanceOfType(word, typeof(Word));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\CzechLearning\App_Data"));
            AppDomain.CurrentDomain.SetData("DataDirectory", fullPath);
        }
    }
}
