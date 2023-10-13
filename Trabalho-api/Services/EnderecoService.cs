using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class EnderecoService
{
    private readonly UserService userService;
    private readonly EnderecoRepository repository;
    
    public EnderecoService(UserService UserService, EnderecoRepository enderecoRepository)
    {
        userService = UserService;
        repository = enderecoRepository;
    }
    
    public async Task<EnderecoResponse> vincularEndereco(EnderecoRequest request)
    {
        var user = await userService.findUserById(request.userId);
        var endereco = Endereco.of(request);
        endereco.vincularUser(user);
        var saveEndereco = await repository.save(endereco);
        await userService.vincularEndereco(saveEndereco, user);
        return EnderecoResponse.convertFrom(saveEndereco);
    }
}