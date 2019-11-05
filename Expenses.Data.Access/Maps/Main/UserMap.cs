using Expenses.Data.Access.Maps.Common;
using Microsoft.EntityFrameworkCore;
using System;
using Expenses.Data.Model;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Data.Access.Maps.Main
{
    public class UserMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
        }
    }
}
