using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class issuebookController : Controller
    {
        LibraryEntities db = new LibraryEntities();
        // GET: issuebook
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getBook()
        {
            var book = db.books.Select(p => new { Id =p.id, Bname = p.bkName}).ToList();
            return Json(book, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult getMid( int mid)
        {
            var memberid = (from s in db.members where s.id == mid select s.name).ToList();
            return Json(memberid, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Save(issuebook issue)
        {
           if(ModelState.IsValid)
            {
                db.issuebooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issue);
        }
    }
}