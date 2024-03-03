using Microsoft.EntityFrameworkCore;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class PosDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<CategoryMdl> Category { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payments> Payments { get; set; }

        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=dbpos;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItemCategory>()
                .HasKey(mc => new {mc.MenuItemId, mc.CategoryId});

            modelBuilder.Entity<MenuItemCategory>()
                .HasOne(mc => mc.MenuItem)
                .WithMany(mi => mi.MenuItemCategories)
                .HasForeignKey(mc => mc.MenuItemId);

            modelBuilder.Entity<MenuItemCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MenuItemCategories)
                .HasForeignKey(mc => mc.CategoryId);
        }

    }
}
