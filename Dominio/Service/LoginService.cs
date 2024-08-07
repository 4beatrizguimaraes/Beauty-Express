using Dominio.Dto;
using Dominio.Interfaces;
using Dominio.Validadores;
using Modelos.Cliente;

namespace Dominio.Service
{
    public class LoginService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly TokenService _tokenService;
        public LoginService(IClienteRepository clienteRepository, TokenService tokenService) 
        {
            _clienteRepository = clienteRepository;
            _tokenService = tokenService;
        }

        public string Login(ClienteDto clienteDto)
        {
            if (string.IsNullOrEmpty(clienteDto.NomeOuEmail))
                throw new Exception("Login deve ter username ou email.");
            if (string.IsNullOrEmpty(clienteDto.Senha))
                throw new Exception("Por favor digite a senha.");

            var usuario = _clienteRepository.VerificarLoginNoBanco(clienteDto)
                            ?? throw new Exception("Credenciais inválidas");

            var token = _tokenService.GerarToken(usuario);
            return token;
        }
    }
}
