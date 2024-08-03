using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios;

public class ServicoRepository : BaseRepository<Servico>, IServicosRepository
{
    public ServicoRepository(BeautyContext contexto) : base(contexto)
    {
    }

    public async Task<List<Servico>> BuscaServicoPorProfissional(int id)
    {
        var profissional = await Db
            .Where(x => x.Id == id)
            .Select(x => x.ProfissionalId)
            .FirstOrDefaultAsync();

        return await Db
            .Where(v => v.ProfissionalId == profissional)
            .ToListAsync();
    }

    public async Task<bool> ExisteServicoPorProfissionalId(int id)
    {
        var queryProfissional = await Db
            .Where(v => v.ProfissionalId == id)
            .ToListAsync();

        return queryProfissional.Count() > 0;
    }
}