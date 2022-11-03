﻿using AdminAndInstructor.Microservice.Dto;
using AdminAndInstructor.Microservice.Repository;
using ApiCommonLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAndInstructor.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public ICourseRepo courseRepo;
        public AdminController(ICourseRepo _courseRepo)
        {
            courseRepo = _courseRepo;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<object>>> Post([FromBody] AddCourseDto[] addCourseDto)
        {
            var response = await courseRepo.AddCourse(addCourseDto);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] string value)
        {
            return Ok("Course updated , "+ id.ToString());
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
