using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CzechLearning.Models;
using System.Data.Entity.Infrastructure;

namespace CzechLearning.Controllers
{
    [Authorize]
    public class WordController : Controller
    {
        private IWordRepository db;

        /// <summary>
        /// TODO: remove this when DI is fully implemented
        /// </summary>
        public WordController() : this (new WordRepository ())
        {
        }

        public WordController(IWordRepository context)
        {
            db = context;
        }

        //
        // GET: /Word/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Words.OrderBy(Word => Word.English).ToList());
        }

        //
        // GET: /Word/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Word word = db.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // GET: /Word/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Word/Create
        [Authorize]
        [HttpPost]
        [MultiButton(MatchFormKey = "Action", MatchFormValue = "Create")] 
        public ActionResult Create(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Create(word);
                return RedirectToAction("Index");
            }

            return View(word);
        }

        //
        // POST: /Word/CreateMore
        [Authorize]
        [HttpPost]
        [MultiButton(MatchFormKey = "Action", MatchFormValue = "Create More")] 
        public ActionResult CreateMore(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Create(word);
                return RedirectToAction("Create");
            }

            return View(word);
        }


        //
        // GET: /Word/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Word word = db.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Word/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Edit(word);
                return RedirectToAction("Index");
            }
            return View(word);
        }

        //
        // GET: /Word/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Word word = db.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Word/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}