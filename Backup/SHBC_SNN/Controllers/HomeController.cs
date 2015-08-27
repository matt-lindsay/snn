using SHBC_SNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHBC_SNN.Controllers
{
    public class HomeController : Controller
    {

        SnnDb _db = new SnnDb(); // Represents new instance of Db connection.
        
        public ActionResult Index(string searchTerm = null)
        {
            //var model = from r in _db.SnnCases // originally _db.SnnCases.ToList(); to display an inital list on the Home page.
            //            orderby r.CaseNo ascending
            //            select r;
            // Linq Comprehension method syntax.
            //var model = from r in _db.SnnCases
            //            orderby r.Contacts.Count() descending
            //            select new
            //            {
            //                r.Id,
            //                r.CaseNo,
            //                r.Address,
            //                r.Uprn,
            //                NumberOfContacts = r.Contacts.Count()  // Anonymous property.
            //            };
            //var model = from r in _db.SnnCases
            //            orderby r.Contacts.Count() descending
            //            where (r => searchTerm == null || r.CaseNo.StartsWith(searchTerm))
            //            select new SnnCaseViewModel
            //            {
            //                Id = r.Id,
            //                CaseNo = r.CaseNo,
            //                Address = r.Address,
            //                Uprn = r.Uprn,
            //                CountOfContacts = r.Contacts.Count()  // Anonymous property.
            //            };
            // Linq Extension method syntax.
            var model = _db.SnnCases
                .OrderByDescending(r => r.Contacts.Count())
                .Where(r => searchTerm == null || r.Address.StartsWith(searchTerm)) // Take input from user (form or query string).
                .Take(10) // Take blocks of 10 results.
                .Select(r => new SnnCaseViewModel
                {
                    Id = r.Id,
                    CaseNo = r.CaseNo,
                    Address = r.Address,
                    Uprn = r.Uprn,
                    CountOfContacts = r.Contacts.Count()
                }); // Now add <form> in Index Action to create search box.

            return View(model); // Edit Index action under Views.
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing) // Add dispose method.
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
