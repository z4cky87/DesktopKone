using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportPerformanceInbound
    {
        public string date { get; set; }
        public string agent { get; set; }
        public int total_recieve { get; set; }
        public int total_answer { get; set; }
        public int total_abandon { get; set; }
        public int total_phantom { get; set; }
        public string total_call_duration { get; set; }
        public string total_avg_call_duration { get; set; }
        public string total_acwtime { get; set; }
        public string total_avg_acwtime { get; set; }
        public int total_blankcall { get; set; }
        public int total_complain { get; set; }
    }
}
