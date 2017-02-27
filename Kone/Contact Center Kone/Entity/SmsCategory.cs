using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class SmsCategory
    {
        public int id { get; set; }
        public string category { get; set; }
        public int direction_id { get; set; }
    }
}
