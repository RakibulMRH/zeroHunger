using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DTOs;
using zeroHunger.EF;

namespace zeroHunger.Controllers
{
    public class LoginController : Controller
    {
        zeroHungerEntities db = new zeroHungerEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            var user = (from u in db.Logins
                        where u.uname.Equals(l.uname)
                        && u.pass.Equals(l.pass)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["user"] = user;
                if (user.type.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (user.type.Equals("Employee"))
                {
                    return RedirectToAction("Index", "Employee");
                }
                if (user.type.Equals("Restaurant"))
                {
                    return RedirectToAction("Index", "Restaurant");
                }

                return RedirectToAction("Index");

            }
            TempData["Msg"] = "Invalid username and password";
            return RedirectToAction("Index");

        }
        //logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}