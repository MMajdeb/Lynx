using FluentAssertions;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Models.BusinessUnit;
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
    public class BusinessUnitTests
    {
        private Mock<IUnitOfWork> _uow;
        private IBusinessUnitService _service;
        private IClientService _clientService;
        private List<BusinessUnit> _bus;
        private Random _random;

        public BusinessUnitTests()
        {
            _uow = new Mock<IUnitOfWork>();
            _bus = new List<BusinessUnit>();

            _clientService = new ClientService(_uow.Object);
            _service = new BusinessUnitService(_uow.Object, _clientService);
            
            _random = new Random();
            _uow.Setup(x => x.Get<BusinessUnit>()).Returns(() => _bus.AsQueryable());
        }

        [Fact]
        public void GetShouldReturnAll()
        {
            _bus.Add(new BusinessUnit());

            var result = _service.Get();
            result.Count().Should().Be(1);
        }

        [Fact]
        public void GetShouldReturnClientById()
        {
            var bu = new BusinessUnit { Id = _random.Next() };
            _bus.Add(bu);

            var result = _service.Get(bu.Id);
            result.Should().Be(bu);
        }

        [Fact]
        public void GetShouldThrowExceptionIfUserIsNotFound()
        {
            var bu = new BusinessUnit { Id = _random.Next() };
            _bus.Add(bu);

            Action get = () =>
            {
                _service.Get(_random.Next());
            };

            get.Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task CreateShouldSaveNewClient()
        {
            var bu = new BusinessUnitModel
            {
                Name = _random.Next().ToString(),
                Mobile = _random.Next().ToString(),
                About = _random.Next().ToString(),
                Country = _random.Next().ToString(),
                Revenue = _random.NextDouble(),
            };

            var result = await _service.Create(bu);

            result.Name.Should().Be(bu.Name);
            result.Mobile.Should().Be(bu.Mobile);
            result.About.Should().Be(bu.About);
            result.Country.Should().Be(bu.Country);
            result.Revenue.Should().Be(bu.Revenue);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void CreateShouldThrowExceptionIfNameIsNotUnique()
        {
            var bu = new BusinessUnitModel
            {
                Name = _random.Next().ToString()
            };
            _bus.Add(new BusinessUnit { Name = bu.Name });

            Action create = () =>
            {
                var x = _service.Create(bu).Result;
            };

            create.Should().Throw<BadRequestException>();
        }

        [Fact]
        public async Task UpdateShouldUpdateClientFiels()
        {
            var bu = new BusinessUnit { Id = _random.Next() };
            _bus.Add(bu);

            var model = new BusinessUnitModel
            {
                Name = _random.Next().ToString(),
                Mobile = _random.Next().ToString(),
                About = _random.Next().ToString(),
                Country = _random.Next().ToString(),
                Revenue = _random.NextDouble(),
            };

            var result = await _service.Update(bu.Id, model);

            result.Name.Should().Be(model.Name);
            result.Mobile.Should().Be(model.Mobile);
            result.About.Should().Be(model.About);
            result.Country.Should().Be(model.Country);
            result.Revenue.Should().Be(model.Revenue);

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public async Task DeleteShouldMarkClientAsDeleted()
        {
            var bu = new BusinessUnit { Id = _random.Next() };
            _bus.Add(bu);

            await _service.Remove(bu.Id);

            bu.IsDeleted.Should().Be(true);
            _uow.Verify(x => x.CommitAsync());
        }
    }
}
