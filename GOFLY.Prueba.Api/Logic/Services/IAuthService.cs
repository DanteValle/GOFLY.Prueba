using GOFLY.Prueba.Api.Model.JWTEntities;

namespace GOFLY.Prueba.Api.Logic.Services
{
    public interface IAuthService
    {
        Task<UserAuth> Authenticate(UserLogin model);
    }
}