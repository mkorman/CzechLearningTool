using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Controllers;
using CzechLearning.Models;
using System.Web.Mvc;

namespace CzechLearning.Tests.Controllers
{
    [TestClass]
    public class QuizControllerTest
    {
        [TestMethod]
        public void Controller_Quiz_Index()
        {
            // Arrange
            var controller = new QuizController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Quiz Controller did not return a non-null ViewResult");
            
            // Act
            var word = result.Model as WordQuiz;

            Assert.IsNotNull (word, "Quiz Controller index did not return a non-null WordQuiz");
            Assert.IsTrue(word.hintLevel == 0, "Hint level is not zero");

        }

        [TestMethod]
        public void Controller_Quiz_Hint()
        {
            // Arrange
            var controller = new QuizController();
            var word = new WordQuiz();
            word.English = "Day";
            word.Czech = "Den";

            // Act
            var result = controller.Hint(word) as JsonResult;

            // Assert: we get back a wordquiz object with the same properties, but hint level increased by 1
            Assert.IsNotNull(word, "Expected a non-null JsonResult");
            var Data = result.Data as WordQuiz;
            Assert.IsNotNull(word, "Expected a non-null WordQuiz instance");
            Assert.IsTrue(word.English == Data.English, "English field modified after a Hint () request");
            Assert.IsTrue(word.Czech == Data.Czech, "Czech field modified after a Hint () request");
            Assert.IsTrue(Data.hintLevel == 1, "Hint level field not increased by 1 after a Hint () request");
        }

        [TestMethod]
        public void Controller_Quiz_Check()
        {
            // Arrange
            var controller = new QuizController();
            var word = new WordQuiz();
            word.English = "Day";
            word.Czech = "Den";

            // Act
            var result = controller.CheckWord(word) as PartialViewResult;

            // Assert
            Assert.IsNotNull(result, "Expected a non-null PartialViewResult");
        }
    }
}
