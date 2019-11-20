using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Models.BusinessUnit;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Models;

namespace Lynx.Api.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IUnitOfWork _uow;
        private readonly IClientService _clientService;
        public BusinessUnitService(IUnitOfWork uow, IClientService clientService)
        {
            _uow = uow;
            _clientService = clientService;
        }

        public async Task<BusinessUnit> Create(BusinessUnitModel model)
        {
            var name = model.Name.Trim();
            var client = _clientService.Get(model.ClientId);

            if (Get().Any(x => x.Name == name && x.Client == client))
            {
                throw new BadRequestException("Business Unit is already exist");
            }

            var bu = new BusinessUnit
            {
                About = model.About,
                Address = model.Address,
                City = model.City,
                ClientId = model.ClientId,
                Country = model.Country,
                ManagerId = model.ManagerId,
                Mobile = model.Mobile,
                Name = model.Name,
                Phone = model.Phone,
                Reference = model.Reference,
                Revenue = model.Revenue,
                Street = model.Street,
                Type = model.Type,
                Zip = model.Zip,
            };

            bu.Client = client;
            AddManager(bu, model.ManagerId);

            _uow.Add<BusinessUnit>(bu);
            await _uow.CommitAsync();

            return bu;
        }

        private void AddManager(BusinessUnit bu, int managerId)
        {
            var manager = _uow.Get<User>().FirstOrDefault(x => x.Id == managerId);
            if (manager == null)
            {
                throw new NotFoundException($"User with ID - {managerId} - is not found");
            }
            bu.Manager = manager;
        }

        public IQueryable<BusinessUnit> Get()
        {
            return _uow.Get<BusinessUnit>();
        }

        public BusinessUnit Get(int id)
        {
            var bu = _uow.Get<BusinessUnit>().FirstOrDefault(x => x.Id == id);
            if (bu == null)
            {
                throw new NotFoundException("Business Unit is not found");
            }
            return bu;
        }

        public async Task Remove(int id)
        {
            var bu = Get(id);
            if (bu.IsDeleted) return;

            bu.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public async Task<BusinessUnit> Update(int id, BusinessUnitModel model)
        {
            var bu = Get(id);

            bu.About = model.About;
            bu.Address = model.Address;
            bu.City = model.City;
            bu.ClientId = model.ClientId;
            bu.Country = model.Country;
            bu.ManagerId = model.ManagerId;
            bu.Mobile = model.Mobile;
            bu.Name = model.Name;
            bu.Phone = model.Phone;
            bu.Reference = model.Reference;
            bu.Revenue = model.Revenue;
            bu.Street = model.Street;
            bu.Type = model.Type;
            bu.Zip = model.Zip;

            AddClient(bu, model.ClientId);
            AddManager(bu, model.ManagerId);

            await _uow.CommitAsync();
            return bu;
        }

        private void AddClient(BusinessUnit bu, int clientId)
        {
            var client = _uow.Get<Client>().FirstOrDefault(x => x.Id == clientId);
            if (client == null)
            {
                throw new NotFoundException($"Client with ID - {clientId} - is not found");
            }
            bu.Client = client;
        }
    }
}
