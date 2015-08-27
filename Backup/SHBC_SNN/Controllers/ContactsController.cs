using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHBC_SNN.Models;
using SHBC_SNN.Migrations;
using System.Net;
using System.Threading.Tasks;

namespace SHBC_SNN.Controllers
{
    public class ContactsController : Controller
    {
        SnnDb db = new SnnDb();

        //
        // GET: /Contacts/

        public ActionResult Index([Bind(Prefix="id")]int snncaseId) // Id of Snn Case. 
        {
            var snnCase = db.SnnCases.Find(snncaseId);
            if (snnCase != null)
            {
                return View(snnCase);
            }
            return View("_NotFound");
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            SnnContacts snncontacts = db.SnnContacts.Find(id);
            if (snncontacts == null)
            {
                return HttpNotFound();
            }
            return View(snncontacts);
        }

        //
        // GET: /Contacts/Create
        [HttpGet]
        public ActionResult Create(int snncaseId)
        {
            return View();
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnnContacts snncontacts)
        {
            if (ModelState.IsValid)
            {
                db.SnnContacts.Add(snncontacts);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = snncontacts.SnnCaseId });
            }

            return View(snncontacts);
        }

        //
        // GET: /Contacts/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //var model = db.SnnContacts.Find(id);
            //return View(model);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SnnContacts contact = db.SnnContacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            PopulateContactMethodDropDownList(contact.ContMethod);
            return View(contact);
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id, Name, Email, SnnCaseId")]SnnContacts snncontacts) // Security measure.
        public ActionResult Edit(SnnContacts snncontacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snncontacts).State = EntityState.Modified; // Sytem.Data.Entity; Method. 
                db.SaveChanges();
                return RedirectToAction("Index", new { id = snncontacts.SnnCaseId });
            }

            return View(snncontacts);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SnnContacts snncontacts = db.SnnContacts.Find(id);
            if (snncontacts == null)
            {
                return HttpNotFound();
            }
            return View(snncontacts);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SnnContacts snncontacts = db.SnnContacts.Find(id);
            db.SnnContacts.Remove(snncontacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PopulateContactMethodDropDownList(object selectedContactMethod = null)
        {
            var contactMethodQuery = from c in db.SnnContacts
                                     orderby c.ContactMethod
                                     select c;
            ViewBag.ContactMethodID = new SelectList(contactMethodQuery, "Number", "Type", selectedContactMethod);
        }
    }
}