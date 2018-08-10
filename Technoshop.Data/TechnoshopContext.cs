using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Technoshop.Models;

namespace Technoshop.Data
{
    public class TechnoshopContext : IdentityDbContext<User>
    {
        public TechnoshopContext(DbContextOptions<TechnoshopContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.Order)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            builder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.ProductId, cp.CategoryId });

            base.OnModelCreating(builder);
        }
    }
}
