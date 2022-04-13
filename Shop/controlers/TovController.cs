using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interf;
using Shop.Data.Models;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.controlers
{
    public class TovController:Controller
    {
        private readonly IAllTovars allTovars;
        private readonly ITovarCat tovarCat;
        public TovController(IAllTovars allTovars,ITovarCat tovarCat)
        {
            this.allTovars = allTovars;
            this.tovarCat = tovarCat;
        }
       
        public object TovlistWiwModel { get; private set; }
        [Route("Tov/List")]
       [Route("Tov/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Tovar> tovars=null;
            string tovCat = "";
            if (string.IsNullOrEmpty(category))
            {
                tovars = allTovars.Tovars.OrderBy(i => i.id);
            }
            else
            {
                if ("salt"== category)
                {
                    tovars = allTovars.Tovars.Where(i => i.Category.name=="salt");
                }
                else
                {
                    tovars = allTovars.Tovars.Where(i => i.Category.name.Equals("ne salt"));

                }
                tovCat = _category;
            }
                
            var tovobj = new TovListViewModel
            {
                getAll = tovars,
                tovCat = tovCat
            };
            ViewBag.Title = "Vape Dream";
            return View(tovobj);
        }

    }
}
