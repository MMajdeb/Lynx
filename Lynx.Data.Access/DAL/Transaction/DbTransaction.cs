using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Access.DAL.Transaction
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _dbContextTransaction;
        public DbTransaction(IDbContextTransaction dbContextTransaction)
        {
            _dbContextTransaction = dbContextTransaction;
        }
        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Dispose()
        {
            _dbContextTransaction.Dispose();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
