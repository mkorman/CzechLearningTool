using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CzechLearning.Models;

namespace CzechLearning.Controllers
{
    public class WordController : Controller
    {
        private CzechLearningContext db = new CzechLearningContext();

        //
        // GET: /Word/

        public ActionResult Index()
        {
            return View(db.Words.OrderBy(Word => Word.English).ToList());
        }

        //
        // GET: /Word/Details/5

        public ActionResult Details(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // GET: /Word/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Word/Create

        [HttpPost]
        public ActionResult Create(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Words.Add(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(word);
        }

        //
        // GET: /Word/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Word/Edit/5

        [HttpPost]
        public ActionResult Edit(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        //
        // GET: /Word/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Word/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Word word = db.Words.Find(id);
            db.Words.Remove(word);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}