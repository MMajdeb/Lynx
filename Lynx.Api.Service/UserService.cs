using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Model.Users;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Access.Helpers;
using Lynx.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Lynx.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task ChangePassword(int id, ChangeUserPasswordModel model)
        {
            var user = Get(id);
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
            };

            AddUserRoles(user, model.Roles);

            _uow.Add<User>(user);
            await _uow.CommitAsync();

            return user;
        }

        private void AddUserRoles(User user, string[] roleNames)
        {
            user.Roles.Clear();
            foreach (var name in roleNames)
            {
                var role = _uow.Get<Role>().FirstOrDefault(x => x.Name == name);
                if (role == null)
                {
                    throw new BadRequestException($"Role - {name} is not found");
                }
                user.Roles.Add(new UserRole
                {
                    User = user,
                    Role = role
                });
            }
        }

        public async Task Remove(int id)
        {
            var user = Get(id);

            if (user.IsDeleted) return;

            user.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<User> Get()
        {
            var query = _uow.Get<User>()
                .Where(x => !x.IsDeleted)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role);

            return query;
        }

        public User Get(int id)
        {
            var user = Get().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }
            return user;
        }

        public async Task<User> Update(int id, UpdateUserModel model)
        {
            var user = Get(id);

            user.IsActive = model.IsActive;
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.Username = model.Username;

            await _uow.CommitAsync();
            return user;
        }
    }
}
