using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Mithrill.MonsterBook.Application.Common.Mappings
{
    public static class MappingConfigurator
    {
        public static void ApplyMapFromAndToFromAssembly(this Assembly assembly, Profile mappingProfile)
        {
            ApplyMapping(assembly, mappingProfile, typeof(IMapFrom<>), "IMapFrom`1");
            ApplyMapping(assembly, mappingProfile, typeof(IMapTo<>), "IMapTo`1");
        }

        private static void ApplyMapping(Assembly assembly, Profile mappingProfile, Type mappingType, string mappingInterface)
        {
            var mapTypes = assembly.GetTypes()
                .Where(type => type.GetInterfaces().Any(interfaceType =>
                    interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == mappingType))
                .ToArray();

            foreach (var mapType in mapTypes)
            {
                var instance = Activator.CreateInstance(mapType);
                var methodInfos = mapType.GetMethods()
                    .Where(methodInfo => methodInfo.Name.Equals("Mapping"))
                    .ToArray();

                if (!methodInfos.Any())
                {
                    methodInfos = mapType.GetInterfaces()
                        .Where(interfaceType => interfaceType.Name.Equals(mappingInterface))
                        .SelectMany(interfaceType => interfaceType.GetMethods()
                            .Where(methodInfo => methodInfo.Name.Equals("Mapping")))
                        .ToArray();
                }

                foreach (var methodInfo in methodInfos)
                {
                    methodInfo.Invoke(instance, new object[] { mappingProfile });
                }
            }
        }
    }
}