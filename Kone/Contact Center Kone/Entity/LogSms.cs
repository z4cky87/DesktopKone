using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class LogSms
    {
        public int sms_id { get; set; }        
        public int user_id { get; set; }
        public int sms_status_id { get; set; }
        public int direction_id { get; set; }
        public int ticket_id { get; set; }
        public string sms_date { get; set; }
        public string sms_time { get; set; }
        public int sms_read { get; set; }
        public string sms_from { get; set; }
        public string sms_to { get; set; }
        public string sms_text { get; set; }
        public string username_agent { get; set; }
        public string sms_status { get; set; }
        public string sms_direction { get; set; }
        public string ticketno { get; set; } 
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
}
