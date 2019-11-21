using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynx.Api.Common.Exceptions;
using Lynx.Api.Models.Client;
using Lynx.Data.Access.DAL.UnitOfWork;
using Lynx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lynx.Api.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _uow;
        public ClientService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Client> Create(ClientModel model)
        {
            var clientName = model.Name.Trim();
            if (Get().Any(x => x.Name == clientName))
            {
                throw new BadRequestException("The client is already exist");
            }

            var client = new Client
            {
                About = model.About,
                Country = model.Country,
                Email = model.Email,
                IsActive = model.IsActive,
                Mobile = model.Mobile,
                Name = model.Name,
                Revenue = model.Revenue,
            };

            _uow.Add<Client>(client);
            await _uow.CommitAsync();

            return client;
        }

        public IQueryable<Client> Get()
        {
            return _uow.Get<Client>()
                .Include(x => x.BusinessUnits);
        }

        public async Task<Client> Get(int id)
        {
            var client = await Get().FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
            {
                throw new NotFoundException("Client is not found");
            }
            return client;
        }

        public async Task Remove(int id)
        {
            var client = await Get(id);
            if (client.IsDeleted) return;

            client.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public async Task<Client> Update(int id, ClientModel model)
        {
            var client = await Get(id);

            client.About = model.About;
            client.Country = model.Country;
            client.Email = model.Email;
            client.IsActive = model.IsActive;
            client.Mobile = model.Mobile;
            client.Name = model.Name;
            client.Revenue = model.Revenue;

            await _uow.CommitAsync();
            return client;
        }
    }
}
