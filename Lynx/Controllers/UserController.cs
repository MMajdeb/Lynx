using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lynx.Data.Models;
using Lynx.Api.Services;
using Lynx.Api.Model.Users;
using Lynx.Mappers;

namespace Lynx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IAutoMapper _mapper;

        public UserController(IUserService service, IAutoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var data = await _service.Get().ToListAsync();
            return _mapper.Map<List<UserModel>>(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _service.Get(id);
            var model = _mapper.Map<UserModel>(user);
            return model;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update(int id, UpdateUserModel user)
        {
            var item = await _service.Update(id, user);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(CreateUserModel user)
        {
            var item = await _service.Create(user);

            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
