using Microsoft.AspNetCore.Mvc;
using SneakerApp1.Models;
using System;
using static SneakerApp1.Models.Shoes;

namespace SneakerApp1.Controllers
{
    public class shoeController : Controller
    {
        [HttpGet("/shoes")]
        public IActionResult GetShoes()
        {
            var shoes = Shoes.ShoeOperations.Get();
            return View("GetShoes", shoes);
        }
        [HttpGet("/add")]
        public IActionResult Add()
        {
            return View("Add", new SneakerDAL.Shoes());
        }

        [HttpPost("/add")]
        public IActionResult Add([FromForm] Shoes shoes)
        {
            Shoes.ShoeOperations.Add(
                shoes.shoeId,
                shoes.Gender,
                shoes.shoePrice,
                shoes.shoeStyle,
                shoes.shoeName,
                shoes.shoeColor,
                shoes.shoeSize
            );

            // Redirect to the GetShoes action to display the updated list
            return RedirectToAction("GetShoes");
        }

        [HttpGet("/update/{shoeId}")]
        public IActionResult Update(int shoeId)
        {
            var found = ShoeOperations.Search(shoeId);
            return View("Update", found);

        }

        [HttpPost("/update/{shoeId}")]
        public IActionResult Update(int shoeId, [FromForm] Shoes p)
        {
            var found = ShoeOperations.Search(p.shoeId);
            found.Gender = p.Gender;
            found.shoePrice = p.shoePrice;
            found.shoeStyle = p.shoeStyle;
            found.shoePrice = p.shoePrice;
            found.shoeName= p.shoeName;
            found.shoeColor=p.shoeColor;
            found.shoeSize = p.shoeSize;
            return View("GetShoes", ShoeOperations.Get());
        }

        [HttpGet("/search/{shoeId}")]
        public IActionResult ShoeDetails(int shoeId)
        {
            var found = ShoeOperations.Search(shoeId);
            return View("Search", found);
        }
    }
}