using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class ReportHourlyInbound
    {
        public string hour { get; set; }
        public int total_recieve { get; set; }
        public int total_answered { get; set; }
        public int total_abandon { get; set; }
        public int total_phantom { get; set; }
        public string total_callduration { get; set; }
        public string total_avgcallduration { get; set; }
        public string total_acw { get; set; }
        public string total_avgacw { get; set; }
        public int total_blankcall { get; set; }
        public int total_wrongno { get; set; }
        public int total_inquiry { get; set; }
        public int total_complaint { get; set; }
        public int total_prospectcust { get; set; }
        public int total_request { get; set; }
        public int total_testcall { get; set; }
        public int total_others { get; set; }
        


    }
}
