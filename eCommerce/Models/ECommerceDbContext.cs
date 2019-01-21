using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Repositories;

namespace Model
{
    public class ECommerceDbContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }

        public ECommerceDbContext()
        {
        }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext>options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=eCommerceDb;uid=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasOne(p => p.Address).WithOne(i => i.User);

            modelBuilder.Entity<Address>().HasOne(u => u.User).WithOne(a => a.Address);

            modelBuilder.Entity<Article>().HasOne(u => u.Vendor).WithMany(a => a.ArticleSale);
            modelBuilder.Entity<Article>().HasOne(t => t.Tax);

            modelBuilder.Entity<ShoppingCart>().HasOne(u => u.Buyer);
            modelBuilder.Entity<ShoppingCart>().HasMany(u => u.Articles);

            modelBuilder.Entity<Comment>().HasOne(a => a.Article);
            modelBuilder.Entity<Comment>().HasOne(u => u.User);

            modelBuilder.Entity<Order>().HasOne(b => b.Basket);
            modelBuilder.Entity<Order>().HasOne(u => u.Client);
            modelBuilder.Entity<Order>().HasOne(s => s.Status);
           

            modelBuilder.Entity<Movement>().HasOne(a => a.Article);
        }
    }
}
