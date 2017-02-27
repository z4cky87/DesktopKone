using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class CallerTypeDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string isActive { get; set; }

        public CallerType callerType { get; set; }
    }
}
