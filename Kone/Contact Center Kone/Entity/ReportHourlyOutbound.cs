using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportHourlyOutbound
    {
        public string hour { get; set; }
        public int outgoing_call { get; set; }
        public int contact { get; set; }
        public int unconnect { get; set; }
        public string outboundcalltime { get; set; }
        public string avg_outboundcalltime { get; set; }
        public int customer { get; set; }
        public int noncustomer { get; set; }
        public int teknisi { get; set; }
        public int pic { get; set; }
    }
}
