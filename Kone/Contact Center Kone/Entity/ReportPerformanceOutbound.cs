using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportPerformanceOutbound
    {
        public string dates { get; set; }
        public string agent { get; set; }
        public string outgoing_call { get; set; }
        public string outboundcalltime { get; set; }
        public string avg_outboundcalltime { get; set; }
    }
}
