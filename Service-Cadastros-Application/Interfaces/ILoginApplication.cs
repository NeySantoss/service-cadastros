using service_cadastros_application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.Interfaces
{
    public interface ILoginApplication
    {        
        Task<int> InserirLoginAsync(RequestLoginViewModel model);
        Task<int> AtualizarLoginAsync(RequestLoginViewModel model);
        Task<bool> DeletarLoginAsync(int id);
        Task<ResponseLoginViewModel> ObterLogiPorIdAsync(int id);        
        Task<List<ResponseLoginViewModel>> ObterLogiPorFiltrosAsync(RequestFiltrosConsultaViewModel filtros);        
    }
}
