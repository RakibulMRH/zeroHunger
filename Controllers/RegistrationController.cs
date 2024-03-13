using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DTOs;
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

        public static Employee Convert (EmployeeDTO emp)
        {
            return new Employee
            {
                empId = emp.empId,
                eName = emp.eName,
                status = emp.status,
                assigned = emp.assigned,
                mobile = emp.mobile,
                email = emp.email,
                Restaurant = emp.Restaurant,
                Restaurants = emp.Restaurants
            };
        }

        public static EmployeeDTO Convert(Employee emp)
        {
            return new EmployeeDTO
            {
                empId = emp.empId,
                eName = emp.eName,
                status = emp.status,
                assigned = emp.assigned,
                mobile = emp.mobile,
                email = emp.email,
                Restaurant = emp.Restaurant,
                Restaurants = emp.Restaurants
            };
        }   

        [HttpPost]
        public ActionResult Index(EmployeeDTO e, string uname, string pass)
        {
            Employee emp = Convert(e);
            emp.assigned = null;
            emp.status = "Pending";
            db.Employees.Add(emp);
            db.SaveChanges();

            Login l = new Login();
            l.uname = uname;
            l.pass = pass;
            l.type = "Employee";
            db.Logins.Add(l);
            db.SaveChanges();

            TempData["Msg"] = "Registration Successful";
            return RedirectToAction("Index");   

        }
    }
}