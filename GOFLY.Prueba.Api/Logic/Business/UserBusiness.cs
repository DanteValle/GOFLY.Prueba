using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;

namespace GOFLY.Prueba.Api.Logic.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserDataAccess _userDataAccess;

        public UserBusiness(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<int> CreateUser(User user)
        {
            try
            {
                var response =await _userDataAccess.CreateUser(user);
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<User> GetByIdUser(int id)
        {
            try
            {
                var response = await _userDataAccess.GetByIdUser(id);
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<int> UpdateUser(User user)
        {
            try
            {
                var response = await _userDataAccess.UpdateUser(user);
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<int> DeleteUser(int id)
        {
            try
            {
                var response = await _userDataAccess.DeleteUser(id);
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<List<User>> GetAllUser()
        {
            try
            {
                var response = await _userDataAccess.GetAllUser();
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
