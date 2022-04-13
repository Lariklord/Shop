using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interf;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.controlers
{
    public class HomeController:Controller
    {
        private IAllTovars _tovrep;
      
        public HomeController(IAllTovars tovrep)
        {
            _tovrep = tovrep;
        }
        public ViewResult Index()
        {
            var HomeCars = new HomeViewModel
            {
                fav=_tovrep.GetFTov
            };
            return View(HomeCars);
        }
    }
}
