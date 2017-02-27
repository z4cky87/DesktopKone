using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class OutboundStatusDetail
    {
        public int id { get; set; }
        public string status_detail { get; set; }
        public int outbound_status_id { get; set; }
    }
}
