using GOFLY.Prueba.Api.Model.Entities;

namespace GOFLY.Prueba.Api.Logic.Interface
{
    public interface IUserDataAccess
    {
        Task<int> CreateUser(User user);
        Task<User> GetByIdUser(int id);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
        Task<List<User>> GetAllUser();

    }
}
