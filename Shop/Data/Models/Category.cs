using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desk { get; set; }
        public List<Tovar> Tovars{get;set;}
    }
}
