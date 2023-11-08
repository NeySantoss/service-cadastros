using System.Data;
using Castle.Core.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace service_cadastros_persistence.Context
{
    public class DbConnectionProvider : IConnectionProvider
    {
        public delegate T Callback<T>(IDbConnection connection);

        public async Task<T> ExecutaSQL<T>(string conexao, Callback<Task<T>> callback)
        {
            var conn = this.GetConnection(this.GetStringConnection(""));
            var retorno = await callback(conn);
            conn.Close();
            FbConnection.ClearAllPools();
            return retorno;
        }
        public IDbConnection GetConnection(string conexao)
        {
            var connection = new FbConnection(conexao);
            connection.Open();
            return connection;
        }       

        public string GetStringConnection(string conexao)
        {            
            var connection = "initial catalog=127.0.0.1:C:\\BancoDados\\ADS.FDB;User Id=sysdba;Password=masterkey;Charset=ISO8859_1";
            return connection;
        }        

    }
}