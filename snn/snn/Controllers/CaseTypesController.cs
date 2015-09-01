﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using snn.Models;

namespace snn.Controllers
{
    public class CaseTypesController : Controller
    {
        private snnContext db = new snnContext();

        // GET: CaseTypes
        public ActionResult Index()
        {
            return View(db.CaseTypes.ToList());
        }

        // GET: CaseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseType caseType = db.CaseTypes.Find(id);
            if (caseType == null)
            {
                return HttpNotFound();
            }
            return View(caseType);
        }

        // GET: CaseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseTypeID,TypeDescription")] CaseType caseType)
        {
            if (ModelState.IsValid)
            {
                db.CaseTypes.Add(caseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseType);
        }

        // GET: CaseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseType caseType = db.CaseTypes.Find(id);
            if (caseType == null)
            {
                return HttpNotFound();
            }
            return View(caseType);
        }

        // POST: CaseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseTypeID,TypeDescription")] CaseType caseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseType);
        }

        // GET: CaseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseType caseType = db.CaseTypes.Find(id);
            if (caseType == null)
            {
                return HttpNotFound();
            }
            return View(caseType);
        }

        // POST: CaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseType caseType = db.CaseTypes.Find(id);
            db.CaseTypes.Remove(caseType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
