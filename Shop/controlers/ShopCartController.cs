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
    public class ShopCartController:Controller
    {
        private  IAllTovars _tovrep;
        private readonly ShopCart _shopcart;
        public ShopCartController(IAllTovars tovrep,ShopCart shopCart)
        {
            _tovrep = tovrep;
            _shopcart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopcart.GetShopItems();
            _shopcart.list = items;
            var obj = new ShopCartViewModel
            {
                shopcart = _shopcart
            };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _tovrep.Tovars.FirstOrDefault(i=>i.id==id);
            if (item != null)
                _shopcart.AddToCart(item);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult delete(int id)
        {
            var item = _tovrep.Tovars.FirstOrDefault(i => i.id == id);
            if (item != null)
                _shopcart.DeleteFrom(item);
            return RedirectToAction("Index");
        }  }
}
