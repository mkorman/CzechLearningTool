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
        // Presents a word at random and allows the user to test it
        //
        // GET: /Test/
        //
        public ActionResult Index()
        {
            /*
            // our DB query
            var query = from word in db.Words
                        select word;

            // 1st round trip to DB: get count
            var count = query.Count();

            // Get a random number
            var rand = new Random();
            var randomIndex = rand.Next(count);

            // 2nd round trip: get a random item
            var randomWord = query.Skip(randomIndex).First();
            */

            // ToList() approach: this is sub-optimal, as we enumerate the whole lot
            var rand = new Random();
            IList <Word> words = db.Words.ToList ();
            var randomWord = words.ElementAt(rand.Next(words.Count));
            
            return View(new WordQuiz (randomWord));
        }

        /// <summary>
        /// This is a test to do the data binding
        /// 
        /// POST: /Test/
        /// 
        /// </summary>
        /// <param name="userWord"></param>
        /// <returns></returns>
        /*
        [HttpPost]
        public ActionResult Index(WordQuiz userWord)
        {
            return View(userWord);
        }
         */

        /// <summary>
        /// Returns a partial view which represents whether the word validated OK or not
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckWord(WordQuiz word)
        {
            return PartialView ("SuccessPartial", ModelState.IsValid);
        }

        /// <summary>
        /// Provides a hint for the supplied word as a JSON object
        /// </summary>
        /// <param name="userWord"></param>
        /// <returns></returns>
        public ActionResult Hint(WordQuiz userWord)
        {
            // Apply the hint for the word
            userWord.Hint();
            // Return the word with updated hint info serialized as Json
            return Json(userWord, JsonRequestBehavior.AllowGet);
        }
    }
}
