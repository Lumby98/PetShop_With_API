using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.Entities;
using PetShopApp.Core.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.RestAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<Pet> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetPets(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, "could not get pets");
            }
        }
       

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return Ok(_petService.GetPet(id));
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Created("", _petService.CreatePet(pet));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                return StatusCode(202, _petService.UpdatePet(id, pet));
            }
            catch (Exception e)
            {
                return StatusCode(406, e.Message);
            }
           
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return Ok(_petService.DeletePet(id));
            }
            catch (Exception e)
            {
                return StatusCode(418, e.Message);
            }
        }
    }
}
