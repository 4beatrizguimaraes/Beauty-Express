using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modelos.Profissional;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionaisService _profissionaisService;

        public ProfissionalController(IProfissionaisService profissionaisService)
        {
            _profissionaisService = profissionaisService;
        }

        [HttpGet("profissionais")]
        public async Task<OkObjectResult> ObterTodos()
        {
            return Ok(await _profissionaisService.ObterTodos());
        }

        [HttpGet("profissional/{id}")]
        public async Task<ActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(await _profissionaisService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpGet("estabelecimento/{idEstabelecimento}/profissionais")]
        public async Task<ActionResult> ObterProfissionaisPorEstabelecimento([FromRoute] int idEstabelecimento)
        {
            try
            {
                return Ok(await _profissionaisService.ObterPorEstabelecimento(idEstabelecimento));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPost("profissional")]
        public async Task<ActionResult> Adicionar([FromBody] Profissional profissional)
        {
            try
            {
                return Ok(await _profissionaisService.Adicionar(profissional));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
        }

        [HttpPatch("profssional/{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Profissional profissional)
        {
            if (id == 0 || id != profissional.Id)
            {
                return NotFound();
            }

            try
            {
                await _profissionaisService.Atualizar(profissional);
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }

            return NoContent();
        }

        [HttpDelete("profissional/{id}")]
        public async Task<IActionResult> Remover([FromRoute] int id)
        {
            try
            {
                Ok(await _profissionaisService.Remover(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = ex.Message
                });
            }
            return NoContent();
        }
    }
}