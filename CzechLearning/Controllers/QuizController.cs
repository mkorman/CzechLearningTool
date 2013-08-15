using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
    [Authorize]
    public class QuizController : Controller
    {
        /// <summary>
        /// Gets or sets the Words to quiz on.
        /// </summary>
        public IEnumerable<Word> Words { get; private set; }

        /// <summary>
        /// Default constructor.
        /// Populates word from a CzechLearningContext
        /// </summary>
        public QuizController ()
        {
            var db = new CzechLearningContext();
            Words = db.Words;
        }

        /// <summary>
        /// Parameterised constructor. Allows user to inject his own words db set
        /// </summary>
        /// <param name="words">The dbset to use</param>
        public QuizController (IEnumerable <Word> words)
        {
            Words = words;
        }

        //
        // Presents a word at random and allows the user to test it
        //
        // GET: /Test/
        //
        public ActionResult Index()
        {
            
            // our DB query
            var query = from word in Words
                        orderby word.WordId
                        select word;

            // 1st round trip to DB: get count
            var count = query.Count();

            // Get a random number
            var rand = new Random();
            var randomIndex = rand.Next(count);

            // 2nd round trip: get a random item
            var randomWord = query.Skip(randomIndex).First ();
            
            return View(new WordQuiz (randomWord));
        }

        /// <summary>
        /// Returns a Json-wrapped bool that indicates whether the word validated OK or not
        /// </summary>
        /// <param name="word">The word to quiz</param>
        /// <returns>A partial view to represent success or failure</returns>
        [HttpPost]
        public JsonResult CheckWord(WordQuiz word)
        {
            // Use validation to check whether the user's guess was successful or not
            return Json (ModelState.IsValid);
        }

        /// <summary>
        /// Provides a hint for the supplied word as a JSON object
        /// </summary>
        /// <param name="userWord"></param>
        /// <returns></returns>
        public JsonResult Hint(WordQuiz userWord)
        {
            // Apply the hint for the word
            userWord.Hint();
            // Return the word with updated hint info serialized as Json
            return Json(userWord, JsonRequestBehavior.AllowGet);
        }
    }
}
