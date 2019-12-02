using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lynx.Data.Access.DAL;
using Lynx.Data.Models;
using Lynx.Api.Models;
using Lynx.Api.Services;
using Lynx.Mappers;

namespace Lynx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;
        private readonly IAutoMapper _mapper;

        public StoreController(IStoreService service, IAutoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Store
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreModel>>> Get()
        {
            var data = await _service.Get().ToListAsync();
            return _mapper.Map<List<StoreModel>>(data);
        }

        // GET: api/Store/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreModel>> Get(int id)
        {
            var store = await _service.Get(id);
            return _mapper.Map<StoreModel>(store);
        }

        // PUT: api/Store/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StoreModel>> Update(int id, StoreModel store)
        {
            var item = await _service.Update(id,store);
            return _mapper.Map<StoreModel>(item);
        }

        // POST: api/Store
        [HttpPost]
        public async Task<ActionResult<StoreModel>> Create(StoreModel store)
        {
            var item = await _service.Create(store);
            return _mapper.Map<StoreModel>(item);
        }

        // DELETE: api/Store/5
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
