using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }     
        public string fullname { get; set; }
        public string email { get; set; }
        public string host_addr { get; set; }
        public string host_name { get; set; }
        public string inbound_ext { get; set; }
        public string inbound_ext_pwd { get; set; }
        public string pbx_inbound { get; set; }
        public string outbound_ext { get; set; }
        public string outbound_ext_pwd { get; set; }
        public string pbx_outbound { get; set; }
        public string department { get; set; }
        public string level { get; set; }  
        public string isActive { get; set; }
        public string password { get; set; }
    }
   
}
