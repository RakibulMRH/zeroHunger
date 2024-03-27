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
                ViewData["eNameValue"] = e.eName;
                ViewData["mobileValue"] = e.mobile;
                ViewData["emailValue"] = e.email;
                ViewData["unameValue"] = e.uname;
                ViewData["passValue"] = pass;
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

                
                return RedirectToAction("Index", "Login");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                TempData["Msg"] = ex.InnerException.InnerException.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(RestaurantDTO r, string uname, string pass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(r.uname))
                    {
                        Login dl = new Login();
                        dl.uname = r.uname;
                        dl.pass = pass;
                        dl.type = "Restaurant";

                        db.Logins.Add(dl);
                        db.SaveChanges();

                        Restaurant res = new Restaurant
                        {
                            resName = r.resName,
                            uname = r.uname,
                            status = r.status = "Pending"
                        };
                        db.Restaurants.Add(res);
                        db.SaveChanges();
                        TempData["Msg"] = "Registration Successful";
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        TempData["Msg"] = "Username already taken!";
                        return RedirectToAction("AddRestaurant");
                    }

                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    TempData["Msg"] = "Username already Exists";
                    return RedirectToAction("AddRestaurant");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            TempData["Msg"] = "Username already Exists";

                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            return RedirectToAction("AddRestaurant");

                        }
                    }
                }
                return RedirectToAction("AddRestaurant");

            }
            else 
            {
                return RedirectToAction("AddRestaurant");

            }
        }
            
        }
    }


