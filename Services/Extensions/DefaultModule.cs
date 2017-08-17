using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Services.Repository;

namespace Services.Extensions
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();
        }
    }
}
