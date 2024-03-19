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
        private readonly zeroHungerEntities _db;

        public EmployeeController()
        {
            _db = new zeroHungerEntities();
        }
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
                riderId = f.riderId,
                resName = f.resName

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
                riderId = f.riderId,
                resName = f.resName

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
            data = data.OrderByDescending(x => x.oId).ToList();

            var convertedData = Convert(data);
            return View(convertedData);
        }

        [HttpPost]
        public ActionResult Index(int rId, int riderId)
        {
            var data = db.Orders.Where(x => (x.rId == rId && x.orderStatus == "collect")).ToList();
            var dataPost = db.Orders.ToList();
            var convertedData = Convert(dataPost);
           
            foreach (var item in data)
            {
                item.orderStatus = "Collecting";
                item.riderId = riderId;
            }
            db.SaveChanges();
            var rider = db.Employees.Where(x => x.empId == riderId).FirstOrDefault();
            
            if (rider.availablity != "Assigned")
            {
                rider.availablity = "Assigned";
                var emp = (from e in db.Employees
                           where e.empId.Equals(riderId)
                           select e).SingleOrDefault();
                Session["emp"] = emp;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                TempData["Msg"] = "You are already assigned to an order";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Completed(int rId, int riderId)
        {
            var ordersToComplete = db.Orders.Where(x => x.rId == rId && x.orderStatus == "Collecting").ToList();

            // Convert all orders
            var convertedData = Convert(db.Orders.ToList());

            string originalOrderStatus = ""; // To store the original order status

            foreach (var order in ordersToComplete)
            {
                originalOrderStatus = order.orderStatus; // Save original status
                order.orderStatus = "Collected";
                order.riderId = riderId;

                // Update restaurant status
                var restaurant = db.Orders.FirstOrDefault(r => r.rId == rId);
                if (restaurant != null)
                {
                    restaurant.orderStatus = "Collected";
                }
                var detail = MvcApplication.Mapper.Map<Detail>(order);
                detail.rider = riderId; // Set rider

                // Add the new Detail entity to the context
                db.Details.Add(detail);
            }

            db.SaveChanges();

            var rider = db.Employees.FirstOrDefault(x => x.empId == riderId);

            if (rider != null)
            {
                if (rider.availablity == "Assigned")
                {
                    rider.availablity = "Available";
                    Session["emp"] = rider;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Msg"] = originalOrderStatus + " You are already assigned to an order";
                }
            }
            else
            {
                TempData["Msg"] = "Rider not found"; // Handle the case where rider is not found
            }

            return RedirectToAction("Index");
        }

    }
}