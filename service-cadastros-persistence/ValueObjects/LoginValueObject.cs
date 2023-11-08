using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.ValueObjects
{
    public class LoginValueObject
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public string? IsAtivo { get; set; }     
    }

    public class RequestFiltrosConsultaValueObject
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
    }



}
