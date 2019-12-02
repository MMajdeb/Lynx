using AutoMapper;
using Lynx.Api.Model.Users;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynx.Mappers
{
    public class UserMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<User, UserModel>();
            map.ForMember(x => x.BusinessUnits, x => x.MapFrom(u => u.BusinessUnits.Select(r => r.Id).ToArray()));
        }
    }
}
