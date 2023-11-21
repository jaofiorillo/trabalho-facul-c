using System.ComponentModel.DataAnnotations;
using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class EnderecoService
{
    private readonly AutenticacaoService autenticacaoService;
    private readonly EnderecoRepository repository;
    private readonly UserService userService;

    public EnderecoService(UserService UserService, EnderecoRepository enderecoRepository,
        AutenticacaoService _autenticacaoService)
    {
        userService = UserService;
        repository = enderecoRepository;
        autenticacaoService = _autenticacaoService;
    }

    public async Task<EnderecoResponse> vincularEndereco(EnderecoRequest request)
    {
        var user = await autenticacaoService.getUsuarioAutenticado();
        var endereco = Endereco.of(request);
        endereco.vincularUser(user);
        var saveEndereco = await repository.save(endereco);
        await userService.vincularEndereco(saveEndereco, user);
        return EnderecoResponse.convertFrom(saveEndereco);
    }

    public async Task<List<EnderecoResponse>> getEnderecosByUserId(int id)
    {
        var enderecos = await repository.getByUserId(id);
        return EnderecoResponse.convertFrom(enderecos);
    }

    public async Task<Endereco?> findEndercoById(int id)
    {
        var user = repository.getById(id);
        return user != null
            ? await user
            : throw new ValidationException("Endereço não encontrado");
    }
}