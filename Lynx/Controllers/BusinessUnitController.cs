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
using Lynx.Api.Models.BusinessUnit;

namespace Lynx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUnitService _service;
        private readonly IAutoMapper _mapper;

        public BusinessUnitController(IBusinessUnitService service, IAutoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/BusinessUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessUnitModel>>> Get()
        {
            var data = await _service.Get().ToListAsync();
            return _mapper.Map<List<BusinessUnitModel>>(data);
        }

        // GET: api/BusinessUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessUnitModel>> Get(int id)
        {
            var item = await _service.Get(id);
            return _mapper.Map<BusinessUnitModel>(item);
        }

        // PUT: api/BusinessUnit/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BusinessUnitModel>> Update(int id, BusinessUnitModel businessUnit)
        {
            var item = await _service.Update(id, businessUnit);
            return _mapper.Map<BusinessUnitModel>(item);
        }

        // POST: api/BusinessUnit
        [HttpPost]
        public async Task<ActionResult<BusinessUnitModel>> Create(BusinessUnitModel businessUnit)
        {
            var item = await _service.Create(businessUnit);
            return _mapper.Map<BusinessUnitModel>(item);
        }

        // DELETE: api/BusinessUnit/5
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
