using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.ValueObjects
{
    public class ProdutoDTO
    {
        public int? Id { get; set; }        
        public string? Descricao { get; set; }
        public DateTime? Validade { get; set; }
        public string? Excluido { get; set; }
        public DateTime? Data_Registro { get; set; }
        public DateTime? Data_Alteracao { get; set; }
        public string? Usuario_Registro { get; set; }
        public string? Usuario_Alteracao { get; set; }        
    }

    public class ConsultaProdutoValueObject : ProdutoDTO
    {
        public double? QtdeEstoque { get; set; }
    }

    public class FiltrosProdutoValueObjet
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime ValidadeInicio { get; set; }
        public DateTime ValidadeFim { get; set; }


        public int? Pagina { get; set; }   ///essas variaveis irao para um objeto base
        public int? ItensPorPagina { get; set; }
    }
    
}
