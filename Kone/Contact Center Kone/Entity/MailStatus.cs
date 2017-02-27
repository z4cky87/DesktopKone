using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class MailStatus
    {
        public int id { get; set; }
        public string mail_status { get; set; }
        public int direction_id { get; set; }
    }
}
