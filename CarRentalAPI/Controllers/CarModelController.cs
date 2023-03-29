using CarRentalAPI.Adapters;
using CarRentalAPI.Models;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CarModelController : ControllerBase
        {
            [HttpGet]
            [Route("GetSpecificModel")]
            public IActionResult GetSpecyficCarModel(string name)
            {
                var resutlModel = CarModelsAdapter.GetCarModel(name);

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
            [Route("CreateNewModel")]
            public IActionResult CreateNewCarModel(CreateNewCarModelModel createNewCarModelModel)
            {
            var type = TypesAdapter.GetType(createNewCarModelModel.typeModel.name);
            var brand = BrandsAdapter.GetBrand(createNewCarModelModel.brandModel.name);

            if (type == null || brand == null)
            {
                return null;
            }

            var result = CarModelsAdapter.InsertNewCarModel(createNewCarModelModel.name, type, brand);

                if (result)
                {
                    return Ok("New model was insert");
                }
                else
                {
                    return BadRequest("Something gone wrong with input parameters!");
                }
            }
        }

    }

