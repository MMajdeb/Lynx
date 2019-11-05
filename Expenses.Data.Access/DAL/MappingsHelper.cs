using Expenses.Data.Access.Maps.Common;
using Expenses.Data.Access.Maps.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Expenses.Data.Access.DAL
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMap> GetMainMappings()
        {
            var assemblyeTypes = typeof(UserMap).GetTypeInfo().Assembly.DefinedTypes;
            var mappings = assemblyeTypes
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(UserMap).Namespace))
                .Where(t => typeof(IMap).GetTypeInfo().IsAssignableFrom(t));
            mappings = mappings.Where(x => !x.IsAbstract);
            return mappings.Select(m => (IMap)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}