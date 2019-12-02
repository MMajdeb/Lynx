using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lynx.Api.Models;
using Lynx.Data.Models;

namespace Lynx.Mappers.Map
{
    public class StoreMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Store, StoreModel>();
        }
    }
}
