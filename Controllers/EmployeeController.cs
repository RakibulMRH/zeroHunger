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
                orderStatus = f.orderStatus,
                riderId = f.riderId
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
                orderStatus = f.orderStatus,
                riderId = f.riderId

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
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.Orders.ToList();
            var convertedData = Convert(data);
            return View(convertedData);
        }

        [HttpPost]
        public ActionResult Index(int rId)
        {
            var data = db.Orders.Where(x => x.rId == rId).ToList();
            var dataPost = db.Orders.ToList();
            var convertedData = Convert(dataPost);
            foreach (var item in data)
            {
                item.orderStatus = "Collecting";
                item.riderId = rId;
            }

            var rider = db.Employees.Where(x => x.empId == rId).FirstOrDefault();
            db.SaveChanges();
            if (rider.availablity != "Assigned")
            {
                rider.availablity = "Assigned";
                var emp = (from e in db.Employees
                           where e.empId.Equals(rId)
                           select e).SingleOrDefault();
                Session["emp"] = emp;
                db.SaveChanges();
                return View(convertedData);
            }

            else
            {
                TempData["Msg"] = "You are already assigned to an order";
                return View(convertedData);
            }

        }
        [HttpPost]
        public ActionResult Completed(int rId, string orderStatus)
        {
            //change order status to collected in db where rId = rId
            var data = db.Orders.Where(x => x.rId == rId).ToList();
            var dataPost = db.Orders.ToList();
            var convertedData = Convert(dataPost);
            foreach (var item in data)
            {
                item.orderStatus = "Collected";
                item.riderId = rId;
            }

            var rider = db.Employees.Where(x => x.empId == rId).FirstOrDefault();
            rider.availablity = "Available";
            db.SaveChanges();
            var emp = (from e in db.Employees
                       where e.empId.Equals(rId)
                       select e).SingleOrDefault();
            Session["emp"] = emp;
            return RedirectToAction("Index");
        }
    }
}