using System;
using System.Collections.Generic;
using System.Text;
using Autofac;


namespace Services.Extensions
{
    
    public class ServiceModuleInitializer : IModuleInitializer
    {
        public virtual ContainerBuilder Register(ContainerBuilder builder)
        {
            var assembly = GetType().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(
                    x =>
                        x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase) ||
                        x.Name.EndsWith("Factory", StringComparison.OrdinalIgnoreCase) ||
                        x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
                .AsImplementedInterfaces()
                .SingleInstance()
                .PropertiesAutowired();            
            return builder;
        }
    }

}
