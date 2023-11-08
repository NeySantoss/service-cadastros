using System.Data;
using System.Threading.Tasks;
using NSubstitute;
using static service_cadastros_persistence.Context.DbConnectionProvider;

namespace service_cadastros_persistence.Context
{
    public interface IConnectionProvider
    {
        Task<T> ExecutaSQL<T>(string conexao, Callback<Task<T>> callback);
        IDbConnection GetConnection(string connectionString);        
        string GetStringConnection(string connectionString);        

    }
}
