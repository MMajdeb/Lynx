using Lynx.Api.Models.BusinessUnit;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public interface IBusinessUnitService
    {
        IQueryable<BusinessUnit> Get();
        BusinessUnit Get(int id);
        Task<BusinessUnit> Create(BusinessUnitModel model);
        Task<BusinessUnit> Update(int id, BusinessUnitModel model);
        Task Remove(int id);
    }
}
