using GroceryDal;
using GroceryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        
        [HttpGet("/search/{pOrderItemId}")]
        public IActionResult GetItemById(int pOrderItemId)
        {
            var found = OrderItemService.GetOrderItemsByOrderId(pOrderItemId);

            //return the view with matching person object
            return Ok(found);
        }


        [HttpPost("/api/addorderitem")]
        public IActionResult AddItems([FromBody] OrderItem o)
        {
            OrderItemService.AddOrderItem(o);
            return Ok($"Added order item: {o.OrderId}");

        }

        [HttpPut("/api/update/{OrderItemId}")]
        public IActionResult UpdateItem([FromRoute] int OrderItemId, [FromForm] OrderItem o)
        {
            try
            {
                OrderItemService.UpdateOrderItem(o);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/api/deleteitem")]
        public IActionResult DeleteItem([FromQuery] int OrderId)
        {
            try
            {
                OrderItemService.DeleteOrderItem(OrderId);
                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
