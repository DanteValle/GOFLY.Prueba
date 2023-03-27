using Dapper;
using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;
using System.Data;

namespace GOFLY.Prueba.Api.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IDataBaseConnectionFactory _dbConnection;
        public UserDataAccess(IDataBaseConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateUser(User user)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@last_name", user.LastName, DbType.String);
                    parameters.Add("@email", user.Email, DbType.String);
                    parameters.Add("@date_of_birth", user.DateOfBirth, DbType.DateTime);
                    parameters.Add("@phone_number", user.PhoneNumber, DbType.Int32);
                    parameters.Add("@country_of_residence", user.CountryOfResidence, DbType.String);
                    parameters.Add("@permission_information", user.PermissionInformation, DbType.Int32);
                    parameters.Add("@name", user.Name, DbType.String);
                    parameters.Add("@id_user", DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync("[dbo].[CreateUser_sp]", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@id_user");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<User> GetByIdUser(int id)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    var sql = "[dbo].[GetUser_sp]";
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_user", id, DbType.Int32);

                    return await connection.QuerySingleOrDefaultAsync<User>(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> UpdateUser(User user)
        {
            try
            {
                const string sql = "dbo.UpdateUser_sp";
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_user", user.IdUser, DbType.Int32);
                    parameters.Add("@last_name", user.LastName, DbType.String);
                    parameters.Add("@email", user.Email, DbType.String);
                    parameters.Add("@date_of_birth", user.DateOfBirth, DbType.DateTime);
                    parameters.Add("@phone_number", user.PhoneNumber, DbType.Int32);
                    parameters.Add("@country_of_residence", user.CountryOfResidence, DbType.String);
                    parameters.Add("@permission_information", user.PermissionInformation, DbType.Boolean);
                    parameters.Add("@name", user.Name, DbType.String);
                    return await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> DeleteUser(int id)
        {
            try
            {
                const string sql = "dbo.DeleteUser_sp";
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_user", id, DbType.Int32);
                    return await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<User>> GetAllUser()
        {
            try
            {
                const string sql = "[dbo].[GetAllUsers_sp]";
                using (var connection = _dbConnection.GetConnection())
                {
                    
                    var user = await connection.QueryAsync<User>(sql, commandType: CommandType.StoredProcedure);
                    return user.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
