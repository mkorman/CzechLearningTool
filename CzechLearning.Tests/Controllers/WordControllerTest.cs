﻿using System;
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
        public void Controller_Word_Index()
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

        [TestMethod]
        public void Controller_Word_Details()
        {
            // Arrange
            var controller = new WordController();

            // Act
            ActionResult result = controller.Details() as ActionResult;

            // Assert
            Assert.IsNotNull(result, "Expected a non null action result");

            // Act
            result = controller.Details(-1) as ActionResult;

            // Assert
            Assert.IsInstanceOfType (result, typeof (HttpNotFoundResult), "Expected Http not found on querying nonexisting word");
        }

        [TestMethod]
        public void Controller_Word_Create()
        {
            // We always expect a view, allowing us to create

            // Arrange
            var controller = new WordController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Expected a non null view result");
        }
    }
}
