﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportEmail
    {
        public string mail_date { get; set; }
        public string mail_time { get; set; }
        public string mail_status_name { get; set; }
        public string direction_name { get; set; }
        public string user_name { get; set; } 
        public string mail_from { get; set; }
        public string mail_to { get; set; }
        public string mail_cc { get; set; }
        public string mail_bcc { get; set; }
        public string mail_subject { get; set; }
        public string mail_text { get; set; }
        public string ticket_no { get; set; }
        public string category_name { get; set; }
    }
}
