using DATAACCESS.Abstract;
using ENTITIES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            User user = _userRepository.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Insert(User user)
        {
            _userRepository.InsertUser(user);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            _userRepository.UpdateUser(user);
            return NoContent();
        }
    }
}
