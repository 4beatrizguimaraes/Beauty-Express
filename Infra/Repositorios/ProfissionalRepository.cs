using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Profissional;

namespace Infra.Repositorios
{
    public class ProfissionalRepository : BaseRepository<Profissional>, IProfissionaisRepository
    {        
        public ProfissionalRepository(BeautyContext contexto) : base(contexto)
        {

        }

        public async Task<IEnumerable<Profissional>> ObterPorEstabelecimento(int idEstabelecimento)
        {
            var x = await Contexto.Profissionais.Where(p => p.EstabelecimentoId == idEstabelecimento).ToListAsync();
            return x;
        }
    }
}