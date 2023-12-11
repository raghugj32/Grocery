using GroceryDal;
using GroceryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("/api/getorder")]
        public IActionResult GetOrders()
        {
            var res = OrderService.GetAllOrders();
            return Ok(res);
        }


        [HttpGet("/search/{pOrderId}")]
        public IActionResult GetOrderDetail(int pOrderId)
        {
            var found = OrderService.GetOrderById(pOrderId);

            //return the view with matching person object
            return Ok(found);
        }


        [HttpPost("/api/placeorder")]
        public IActionResult AddOrder(int OrderId, DateTime ODate,int CustID,int Amount, string Address,string status)
        {
            OrderService.PlaceOrder(OrderId,ODate,CustID, Amount, Address,status);
            return Ok($"Order Placed {OrderId}");

        }

        [HttpPut("/api/update/{OrderId}")]
        public IActionResult Update([FromRoute] int OrderId, [FromForm] Order o)
        {
            try
            {
                OrderService.UpdateOrder(o);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/api/deleteorder")]
        public IActionResult Delete([FromQuery] int OrderId)
        {
            try
            {
                OrderService.DeleteOrder(OrderId);
                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
