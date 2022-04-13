using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interf;
using Shop.Data.Models;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.controlers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders orders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders orders, ShopCart shopCart)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            shopCart.list = shopCart.GetShopItems();
            if (shopCart.list.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пустая");
                return View();
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.list = shopCart.GetShopItems();
           
            if(ModelState.IsValid)
            {
                orders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            shopCart.AllDel();
            ViewBag.Message = "Заказ обработан";
            return View();
        }
    }
}
