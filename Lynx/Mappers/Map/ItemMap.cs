using AutoMapper;
using Lynx.Api.Models;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynx.Mappers.Map
{
    public class ItemMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Item, ItemModel>();
            map.ForMember(x => x.items, x => x.MapFrom(u => u.Items.Select(r => r.Id).ToArray()));
            map.ForMember(x => x.Units, x => x.MapFrom(u => u.Units.Select(r => r.Id).ToArray()));
        }
    }
}
