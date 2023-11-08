using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.ViewModels
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }        
        public string? Descricao { get; set; }
        public DateTime? Validade { get; set; }        
        public DateTime? DataRegistro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? UsuarioAlteracao { get; set; }        
    }

    public class ResquestProdutoViewModel: ProdutoViewModel
    {
    }

    public class ResponseProdutoViewModel : ProdutoViewModel
    {
        public double? QtdeEstoque { get; set; }        
    }

    public class RequestProdutoFiltrosViewModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime ValidadeInicio { get; set; }
        public DateTime ValidadeFim { get; set; }

    }

}
