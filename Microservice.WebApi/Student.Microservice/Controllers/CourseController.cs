using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Student.Microservice.Feature.StudentFeature.Query;
using Student.Microservice.Feature.StudentFeature.Update;
using Student.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult>  GetCourseDetails()
        {
            return Ok(await Mediator.Send(new GetAllCoursesQuery()));
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEnrollCoursebyStudent { Id = id }));
        }

        // PUT api/<CourseController>/5
        [HttpPut("enroll/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EnrollCourseToStudentCommand enrollCourseCommand)
        {
            if (id != enrollCourseCommand.EnrollCourseId)
                return BadRequest();
            return Ok(await Mediator.Send(enrollCourseCommand));
        }

        // DELETE api/<CourseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
