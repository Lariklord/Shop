using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int TovID { get; set; }
        public uint price { get; set; }
        public virtual Tovar tovar { get; set; }
        public virtual Order order { get; set; }
   
    }
}
