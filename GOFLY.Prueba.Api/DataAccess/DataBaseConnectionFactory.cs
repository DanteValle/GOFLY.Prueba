using GOFLY.Prueba.Api.Logic.Interface;
using System.Data;
using System.Data.SqlClient;

namespace GOFLY.Prueba.Api.DataAccess
{
    public class DataBaseConnectionFactory: IDataBaseConnectionFactory
    {
        private readonly string _connectionString;

        public DataBaseConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MiConexion");
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
