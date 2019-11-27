using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lynx.Data.Access.DAL;
using Lynx.Data.Models;
using Lynx.Api.Services;
using Lynx.Mappers;
using Lynx.Api.Models;

namespace Lynx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemService _service;
        private readonly IAutoMapper _mapper;

        public ItemController(IItemService service, IAutoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> Get()
        {
            var data = await _service.Get().ToListAsync();
            return _mapper.Map<List<ItemModel>>(data);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> Get(int id)
        {
            var item = await _service.Get(id);
            return _mapper.Map<ItemModel>(item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> Update(int id, CreateItemModel item)
        {
            var updatedItem= await _service.Update(id, item);
            return _mapper.Map<ItemModel>(updatedItem);
        }

        // POST: api/Items
        [HttpPost]
        public async Task<ActionResult<ItemModel>> Create(CreateItemModel item)
        {
            var newItem = await _service.Create(item);
            return _mapper.Map<ItemModel>(newItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
