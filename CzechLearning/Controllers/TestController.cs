using CzechLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CzechLearning.Controllers
{
    public class TestController : Controller
    {

        private CzechLearningContext db = new CzechLearningContext();

        //
        // GET: /Test/

        public ActionResult Index()
        {

            var rand = new Random ();

            IList <Word> words = db.Words.ToList ();

            var Word = words.ElementAt(rand.Next(words.Count));

            return View(Word);
        }

    }
}
