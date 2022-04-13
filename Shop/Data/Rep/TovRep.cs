using Microsoft.EntityFrameworkCore;
using Shop.Data.Interf;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Rep
{
    public class TovRep : IAllTovars
    {
        private readonly AddDb appDBContent;
        public TovRep(AddDb addDb)
        {
            this.appDBContent = addDb;
        }

        public IEnumerable<Tovar> Tovars => appDBContent.Tovar.Include(c => c.Category);

        public IEnumerable<Tovar> GetFTov => appDBContent.Tovar.Where(p => p.isF).Include(c => c.Category);

        public Tovar getObj(int tovarid) => appDBContent.Tovar.FirstOrDefault(p => p.id == tovarid);
        
           
        
    }
}
