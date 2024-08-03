using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.Cliente;

namespace Dominio.Service;

public class ClienteService : BaseService, IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ClienteValidator _clienteValidator;
    private readonly IAgendamentosService _agendamentosService;

    public ClienteService(IClienteRepository clienteRepository, ClienteValidator clienteValidator, 
        IAgendamentosService agendamentosService)
    {
        _clienteRepository = clienteRepository;
        _clienteValidator = clienteValidator;
        _agendamentosService = agendamentosService;
    }

    public async Task<Cliente> Adicionar(Cliente cliente)
    {
        ValidationResult result = _clienteValidator.Validate(cliente);

        if (!result.IsValid)
        {
            string erros = ""; 
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _clienteRepository.Adicionar(cliente);
        return cliente;
    }

    public async Task<bool> Atualizar(Cliente cliente)
    {
        ValidationResult result = _clienteValidator.Validate(cliente);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _clienteRepository.ObterPorId(cliente.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Cliente não encontrada!");
        }
        await _clienteRepository.Atualizar(cliente.Id, cliente);
        return true;
    }

    public async Task<Cliente> ObterPorId(int id)
    {
        var cliente = await _clienteRepository.ObterPorId(id);
        if (cliente == null)
        {
            throw new Exception("Cliente não encontrada!");
        }
        return cliente;
    }

    public async Task<IEnumerable<Cliente>> ObterTodos()
    {
        return await _clienteRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _clienteRepository.ObterPorId(id) == null)
        {
            throw new Exception("Cliente não existe!");
        }

        if (await _agendamentosService.ExisteCliente(id))
        {
            throw new Exception("Cliente vinculado a um agendamento!");
        }

        await _clienteRepository.Remover(id);
        return true;
    }
}
