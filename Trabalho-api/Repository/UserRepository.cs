using Microsoft.EntityFrameworkCore;
using Trabalho_api.Data;
using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public class UserRepository : IUserRepository
{
    private readonly Trabalho_apiContext dbContext;

    public UserRepository(Trabalho_apiContext trabalhoApiContext)
    {
        dbContext = trabalhoApiContext;
    }

    public async Task<List<User?>> findAll()
    {
        return await dbContext.user.Include(u => u.enderecos).ToListAsync();
    }

    public async Task<User?> getById(int id)
    {
        return await dbContext.user.Include(u => u.enderecos)
            .FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<User?> getByEmail(string email)
    {
        return await dbContext.user.FirstOrDefaultAsync(u => u.email == email);
    }

    public async Task<User> save(User user)
    {
        dbContext.user.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> atualizar(User user)
    {
        dbContext.Update(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> delete(User? user)
    {
        dbContext.user.Remove(user);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> getByEmailAndSenha(string email, string senha)
    {
        return await dbContext.user.Include(u => u.enderecos)
            .FirstOrDefaultAsync(u => u.email == email && u.senha == senha);
    }
}