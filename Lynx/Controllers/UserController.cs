using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lynx.Data.Access.DAL;
using Lynx.Data.Model;
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

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _service.Get().ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(int id)
        {
            var user = _service.Get(id);
            var model = _mapper.Map<UserModel>(user);
            return model;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update(int id, UpdateUserModel user)
        {
            var item = await _service.Update(id, user);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        // POST: api/User
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserModel>> Add(CreateUserModel user)
        {
            var item = await _service.Create(user);

            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _service.Remove(id);
        }
    }
}
