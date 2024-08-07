using Dominio.Dto;
using Dominio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly TokenService _tokenService;
        public LoginController(LoginService loginService, TokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public OkObjectResult Login([FromQuery] ClienteDto clienteDto)
        {
            var token = _loginService.Login(clienteDto);
            return Ok(token);
        }

        [HttpGet("tokenValido")]
        public IActionResult VerificaValidadeToken([FromQuery] string token)
        {
            var tokenEhValido = _tokenService.TokenEhValido(token);
            return tokenEhValido ?  Ok() : Unauthorized();
        }
    }
}
