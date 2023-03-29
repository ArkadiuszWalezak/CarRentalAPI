using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalAPI.Adapters;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        [HttpGet]
        [Route("GetType")]
        public IActionResult Get(string name)
        {
            var resultType = TypesAdapter.GetType(name);

            if (resultType != null)
            {
                return Ok(resultType);
            }
            return NotFound($"Specific type {name} not found.");
        }

        [HttpPost]
        [Route("InsertNewType")]
        public IActionResult Post(InsertNewTypeModel insertNewTypeModel)
        {
            var resulType = TypesAdapter.InsertNewType(insertNewTypeModel.name);

            if (resulType)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateType")]
        public IActionResult Put(UpdateTypeModel updateTypeModel)
        {
            var type = TypesAdapter.GetType(updateTypeModel.nameModel);

            if(type == null)
            {
                return BadRequest($"Specyfic type: {updateTypeModel.nameModel} not exist");
            }

            var result = TypesAdapter.UpdateType(type, updateTypeModel.newNameModel);

            if (result)
            {
                type = TypesAdapter.GetType(updateTypeModel.newNameModel);
                return Ok(type);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteType")]
        public IActionResult Delete(DeleteTypeModel deleteTypeModel)
        {
            var type = TypesAdapter.GetType(deleteTypeModel.nameTypeModel);

            if (type == null)
            {
                return BadRequest($"Specyfic type: {deleteTypeModel.nameTypeModel} not exist");
            }

            else
            {
                var result = TypesAdapter.DeleteType(deleteTypeModel);

                if (result)
                {
                    return Ok($"Specific type: {deleteTypeModel.nameTypeModel} was delete");
                }
            }
            return BadRequest();
        }
    }
}
