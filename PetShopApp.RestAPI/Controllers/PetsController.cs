﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.Entities;

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
        public ActionResult<Pet> Get()
        {
            try
            {
                return Ok(_petService.GetPets());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
       

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
                return StatusCode(406, e.Message);
            }
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.UpdatePet(id, pet));
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
