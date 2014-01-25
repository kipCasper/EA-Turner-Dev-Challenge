using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class TitlesController : Controller
    {
        private TitlesEntities1 db = new TitlesEntities1();

        //
        // GET: /Titles/

        public ActionResult Index(string searchString = "")
        {
            if (searchString == "")
            {
                return View(db.Titles.ToList());
            }

            var titles = from m in db.Titles
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                titles = titles.Where(s => s.TitleName.Contains(searchString));
            }

            return View(titles);
        }

        //
        // GET: /Titles/Details/5

        public ActionResult Details(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }        

        //
        // GET: /Titles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titles/Create

        [HttpPost]
        public ActionResult Create(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        //
        // GET: /Titles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Titles/Edit/5

        [HttpPost]
        public ActionResult Edit(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }        
    }
}