using AdminAndInstructor.Microservice.Dto;
using AdminAndInstructor.Microservice.Repository;
using ApiCommonLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAndInstructor.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly ICourseRepo courseRepo;
        private readonly ILogger logger;
        public AdminController(ICourseRepo _courseRepo, ILogger<AdminController> _logger)
        {
            courseRepo = _courseRepo;
            logger = _logger;
        }
        // GET: api/<AdminController>
        [HttpGet("notification")]
        public async Task<ActionResult<ServiceResponse<object>>> Get()
        {
            return Ok(await courseRepo.GetNotification());
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return  Ok(await courseRepo.GetCoursebyId(id));
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<object>>> Post([FromBody] AddCourseDto[] addCourseDto)
        {
            logger.LogInformation("Task<ActionResult<ServiceResponse<object>>> Post");
            var role = (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value);
            if (role != "Admin" && role != "Instructor")
                return Unauthorized("You are not allowed to perform operation");
            var response = await courseRepo.AddCourse(addCourseDto);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
           
        }

        // PUT api/<AdminController>/5
       
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> Put(int id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            logger.LogInformation("Task<ActionResult<ServiceResponse<object>>> Put");
            var role = (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value);
            if (role != "Admin" && role != "Instructor")
            {
                return Unauthorized("You are not allowed to perform operation");
            }
            var response = await courseRepo.UpdateCourse(id, updateCourseDto);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("enrollStudents")]
        public async Task<IActionResult> GetEnrollStudents()
        {
            return Ok(await courseRepo.GetEnrollStudents());
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
