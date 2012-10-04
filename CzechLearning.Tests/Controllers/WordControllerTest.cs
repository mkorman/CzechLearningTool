using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CzechLearning.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CzechLearning.Models;

namespace CzechLearning.Tests.Controllers
{
    [TestClass]
    public class WordControllerTest
    {
        [TestMethod]
        public void TestWordControllerIndex()
        {
            // Arrange
            var controller = new WordController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType (result.Model, typeof (List<Word>));
        }
    }
}
