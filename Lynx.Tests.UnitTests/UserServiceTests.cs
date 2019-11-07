using FluentAssertions;
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
        public async Task GetShouldReturnAll()
        {
            _users.Add(new User());

            var result = _service.Get();
            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetShouldReturnAllExceptDeleted()
        {
            _users.Add(new User());
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User { IsDeleted = true });
            _users.Add(new User());

            var result = _service.Get();
            result.Count().Should().Be(2);
        }
    }
}
