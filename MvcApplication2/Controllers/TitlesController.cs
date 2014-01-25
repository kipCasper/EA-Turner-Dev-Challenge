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

        public ActionResult Index()
        {
            return View(db.Titles.ToList());
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

        public ActionResult Search(string name)
        {
            var result = db.Titles.Where(a => a.TitleName == name).FirstOrDefault();
            if (result == null)
            {
                return View("/titles/");
            }
            Title title = db.Titles.Find(result.TitleId);
            if (title == null)
            {
                return HttpNotFound();
            }

            return View("/details/", title.TitleId);
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