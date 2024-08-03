using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validadores;

public class ServicosValidator : AbstractValidator<Servico>
{
    public ServicosValidator()
    {
        RuleFor(servico => servico.Nome)
            .NotEmpty().WithMessage("O nome do serviço é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do serviço não pode ter mais de 100 caracteres.");

        RuleFor(servico => servico.DuracaoHoras)
            .GreaterThan(0)
            .WithMessage("A duração do serviço deve ser maior que zero.");

        RuleFor(servico => servico.Categoria)
            .IsInEnum()
            .WithMessage("A categoria do serviço é inválida.");

        RuleFor(servico => servico.ProfissionalId)
            .GreaterThan(0)
            .WithMessage("O ID do profissional deve ser maior que zero.");
    }
}