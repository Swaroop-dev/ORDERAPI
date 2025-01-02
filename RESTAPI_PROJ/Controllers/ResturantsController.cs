using Microsoft.AspNetCore.Mvc;
using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Services;

namespace RESTAPI_PROJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResturantsController : ControllerBase
    {
        private readonly IResturantservice _resturantservice;


        public ResturantsController(IResturantservice resturantservice)
        {
            _resturantservice = resturantservice;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAllResturants(int pageno, int pagesize) {

            try
            {
                List<ResturantModel> listofResturants =await _resturantservice.GetAllResturants(pageno, pagesize);

                return Ok(listofResturants);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
