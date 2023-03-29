using CarRentalAPI.Adapters;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpPost]
        [Route("CreateNewCar")]
        public IActionResult CreateNewCar(CreateNewCarModel createNewCarModel)
        {
            var type = TypesAdapter.GetType(createNewCarModel.carModel.typeModel.name);
            var brand = BrandsAdapter.GetBrand(createNewCarModel.carModel.brandModel.name);
            var carModel = CarModelsAdapter.GetCarModel(createNewCarModel.carModel.name, brand, type);

            if(type == null || brand == null || carModel == null)
            {
                return BadRequest("Something gone wrong with input parameters!");
            }

            var result = CarsAdapter.InsertNewCar(createNewCarModel.registrationNumber, createNewCarModel.year, createNewCarModel.color, carModel);

            if (result)
            {
                return Ok("New car was inserted");
            }
            else
            {
                return BadRequest("Something gone wrong with input parameters!");
            }
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public IActionResult DeleteCar(DeleteCarModel deleteCar)
        {
            var car = CarsAdapter.DeleteCar(deleteCar);

            if (!car)
            {
                return BadRequest($"Specyfic car: {deleteCar.registrationNumber} not exist.");
            }

            else
            {
                var result = CarsAdapter.DeleteCar(deleteCar);

                if (result)
                {
                    return Ok($"Specific user: {deleteCar.registrationNumber} was delete.");
                }
            }
            return BadRequest();
        }
    }

    
}
