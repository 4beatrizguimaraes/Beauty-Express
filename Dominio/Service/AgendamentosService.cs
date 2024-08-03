using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Dominio.Service;

public class AgendamentosService : BaseService, IAgendamentosService
{
    private readonly IAgendamentosRepository _agendamentosRepository;
    private readonly AgendamentosValidator _agendamentosValidator;
    private readonly IEstabelecimentosRepository _estabelecimentosRepository;
    private readonly IDataHorariosRepository _horariosRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IServicosRepository _servicosRepository;

    public AgendamentosService(IAgendamentosRepository agendamentosRepository, AgendamentosValidator agendamentosValidator, 
        IEstabelecimentosRepository estabelecimentosRepository, 
        IDataHorariosRepository horariosRepository, 
        IClienteRepository clienteRepository, 
        IServicosRepository servicosRepository)
    {
        _agendamentosRepository = agendamentosRepository;
        _agendamentosValidator = agendamentosValidator;
        _estabelecimentosRepository = estabelecimentosRepository;
        _horariosRepository = horariosRepository;
        _clienteRepository = clienteRepository;
        _servicosRepository = servicosRepository;
    }

    public async Task<Agendamento> Adicionar(Agendamento agendamento)
    {
        ValidationResult result = _agendamentosValidator.Validate(agendamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await ValidaChaves(agendamento);

        await _agendamentosRepository.Adicionar(agendamento);
        return agendamento;
    }

    public async Task<bool> Atualizar(Agendamento agendamento)
    {
        ValidationResult result = _agendamentosValidator.Validate(agendamento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await ValidaChaves(agendamento);

        await _agendamentosRepository.Atualizar(agendamento.Id, agendamento);
        return true;
    }

    public async Task<bool> ExisteCliente(int id)
    {
        return await _agendamentosRepository.ExisteCliente(id);
    }

    public async Task<bool> ExisteDataHorario(int id)
    {
        return await _agendamentosRepository.ExisteDataHorario(id);
    }

    public async Task<bool> ExisteEstabelecimento(int id)
    {
        return await _agendamentosRepository.ExisteEstabelecimento(id);
    }

    public async Task<bool> ExisteServico(int id)
    {
        return await _agendamentosRepository.ExisteServico(id);
    }

    public async Task<Agendamento> ObterPorId(int id)
    {
        var agendamento = await _agendamentosRepository.ObterPorId(id);
        if (agendamento == null)
        {
            throw new Exception("Agendamento não encontrada!");
        }
        return agendamento;
    }

    public async Task<IEnumerable<Agendamento>> ObterTodos()
    {
        return await _agendamentosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _agendamentosRepository.ObterPorId(id) == null)
        {
            throw new Exception("Agendamento não existe!");
        }

        await _agendamentosRepository.Remover(id);
        return true;
    }

    private async Task ValidaChaves(Agendamento agendamento)
    {
        if(await _estabelecimentosRepository.ObterPorId(agendamento.EstabelecimentoId) == null)
        {
            throw new Exception("Estabelecimento não existe!");
        }
        if (await _horariosRepository.ObterPorId(agendamento.DataHorarioId) == null)
        {
            throw new Exception("Data Horario não existe!");
        }
        if (await _clienteRepository.ObterPorId(agendamento.ClienteId) == null)
        {
            throw new Exception("Cliente não existe!");
        }
        if (await _servicosRepository.ObterPorId(agendamento.ServicoId) == null)
        {
            throw new Exception("Serviço não existe!");
        }
        if (await _agendamentosRepository.ExisteAgendamentoClienteMesmoHorario(agendamento))
        {
            throw new Exception("Existe um outro agendamento para esse cliente nesse horario!");
        }

        var servicos = await _servicosRepository
            .BuscaServicoPorProfissional(agendamento.ServicoId);


        if (await _agendamentosRepository.ExisteAgendamentoProfissionalMesmoHorario(agendamento, servicos))
        {
            throw new Exception("Existe um outro agendamento para esse profissional nesse horario!");
        }
    }
}