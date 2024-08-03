using Dominio.Modelos;

namespace Dominio.Interfaces;

public interface IServicosRepository : IRepository<Servico>
{
    Task<bool> ExisteServicoPorProfissionalId(int id);
    Task<List<Servico>> BuscaServicoPorProfissional(int id);
}