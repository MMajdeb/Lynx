using FluentAssertions;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Model.Users;
using Lynx.Api.Models;
using Lynx.Api.Services;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Models;
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
        private IUserService _userService;
        private IClientService _clientService;
        private IBusinessUnitService _businessUnitService;
        private List<User> _users;
        private Random _random;
        public UserServiceTests()
        {
            _random = new Random();
            _uow = new Mock<IUnitOfWork>();

            _users = new List<User>();

            _clientService = new ClientService(_uow.Object);
            _businessUnitService = new BusinessUnitService(_uow.Object, _clientService);
            _userService = new UserService(_uow.Object, _clientService, _businessUnitService);

            _uow.Setup(x => x.Get<User>()).Returns(() => _users.AsQueryable());
        }
        
        [Fact]
        public void GetShouldReturnAll()
        {
            _users.Add(new User());

            var result = _userService.Get();
            result.Should().HaveCount(1);
        }

        [Fact]
        public void GetShouldReturnAllExceptDeleted()
        {
            _users.Add(new User());
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User());

            var result = _userService.Get();
            result.Count().Should().Be(2);
        }
        [Fact]
        public void GetShouldReturnUserById()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            var result = _userService.Get(user.Id);
            result.Should().Be(user);
        }

        [Fact]
        public void GetShouldThrowExceptionIfUserIsNotFoundById()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            Action get = () =>
            {
                _userService.Get(_random.Next());
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
                _userService.Get(user.Id);
            };

            get.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task CreateShouldSaveNewUser()
        {
            var client = new ClientModel
            {
                Name = _random.Next().ToString(),
                Mobile = _random.Next().ToString()
            };

            var newClient = await _clientService.Create(client);

            var model = new CreateUserModel
            {
                Password = _random.Next().ToString(),
                Username = _random.Next().ToString(),
                LastName = _random.Next().ToString(),
                FirstName = _random.Next().ToString(),
                LastConnection = DateTime.Now,
                ClientId = newClient.Id,
            };

            var result = await _userService.Create(model);

            result.Password.Should().NotBeEmpty();
            result.Username.Should().Be(model.Username);
            result.LastName.Should().Be(model.LastName);
            result.FirstName.Should().Be(model.FirstName);
            result.LastConnection.Should().Be(model.LastConnection);
            result.ClientId.Should().Be(model.ClientId);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
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
                var x = _userService.Create(model).Result;
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

            var result = await _userService.Update(user.Id, model);

            result.Should().Be(user);
            result.Username.Should().Be(model.Username);
            result.LastName.Should().Be(model.LastName);
            result.FirstName.Should().Be(model.FirstName);

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void UpdateShoudlThrowExceptionIfUserIsNotFound()
        {
            Action create = () =>
            {
                var result = _userService.Update(_random.Next(), new UpdateUserModel()).Result;
            };

            create.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task DeleteShouldMarkUserAsDeleted()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            await _userService.Remove(user.Id);

            user.IsDeleted.Should().BeTrue();

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void DeleteShoudlThrowExceptionIfUserIsNotFound()
        {
            Action create = () =>
            {
                _userService.Remove(_random.Next()).Wait();
            };

            create.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ChangePasswordShouldChangeUsersPassword()
        {
            var user = new User { Id = _random.Next() };
            _users.Add(user);

            var newPassword = _random.Next().ToString();

            await _userService.ChangePassword(user.Id, new ChangeUserPasswordModel
            {
                Password = newPassword
            });

            user.Password.Should().NotBeEmpty();

            _uow.Verify(x => x.CommitAsync());
        }
    }
}