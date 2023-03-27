using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;

namespace GOFLY.Prueba.Api.Logic.Business
{
    public class ActivityBusiness: IActivityBusiness
    {
        public IActivityDataAccess _activityDataAccess;

        public ActivityBusiness(IActivityDataAccess activityDataAccess)
        {
            _activityDataAccess = activityDataAccess;
        }

        public async Task<int> CreateActivity(Activity activity)
        {
            try
            {
                var response = await _activityDataAccess.CreateActivity(activity);
                return response;
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
                var response = await _activityDataAccess.GetActivityById(id);
                return response;
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
                var response = await _activityDataAccess.UpdateActivity(activity);
                return response;
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
                var response = await _activityDataAccess.DeleteActivity(id);
                return response;
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
                var response = await _activityDataAccess.GetAllActivities();
                return response;
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
                var response = await _activityDataAccess.GetActivitiesByUserId(idUser);
                return response;
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
                var response = await _activityDataAccess.GetActivitiesWithUsers();
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
