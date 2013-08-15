using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Controllers;
using CzechLearning.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using CzechLearning.Tests.Mocks;

namespace CzechLearning.Tests.Controllers
{
    [TestClass]
    public class QuizControllerTest
    {
        QuizController controller;

        [TestMethod]
        public void Controller_Quiz_Index()
        {
            // Arrange
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
            Assert.AreEqual(word.English, Data.English, "English field modified after a Hint () request");
            Assert.AreEqual(word.Czech, Data.Czech, "Czech field modified after a Hint () request");
            Assert.AreEqual(Data.hintLevel, 1, "Hint level field not increased by 1 after a Hint () request");
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
            var jsonResult = controller.CheckWord(word) as JsonResult;

            // Assert
            Assert.IsNotNull(jsonResult, "Expected a non-null PartialViewResult");
            Assert.IsInstanceOfType(jsonResult.Data, typeof (bool), "Expected a bool result");
        }

        [TestInitialize]
        public void Initialize ()
        {
            var mockRepo = new MockWordRepository();
            mockRepo.Create(new Word() { English = "Day", Czech = "Den" });
            controller = new QuizController(mockRepo.Words);
        }
    }
}
