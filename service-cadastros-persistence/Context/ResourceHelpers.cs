using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace service_cadastros_persistence.Context
{   
    public static class ResourceHelper
    {
        public static string GetResource(string assemblyName, string resourceName)
        {
            try
            {
                _ = string.Empty;
                Assembly? assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly x) => x.FullName!.Contains(assemblyName));
                string name = assembly!.GetManifestResourceNames().FirstOrDefault((string x) => x.EndsWith(resourceName));
                using Stream stream = assembly!.GetManifestResourceStream(name);
                using StreamReader streamReader = new StreamReader(stream);
                return streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível carregar o arquivo: " + resourceName);
            }
        }
    }
}
