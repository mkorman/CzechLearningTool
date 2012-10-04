using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Models;
using System.Linq;

namespace CzechLearning.Tests.Models
{
    [TestClass]
    public class WordQuizTest
    {

        private const string ENGLISH = "SomeEnglishText";
        private const string CZECH = "SomeCzechText";

        [TestMethod]
        public void TestWordQuizConstructor()
        {
            //Arrange
            var word = new Word();
            word.English = ENGLISH;
            word.Czech = CZECH;
            var quiz = new WordQuiz(word);

            //Act
            
            //Assert
            Assert.AreEqual(quiz.English, ENGLISH);
            Assert.AreEqual(quiz.Czech, CZECH);
        }

        [TestMethod]
        public void TestValidation()
        {
            //Arrange
            var quiz = new WordQuiz();
            quiz.Czech = CZECH;
            quiz.English = ENGLISH;

            //Assert (wrong translation yields validation errors)
            quiz.userTranslation = ENGLISH;
            var validationErrors = quiz.Validate(null);
            Assert.IsFalse(validationErrors.ToList ().Count == 0);

            //Assert (right translation yields no validation errors)
            quiz.userTranslation = CZECH;
            validationErrors = quiz.Validate(null);
            Assert.IsTrue(validationErrors.ToList().Count == 0);

        }

    }
}
