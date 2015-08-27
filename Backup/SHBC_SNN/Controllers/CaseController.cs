using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHBC_SNN.Models;

namespace SHBC_SNN.Controllers
{
    public class CaseController : Controller
    {
        SnnDb db = new SnnDb();

        //
        // GET: /Case/

        public ActionResult Index()
        {
            
            return View(db.SnnCases.ToList());
        }

        //
        // GET: /Case/Details/5

        public ActionResult Details(int id = 0)
        {
            SnnCase snncase = db.SnnCases.Find(id);
            if (snncase == null)
            {
                //return HttpNotFound();
                return View("_NotFound"); // Shared view to replace standard 404 message.
            }
            return View(snncase);
        }

        //
        // GET: /Case/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Case/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnnCase snncase)
        {
            if (ModelState.IsValid)
            {
                db.SnnCases.Add(snncase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(snncase);
        }

        //
        // GET: /Case/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SnnCase snncase = db.SnnCases.Find(id);
            if (snncase == null)
            {
                return HttpNotFound();
            }
            return View(snncase);
        }

        //
        // POST: /Case/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SnnCase snncase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snncase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(snncase);
        }

        //
        // GET: /Case/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SnnCase snncase = db.SnnCases.Find(id);
            if (snncase == null)
            {
                return HttpNotFound();
            }
            return View(snncase);
        }

        //
        // POST: /Case/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SnnCase snncase = db.SnnCases.Find(id);
            db.SnnCases.Remove(snncase);
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