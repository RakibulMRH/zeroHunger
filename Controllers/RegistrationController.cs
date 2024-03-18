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

        [HttpPost]
        public ActionResult Index(EmployeeDTO e, string uname, string pass)
        {
            try
            {
                Login l = new Login();
                l.uname = uname;
                l.pass = pass;
                l.type = "Employee";

                db.Logins.Add(l);
                db.SaveChanges();

                e.availablity = "Available";

                Employee emp = Convert(e);
                emp.status = "Pending";
                db.Employees.Add(emp);
                db.SaveChanges();

                TempData["Msg"] = "Registration Successful";

                ViewData["eNameValue"] = e.eName;
                ViewData["mobileValue"] = e.mobile;
                ViewData["emailValue"] = e.email;
                ViewData["unameValue"] = e.uname;
                ViewData["passValue"] = pass;
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                TempData["Msg"] = ex.InnerException.InnerException.Message;
                return RedirectToAction("Index");
            }
        }


        public ActionResult AddRestaurant()
        {

            return View();
        }
    }
}