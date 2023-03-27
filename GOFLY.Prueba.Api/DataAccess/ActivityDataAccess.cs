using Dapper;
using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;
using System.Data;

namespace GOFLY.Prueba.Api.DataAccess
{
    public class ActivityDataAccess : IActivityDataAccess
    {
        private readonly IDataBaseConnectionFactory _dbConnection;

        public ActivityDataAccess(IDataBaseConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateActivity(Activity activity)
        {
            try
            {
                activity.CreateDate = DateTime.Now;
                using (var connection = _dbConnection.GetConnection())
                {

                    var parameters = new DynamicParameters();
                    parameters.Add("@create_date", activity.CreateDate, DbType.DateTime);
                    parameters.Add("@activity", activity.ActivityName, DbType.String);
                    parameters.Add("@id_user", activity.IdUser, DbType.Int32);
                    parameters.Add("@id_activities", DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync("CreateActivity_sp", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@id_activities");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Activity> GetActivityById(int id)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_activities", id);
                    var activity = await connection.QuerySingleOrDefaultAsync<Activity>("GetActivity_sp", parameters, commandType: CommandType.StoredProcedure);
                    return activity;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> UpdateActivity(Activity activity)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_activities", activity.Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@create_date", activity.CreateDate, DbType.Date, ParameterDirection.Input);
                    parameters.Add("@activity", activity.ActivityName, DbType.String, ParameterDirection.Input, 20);
                    parameters.Add("@id_user", activity.IdUser, DbType.Int32, ParameterDirection.Input);

                    await connection.ExecuteAsync("[dbo].[UpdateActivity_sp]", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> DeleteActivity(int id)
        {
            try
            {
                const string sql = "[dbo].[DeleteActivity_sp]";
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_activities", id, DbType.Int32);
                    return await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            try
            {
                const string sql = "[dbo].[GetAllActivities_sp]";
                using (var connection = _dbConnection.GetConnection())
                {
                    var user = await connection.QueryAsync<Activity>(sql, commandType: CommandType.StoredProcedure);
                    return user.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Activity>> GetActivitiesByUserId(int idUser)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id_user", idUser);

                    var activities = await connection.QueryAsync<Activity>("GetActivitiesByIdUser_sp", parameters, commandType: CommandType.StoredProcedure);
                    return activities.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Activity>> GetActivitiesWithUsers()
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    const string sql = "[dbo].[GetActivitiesWithUsers]";

                    var activities = await connection.QueryAsync<Activity, User, Activity>(sql, (activity, user) =>
                     {
                         activity.User = user;
                         activity.IdUser = user.IdUser;
                         return activity;
                     },
                     splitOn: "IdUser",
                     commandType: CommandType.StoredProcedure
                     );
                    return activities.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
