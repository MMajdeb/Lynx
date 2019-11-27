using Lynx.Api.Models;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public interface IItemService
    {
        IQueryable<Item> Get();
        Task<Item> Get(int id);
        Task<Item> Create(CreateItemModel model);
        Task<Item> Update(int id, CreateItemModel model);
        Task Remove(int id);
    }
}
