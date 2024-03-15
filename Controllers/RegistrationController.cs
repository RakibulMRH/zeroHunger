﻿using System;
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
                uname = emp.uname
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
            };
        }   

        [HttpPost]
        public ActionResult Index(EmployeeDTO e, string uname, string pass)
        {
            Login l = new Login();
            l.uname = uname;
            l.pass = pass;
            l.type = "Employee";
            db.Logins.Add(l);
            db.SaveChanges();

            Employee emp = Convert(e);
            emp.status = "Pending";
            db.Employees.Add(emp);
            db.SaveChanges();

            

            TempData["Msg"] = "Registration Successful";
            return RedirectToAction("Index");   

        }

        public ActionResult AddRestaurant()
        {

            return View();
        }
    }
}