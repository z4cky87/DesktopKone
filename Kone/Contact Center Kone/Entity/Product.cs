using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Entity
{
    public class Product
    {
       
   
        public int id { get; set; }
        public string productTypeName { get { return productType.name; } }
        public string name { get; set; }
        public string technology { get; set; }
        public string price { get; set; }
        public string warranty { get; set; }
        public string qty { get; set; }
        public string isActive { get; set; }

        public ProductType productType { get; set; }
      
    }
}
