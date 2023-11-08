using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.Context
{
    public static class SqlQueryExtension
    {
        public static string GetQuery(string queryName)
        {
            return ResourceHelper.GetResource("service-cadastros-persistence", queryName);
        }
    }
}
