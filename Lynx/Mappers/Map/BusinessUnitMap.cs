using AutoMapper;
using Lynx.Api.Models.BusinessUnit;
using Lynx.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynx.Mappers
{
    public class BusinessUnitMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<BusinessUnit, BusinessUnitModel>();
        }
    }
}
