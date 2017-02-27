using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportBreak
    {
        public string username { get; set; }
        public string breakreason { get; set; }
        public string note { get; set; }
        public string break_date { get; set; }
        public string break_time { get; set; }
        public string resume_date { get; set; }
        public string resume_time { get; set; }
        public string duration { get; set; }
        public string total_duration { get; set; }
    }
}
