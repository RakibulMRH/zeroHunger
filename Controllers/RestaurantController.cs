using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [Auth.RestaurantAccess]
        public ActionResult Index()
        {
            return View();
        }
    }
}