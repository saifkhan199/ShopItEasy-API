using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.API.Model;

namespace ProductServices.Model { 
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   

            modelBuilder.Entity<CartProduct>()
               .HasNoKey();

        }
        public DbSet<ClothingProduct> ClothingProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<PurchasedItems> PurchasedItems { get; set; }

        public DbSet<Promo> Promos { get; set; }
        public DbSet<OrderStatus> orderStatus { get; set; }

    }
}
