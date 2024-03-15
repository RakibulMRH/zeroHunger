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
            var emp = (from e in db.Employees
                       where e.uname.Equals(l.uname)
                       select e).SingleOrDefault();
            var res = (from r in db.Restaurants
                       where r.uname.Equals(l.uname)
                       select r).SingleOrDefault();

            if (user != null)
            {
                Session["user"] = user;
                if (user.type.Equals("Admin"))
                {
                    return RedirectToAction("Home", "Admin");
                }
                if (user.type.Equals("Employee"))
                {
                    if (emp != null)
                    {
                        if (emp.status.Equals("Pending"))
                        {
                            TempData["Msg"] = "Your account is not yet approved";
                            return RedirectToAction("Index");
                        }
                        if (emp.status.Equals("Rejected"))
                        {
                            TempData["Msg"] = "Your account is rejected";
                            return RedirectToAction("Index");
                        }
                        if(emp.status.Equals("Approved"))
                        {
                            Session["emp"] = emp;
                            return RedirectToAction("Index", "Employee");
                        }   
                    }
                    return RedirectToAction("Index", "Employee");
                }
                if (user.type.Equals("Restaurant"))
                {
                    if (res != null)
                    {
                        Session["res"] = res;
                    }
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