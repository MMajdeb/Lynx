using Lynx.Api.Models;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public interface IStoreService
    {
        IQueryable<Store> Get();
        Task<Store> Get(int id);
        Task<Store> Create(StoreModel model);
        Task<Store> Update(int id, StoreModel model);
        Task Remove(int id);
    }
}
