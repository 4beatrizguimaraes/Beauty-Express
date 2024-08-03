using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios;

public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentosRepository
{
    public AgendamentoRepository(BeautyContext contexto) : base(contexto)
    {
    }

    public async Task<bool> ExisteAgendamentoClienteMesmoHorario(Agendamento agendamento)
    {
        var query = await Db
            .Where(x => x.ClienteId == agendamento.ClienteId && x.DataHorarioId == agendamento.DataHorarioId
                        && x.EstabelecimentoId == agendamento.EstabelecimentoId && x.Id != agendamento.Id)
            .ToListAsync();
        
        return query.Count() > 0;
    }

    public async Task<bool> ExisteAgendamentoProfissionalMesmoHorario(Agendamento agendamento, List<Servico> servicos)
    {
        var servicoIds = servicos.Select(s => s.Id).ToList();

        /* var query = await Db
             .Where(x => x.ServicoId != agendamento.ServicoId
                         && x.DataHorarioId == agendamento.DataHorarioId
                         && x.EstabelecimentoId == agendamento.EstabelecimentoId
                         && x.Id != agendamento.Id)
             .AsEnumerable() // Move o restante da avaliação para o cliente
             .Where(x => servicoIds.Contains(x.ServicoId))
             .;*/

        var query = await Db
            .Where(x => x.DataHorarioId == agendamento.DataHorarioId
                        && x.EstabelecimentoId == agendamento.EstabelecimentoId
                        && x.Id != agendamento.Id)
            .ToListAsync();

        var resultado = query
            .Where(x => servicoIds.Contains(x.ServicoId))
            .FirstOrDefault();

        return resultado != null;
        /* var servicoIds = servicos.Select(s => s.Id).ToList();

         var query = await Db
             .Where(x => x.ServicoId != agendamento.ServicoId 
                         && x.DataHorarioId == agendamento.DataHorarioId
                         && x.EstabelecimentoId == agendamento.EstabelecimentoId 
                         && x.Id != agendamento.Id
                         && servicoIds.Contains(x.ServicoId))
             .ToListAsync();

         return query.Count() > 0;*/
    }

    public async Task<bool> ExisteCliente(int id)
    {
        var query = await Db.Where(v => v.ClienteId == id).ToListAsync();

        return query.Count() > 0;
    }

    public async Task<bool> ExisteDataHorario(int id)
    {
        var query = await Db.Where(v => v.DataHorarioId == id).ToListAsync();

        return query.Count() > 0;
    }

    public async Task<bool> ExisteEstabelecimento(int id)
    {
        var query = await Db.Where(v => v.EstabelecimentoId == id).ToListAsync();

        return query.Count() > 0;
    }

    public async Task<bool> ExisteServico(int id)
    {
        var query = await Db.Where(v => v.ServicoId == id).ToListAsync();

        return query.Count() > 0;
    }
}