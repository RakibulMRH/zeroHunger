using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class OrderDTO
    {
        public int oId { get; set; }
        public string foodName { get; set; }
        public System.DateTime prsrvTime { get; set; }
        public Nullable<int> rId { get; set; }
        public string orderStatus { get; set; }
        public byte[] placeTime { get; set; }
        public string resName { get; set; }

        public Nullable<int> riderId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}