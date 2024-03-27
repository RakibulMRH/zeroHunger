using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace zeroHunger.DTOs
{
    public class RestaurantDTO
    {
        public int rId { get; set; }
        
        [Required(ErrorMessage = "Mobile Number is required")]

        public string resName { get; set; }
        [Required(ErrorMessage = "Username is required")]

        public string uname { get; set; }

        public string status { get; set; }

        public virtual ICollection<DetailDTO> Details { get; set; } // Assuming DetailDTO exists
        public virtual LoginDTO Login { get; set; } // Assuming LoginDTO exists
        public virtual ICollection<OrderDTO> Orders { get; set; } // Assuming OrderDTO exists
    }
}
