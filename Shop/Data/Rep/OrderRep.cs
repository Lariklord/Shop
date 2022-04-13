using Shop.Data.Interf;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Rep
{
    public class OrderRep : IAllOrders
    {
        private readonly AddDb Add;
        private readonly ShopCart shopCart;
        public OrderRep(AddDb Add,ShopCart shopCart)
        {
            this.Add = Add;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            Add.Order.Add(order);
            Add.SaveChanges();
            var items = shopCart.list;

            foreach (var item in items)
            {
                var orderdetail = new OrderDetail()
                {
                    TovID = item.tovar.id,
                    orderID = order.id,
                    price = item.tovar.price
                };
                Add.orderDetails.Add(orderdetail);
            }
            Add.SaveChanges();
        }
    }
}
