using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Auth.AdminAccess]
        public ActionResult Index()
        {
            return View();
        }
    }
}