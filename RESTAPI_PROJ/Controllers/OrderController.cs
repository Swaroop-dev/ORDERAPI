using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPI_PROJ.Services;

namespace RESTAPI_PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderservice _orderservice;

        public OrderController(IOrderservice orderservice) {
            _orderservice = orderservice;
        }    

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetAllOrders(int userid) {
            try
            {
                var orderlist = await _orderservice.GetAllOrder(userid);
                if (orderlist == null) { 
                    return NotFound();
                }

                return Ok(orderlist);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }


       
    }
}
