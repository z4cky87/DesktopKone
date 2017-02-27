using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class MailAttachment
    {
        public int id { get; set; }
        public int mail_id { get; set; }
        public string filename { get; set; }
    }
}
