using Expenses.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Security
{
    public interface ISecurityContext
    {
        User User { get; }
        bool IsAdministrator { get; }
    }
}
