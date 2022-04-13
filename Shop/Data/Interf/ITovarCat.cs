using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interf
{
    public interface ITovarCat
    {
        IEnumerable<Category> All { get; }
    }
}
