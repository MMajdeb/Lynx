using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Data.Access.DAL.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Lynx.Data.Access.DAL.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public EfUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext DbContext => _dbContext;

        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return new DbTransaction(_dbContext.Database.BeginTransaction(isolationLevel));
        }

        public void Add<T>(T obj) where T : class
        {
            var set = _dbContext.Set<T>();
            set.Add(obj);
        }

        public void Attach<T>(T obj) where T : class
        {
            var set = _dbContext.Set<T>();
            set.Attach(obj);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
        public async Task<T> Get<T>(int id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Remove<T>(T obj) where T : class
        {
            var set = _dbContext.Set<T>();
            set.Remove(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            var set = _dbContext.Set<T>();
            set.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _dbContext = null;
        }

    }
}
