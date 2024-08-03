using Dominio.Modelos;

namespace Dominio.Interfaces;

public interface IServicosService
{
    Task<IEnumerable<Servico>> ObterTodos();
    Task<Servico> ObterPorId(int id);
    Task<Servico> Adicionar(Servico servico);
    Task<bool> Atualizar(Servico servico);
    Task<bool> Remover(int id);
    Task<bool> ExisteServicoPorProfissionalId(int id);
}