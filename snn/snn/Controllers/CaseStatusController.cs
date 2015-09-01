using System;
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
    public class CaseStatusController : Controller
    {
        private snnContext db = new snnContext();

        // GET: CaseStatus
        public ActionResult Index()
        {
            return View(db.CaseStatus.ToList());
        }

        // GET: CaseStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStatus caseStatus = db.CaseStatus.Find(id);
            if (caseStatus == null)
            {
                return HttpNotFound();
            }
            return View(caseStatus);
        }

        // GET: CaseStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseStatusID,StatusDescription")] CaseStatus caseStatus)
        {
            if (ModelState.IsValid)
            {
                db.CaseStatus.Add(caseStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseStatus);
        }

        // GET: CaseStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStatus caseStatus = db.CaseStatus.Find(id);
            if (caseStatus == null)
            {
                return HttpNotFound();
            }
            return View(caseStatus);
        }

        // POST: CaseStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseStatusID,StatusDescription")] CaseStatus caseStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseStatus);
        }

        // GET: CaseStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStatus caseStatus = db.CaseStatus.Find(id);
            if (caseStatus == null)
            {
                return HttpNotFound();
            }
            return View(caseStatus);
        }

        // POST: CaseStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseStatus caseStatus = db.CaseStatus.Find(id);
            db.CaseStatus.Remove(caseStatus);
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
