using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.ViewModels
{
    public class LoginViewModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public bool? IsAtivo { get; set; }

    }

    public class ResponseLoginViewModel : LoginViewModel
    {
    }
    public class RequestLoginViewModel : LoginViewModel
    {
    }

    public class RequestFiltrosConsultaViewModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
    }
}
