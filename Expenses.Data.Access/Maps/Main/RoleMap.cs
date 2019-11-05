using Expenses.Data.Access.Maps.Common;
using Expenses.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Data.Access.Maps.Main
{
    public class RoleMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable("Roles").HasKey(x => x.Id);
        }
    }
}
