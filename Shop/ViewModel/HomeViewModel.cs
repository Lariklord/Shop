using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Tovar> fav { get; set; }
    }
}
