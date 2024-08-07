using Dominio.Dto;
using Dominio.Interfaces;
using Modelos.Cliente;

namespace Infra.Repositorios;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(BeautyContext contexto) : base(contexto) 
    {
        
    }

    public Cliente? VerificarLoginNoBanco(ClienteDto clienteDto)
    {
        return Contexto
            .Clientes
            .FirstOrDefault(c => (c.Nome == clienteDto.NomeOuEmail || c.Email == clienteDto.NomeOuEmail) && c.Senha == clienteDto.Senha);
    }
}