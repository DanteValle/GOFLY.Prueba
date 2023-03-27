using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOFLY.Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Authorize]
        [HttpGet("/api/User/GetAllUser")]
        public async Task<ActionResult> GetAllUser()
        {
            try
            {
                var response = await _userBusiness.GetAllUser();
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("/api/User/GetUser/{idUser}")]
        public async Task<ActionResult> GetUser(int idUser)
        {
            try
            {
                var response = await _userBusiness.GetByIdUser(idUser);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost("/api/User/CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            try
            {
               
                    var response = await _userBusiness.CreateUser(user);
                    return Ok(response);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut("/api/User/UpdateUser")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            try
            {
                var response = await _userBusiness.UpdateUser(user);
                return Ok(response);
            }
            catch (Exception )
            {

                throw ;
            }
        }

        [Authorize]
        [HttpDelete("/api/User/DeleteUser/{idUser}")]
        public async Task<ActionResult> DeleteUser(int idUser)
        {
            try
            {
                var response = await _userBusiness.DeleteUser(idUser);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
