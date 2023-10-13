using System.ComponentModel.DataAnnotations;
using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class DoacaoService
{
    private readonly DoacaoRepository repository;
    private readonly UserService userService;

    public DoacaoService(DoacaoRepository doacaoRepository, UserService _userService)
    {
        repository = doacaoRepository;
        userService = _userService;
    }
    
    public async Task<DoacaoResponse?> save(DoacaoRequest request)
    {
        var user = await userService.findUserById(request.vendedorId);
        var doacao = Doacao.of(request, user);
        doacao.pulicarDoacao();
        return DoacaoResponse.convertFrom(await repository.save(doacao));
    }
    
    public async Task<List<DoacaoResponse?>> getAll()
    {
        var doacoes = await repository.findAll();
        return DoacaoResponse.convertFrom(doacoes);
    }

    public async Task<DoacaoResponse?> finalizarSituacaoDoacao(int id)
    {
        var doacao = await getById(id);
        doacao.finalizarDoacao();
        await repository.incluirVendedor(doacao.id);
        return DoacaoResponse.convertFrom(await repository.atualizar(doacao));
    }

    private async Task<Doacao> getById(int id)
    {
        var doacao = await repository.getById(id);
        return doacao != null
            ? doacao
            : throw new ValidationException("Doação não encontrada");
    }

    public async Task<List<DoacaoResponse?>> getDoacoesById(int id)
    {
        var doacoes = await repository.findByVendedor(id);
        return DoacaoResponse.convertFrom(doacoes);
    }
}