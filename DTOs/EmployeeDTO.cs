using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class EmployeeDTO
    {

        public int empId { get; set; }
        public string eName { get; set; }
        public string status { get; set; }
        public Nullable<int> assigned { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}