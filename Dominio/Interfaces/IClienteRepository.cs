using Dominio.Dto;
using Modelos.Cliente;

namespace Dominio.Interfaces;

public interface IClienteRepository : IRepository<Cliente>
{
    public Cliente? VerificarLoginNoBanco(ClienteDto clienteDto);
}