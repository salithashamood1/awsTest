using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testApi.model;

namespace testApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User
            {
                   Id = "1", Name = "Kalpa", Age = 20, MobileNumber = "0712115457",  Gender = "Male"
            },
            new User
            {
                   Id = "2", Name = "Hirusha", Age = 25, MobileNumber = "0725489201",  Gender = "Male"
            },
            new User
            {
                   Id = "3", Name = "Gayani", Age = 30, MobileNumber = "0758941236",  Gender = "Female"
            },
        };

        [HttpGet("User")]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return Ok(users);
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(user);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var user = users.Find(u => u.Id == request.Id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            user.Name = request.Name;
            user.Age = request.Age;
            user.MobileNumber = request.MobileNumber;
            user.Gender = request.Gender;

            return Ok(users);
        }

        [HttpDelete("User/{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(string id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            users.Remove(user);
            return Ok(users);
        }
    }
}
