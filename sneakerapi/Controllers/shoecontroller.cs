using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SneakerLIB;
using static SneakerLIB.Shoes;

namespace sneakerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shoecontroller : ControllerBase
    {

        [HttpGet("/View Sneakers")]
        public IActionResult viewshoe()
        {
            var result = ShoesOperations2.Get();


            return Ok(result);
        }
        //[HttpPost("/searchshoe")]
        /*public IActionResult search(int pshoeId)
        {
            try
            {
                ShoeOperations.Search(pshoeId);

                return Ok("Search Successfull");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }*/
        [HttpPost("/Add Sneaker")]
        public IActionResult addshoes(int shoeId, string gender, float shoeprice, string shoestyle, string shoename, string shoecolor, int shoesize)
            
        {
            ShoesOperations2.Add(shoeId, gender, shoeprice, shoestyle, shoename, shoecolor, shoesize);
            
            return Ok($"Created Shoe by name Successfully");

        }
        [HttpPost("/Update Sneaker")]
        
       public IActionResult updateshoes(int shoeid, string Newgender, float Newshoeprice, string Newshoestyle, string Newshoename, string Newshoecolor, int Newshoesize)
           
        {
            try
            {


                ShoesOperations2.Update(shoeid,Newgender,Newshoeprice,Newshoestyle,Newshoename,Newshoecolor,Newshoesize);
                return Ok("Update Successfull");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        


        [HttpDelete("/Delete Sneaker")]
        public IActionResult deleteshoe(int dshoeId)
        {
            try
            {
                ShoesOperations2.Delete(dshoeId);
               
                return Ok("Delete Successfull");
            }
            catch (Exception ex)
            {
                
                return NotFound(ex.Message);
            }

        }

    }

    
}
