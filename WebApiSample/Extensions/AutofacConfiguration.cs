using Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiSample.Extensions
{
    public class AutofacConfiguration
    {
        public static List<IAutofacModuleInitializer> GetModuleInitializers()
        {
            var binFolder = new DirectoryInfo(AppContext.BaseDirectory);
            //var searchRegex = new Regex("*.dll", RegexOptions.IgnoreCase);
            var assemblyFilenames = binFolder.GetFileSystemInfos().Where(x => x.Name.Contains(".dll"));
            var moduleInitializerType = typeof(IAutofacModuleInitializer);
            var result = new List<IAutofacModuleInitializer>();
            foreach (var assemblyFileName in assemblyFilenames)
            {
                var assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyFileName.Name)));
                var initializerType = assembly.GetTypes().FirstOrDefault(x => moduleInitializerType.IsAssignableFrom(x));
                if(initializerType != null && initializerType != moduleInitializerType)
                {
                    result.Add(Activator.CreateInstance(initializerType) as IAutofacModuleInitializer);
                }                
            }
            return result;
        }
    }
}
