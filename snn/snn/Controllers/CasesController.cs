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
    public class CasesController : Controller
    {
        private snnContext db = new snnContext();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases.Include(r => r.Address).Include(s => s.CaseStatus).Include(t => t.CaseType);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            var statuses = db.CaseStatus.OrderBy(s => s.StatusDescription);
            var types = db.CaseTypes.OrderBy(t => t.TypeDescription);

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress");
            ViewBag.CaseStatusID = new SelectList(statuses, "CaseStatusID", "StatusDescription");
            ViewBag.CaseTypeID = new SelectList(types, "CaseTypeID", "TypeDescription", 6); // 6 equals default value ('N/A').
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,CaseStatusID,CaseTypeID,AddressID")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", @case.AddressID);
            ViewBag.CaseStatusID = new SelectList(db.CaseStatus, "CaseStatusID", "StatusDescription", @case.CaseStatusID);
            ViewBag.CaseTypeID = new SelectList(db.CaseTypes, "CaseTypeID", "TypeDescription", @case.CaseTypeID);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", @case.AddressID);
            ViewBag.CaseStatusID = new SelectList(db.CaseStatus, "CaseStatusID", "StatusDescription", @case.CaseStatusID);
            ViewBag.CaseTypeID = new SelectList(db.CaseTypes, "CaseTypeID", "TypeDescription", @case.CaseTypeID);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,CaseStatusID,CaseTypeID,AddressID")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "FullAddress", @case.AddressID);
            ViewBag.CaseStatusID = new SelectList(db.CaseStatus, "CaseStatusID", "StatusDescription", @case.CaseStatusID);
            ViewBag.CaseTypeID = new SelectList(db.CaseTypes, "CaseTypeID", "TypeDescription", @case.CaseTypeID);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
