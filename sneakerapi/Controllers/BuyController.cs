using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SneakerLIB.Buys;
using static SneakerLIB.Customer;

namespace sneakerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        [HttpGet("/View Buy")]
        public IActionResult viewbuy()
        {
            var result = BuyOperations.Get();


            return Ok(result);
        }

        [HttpPost("/Add Buy")]
        public IActionResult addbuy(int orderId, int quantity)

        {
            BuyOperations.Add(orderId, quantity);

            return Ok($"Created Buy by OrderedId Successfully");

        }
        [HttpPost("/Update Buy")]

        public IActionResult updatebuy(int id, int newQuantity, int newOrderId)

        {
            try
            {


                BuyOperations.Update(id,newQuantity,newOrderId);
                return Ok("Update Successfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Delete Buy")]
        public IActionResult deletecust(int dbuyId)
        {
            try
            {
                BuyOperations.Delete(dbuyId);

                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
