using CarRentalAPI.Adapters;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("GetSpecificUser")]
        public IActionResult GetSpecificUser(string name, string surname, string idNumber)
        {
            var resutlModel = UsersAdapter.GetSpecificUser(name, surname, idNumber);

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
        [Route("CreateNewUser")]
        public IActionResult CreateNewUser(CreateNewUserModel createNewUser)
        {
            var result = UsersAdapter.InsertNewUser(createNewUser.name, createNewUser.surname, createNewUser.phone, createNewUser.idNumber);

            if (result)
            {
                return Ok("New user has been created.");
            }
            else
            {
                return BadRequest("Something gone wrong with input parameters!");
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult Put(UpdateUserModel updateUserModel)
        {
            var user = UsersAdapter.GetSpecificUser(updateUserModel.nameUser,updateUserModel.surnameUser, updateUserModel.idNumberUser);

            if (user == null)
            {
                return BadRequest($"Specyfic type: {updateUserModel.nameUser} not exist");
            }

            var result = UsersAdapter.UpdateUser(user, updateUserModel.newUserName, updateUserModel.newUserSurname, updateUserModel.newUserPhone, updateUserModel.newUserIdNumber);

            if (result)
            {
                user = UsersAdapter.GetSpecificUser(updateUserModel.newUserName, updateUserModel.newUserSurname, updateUserModel.idNumberUser);
                return Ok(user);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult Delete(DeleteUserModel deleteUser)
        {
            var user = UsersAdapter.GetSpecificUser(deleteUser.name,deleteUser.surname,deleteUser.idNumber);

            if (user == null)
            {
                return BadRequest($"Specyfic user: {deleteUser.name} {deleteUser.surname} not exist");
            }

            else
            {
                var result = UsersAdapter.DeleteUser(deleteUser);

                if (result)
                {
                    return Ok($"Specific user: {deleteUser.name} {deleteUser.surname} was delete");
                }
            }
            return BadRequest();
        }
    }
}
