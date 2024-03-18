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
        public string resName { get; set; }
        public string uname { get; set; }
        public string status { get; set; }

        public virtual ICollection<DetailDTO> Details { get; set; } // Assuming DetailDTO exists
        public virtual LoginDTO Login { get; set; } // Assuming LoginDTO exists
        public virtual ICollection<OrderDTO> Orders { get; set; } // Assuming OrderDTO exists

    }
}