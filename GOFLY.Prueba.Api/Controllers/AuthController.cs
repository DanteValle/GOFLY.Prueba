using GOFLY.Prueba.Api.Logic.Services;
using GOFLY.Prueba.Api.Model.JWTEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOFLY.Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAuth>> Login(UserLogin model)
        {
            var userAuth = await _authService.Authenticate(model);

            if (userAuth == null)
            {
                return Unauthorized();
            }

            return Ok(userAuth);
        }
    }
}
