using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;
using FluentValidation.Results;

namespace Dominio.Service;

public class EstabelecimentosService : BaseService, IEstabelecimentosService
{
    private readonly IEstabelecimentosRepository _estabelecimentosRepository;
    private readonly EstabelecimentosValidator _estabelecimentosValidator;
    private readonly IAgendamentosService _agendamentosService;

    public EstabelecimentosService(IEstabelecimentosRepository estabelecimentosRepository, EstabelecimentosValidator estabelecimentosValidator,
        IAgendamentosService agendamentosService)
    {
        _estabelecimentosRepository = estabelecimentosRepository;
        _estabelecimentosValidator = estabelecimentosValidator;
        _agendamentosService = agendamentosService;
    }

    public async Task<Estabelecimento> Adicionar(Estabelecimento estabelecimento)
    {
        ValidationResult result = _estabelecimentosValidator.Validate(estabelecimento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        await _estabelecimentosRepository.Adicionar(estabelecimento);
        return estabelecimento;
    }

    public async Task<bool> Atualizar(Estabelecimento estabelecimento)
    {
        ValidationResult result = _estabelecimentosValidator.Validate(estabelecimento);

        if (!result.IsValid)
        {
            string erros = "";
            foreach (var erro in result.Errors)
            {
                erros += erro.ToString() + "; ";
            }
            throw new Exception(erros);
        }
        
        if (await _estabelecimentosRepository.ObterPorId(estabelecimento.Id) == null)
        {
            throw new Exception("Estabelicimento não encontrada!");
        }
        await _estabelecimentosRepository.Atualizar(estabelecimento.Id, estabelecimento);
        return true;
    }

    public async Task<Estabelecimento> ObterPorId(int id)
    {
        var estabelecimentos = await _estabelecimentosRepository.ObterPorId(id);
        if (estabelecimentos == null)
        {
            throw new Exception("Estabelecimento não encontrada!");
        }
        return estabelecimentos;
    }

    public async Task<IEnumerable<Estabelecimento>> ObterTodos()
    {
        return await _estabelecimentosRepository.ObterTodos();
    }

    public async Task<bool> Remover(int id)
    {
        if (await _estabelecimentosRepository.ObterPorId(id) == null)
        {
            throw new Exception("Estabelecimento não existe!");
        }

        if(await _agendamentosService.ExisteEstabelecimento(id))
        {
            throw new Exception("Estabelecimento vinculado a um agendamento!");
        }

        await _estabelecimentosRepository.Remover(id);
        return true;
    }
}