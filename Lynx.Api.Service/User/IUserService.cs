using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Model.Users;
using Lynx.Data.Models;

namespace Lynx.Api.Services
{
    public interface IUserService
    {
        IQueryable<User> Get();
        User Get(int id);
        Task<User> Create(CreateUserModel model);
        Task<User> Update(int id, UpdateUserModel model);
        Task Remove(int id);
        Task ChangePassword(int id, ChangeUserPasswordModel model);
    }
}
