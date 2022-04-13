using Shop.Data.Interf;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Rep
{
    public class CatRep : ITovarCat
    {
        private readonly AddDb appDBContent;
        public CatRep(AddDb addDb)
        {
            this.appDBContent = addDb;
        }
        public IEnumerable<Category> All => appDBContent.Category;
    }
}
