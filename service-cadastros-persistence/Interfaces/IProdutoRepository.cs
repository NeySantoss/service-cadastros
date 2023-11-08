using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.Interfaces
{
    public interface IProdutoRepository
    {
        Task<int> InserirProdutoAsync(ProdutoDTO model);
        Task<int> AtualizarProdutoAsync(ProdutoDTO model);
        Task<bool> DeletarProdutoAsync(int id, string usuario);
        Task<ConsultaProdutoValueObject> ObterProdutoPorIdAsync(int id);
        Task<List<ConsultaProdutoValueObject>> ObterListaProdutosAsync(FiltrosProdutoValueObjet model);
        Task<List<ConsultaProdutoValueObject>> ObterProdutosPaginadoAsync(FiltrosProdutoValueObjet model);

    }
}
