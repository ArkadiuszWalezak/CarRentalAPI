using CarRentalAPI.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("getSpecificUser")]
        public IActionResult GetSpecificUser(string name, string surname)
        {
            var resutlModel = UsersAdapter.GetSpecificUser(name, surname);

            if (resutlModel != null)
            {
                return Ok(resutlModel);
            }
            else
            {
                return NotFound("No data is here");
            }
        }
    }
}
