using System.ComponentModel.DataAnnotations;
using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class DoacaoService
{
    private readonly DoacaoRepository repository;
    private readonly EnderecoService enderecoService;
    private readonly AutenticacaoService autenticacaoService;

    public DoacaoService(DoacaoRepository doacaoRepository, EnderecoService _enderecoService, AutenticacaoService _autenticacaoService)
    {
        repository = doacaoRepository;
        enderecoService = _enderecoService;
        autenticacaoService = _autenticacaoService;
    }

    public async Task<DoacaoResponse?> save(DoacaoRequest request)
    {
        var user = await autenticacaoService.getUsuarioAutenticado();
        validarEndereco(user);
        var endereco = await enderecoService.findEndercoById(request.enderecoId);
        var doacao = Doacao.of(request, user, endereco);
        doacao.pulicarDoacao();
        return DoacaoResponse.convertFrom(await repository.save(doacao));
    }

    private void validarEndereco(User user)
    {
        if (!user.hasEnderecos())
        {
            throw new ValidationException("É necessario ter um endereço vinculado para realizar a doação");
        }
    }

    public async Task<List<DoacaoResponse?>> getAll()
    {
        var doacoes = await repository.findAll();
        return DoacaoResponse.convertFrom(doacoes);
    }

    public async Task<DoacaoResponse?> finalizarSituacaoDoacao(int id)
    {
        var doacao = await findById(id);
        doacao.finalizarDoacao();
        await repository.incluirVendedor(doacao.id);
        return DoacaoResponse.convertFrom(await repository.atualizar(doacao));
    }

    public async Task<bool> deletarDoacao(int id)
    {
        var doacao = await findById(id);
        return await repository.delete(doacao);
    }

    private async Task<Doacao> findById(int id)
    {
        var doacao = await repository.getById(id);
        return doacao != null
            ? doacao
            : throw new ValidationException("Doação não encontrada");
    }

    public async Task<List<DoacaoResponse?>> getDoacoesByUserId(int id)
    {
        var doacoes = await findDoacoesByUserId(id);
        return DoacaoResponse.convertFrom(doacoes);
    }

    private async Task<List<Doacao>> findDoacoesByUserId(int id)
    {
        return await repository.findByVendedor(id);
    }
}