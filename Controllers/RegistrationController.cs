using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.EF;

namespace zeroHunger.Controllers
{
    public class RegistrationController : Controller
    {
        zeroHungerEntities db = new zeroHungerEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String name)
        {
            //register employee
            return View("Login", "Login");

        }
    }
}