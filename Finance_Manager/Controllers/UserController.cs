using Microsoft.AspNetCore.Mvc;
using Service.DTOS.UserDTO;
using Service.Interfaces;
using System.ComponentModel;

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

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<ActionResult> FindAll()
        {
            var response = await _service.FindAll();
            if (response.Code == 200) return Ok(response);
            return BadRequest(response);
        }


        /// <summary>
        /// Retorna um usuário de acordo com o ID
        /// </summary>
        [HttpGet("id")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        public async Task<ActionResult> FindById([FromQuery] int id)
        {
            var response = await _service.FindById(id);
            if (response.Code == 406) return Problem(statusCode: response.Code, title: response.Message);
            if (response.Code == 404) return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Cria um usuário (adiciona uma conta para ele automaticamente)
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromBody] UserCreateDTO user)
        {
            var response = await _service.Create(user);
            if (response.Code == 400) return BadRequest(response);
            return StatusCode(201,response);
        }
    }
}
