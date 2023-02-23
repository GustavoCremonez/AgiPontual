using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var funcionarios = await _service.GetFuncionarios();

                if (funcionarios == null) return NotFound("Nenhum evento encontrado.");

                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return this.
                   StatusCode(StatusCodes.Status500InternalServerError,
                       $"Erro ao tentar recuperar os funcionarios. Erro: {ex.Message}"
                   );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
        {
            try
            {
                var evento = await _service.AddFuncionario(model);
                if (evento == null) return BadRequest("Erro ao cadastrar novo funcionario.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar novo evento, Erro: {ex.Message}");
            }
        }
    }
}
