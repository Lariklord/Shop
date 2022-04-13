using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Data
{
    public class AddDb:DbContext
    {
        public AddDb(DbContextOptions<AddDb> options):base(options)
        {

        }
        public DbSet<Tovar> Tovar { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> shopCartItem  { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }
}
