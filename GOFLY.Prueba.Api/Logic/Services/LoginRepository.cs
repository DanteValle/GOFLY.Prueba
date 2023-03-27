using GOFLY.Prueba.Api.Model.JWTEntities;

namespace GOFLY.Prueba.Api.Logic.Services
{
    public class LoginRepository: ILoginRepository
    {
        public async Task<UserLogin> GetUser(string userName, string password)
        {
            if (userName == "dante" && password == "dante")
            {
                return _ = new UserLogin() { Id = 1, Username = "dante", Password = "dante", Role = "Admi" };
            }
            else
            {
                return null;
            }
        }
    }
}
