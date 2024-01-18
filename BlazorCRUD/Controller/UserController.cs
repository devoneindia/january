using BlazorCRUD.Interfaces;
using BlazorCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Controller
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
        public async Task<List<UserDetail>> Get()
        {
            return await Task.FromResult(_IUser.GetUserDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserDetail user = _IUser.GetUserData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(UserDetail user)
        {
            _IUser.AddUser(user);
        }
        [HttpPut]
        public void Put(UserDetail user)
        {
            _IUser.UpdateUserDetails(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}
