using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynx.Mappers
{
    interface IAutoMapperTypeConfigurator    {
        void Configure(IMapperConfigurationExpression configuration);

    }
}
