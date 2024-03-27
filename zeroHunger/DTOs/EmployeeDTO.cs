using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class EmployeeDTO
    {
        public int empId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string eName { get; set; }

        public string status { get; set; }

        public Nullable<int> assigned { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^(?:\+?88)?01[3-9]\d{8}$", ErrorMessage = "Please enter a valid Bangladeshi mobile number.")]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Username is required")]

        public string uname { get; set; }

        public string availablity { get; set; }

        public virtual Employee Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Login Login { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}