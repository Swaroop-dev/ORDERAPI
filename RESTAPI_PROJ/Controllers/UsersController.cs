using Microsoft.AspNetCore.Mvc;
using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Services;

namespace RESTAPI_PROJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserservice _userservice;

        public UsersController(IUserservice userservice) { 
            _userservice = userservice;
        }

        [HttpGet("{id}")]
        public IActionResult GetAllUsers(int id)
        {
            
            UserModel model = new UserModel();
            model = _userservice.GetUserbyid(id);
            return Ok(model);
        }
    }
}
