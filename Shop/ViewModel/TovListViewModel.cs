using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public class TovListViewModel
    {
        public IEnumerable<Tovar> getAll { get; set; }
        public string tovCat { get; set; }
    }
}
