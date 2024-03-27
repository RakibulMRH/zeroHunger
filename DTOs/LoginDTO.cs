using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class LoginDTO
    {
        public int sl { get; set; }
        public string uname { get; set; }
        public string pass { get; set; }
        public string type { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}