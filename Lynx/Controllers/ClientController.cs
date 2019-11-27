using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lynx.Data.Models;
using Lynx.Api.Services;
using Lynx.Mappers;
using Lynx.Api.Models.Client;

namespace Lynx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IAutoMapper _mapper;
        public ClientController(IClientService service, IAutoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> Get()
        {
            var data = await _service.Get().ToListAsync();
            return _mapper.Map<List<ClientModel>>(data);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> Get(int id)
        {
            var client = await _service.Get(id);
            return _mapper.Map<ClientModel>(client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> Update(int id, ClientModel client)
        {
            var item = await _service.Update(id, client);
            return _mapper.Map<ClientModel>(item);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<ClientModel>> Create(ClientModel client)
        {
            var item = await _service.Create(client);
            return _mapper.Map<ClientModel>(item);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
