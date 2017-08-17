using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Services.Extensions
{
    public interface IAutofacModuleInitializer
    {
        ContainerBuilder Register(ContainerBuilder builder);
    }
}
