using Microsoft.AspNetCore.Mvc;
using Service.DTOS.UserDTO;
using Service.Interfaces;

namespace Finance_Manager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var response = await _service.FindAll();
            if (response.Code == 200) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<ActionResult> FindById([FromQuery] int id)
        {
            var response = await _service.FindById(id);
            if (response.Code == 406) return Problem(statusCode: response.Code, title: response.Message);
            if (response.Code == 404) return NotFound(response);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody] UserCreateDTO user)
        {
            var response = await _service.Create(user);
            if (response.Code == 400) return BadRequest(response);
            return StatusCode(201,response);
        }
    }
}
