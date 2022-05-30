using Microsoft.AspNetCore.Mvc;
using testApi.model;
using testApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var existingUser = userService.Get().Find(u => u.Id == id);
            if (existingUser != null)
            {
                var user = userService.Get(id);

                if (user == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }
                return user;
            }
            return NotFound($"Student with Id = {id} not found");
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(string id, [FromBody] User  user)
        {
            var existingUser = userService.Get().Find(u => u.Id == id);
            if (existingUser != null)
            {
                var existUser = userService.Get(id);

                if (existUser == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }
                userService.Update(id, user);
                return NoContent();
            }
            return NotFound($"Student with Id = {id} not found");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(string id)
        {
            var existingUser = userService.Get().Find(u => u.Id == id);
            if (existingUser != null)
            {
                var user = userService.Get(id);
                if (user == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }
                userService.Remove(id);
                return Ok($"Student with Id = {id} deleted");
            }
            return NotFound($"Student with Id = {id} not found");
            
        }
    }
}
