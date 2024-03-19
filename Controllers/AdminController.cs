using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DTOs;
using zeroHunger.EF;

namespace zeroHunger.Controllers
{
    public class AdminController : Controller
    {
        zeroHungerEntities db = new zeroHungerEntities();

        private readonly zeroHungerEntities _db;

        public AdminController()
        {
            _db = new zeroHungerEntities(); 
        }

        // GET: Admin
        [Auth.AdminAccess]
        public ActionResult Index()
        {
            var data = db.Orders.ToList();
            data = data.OrderByDescending(x => x.oId).ToList();
            return View(Convert(data));
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Employees()
        {
            var data = db.Employees.ToList();
            data = data.OrderByDescending(x => x.empId).ToList();

            return View(Convert(data));
        }
        public ActionResult EmployeesRemove(int empId)
        {
            var emp = db.Employees.Find(empId);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Employees");
        }
        [HttpPost]
        public ActionResult Employees(int? empId)
        {
            var data = db.Employees.Where(x => x.empId == empId).ToList();
            //change the status of the employee to verified
            var emp = db.Employees.Find(empId);
            emp.status = "Verified";
            db.SaveChanges();
            return RedirectToAction("Employees");
        }

        public ActionResult Restaurants()
        {
            var data = db.Restaurants.ToList();
            data = data.OrderByDescending(x => x.rId).ToList();

            return View(Convert(data));
        }

        public ActionResult RestaurantsRemove(int rId)
        {
            var res = db.Restaurants.Find(rId);
            db.Restaurants.Remove(res);
            db.SaveChanges();
            return RedirectToAction("Restaurants");
        }
        public ActionResult Details()
        {
            var mapper = MvcApplication.Mapper;

            var data = _db.Details.ToList();
            data = data.OrderByDescending(x => x.collectId).ToList();

            var dtoData = mapper.Map<List<DetailDTO>>(data);

            return View(dtoData);
        }
        [HttpPost]
        public ActionResult Restaurants(int? rId)
        {
            var data = db.Restaurants.Where(x => x.rId == rId).ToList();
            //change the status of the restaurant to verified
            var res = db.Restaurants.Find(rId);
                res.status = "Verified";
            db.SaveChanges();
            return RedirectToAction("Restaurants");
        }
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

        public static Employee Convert(EmployeeDTO emp)
        {
            return new Employee
            {
                empId = emp.empId,
                eName = emp.eName,
                status = emp.status,
                mobile = emp.mobile,
                email = emp.email,
                uname = emp.uname,
                availablity = emp.availablity
            };
        }

        public static EmployeeDTO Convert(Employee emp)
        {
            return new EmployeeDTO
            {
                empId = emp.empId,
                eName = emp.eName,
                status = emp.status,
                mobile = emp.mobile,
                email = emp.email,
                uname = emp.uname,
                availablity = emp.availablity
            };
        }

        public static Restaurant Convert(RestaurantDTO res)
        {
            return new Restaurant
            {
                rId = res.rId,
                resName = res.resName,
                uname = res.uname,
                status = res.status
            };
        }

        public static RestaurantDTO Convert(Restaurant res)
        {
            return new RestaurantDTO
            {
                rId = res.rId,
                resName = res.resName,
                uname = res.uname,
                status = res.status
            };
        }

        public static List<RestaurantDTO> Convert(List<Restaurant> data)
        {
            var list = new List<RestaurantDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static List<EmployeeDTO> Convert(List<Employee> data)
        {
            var list = new List<EmployeeDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
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



    }
}