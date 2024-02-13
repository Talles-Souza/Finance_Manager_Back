using Microsoft.AspNetCore.Mvc;
using Service.DTOS.SpendDTO;
using Service.DTOS.UserDTO;
using Service.Interfaces;

namespace Finance_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendController : ControllerBase
    {
        private readonly ISpendService _spend;

        public SpendController(ISpendService spend)
        {
            _spend = spend ?? throw new ArgumentNullException(nameof(spend));
        }



        /// <summary>
        /// Retorna todos os gastos.
        /// </summary>
        /// <returns>Lista de gastos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(SpendDTO), 200)]
        public async Task<ActionResult> FindAll()
        {
            var response = await _spend.FindAll();
            if (response.Code == 200) return Ok(response);
            return BadRequest(response);
        }


        /// <summary>
        /// Retorna um gasto de acordo com o ID
        /// </summary>
        [HttpGet("id")]
        [ProducesResponseType(typeof(SpendDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        public async Task<ActionResult> FindById([FromQuery] int id)
        {
            var response = await _spend.FindById(id);
            if (response.Code == 406) return Problem(statusCode: response.Code, title: response.Message);
            if (response.Code == 404) return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Cria um gasto que ja nasce relacionado a uma conta
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(SpendDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromBody] SpendDTO spend)
        {
            var response = await _spend.Create(spend);
            if (response.Code == 400) return BadRequest(response);
            return StatusCode(201, response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SpendDTO spend)
        {
            var response = await _spend.Update(spend);
            if (response.Code == 200) return Ok(response);
            if (response.Code == 404) return NotFound();
            return BadRequest(response);

        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var response = await _spend.Delete(id);
            if (response.Code == 200) return Ok(response);
            if (response.Code == 406) return Problem(statusCode: 406, title: "Caracter Not Acceptable");
            if (response.Code == 404) return NotFound();
            return BadRequest(response);

        }
    }
}
