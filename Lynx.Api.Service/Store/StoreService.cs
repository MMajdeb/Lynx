using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Models;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lynx.Api.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _uow;
        private readonly IBusinessUnitService _businessUnitService;
        public StoreService(IUnitOfWork uow, IBusinessUnitService businessUnitService)
        {
            _uow = uow;
            _businessUnitService = businessUnitService;
        }

        public async Task<Store> Create(StoreModel model)
        {
            var store = new Store
            {
                Name=model.Name,
                BusinessUnitId=model.BusinessUnitId,
            };

            await AddBusinessUnit(store, model.BusinessUnitId);

            _uow.Add<Store>(store);
            await _uow.CommitAsync();
            return store;
        }

        private async Task AddBusinessUnit(Store store, int businessUnitId)
        {
            var bu = await _businessUnitService.Get(businessUnitId);
            store.BusinessUnit = bu;
        }

        public IQueryable<Store> Get()
        {
            return _uow.Get<Store>()
                .Include(x => x.BusinessUnit);
        }

        public async Task<Store> Get(int id)
        {
            var item= await Get().FirstOrDefaultAsync(x => x.Id==id);
            if(item == null)
            {
                throw new NotFoundException("Store is not found");
            }

            return item;
        }

        public async Task Remove(int id)
        {
            var item = await Get(id);
            if (item.IsDeleted) return;

            item.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public async Task<Store> Update(int id, StoreModel model)
        {
            var item =await Get(id);

            item.Name = model.Name;
            item.BusinessUnitId = model.BusinessUnitId;
            await AddBusinessUnit(item, model.BusinessUnitId);

            await _uow.CommitAsync();
            return item;
        }
    }
}
