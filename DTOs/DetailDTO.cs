using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zeroHunger.EF;

namespace zeroHunger.DTOs
{
    public class DetailDTO
    {
        public int collectId { get; set; }
        public int rId { get; set; }
        public int rider { get; set; }
        public string foodName { get; set; }
        public System.DateTime timeRemained { get; set; }
        public string status { get; set; }
        public string resName { get; set; }

        public virtual Detail Details1 { get; set; }
        public virtual Detail Detail1 { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}