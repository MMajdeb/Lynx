using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lynx.Data.Access.DAL
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<UserBusinessUnit> UserBusinessUnits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Taxe> Taxes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Transfert> Transferts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
