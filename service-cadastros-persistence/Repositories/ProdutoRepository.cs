using service_cadastros_persistence.Context;
using service_cadastros_persistence.Interfaces;
using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace service_cadastros_persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public ProdutoRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<int> InserirProdutoAsync(ProdutoDTO model)
        {
            var sql = SqlQueryExtension.GetQuery("ProdutoInserirAlterar.sql");
            var id = await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteScalarAsync<int>(sql, new
            {
                @ID = model.Id,
                @DESCRICAO = model.Descricao,
                @VALIDADE = model.Validade,
                @EXCLUIDO = "F",
                @DATA_REGISTRO = DateTime.Now,
                @DATA_ALTERACAO = DateTime.Now,
                @USUARIO_REGISTRO = model.Usuario_Registro,
                @USUARIO_ALTERACAO = model.Usuario_Alteracao
            }));
            return id;
        }

        public async Task<int> AtualizarProdutoAsync(ProdutoDTO model)
        {
            var sql = SqlQueryExtension.GetQuery("ProdutoInserirAlterar.sql");
            var id = await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteScalarAsync<int>(sql, new
            {
                @ID = model.Id,
                @DESCRICAO = model.Descricao,
                @VALIDADE = model.Validade,
                @EXCLUIDO = "F",
                @DATA_REGISTRO = model.Data_Registro,
                @DATA_ALTERACAO = DateTime.Now,
                @USUARIO_REGISTRO = model.Usuario_Registro,
                @USUARIO_ALTERACAO = model.Usuario_Alteracao
            }));
            return id;
        }

        public async Task<bool> DeletarProdutoAsync(int id, string usuario)
        {
            var sql = SqlQueryExtension.GetQuery("ProdutoDeletar.sql");
            await _connectionProvider.ExecutaSQL("", (conn) => conn.ExecuteAsync(sql, new
            {
                @usuario = usuario,
                @id = id,
            }));
            return true;
        }
        public async Task<ConsultaProdutoValueObject> ObterProdutoPorIdAsync(int id)
        {
            string filtros = $@" and prod.id = {id}";
            var sql = SqlQueryExtension.GetQuery("ProdutoConsulta.sql").Replace("@filtros",filtros);
            var dado = await _connectionProvider.ExecutaSQL("", (conn) => conn.QueryFirstOrDefaultAsync<ConsultaProdutoValueObject>(sql) );
            return dado;
        }

        public async Task<List<ConsultaProdutoValueObject>> ObterListaProdutosAsync(FiltrosProdutoValueObjet model)
        {                        
            string filtros = string.Empty;
            if (model.Id != null)
                filtros += $@" and prod.id = {model.Id} ";

            if (model.Descricao != null)
                filtros += $@" and prod.descricao like(%'{model.Descricao}'%) ";

            var sql = SqlQueryExtension.GetQuery("ProdutoConsulta.sql")
                .Replace("@filtros", filtros);

            var dado = await _connectionProvider.ExecutaSQL("", (conn) => conn.QueryAsync<ConsultaProdutoValueObject>(sql));
            return dado.ToList();
        }



        //sem terminar isso aqui sera uma consulta que tera objetos base 
        public async Task<List<ConsultaProdutoValueObject>> ObterProdutosPaginadoAsync(FiltrosProdutoValueObjet model)
        {             
            string filtros = String.Empty;
            if (model.Id != null)
                filtros += $@" and prod.id = {model.Id} ";

            if (model.Descricao != null)
                filtros += $@" and prod.descricao like(%'{model.Descricao}'%) ";

            var sql = SqlQueryExtension.GetQuery("ProdutoConsulta.sql")
                .Replace("@paginacao", $@" first {model.ItensPorPagina} skip {model.Pagina * @model.ItensPorPagina} count(*) over() as totalRegistros,")
                .Replace("@filtros", filtros);

            var dado = await _connectionProvider.ExecutaSQL("", (conn) => conn.QueryAsync<ConsultaProdutoValueObject>(sql));
            return dado.ToList();
        }



    }
}
