using GOFLY.Prueba.Api.Logic.Interface;
using GOFLY.Prueba.Api.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOFLY.Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        public IActivityBusiness _activityBusiness;

        public ActivityController(IActivityBusiness activityBusiness)
        {
            _activityBusiness = activityBusiness;
        }

        [Authorize]
        [HttpGet("/api/Activity/GetAllActivities")]
        public async Task<ActionResult> GetAllActivities()
        {
            try
            {
                var response = await _activityBusiness.GetAllActivities();
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("/api/Activity/GetAllActivitiesWithUser")]
        public async Task<ActionResult> GetAllActivitiesWithUser()
        {
            try
            {
                var response = await _activityBusiness.GetActivitiesWithUsers();
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("/api/Activity/GetActivityById/{idActivity}")]
        public async Task<ActionResult> GetActivityById(int idActivity)
        {
            try
            {
                var response = await _activityBusiness.GetActivityById(idActivity);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost("/api/Activity/CreateActivity")]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            try
            {

                var response = await _activityBusiness.CreateActivity(activity);
                return Ok(response);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut("/api/Activity/UpdateActivity")]
        public async Task<ActionResult> UpdateActivity(Activity activity)
        {
            try
            {
                var response = await _activityBusiness.UpdateActivity(activity);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete("/api/Activity/DeleteActivity/{idActivity}")]
        public async Task<ActionResult> DeleteActivity(int idActivity)
        {
            try
            {
                var response = await _activityBusiness.DeleteActivity(idActivity);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
