using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Services.Repository;

namespace Services.Extensions
{
    
    public class ServiceModuleInitializer : IModuleInitializer
    {
        public virtual ContainerBuilder Register(ContainerBuilder builder)
        {
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();
            return builder;
        }
    }

}
