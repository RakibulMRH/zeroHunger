using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DTOs;
using zeroHunger.EF;

namespace zeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        zeroHungerEntities db = new zeroHungerEntities();
        // GET: Employee
        [Auth.EmployeeAccess]
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

        public ActionResult Collecting(int rId) 
        {

        }
    }
}