using Dominio.Modelos;

namespace Dominio.Interfaces;

public interface IAgendamentosService
{
    Task<IEnumerable<Agendamento>> ObterTodos();
    Task<Agendamento> ObterPorId(int id);
    Task<Agendamento> Adicionar(Agendamento agendamento);
    Task<bool> Atualizar(Agendamento agendamento);
    Task<bool> Remover(int id);
    Task<bool> ExisteEstabelecimento(int id);
    Task<bool> ExisteDataHorario(int id);
    Task<bool> ExisteCliente(int id);
    Task<bool> ExisteServico(int id);
}