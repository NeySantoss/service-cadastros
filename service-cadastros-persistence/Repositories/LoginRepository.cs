using Dapper;
using service_cadastros_persistence.Context;
using service_cadastros_persistence.Interfaces;
using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public LoginRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<int> InserirLoginAsync(LoginValueObject model)
        {
            var sql = SqlQueryExtension.GetQuery("LoginInserir.sql");
            var id = await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteScalarAsync<int>(sql, new
            {
                @id = model.Id,
                @descricao = model.Descricao,
                @ativo = model.IsAtivo
            }));
            return id;
        }

        public async Task<int> AtualizarLoginAsync(LoginValueObject model)
        {
            var sql = SqlQueryExtension.GetQuery("LoginAtualizar.sql");
            await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteAsync(sql, new
            {
                @id = model.Id,
                @descricao = model.Descricao,
                @ativo = model.IsAtivo
            }));
            return (int)model.Id;
        }

        public async Task<LoginValueObject> ObterLoginAsync(int id)
        {
            var filtro = @$" and id = {id}";
            var sql = SqlQueryExtension.GetQuery("LoginConsulta.sql").Replace("@filtros", filtro);
            var retorno = await _connectionProvider.ExecutaSQL("", (conn) => conn.QueryFirstOrDefaultAsync<LoginValueObject>(sql));
            return retorno;
        }

        public async Task<bool> DeletarLoginAsync(int id)
        {
            var sql = SqlQueryExtension.GetQuery("LoginDeletar.sql");
            var retorno = await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteAsync(sql, new
            {
                @id = id
            }));
            return true;
        }

        public async Task<List<LoginValueObject>> ObterLoginPorFiltrosAsync(RequestFiltrosConsultaValueObject filtros)
        {
            var filtro = string.Empty;
            if (filtros.Id != null)
                filtro = @$" and id = {filtros.Id}";

            if (filtros.Descricao != null)
                filtro = @$" and descricao like '%{filtros.Descricao}%' ";

            var sql = SqlQueryExtension.GetQuery("LoginConsulta.sql").Replace("@filtros", filtro);
            var retorno = await _connectionProvider.ExecutaSQL("", (conn) => conn.QueryAsync<LoginValueObject>(sql));
            return retorno.ToList();
        }
    }
}
