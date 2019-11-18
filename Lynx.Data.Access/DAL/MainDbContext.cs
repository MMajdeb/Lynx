using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Access.DAL
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<UserBusinessUnit> UserBusinessUnits { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
