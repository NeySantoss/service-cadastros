using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.Interfaces
{
    public interface ILoginRepository
    {
        Task<int> InserirLoginAsync(LoginValueObject model);
        Task<int> AtualizarLoginAsync(LoginValueObject model);
        Task<bool> DeletarLoginAsync(int id);
        Task<LoginValueObject> ObterLoginAsync(int id);
        Task<List<LoginValueObject>> ObterLoginPorFiltrosAsync(RequestFiltrosConsultaValueObject filtros);

    }
}
