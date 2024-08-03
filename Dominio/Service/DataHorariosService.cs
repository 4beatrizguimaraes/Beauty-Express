using Dominio.Interfaces;
using Dominio.Validadores;
using FluentValidation.Results;
using Modelos.Cliente;
using Modelos.DataHorario;

namespace Dominio.Service;

public class DataHorariosService : BaseService, IDataHorariosService
{
    private readonly IDataHorariosRepository _dataHorariosRepository;
    private readonly DataHorariosValidator _dataHorariosValidator;
    private readonly IAgendamentosService _agendamentosService;

    public DataHorariosService(IDataHorariosRepository dataHorariosRepository, DataHorariosValidator dataHorariosValidator, 
        IAgendamentosService agendamentosService)
    {
        _dataHorariosRepository = dataHorariosRepository;
        _dataHorariosValidator = dataHorariosValidator;
        _agendamentosService = agendamentosService;
    }

    public async Task<DataHorario> Adicionar(DataHorario dataHorario)
    {
        ValidationResult result = _dataHorariosValidator.Validate(dataHorario);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _dataHorariosRepository.Adicionar(dataHorario);
        return dataHorario;
    }

    public async Task<bool> Atualizar(DataHorario dataHorario)
    {
        ValidationResult result = _dataHorariosValidator.Validate(dataHorario);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        var clienteBusca = await _dataHorariosRepository.ObterPorId(dataHorario.Id);
        if (clienteBusca == null)
        {
            throw new Exception("Data horario não encontrada!");
        }
        await _dataHorariosRepository.Atualizar(dataHorario.Id, dataHorario);
        return true;
    }

    public async Task<DataHorario> ObterPorId(int id)
    {
        var dataHorario = await _dataHorariosRepository.ObterPorId(id);
        if (dataHorario == null)
        {
            throw new Exception("Data horario não encontrada!");
        }
        return dataHorario;
    }

    public async Task<IEnumerable<DataHorario>> ObterTodos()
    {
        return await _dataHorariosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _dataHorariosRepository.ObterPorId(id) == null)
        {
            throw new Exception("Data horario não existe!");
        }

        if (await _agendamentosService.ExisteDataHorario(id))
        {
            throw new Exception("Data horario vinculado a um agendamento!");
        }

        await _dataHorariosRepository.Remover(id);
        return true;
    }
}