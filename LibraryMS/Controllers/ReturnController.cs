using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class ReturnController : Controller
    {

        LibraryEntities db = new LibraryEntities();
        // GET: Return
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetMid(int mid)
        {
            var memid = (from s in db.issuebooks
                         where s.member_id == mid select new
                         {
                             issueDate =s.issuedate,
                             RtnDate =s.returndate,
                             BkName = s.book_id,
                             ElapsDay = SqlFunctions.DateDiff("day", s.returndate, DateTime.Now)

                         }).ToArray();


            return Json(memid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(returnbook returns)
        {
            if (ModelState.IsValid)
            {
                db.returnbooks.Add(returns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returns);
        }
    }
}