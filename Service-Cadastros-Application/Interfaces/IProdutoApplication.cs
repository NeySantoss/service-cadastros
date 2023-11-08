using service_cadastros_application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<int> InserirProdutoAsync(ResquestProdutoViewModel model);
        Task<int> AtualizarProdutoAsync(ResquestProdutoViewModel model);
        Task<bool> DeletarProdutoAsync(int id, string usuario);
        Task<ResponseProdutoViewModel> ObterProdutoPorIdAsync(int id);
        Task<List<ResponseProdutoViewModel>> ObterListaProdutosAsync(RequestProdutoFiltrosViewModel model);       
    }
}
