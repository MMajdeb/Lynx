using FluentAssertions;
using Lynx.Api.Common.Exceptions;
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
    public class ClientServiceTests
    {
        private Mock<IUnitOfWork> _uow;
        private IClientService _service;
        private List<Client> _clients;
        private Random _random;

        public ClientServiceTests()
        {
            _random = new Random();
            _uow = new Mock<IUnitOfWork>();

            _service = new ClientService(_uow.Object);
            _clients = new List<Client>();

            _uow.Setup(x => x.Get<Client>()).Returns(() => _clients.AsQueryable());
        }

        [Fact]
        public void GetShouldReturnAll()
        {
            _clients.Add(new Client());

            var result = _service.Get();
            result.Count().Should().Be(1);
        }

        [Fact]
        public void GetShouldReturnClientById()
        {
            var client = new Client { Id = _random.Next() };
            _clients.Add(client);

            var result = _service.Get(client.Id);
            result.Should().Be(client);
        }

        [Fact]
        public void GetShouldThrowExceptionIfUserIsNotFound()
        {
            var client = new Client { Id = _random.Next() };
            _clients.Add(client);

            Action get = () =>
            {
                _service.Get(_random.Next());
            };

            get.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task CreateShouldSaveNewClient()
        {
            var client = new ClientModel
            {
                Name = _random.Next().ToString(),
                Mobile = _random.Next().ToString(),
                About = _random.Next().ToString(),
                Country = _random.Next().ToString(),
                Email = _random.Next().ToString(),
                IsActive = true,
                Revenue = _random.NextDouble(),
            };

            var result = await _service.Create(client);

            result.Name.Should().Be(client.Name);
            result.Mobile.Should().Be(client.Mobile);
            result.About.Should().Be(client.About);
            result.Country.Should().Be(client.Country);
            result.Email.Should().Be(client.Email);
            result.IsActive.Should().Be(client.IsActive);
            result.Revenue.Should().Be(client.Revenue);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void CreateShouldThrowExceptionIfNameIsNotUnique()
        {
            var client = new ClientModel
            {
                Name = _random.Next().ToString()
            };
            _clients.Add(new Client { Name = client.Name });

            Action create = () =>
            {
                var x = _service.Create(client).Result;
            };

            create.Should().Throw<BadRequestException>();
        }

        [Fact]
        public async Task UpdateShouldUpdateClientFiels()
        {
            var client = new Client { Id = _random.Next() };
            _clients.Add(client);

            var model = new ClientModel
            {
                Name = _random.Next().ToString(),
                Mobile = _random.Next().ToString(),
                About = _random.Next().ToString(),
                Country = _random.Next().ToString(),
                Email = _random.Next().ToString(),
                IsActive = true,
                Revenue = _random.NextDouble(),
            };

            var result = await _service.Update(client.Id,model);

            result.Name.Should().Be(model.Name);
            result.Mobile.Should().Be(model.Mobile);
            result.About.Should().Be(model.About);
            result.Country.Should().Be(model.Country);
            result.Email.Should().Be(model.Email);
            result.IsActive.Should().Be(model.IsActive);
            result.Revenue.Should().Be(model.Revenue);

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public async Task DeleteShouldMarkClientAsDeleted()
        {
            var client = new Client { Id = _random.Next() };
             _clients.Add(client);

            await _service.Remove(client.Id);

            client.IsDeleted.Should().Be(true);
            _uow.Verify(x => x.CommitAsync());
        }
    }
}
