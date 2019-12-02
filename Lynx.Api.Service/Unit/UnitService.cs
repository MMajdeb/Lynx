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
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _uow;
        private readonly IItemService _itemService;

        public UnitService(IUnitOfWork uow, IItemService itemService)
        {
            _uow = uow;
            _itemService = itemService;
        }
        public async Task<Unit> Create(UnitModel model)
        {
            var unit = new Unit
            {
                ItemId = model.ItemId,
                Name = model.Name,
                Notes = model.Notes,
                PriceMultiplier = model.PriceMultiplier,
                QuantityMultiplier = model.QuantityMultiplier,
            };

            await AddItem(unit, model.ItemId);
            
            _uow.Add<Unit>(unit);
            await _uow.CommitAsync();

            return unit;
        }

        private async Task AddItem(Unit unit, int itemId)
        {
            unit.Item = await _itemService.Get(itemId);
        }

        public IQueryable<Unit> Get()
        {
            return _uow.Get<Unit>();
        }

        public async Task<Unit> Get(int id)
        {
            var unit = await Get().FirstOrDefaultAsync(x => x.Id == id);
            if (unit == null)
            {
                throw new NotFoundException("Unit is not found");
            }
            return unit;
        }

        public async Task Remove(int id)
        {
            var unit = await Get(id);
            if (unit.IsDeleted) return;

            unit.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public async Task<Unit> Update(int id, UnitModel model)
        {
            var unit =await Get(id);

            unit.ItemId = model.ItemId;
            unit.Name = model.Name;
            unit.Notes = model.Notes;
            unit.PriceMultiplier = model.PriceMultiplier;
            unit.QuantityMultiplier = model.QuantityMultiplier;

            await _uow.CommitAsync();
            return unit;
        }
    }
}
