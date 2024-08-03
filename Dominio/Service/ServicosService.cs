using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Service;

public class ServicosService : BaseService, IServicosService
{
    private readonly IServicosRepository _servicosRepository;
    private readonly ServicosValidator _servicosValidator;
    private readonly IProfissionaisRepository _profissionaisRepository;
    private readonly IAgendamentosService _agendamentosService;

    public ServicosService(IServicosRepository servicosRepository, ServicosValidator servicosValidator, 
        IProfissionaisRepository profissionaisRepository, 
        IAgendamentosService agendamentosService)
    {
        _servicosRepository = servicosRepository;
        _servicosValidator = servicosValidator;
        _profissionaisRepository = profissionaisRepository;
        _agendamentosService = agendamentosService;
    }

    public async Task<Servico> Adicionar(Servico servico)
    {
        ValidationResult result = _servicosValidator.Validate(servico);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        if (!(await ExisteProfissionalAsync(servico.ProfissionalId)))
        {
            throw new Exception("Profissional não existe.");
        }

        await _servicosRepository.Adicionar(servico);
        return servico;
    }

    public async Task<bool> Atualizar(Servico servico)
    {
        ValidationResult result = _servicosValidator.Validate(servico);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var servicoBusca = await _servicosRepository.ObterPorId(servico.Id);
        if (servicoBusca == null)
        {
            throw new Exception("Serviço não encontrada!");
        }
        if (!(await ExisteProfissionalAsync(servico.ProfissionalId)))
        {
            throw new Exception("Profissional não existe.");
        }
        await _servicosRepository.Atualizar(servico.Id, servico);
        return true;
    }

    public async Task<bool> ExisteServicoPorProfissionalId(int id)
    {
        return await _servicosRepository.ExisteServicoPorProfissionalId(id);
    }

    public async Task<Servico> ObterPorId(int id)
    {
        var servico = await _servicosRepository.ObterPorId(id);
        if (servico == null)
        {
            throw new Exception("Serviço não encontrada!");
        }
        return servico;
    }

    public async Task<IEnumerable<Servico>> ObterTodos()
    {
        return await _servicosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _servicosRepository.ObterPorId(id) == null)
        {
            throw new Exception("Serviço não existe!");
        }

        if(await _agendamentosService.ExisteServico(id))
        {
            throw new Exception("Serviço vinculado a um agendamento!");
        }

        await _servicosRepository.Remover(id);
        return true;
    }

    private async Task<bool> ExisteProfissionalAsync(int id)
    {
        var retorno = await _profissionaisRepository.ObterPorId(id);
        return retorno != null;
    }
}