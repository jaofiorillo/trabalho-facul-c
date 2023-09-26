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
    
    public async Task<UserResponse?> createUser(UserRequest request)
    {
        validarDigitacaoEmail(request.email);
        await validarEmailExistente(request.email);
        var user = await repository.save(User.of(request));
        return UserResponse.convertFrom(user);
    }

    private void validarDigitacaoEmail(string email)
    {
        var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        var regex = new Regex(pattern);
        if (!regex.IsMatch(email))
        {
            throw new Exception("Email invalido");
        }
    }
    
    private async Task validarEmailExistente(string email)
    {
        var user = await repository.getByEmail(email);
        if (user != null)
        {
            throw new Exception("Email já cadastrado");
        }
    }
    
    public async Task<List<UserResponse?>> getAll()
    {
        var users = await repository.findAll();
        return UserResponse.convertFrom(users);
    }
    
    public async Task<UserResponse?> getById(int id)
    {
        var user = await repository.getById(id);
        return UserResponse.convertFrom(user);
    }

    public async Task<User?> atualizarUser(UserRequest request)
    {
        validarDigitacaoEmail(request.email);
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