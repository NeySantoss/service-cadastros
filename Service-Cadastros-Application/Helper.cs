using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application
{
    public static class Helper
    {
        public static string BooleanToString(bool valor)
        {
            if(valor)
                return "T";
            else 
                return "F";
        }

        public static string BooleanToString(bool? valor)
        {
            bool aux = false;
            if (valor != null)
                aux = (bool)valor;

            return BooleanToString(aux);
        }




    }
}
