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
        public static List<IAutofacDiInitializer> GetModuleInitializers()
        {
            var binFolder = new DirectoryInfo(AppContext.BaseDirectory);            
            var assemblyFilenames = binFolder.GetFileSystemInfos().Where(x => x.Name.Contains(".dll"));
            var moduleInitializerType = typeof(IAutofacDiInitializer);
            var result = new List<IAutofacDiInitializer>();
            foreach (var assemblyFileName in assemblyFilenames)
            {
                var assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyFileName.Name)));
                var initializerTypes = assembly.GetTypes().Where(x => moduleInitializerType.IsAssignableFrom(x) && x != moduleInitializerType).ToList();
                foreach (var initializerType in initializerTypes)
                {
                    if (initializerType != null)
                    {
                        result.Add(Activator.CreateInstance(initializerType) as IAutofacDiInitializer);
                    }
                }
                             
            }
            return result;
        }
    }
}
