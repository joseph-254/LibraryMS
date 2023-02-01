using LibraryMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryMS.Controllers
{
    
    public class UsertTbController : Controller
    {
        LibraryEntities db = new LibraryEntities();
        // GET: UsertTb
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Usertable u)
        {
            if (db.Usertables.Any(x => x.userName == u.userName))
            {
                ViewBag.Notification = "This account already exists ";
                return View();
            }


            else
            {
                db.Usertables.Add(u);
                db.SaveChanges();

                Session["ids"] = u.id.ToString();
                Session["userNames"] = u.userName.ToString();
                return RedirectToAction("Index", "Home");

            }
        }
       

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usertable log)
        {
            var result = db.Usertables.Where(a => a.userName == log.userName && a.passWord == log.passWord).ToList();
            if (result.Count() > 0)
            {
                Session["ids"] = log.id.ToString(); /*result[0].id;*/
                Session["Usernames"] = log.userName.ToString();
                FormsAuthentication.SetAuthCookie(result[0].userName, false);
                //if Admin
                if (result[0].userRoleId == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result[0].userRoleId == 2)
                {
                    return RedirectToAction("Index", "books");
                }
            }
            else
            {
                ViewBag.Message = "Incorrect Username or Password";
            }
            return View(log);
        }

    }
}