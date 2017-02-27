using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class OutboundTypeDetail
    {
        public int id { get; set; }
        public string type_detail { get; set; }
        public string isActive { get; set; }

        public Entity.OutboundType outboundType { get; set; }
    }
}
