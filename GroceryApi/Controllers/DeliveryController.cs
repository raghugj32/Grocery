using GroceryDal;
using GroceryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        /*[HttpPost("/api/adddelivery")]
        public IActionResult AddDelivery([FromBody] Delivery d)
        {
            DeliveryService.AddDelivery(d);
            return Ok($"Added order item: {d.DeliveryId}");

        }*/
    }
}
