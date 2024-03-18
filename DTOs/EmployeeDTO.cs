using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;
using System.ComponentModel.DataAnnotations;

namespace zeroHunger.DTOs
{
    public class EmployeeDTO
    {//add validation
        public int empId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string eName { get; set; }
        public string status { get; set; }
        public Nullable<int> assigned { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string uname { get; set; }
        public string availablity { get; set; }

        public virtual Employee Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Login Login { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}