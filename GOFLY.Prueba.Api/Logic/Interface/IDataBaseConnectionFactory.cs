using System.Data;

namespace GOFLY.Prueba.Api.Logic.Interface
{
    public interface IDataBaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
