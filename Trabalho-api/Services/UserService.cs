using System.Text.RegularExpressions;
using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class UserService
{
    private readonly UserRepository repository;

    public UserService(UserRepository userRepository)
    {
        repository = userRepository;
    }
    
    public async Task<User?> createUser(UserRequest request)
    {
        validarEmail(request.email);
        return await repository.save(User.of(request));
    }

    private void validarEmail(string email)
    {
        var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        var regex = new Regex(pattern);
        if (!regex.IsMatch(email))
        {
            throw new Exception("Email invalido");
        }
    }

    public async Task<List<User?>> getAll()
    {
        return await repository.findAll();
    }

    public async Task<User?> atualizarUser(UserRequest request)
    {
        validarEmail(request.email);
        return await repository.atualizar(User.of(request));
    }

    public async Task<bool> deleteUser(int id)
    {
        var user = await repository.getById(id);
        return user != null
            ? await repository.delete(user)
            : throw new Exception("Usuário não encontrado");
    }
}