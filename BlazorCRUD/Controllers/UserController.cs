using BlazorCRUD.Contracts;
using BlazorCRUD.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Task.FromResult(_IUser.GetUserDetails());
        }
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _IUser.GetUserData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
           
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _IUser.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _IUser.UpdateUserDetails(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}
