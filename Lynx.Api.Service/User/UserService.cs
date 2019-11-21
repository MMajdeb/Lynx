using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Model.Users;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Access.Helpers;
using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lynx.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IClientService _clientService;
        private readonly IBusinessUnitService _businessUnitService;
        public UserService(IUnitOfWork uow, IClientService clientService, IBusinessUnitService businessUnitService)
        {
            _uow = uow;
            _clientService = clientService;
            _businessUnitService = businessUnitService;
        }

        public async Task ChangePassword(int id, ChangeUserPasswordModel model)
        {
            var user = await Get(id);
            user.Password = model.Password.WithBCrypt();
            await _uow.CommitAsync();
        }

        public async Task<User> Create(CreateUserModel model)
        {
            var username = model.Username.Trim();
            if (Get().Any(x => x.Username == username))
            {
                throw new BadRequestException("The username is already in use");
            }
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password.WithBCrypt(),
                IsActive = model.IsActive,
                LastConnection = model.LastConnection,
                ClientId = model.ClientId,
            };

            await AddBusinessUnits(user, model.BusinessUnits);
            await AddClient(user, model.ClientId);

            _uow.Add<User>(user);
            await _uow.CommitAsync();

            return user;
        }

        private async Task AddClient(User user, int clientId)
        {
            var client = await _clientService.Get(clientId);
            user.Client = client;
        }

        private async Task AddBusinessUnits(User user, int[] businessUnitIds)
        {
            user.BusinessUnits.Clear();
            foreach (int id in businessUnitIds)
            {
                var bu = await _businessUnitService.Get(id);
                user.BusinessUnits.Add(bu);
            }
        }

        public async Task Remove(int id)
        {
            var user = await Get(id);

            if (user.IsDeleted) return;

            user.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<User> Get()
        {
            var query = _uow.Get<User>()
                .Where(x => !x.IsDeleted)
                .Include(x => x.Client)
                .ThenInclude(x => x.BusinessUnits);

            return query;
        }

        public async Task<User> Get(int id)
        {
            var user = await Get().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }
            return user;
        }

        public async Task<User> Update(int id, UpdateUserModel model)
        {
            var user = await Get(id);

            user.IsActive = model.IsActive;
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.Username = model.Username;
            user.LastConnection = model.LastConnection;
            user.ClientId = model.ClientId;

            AddBusinessUnits(user, model.BusinessUnits);
            AddClient(user, model.ClientId);

            await _uow.CommitAsync();
            return user;
        }
    }
}
