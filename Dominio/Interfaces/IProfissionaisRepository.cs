using Modelos.Profissional;

namespace Dominio.Interfaces;

public interface IProfissionaisRepository : IRepository<Profissional>
{
    public Task<IEnumerable<Profissional>> ObterPorEstabelecimento(int idEstabelecimento);
}