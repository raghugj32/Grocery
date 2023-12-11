using GroceryDal;
using GroceryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        [HttpGet("/api/get")]
        public IActionResult GetCustomers()
        {
            var res = CustomerService.GetAllCustomers();
            return Ok(res);
        }


        //[HttpGet("/search/{pCustId}")]
        //public IActionResult GetCustDetail(int pCustId)
        //{            
        //    var found = CustomerService.GetCustomerById(pCustId);

        //    //return the view with matching person object
        //    return Ok(found);
        //}


        [HttpPost("/api/addCustomer")]
        public IActionResult CreateCustomer(int CustId, string CName, string Email, string Address, string Phone)
        {
            CustomerService.AddCustomer(CustId, CName, Email, Address, Phone);
            return Ok($"Customer Created with {CName}");

        }

        [HttpPut("/api/update/{CustId}")]
        public IActionResult UpdateCust(int CustId, string CName, string Email, string Address, string Phone)
        {
            try
            {
                CustomerService.UpdateCustomer(CustId, CName,Email, Address, Phone);               
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {               
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/api/delete")]
        public IActionResult DeleteCust([FromQuery] int CustId)
        {
            try
            {
                CustomerService.DeleteCustomer(CustId);               
                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {               
                return NotFound(ex.Message);
            }
        }
    }
}
