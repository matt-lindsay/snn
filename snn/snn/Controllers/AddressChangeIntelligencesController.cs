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
    public class AddressChangeIntelligencesController : Controller
    {
        private snnContext db = new snnContext();

        // GET: AddressChangeIntelligences
        public ActionResult Index()
        {
            return View(db.AddressChangeIntelligences.ToList());
        }

        // GET: AddressChangeIntelligences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressChangeIntelligence addressChangeIntelligence = db.AddressChangeIntelligences.Find(id);
            if (addressChangeIntelligence == null)
            {
                return HttpNotFound();
            }
            return View(addressChangeIntelligence);
        }

        // GET: AddressChangeIntelligences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressChangeIntelligences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressChangeIntelligenceID,AddressChangeIntelligenceDescription")] AddressChangeIntelligence addressChangeIntelligence)
        {
            if (ModelState.IsValid)
            {
                db.AddressChangeIntelligences.Add(addressChangeIntelligence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addressChangeIntelligence);
        }

        // GET: AddressChangeIntelligences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressChangeIntelligence addressChangeIntelligence = db.AddressChangeIntelligences.Find(id);
            if (addressChangeIntelligence == null)
            {
                return HttpNotFound();
            }
            return View(addressChangeIntelligence);
        }

        // POST: AddressChangeIntelligences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressChangeIntelligenceID,AddressChangeIntelligenceDescription")] AddressChangeIntelligence addressChangeIntelligence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressChangeIntelligence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressChangeIntelligence);
        }

        // GET: AddressChangeIntelligences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressChangeIntelligence addressChangeIntelligence = db.AddressChangeIntelligences.Find(id);
            if (addressChangeIntelligence == null)
            {
                return HttpNotFound();
            }
            return View(addressChangeIntelligence);
        }

        // POST: AddressChangeIntelligences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressChangeIntelligence addressChangeIntelligence = db.AddressChangeIntelligences.Find(id);
            db.AddressChangeIntelligences.Remove(addressChangeIntelligence);
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
