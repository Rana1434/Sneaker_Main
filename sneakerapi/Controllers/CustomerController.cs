using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SneakerLIB.Customer;
using static SneakerLIB.Shoes;

namespace sneakerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("/View Customers")]
        public IActionResult viewcust()
        {
            var result = CustomerOperations.Get();


            return Ok(result);
        }

        [HttpPost("/Add Customer")]
        public IActionResult addcust(int custId, string custName, string custAddress)

        {
           CustomerOperations.Add(custId, custName, custAddress);

            return Ok($"Created Customer by custId Successfully");

        }
        [HttpPost("/Update Customer")]

        public IActionResult updatecust(int custId, string NewcustName, string NewcustAddress)

        {
            try
            {


                CustomerOperations.Update(custId, NewcustName, NewcustAddress);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Delete Customer")]
        public IActionResult deletecust(int dcustId)
        {
            try
            {
                CustomerOperations.Delete(dcustId);

                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }

    }
}
