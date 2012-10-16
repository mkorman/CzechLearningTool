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
        public void Model_WordQuiz_DefaultConstructor()
        {
            //arrange
            var quiz = new WordQuiz();

            // act

            // Assert
            Assert.IsNotNull(quiz, "WordQuiz created by default constructor is supposed to be non-null");
        }

        [TestMethod]
        public void Model_WordQuiz_Constructor()
        {
            //Arrange
            var word = new Word();
            word.English = ENGLISH;
            word.Czech = CZECH;
            var quiz = new WordQuiz(word);

            //Act
            
            //Assert: ensure that the properties map to the word object
            Assert.IsNotNull(quiz, "WordQuiz created by constructor is supposed to be non-null");
            Assert.AreEqual(quiz.English, word.English, "Word and Test Word English property do not match");
            Assert.AreEqual(quiz.Czech, word.Czech, "Word and Test Word Czech property do not match");
            Assert.IsTrue(quiz.hintLevel == 0, "Initial hint level is not 0");
        }

        [TestMethod]
        public void Model_WordQuiz_Validation()
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

        [TestMethod]
        public void Model_WordQuiz_Hint()
        {
            // Arrange
            var quiz = new WordQuiz();
            quiz.English = "Saturday";
            quiz.Czech = "Sobota";

            // Act + Assert
            Assert.IsTrue(quiz.userTranslation.Equals(String.Empty));
            quiz.Hint();
            Assert.IsTrue (quiz.userTranslation.Equals ("S*****"),"Hint failed on level 1");
            quiz.Hint();
            Assert.IsTrue(quiz.userTranslation.Equals("So****"), "Hint failed on level 2");
            quiz.Hint();
            Assert.IsTrue(quiz.userTranslation.Equals("Sob***"), "Hint failed on level 3");
            quiz.Hint();
            Assert.IsTrue(quiz.userTranslation.Equals("Sobo**"), "Hint failed on level 4");
            quiz.Hint();
            Assert.IsTrue(quiz.userTranslation.Equals("Sobot*"), "Hint failed on level 5");
            quiz.Hint();
            Assert.IsTrue(quiz.userTranslation.Equals("Sobota"), "Hint failed on level 6");
            // At this point, it should validate OK
            var validationErrors = quiz.Validate(null);
            Assert.IsTrue(validationErrors.ToList().Count == 0, "Word quiz does not validate successfully after as many hints as its word length");


            // Test that any further quizzes don't break
            for (int i = 0; i < 100; i++)
            {
                quiz.Hint();
                Assert.IsTrue(quiz.userTranslation.Equals("Sobota"), "Hint failed when over the word length");
            }
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException), "Hinting on a null English word did not throw as expected")]
        public void Model_WordQuiz_HintOnEmptyCzech()
        {
            // Arrange
            var quiz = new WordQuiz();
            quiz.English = "ABCDE";

            // Act + Assert
            Assert.IsTrue(quiz.userTranslation.Equals(String.Empty));

            quiz.Hint(); // This should throw as English is null ATM
        }

    }
}
