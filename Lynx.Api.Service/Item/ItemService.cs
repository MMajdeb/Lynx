using Lynx.Api.Common.Exceptions;
using Lynx.Api.Models;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _uow;
        public ItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Item> Create(CreateItemModel model)
        {
            var bcd = model.Barcode.Trim();
            if (Get().Any(x => x.Barcode == bcd))
            {
                throw new BadRequestException("The barcode is already in use");
            }

            var item = new Item
            {
                AlertQuantity = model.AlertQuantity,
                Barcode = model.Barcode,
                CategoryId = model.CategoryId,
                Color = model.Color,
                Cost = model.Cost,
                DiscountId = model.DiscountId,
                GroupId = model.GroupId,
                Height = model.Height,
                Image = model.Image,
                LastCost = model.LastCost,
                LastPrice = model.LastPrice,
                Length = model.Length,
                MinQuantity = model.MinQuantity,
                Name = model.Name,
                Notes = model.Notes,
                Price = model.Price,
                Size = model.Size,
                StoreId = model.StoreId,
                TaxeId = model.TaxeId,
                Weight = model.Weight,
                WholeSalePrice = model.WholeSalePrice,
                Width = model.Width,
                Type = model.Type,
            };

            await AddGroupItem(item, model.GroupId);

            _uow.Add<Item>(item);
            await _uow.CommitAsync();

            return item;
        }

        private async Task AddGroupItem(Item item, int? groupId)
        {
            if (groupId != null)
                item.Group = await Get((int)groupId);
        }

        public IQueryable<Item> Get()
        {
            return _uow.Get<Item>()
                .Include(x => x.Items)
                .Include(x => x.Units)
                .Where(x => !x.IsDeleted);
        }

        public async Task<Item> Get(int id)
        {
            var item = await Get().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new NotFoundException("Item is not found");
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

        public async Task<Item> Update(int id, CreateItemModel model)
        {
            var item = await Get(id);

            item.AlertQuantity = model.AlertQuantity;
            item.Barcode = model.Barcode;
            item.CategoryId = model.CategoryId;
            item.Color = model.Color;
            item.Cost = model.Cost;
            item.DiscountId = model.DiscountId;
            item.GroupId = model.GroupId;
            item.Height = model.Height;
            item.Image = model.Image;
            item.LastCost = model.LastCost;
            item.LastPrice = model.LastPrice;
            item.Length = model.Length;
            item.MinQuantity = model.MinQuantity;
            item.Name = model.Name;
            item.Notes = model.Notes;
            item.Price = model.Price;
            item.Size = model.Size;
            item.StoreId = model.StoreId;
            item.TaxeId = model.TaxeId;
            item.Weight = model.Weight;
            item.WholeSalePrice = model.WholeSalePrice;
            item.Width = model.Width;
            item.Type = model.Type;

            await AddGroupItem(item, model.GroupId);

            await _uow.CommitAsync();
            return item;
        }
    }
}
