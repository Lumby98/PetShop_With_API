using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entities;
using PetShopApp.Core.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        // GET: api/<PetTypeController>
        [HttpGet]
        public ActionResult<PetType> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petTypeService.GetPetTypes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "could not get pet types");
            }
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            try
            {
                PetType t = _petTypeService.GetPetType(id);
                if (t == null)
                {
                    return StatusCode(404, "pet not found");
                }
                
                return Ok(t);

            }
            catch(Exception ex)
            {
                return StatusCode(500, "something went wrong");
            }
        }

        // POST api/<PetTypeController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            try
            {
                return Created("", _petTypeService.CreatePetType(petType));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            try
            {
                PetType editType = _petTypeService.UpdatePetType(id, petType);
                if (editType == null)
                {
                    return StatusCode(404, "could not find pet to edit");
                }
                return StatusCode(202, _petTypeService.UpdatePetType(id, petType));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                PetType typeDelete = _petTypeService.GetPetType(id);
                if (typeDelete == null)
                {
                    return StatusCode(404, "could not find pet type to delete");
                }

                return StatusCode(202, _petTypeService.DeletePetType(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
