using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Expenses.Data.Model;
using System.Threading.Tasks;
using Expenses.Api.Models.Expenses;

namespace Expenses.Queries.Queries
{
    public interface IExpensesQueryProcessor
    {
        IQueryable<Expense> GetQuery();
        Expense Get(int id);
        Task<Expense> Create(CreateExpenseModel expense);
        Task<Expense> Update(int id, UpdateExpenseModel expense);
        Task Delete(int id);
    }
}
