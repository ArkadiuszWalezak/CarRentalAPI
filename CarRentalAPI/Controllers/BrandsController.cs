using CarRentalAPI.Adapters;
using CarRentalAPI.Models;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpGet]
        [Route("GetSpecificBrand")]
        public IActionResult GetSpecificBrand(string name)
        {
            var resutlModel = BrandsAdapter.GetBrand(name);

            if (resutlModel != null)
            {
                return Ok(resutlModel);
            }
            else
            {
                return NotFound("No data is here");
            }
        }

        [HttpPost]
        [Route("CreateNewBrand")]
        public IActionResult CreateNewBrand(BrandModel createBrandModel)
        {
            var result = BrandsAdapter.InsertNewBrand(createBrandModel.name);

            if (result)
            {
                return Ok("New brand was insert");
            }
            else
            {
                return BadRequest("Something gone wrong with input parameters!");
            }
        }
    }
}