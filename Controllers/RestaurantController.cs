using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DTOs;
using zeroHunger.EF;

namespace zeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        zeroHungerEntities db = new zeroHungerEntities();
        // GET: Restaurant
       // [Auth.RestaurantAccess]
        
        public static Order Convert(OrderDTO f)
        {
            return new Order
            {
                oId = f.oId,
                foodName = f.foodName,
                prsrvTime = f.prsrvTime,
                rId = f.rId,
                placeTime = f.placeTime,
                orderStatus = f.orderStatus
            };
        }
        public static OrderDTO Convert(Order f)
        {
            return new OrderDTO
            {
                oId = f.oId,
                foodName = f.foodName,
                prsrvTime = f.prsrvTime,
                rId = f.rId,
                placeTime = f.placeTime,
                orderStatus = f.orderStatus

            };
        }

        public static List<OrderDTO> Convert(List<Order> data)
        {
            var list = new List<OrderDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public ActionResult Index()
        {
            var data = db.Orders.ToList();
            var convertedData = Convert(data);
            return View(convertedData);
        }

        [HttpGet]
        public ActionResult AddFood()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddFood(OrderDTO f)
        {
            /*DateTime combinedDateTime;
            string combinedDateTimeString = $"{prsrvDate} {prsrvTime}:00";

            if (DateTime.TryParseExact(combinedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out combinedDateTime))
            {
                f.prsrvTime = combinedDateTime;
            }*/

            f.orderStatus = "collect";
            Order food = Convert(f);
            db.Orders.Add(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ViewFood()
        {
            zeroHungerEntities db = new zeroHungerEntities();
            return View(db.Orders.ToList());
        }
    }
}