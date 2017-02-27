using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportCallOutbound
    {
        public int id { get; set; }
        public string call_date { get; set; }
        public string call_time { get; set; } 
        public string user_agent { get; set; }
        public string direction { get; set; }
        public string callertype { get; set; }
        public string call_status { get; set; }
        public string call_status_detail { get; set; } 
        public string shift { get; set; } 
        public string host_addr { get; set; }
        public string host_name { get; set; }
        public string extension { get; set; }
        public string duration { get; set; } 
        public string callernumber { get; set; }
        public string note { get; set; } 
    }
}
