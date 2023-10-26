using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public interface IUserRepository
{
    Task<List<User?>> findAll();

    Task<User?> getById(int id);

    Task<User?> save(User? user);

    Task<User?> atualizar(User? user);

    Task<bool> delete(User? user);

    Task<User?> getByEmail(string email);
}