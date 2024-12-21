using Microsoft.AspNetCore.Mvc;
using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Services;

namespace RESTAPI_PROJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserservice _userservice;

        public UsersController(IUserservice userservice) { 
            _userservice = userservice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUsers(int id)
        {
            try
            {
                UserModel model = new UserModel();
                model = await _userservice.GetUserbyid(id);
                return Ok(model);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
            
        }
    }
}
