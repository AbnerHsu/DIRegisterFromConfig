using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionHelper
{
    public static class DIHelper
    {
        /// <summary>
        /// Add a service that specified in setting to the specified Microsoft.Extensions.DependencyInject.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="setting">The service description in DIService data objects</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddFromDIService(this IServiceCollection services, IEnumerable<DIService> setting)
        {
            foreach (var service in setting)
            {
                var serviceType = ResolveType(service.Type);
                var implementationType = ResolveType(service.MapTo);
                services.Add(new ServiceDescriptor(serviceType, implementationType, service.LifeCycle));
            }
            return services;
        }
        private static Type ResolveType(string typeNameOrAlias)
        {
            return Type.GetType(typeNameOrAlias);
        }
    }
}
