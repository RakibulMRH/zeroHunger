using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class RestaurantDTO
    {
        public int rId { get; set; }
        public string foodName { get; set; }
        public System.DateTime prsvTime { get; set; }
        public string status { get; set; }
        public Nullable<int> rider { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee Employee { get; set; }
    }
}