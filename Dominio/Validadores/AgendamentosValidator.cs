using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validadores;

public class AgendamentosValidator : AbstractValidator<Agendamento>
{
    public AgendamentosValidator()
    {
        RuleFor(agendamento => agendamento.EstabelecimentoId)
            .GreaterThan(0);
        RuleFor(agendamento => agendamento.ServicoId)
            .GreaterThan(0);
        RuleFor(agendamento => agendamento.ClienteId)
            .GreaterThan(0);
        RuleFor(agendamento => agendamento.DataHorarioId)
            .GreaterThan(0);
    }
}