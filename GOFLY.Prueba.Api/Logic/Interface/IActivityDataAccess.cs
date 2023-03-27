
using GOFLY.Prueba.Api.Model.Entities;
namespace GOFLY.Prueba.Api.Logic.Interface
{
    public interface IActivityDataAccess
    {
        Task<int> CreateActivity(Activity activity);
        Task<Activity> GetActivityById(int id);
        Task<bool> UpdateActivity(Activity activity);
        Task<int> DeleteActivity(int id);
        Task<List<Activity>> GetAllActivities();
        Task<List<Activity>> GetActivitiesByUserId(int idUser);
        Task<List<Activity>> GetActivitiesWithUsers();
    }
}
