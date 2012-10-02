using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning.Controllers
{
    /// <summary>
    /// Allows the user to test his knowledge by presenting an English word and asking for the translation.
    /// 
    /// If the translation is wrong, an error will be presented to the user
    /// </summary>
    public class QuizController : Controller
    {

        private CzechLearningContext db = new CzechLearningContext();

        //
        // Presents the test of a word at random
        //
        // GET: /Test/
        //
        public ActionResult Index()
        {

            var rand = new Random ();

            IList <Word> words = db.Words.ToList ();

            var word = words.ElementAt(rand.Next(words.Count));

            return View(new WordQuiz (word));
        }


        public ActionResult CheckWord(WordQuiz word)
        {
            if (ModelState.IsValid)
                return View("Index");

            return View("Index", word);
        }
    }
}
