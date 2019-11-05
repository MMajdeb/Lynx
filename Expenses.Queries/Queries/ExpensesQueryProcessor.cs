using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expenses.Api.Common.Exceptions;
using Expenses.Api.Models.Expenses;
using Expenses.Data.Access.DAL;
using Expenses.Data.Model;
using Expenses.Security;

namespace Expenses.Queries.Queries
{
    public class ExpensesQueryProcessor : IExpensesQueryProcessor
    {
        public readonly IUnitOfWork _uow;
        public readonly ISecurityContext _securityContext;

        public ExpensesQueryProcessor(IUnitOfWork uow, ISecurityContext securityContext)
        {
            _uow = uow;
            _securityContext = securityContext;
        }
        public async Task<Expense> Create(CreateExpenseModel model)
        {
            var item = new Expense
            {
                UserId = _securityContext.User.Id,
                Amount = model.Amount,
                Comment = model.Comment,
                Date = model.Date,
                Description = model.Description,
            };

            _uow.Add(item);
            await _uow.CommitAsync();

            return item;
        }

        public async Task Delete(int id)
        {
            var expense = GetQuery().FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                throw new NotFoundException("Expense is not found");
            }
            if (expense.IsDeleted) return;

            expense.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<Expense> GetQuery()
        {
            var query = _uow.Query<Expense>().Where(x => !x.IsDeleted);

            if (!_securityContext.IsAdministrator)
            {
                var userId = _securityContext.User.Id;
                query = query.Where(x => x.UserId == userId);
            }
            return query;
        }
        public IQueryable<Expense> Get()
        {
            var query = GetQuery();
            return query;
        }

        public Expense Get(int id)
        {
            var expense = GetQuery().FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                throw new NotFoundException("Expense is not found");
            }
            return expense;
        }

        public async Task<Expense> Update(int id, UpdateExpenseModel model)
        {
            var expense = GetQuery().FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                throw new NotFoundException("Expense is not found");
            }

            expense.Amount = model.Amount;
            expense.Comment = model.Comment;
            expense.Description = model.Description;
            expense.Date = model.Date;

            await _uow.CommitAsync();
            return expense;
        }
    }
}
