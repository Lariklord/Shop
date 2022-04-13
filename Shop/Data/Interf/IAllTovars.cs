using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interf
{
    public interface IAllTovars
    {
        IEnumerable<Tovar> Tovars { get; }
        IEnumerable<Tovar> GetFTov { get; }
        Tovar getObj(int tovarid);
    }
}
