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


        [HttpGet("{pid}")]
        public IActionResult GetCustomerById(int pid)
        {
            var found = ProductService.GetProductById(pid);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }


        [HttpPost("/api/addproduct")]
        public IActionResult AddProducts(int ProdId, string Name,int Price, string Desc)
        {
            ProductService.AddProduct(ProdId, Name, Price, Desc);
            return Ok($"Product Added with {Name}");

        }

        [HttpPut("update/{pId}")]
        public IActionResult UpdateProd(int pId, string Name, int Price, string Desc)
        {
            try
            {
                ProductService.UpdateProduct(pId, Name, Price, Desc);
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

