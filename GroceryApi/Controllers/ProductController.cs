using GroceryDal;
using GroceryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("/api/getproduct")]
        public IActionResult GetProducts()
        {
            var res = ProductService.GetAllProducts();
            return Ok(res);
        }


        [HttpGet("/search/{pId}")]
        public IActionResult GetProductDetail(int pId)
        {
            var found = ProductService.GetProductById(pId);

            //return the view with matching person object
            return Ok(found);
        }


        [HttpPost("/api/addproduct")]
        public IActionResult AddProducts(int ProdId, string Name,int Price, string Desc)
        {
            ProductService.AddProduct(ProdId, Name, Price, Desc);
            return Ok($"Product Added with {Name}");

        }

        [HttpPut("/api/update/{pId}")]
        public IActionResult UpdateProd([FromRoute] int pId, [FromForm] Product p)
        {
            try
            {
                ProductService.UpdateProduct(pId, p);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/api/deleteproduct")]
        public IActionResult DeleteProd([FromQuery] int pId)
        {
            try
            {
                ProductService.DeleteProduct(pId);
                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

