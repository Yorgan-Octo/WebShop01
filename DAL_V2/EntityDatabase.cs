using DAL_V2.Entity;
using DAL_V2.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V2
{
    internal class EntityDatabase : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<KeyParams> KeyLink { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDB_Task_2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
              .HasOne(c => c.User)
              .WithMany(p => p.Cart)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Cart)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<KeyParams>()
                .HasOne(p => p.Product)
                .WithMany(c => c.KeyWords);

            modelBuilder.Entity<KeyParams>()
                .HasOne(p => p.KeyWords)
                .WithMany(c => c.ProductLink);
        }


    }
}
