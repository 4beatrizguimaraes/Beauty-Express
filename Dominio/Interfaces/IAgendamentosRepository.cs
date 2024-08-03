using Dominio.Modelos;

namespace Dominio.Interfaces;

public interface IAgendamentosRepository : IRepository<Agendamento>
{
    Task<bool> ExisteEstabelecimento(int id);
    Task<bool> ExisteDataHorario(int id);
    Task<bool> ExisteCliente(int id);
    Task<bool> ExisteServico(int id);
    Task<bool> ExisteAgendamentoClienteMesmoHorario(Agendamento agendamento);
    Task<bool> ExisteAgendamentoProfissionalMesmoHorario(Agendamento agendamento, List<Servico> servicos);
}