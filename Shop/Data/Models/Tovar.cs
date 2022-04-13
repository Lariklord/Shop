using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Tovar
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sdesk { get; set; }
        public string ldesk { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }

        public bool isF { get; set; }
        public bool available { get; set; }
        public int catID { get; set; }
        public virtual Category Category { get; set; }
    }
}
