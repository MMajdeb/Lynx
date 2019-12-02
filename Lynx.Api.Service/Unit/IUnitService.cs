using Lynx.Api.Models;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public interface IUnitService
    {
        IQueryable<Unit> Get();
        Task<Unit> Get(int id);
        Task<Unit> Create(UnitModel model);
        Task<Unit> Update(int id, UnitModel model);
        Task Remove(int id);
    }
}
