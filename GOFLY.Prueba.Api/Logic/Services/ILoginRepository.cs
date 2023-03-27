using GOFLY.Prueba.Api.Model.JWTEntities;

namespace GOFLY.Prueba.Api.Logic.Services
{
    public interface ILoginRepository
    {
        Task<UserLogin> GetUser(string userName, string password);
    }
}