using Modelos.Profissional;

namespace Dominio.Interfaces;

public interface IProfissionaisService
{
    Task<IEnumerable<Profissional>> ObterTodos();
    Task<Profissional> ObterPorId(int id);
    Task<IEnumerable<Profissional>> ObterPorEstabelecimento(int id);
    Task<Profissional> Adicionar(Profissional profissional);
    Task<bool> Atualizar(Profissional profissional);
    Task<bool> Remover(int id);
}