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
                var instance = CreateInstance(mapType);
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

        private static object? CreateInstance(Type mapType)
        {
            if (!IsRecordType(mapType))
            {
                return Activator.CreateInstance(mapType);
            }

            var constructorInfo = mapType.GetTypeInfo().DeclaredConstructors.First();
            
            return constructorInfo.Invoke(constructorInfo.GetParameters()
                .Select(parameter => Activator.CreateInstance(parameter.ParameterType))
                .ToArray());
        }

        /*
         * Logic is taken from ASP.NET MVC.Core ModelBinder. Should be rewritten if there is an official way to support detecting Records.
         * https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.Core/src/ModelBinding/Metadata/DefaultBindingMetadataProvider.cs
         */

        private static bool IsRecordType(Type type)
        {
            // Based on the state of the art as described in https://github.com/dotnet/roslyn/issues/45777
            var cloneMethod = type.GetMethod("<Clone>$", BindingFlags.Public | BindingFlags.Instance);
            return cloneMethod != null && (cloneMethod.ReturnType == type || cloneMethod.ReturnType == type.BaseType);
        }
    }
}