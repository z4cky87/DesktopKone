using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportCallInbound
    {
        public int id { get; set; }
        public string call_date { get; set; }
        public string customer { get; set; }
        public string user_agent { get; set; }
        public string direction { get; set; }
        public string call_status { get; set; }
        public string inbound_caller_type { get; set; }
        public string inbound_type { get; set; }
        public string inbound_type_detail { get; set; }
        public string shift { get; set; }
        public string payment_method { get; set; }
        public string blank_call { get; set; }
        public string wrong_number { get; set; }
        public string host_addr { get; set; }
        public string host_name { get; set; }
        public string extension { get; set; }
        public string duration { get; set; }
        public string abandon { get; set; }
        public string delay { get; set; }
        public string busy { get; set; }
        public string callernumber { get; set; }
        public string note { get; set; }
        public string phonenumber { get; set; }
    }
}
