using Lynx.Api.Models.Client;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Api.Services
{
    public interface IClientService
    {
        IQueryable<Client> Get();
        Client Get(int id);
        Task<Client> Create(ClientModel model);
        Task<Client> Update(int id, ClientModel model);
        Task Remove(int id);
    }
}
