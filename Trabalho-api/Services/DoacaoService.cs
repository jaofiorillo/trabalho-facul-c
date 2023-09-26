using System.ComponentModel.DataAnnotations;
using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class DoacaoService
{
    private readonly DoacaoRepository repository;
    private readonly UserRepository userRepository;

    public DoacaoService(DoacaoRepository doacaoRepository, UserRepository _userRepository)
    {
        repository = doacaoRepository;
        userRepository = _userRepository;
    }
    
    public async Task<DoacaoResponse?> save(DoacaoRequest request)
    {
        var user = await userRepository.getById(request.vendedorId);
        var doacao = Doacao.of(request, user);
        doacao.pulicarDoacao();
        return DoacaoResponse.convertFrom(await repository.save(doacao));
    }
    
    public async Task<List<DoacaoResponse?>> getAll()
    {
        var doacoes = await incluirVendedores(await repository.findAll());
        return DoacaoResponse.convertFrom(doacoes);
    }

    private async Task<List<Doacao>> incluirVendedores(List<Doacao> doacoes)
    {
        return doacoes != null 
            ? await repository.incluirVendedores(doacoes)
            : Enumerable.Empty<Doacao>().ToList();
    }
    
    private async Task<Doacao> incluirVendedor(Doacao doacao)
    {
        return await repository.incluirVendedor(doacao.id);

    }

    public async Task<DoacaoResponse?> finalizarSituacaoDoacao(int id)
    {
        var doacao = await getById(id);
        doacao.finalizarDoacao();
        await incluirVendedor(doacao);
        return DoacaoResponse.convertFrom(await repository.atualizar(doacao));
    }

    private async Task<Doacao> getById(int id)
    {
        var doacao = await repository.getById(id);
        return doacao != null
            ? doacao
            : throw new ValidationException("Doação não encontrada");
    }
}