using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AddDb appDBContent;
        public ShopCart(AddDb addDb)
        {
            this.appDBContent = addDb;
            ShopCartId = "CartId";
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> list { get; set; }
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AddDb>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Tovar tovar)
        {
            this.appDBContent.shopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                tovar = tovar,
                price = tovar.price
            });
            appDBContent.SaveChanges();   
        }
        public void DeleteFrom(Tovar tovar)
        {
            appDBContent.shopCartItem.Remove(appDBContent.shopCartItem.FirstOrDefault(c=>c.tovar==tovar && c.ShopCartId==ShopCartId));
            appDBContent.SaveChanges();
        }
        public void AllDel()
        {
            appDBContent.shopCartItem.RemoveRange(appDBContent.shopCartItem);
            appDBContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.shopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.tovar).ToList();
        }
    }
}
