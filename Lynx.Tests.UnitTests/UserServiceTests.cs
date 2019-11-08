using FluentAssertions;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Model.Users;
using Lynx.Api.Services;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lynx.Tests.UnitTests
{
    public class UserServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private IUserService _service;
        private List<User> _users;
        private List<Role> _roles;
        private Random _random;
        public UserServiceTests()
        {
            _random = new Random();
            _uow = new Mock<IUnitOfWork>();

            _roles = new List<Role>();
            _users = new List<User>();

            _service = new UserService(_uow.Object);

            _uow.Setup(x => x.Get<Role>()).Returns(() => _roles.AsQueryable());
            _uow.Setup(x => x.Get<User>()).Returns(() => _users.AsQueryable());
        }

        [Fact]
        public void GetShouldReturnAll()
        {
            _users.Add(new User());

            var result = _service.Get();
            result.Should().HaveCount(1);
        }

        [Fact]
        public void GetShouldReturnAllExceptDeleted()
        {
            _users.Add(new User());
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User());

            var result = _service.Get();
            result.Count().Should().Be(2);
        }
        [Fact]
        public void GetShouldReturnUserById()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            var result = _service.Get(user.Id);
            result.Should().Be(user);
        }

        [Fact]
        public void GetShouldThrowExceptionIfUserIsNotFoundById()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            Action get = () =>
            {
                _service.Get(_random.Next());
            };

            get.Should().Throw<NotFoundException>();
        }

        [Fact]
        public void GetShouldThrowExceptionIfUserIsDeleted()
        {
            var user = new User { Id = _random.Next(), IsDeleted = true };
            _users.Add(user);

            Action get = () =>
            {
                _service.Get(user.Id);
            };

            get.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task CreateShouldSaveNewUser()
        {
            var model = new CreateUserModel
            {
                Password = _random.Next().ToString(),
                Username = _random.Next().ToString(),
                LastName = _random.Next().ToString(),
                FirstName = _random.Next().ToString(),
            };

            var result = await _service.Create(model);

            result.Password.Should().NotBeEmpty();
            result.Username.Should().Be(model.Username);
            result.LastName.Should().Be(model.LastName);
            result.FirstName.Should().Be(model.FirstName);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public async Task CreateShouldAddUserRoles()
        {
            var role = new Role
            {
                Name = _random.Next().ToString()
            };
            _roles.Add(role);

            var model = new CreateUserModel
            {
                Password = _random.Next().ToString(),
                Username = _random.Next().ToString(),
                LastName = _random.Next().ToString(),
                FirstName = _random.Next().ToString(),
                Roles = new[] { role.Name }
            };

            var result = await _service.Create(model);

            result.Roles.Should().HaveCount(1);
            result.Roles.Should().Contain(x => x.User == result && x.Role == role);
        }

        [Fact]
        public void CreateShouldThrowExceptionIfUsernameIsNotUnique()
        {
            var model = new CreateUserModel
            {
                Username = _random.Next().ToString(),
            };

            _users.Add(new User { Username = model.Username });

            Action create = () =>
            {
                var x = _service.Create(model).Result;
            };

            create.Should().Throw<BadRequestException>();
        }

        [Fact]
        public async Task UpdateShouldUpdateUserFields()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            var model = new UpdateUserModel
            {
                Username = _random.Next().ToString(),
                LastName = _random.Next().ToString(),
                FirstName = _random.Next().ToString(),
            };

            var result = await _service.Update(user.Id, model);

            result.Should().Be(user);
            result.Username.Should().Be(model.Username);
            result.LastName.Should().Be(model.LastName);
            result.FirstName.Should().Be(model.FirstName);

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public async Task UpdateShouldUpdateRoles()
        {
            var role = new Role
            {
                Name = _random.Next().ToString()
            };
            _roles.Add(role);

            var user = new User
            {
                Id = _random.Next(),
                Roles = new List<UserRole>
                {
                    new UserRole()
                }
            };
            _users.Add(user);

            var model = new UpdateUserModel
            {
                LastName = _random.Next().ToString(),
                FirstName = _random.Next().ToString(),
                Roles = new[] { role.Name }
            };

            var result = await _service.Update(user.Id, model);

            result.Roles.Should().HaveCount(1);
            result.Roles.Should().Contain(x => x.User == result && x.Role == role);
        }

        [Fact]
        public void UpdateShoudlThrowExceptionIfUserIsNotFound()
        {
            Action create = () =>
            {
                var result = _service.Update(_random.Next(), new UpdateUserModel()).Result;
            };

            create.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task DeleteShouldMarkUserAsDeleted()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            await _service.Remove(user.Id);

            user.IsDeleted.Should().BeTrue();

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void DeleteShoudlThrowExceptionIfUserIsNotFound()
        {
            Action create = () =>
            {
                _service.Remove(_random.Next()).Wait();
            };

            create.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ChangePasswordShouldChangeUsersPassword()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            var newPassword = _random.Next().ToString();

            await _service.ChangePassword(user.Id, new ChangeUserPasswordModel
            {
                Password = newPassword
            });

            user.Password.Should().NotBeEmpty();

            _uow.Verify(x => x.CommitAsync());
        }
    }
}