using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SneakerLIB.Customer;
using static SneakerLIB.Orders;
using static SneakerLIB.Shoes;

namespace sneakerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("/View Orders")]
        public IActionResult vieworder()
        {
            var result = OrdersOperations.Get();


            return Ok(result);
        }


        [HttpPost("/Add Order")]
        public IActionResult addcust(int id, string orderName)

        {
            OrdersOperations.Add(id, orderName);

            return Ok($"Created Order by OrderId Successfully");

        }

        [HttpPost("/Update Order")]

        public IActionResult updateorder(int id, string NeworderName)

        {
            try
            {


                OrdersOperations.Update(id,NeworderName);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Delete Order")]
        public IActionResult deletecust(int dorderId)
        {
            try
            {
                OrdersOperations.Delete(dorderId);

                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
