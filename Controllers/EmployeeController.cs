using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Auth.EmployeeAccess]
        public ActionResult Index()
        {
            return View();
        }
    }
}