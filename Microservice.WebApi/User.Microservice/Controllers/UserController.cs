using ApiCommonLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.DTO;
using User.Microservice.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo userRepo;
        public UserController(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<object>>> Post([FromBody] AddUserDto user)
        {
            var response = await userRepo.Register(user);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpPost("login")]
        public object Register([FromBody] SignInDto user)
        {
            return Ok("User resgistered successfully");
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
