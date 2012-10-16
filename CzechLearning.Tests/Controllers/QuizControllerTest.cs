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
    }
}
