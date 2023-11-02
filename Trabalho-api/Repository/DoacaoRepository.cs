using Microsoft.EntityFrameworkCore;
using Trabalho_api.Data;
using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public class DoacaoRepository : IDoacaoRepository
{
    private readonly Trabalho_apiContext dbContext;

    public DoacaoRepository(Trabalho_apiContext trabalhoApiContext)
    {
        dbContext = trabalhoApiContext;
    }

    public async Task<List<Doacao>> findAll()
    {
        return await dbContext.doacao.Include(d => d.vendedor).ToListAsync();
    }

    public async Task<Doacao?> getById(int id)
    {
        return await dbContext.doacao.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<Doacao?> save(Doacao doacao)
    {
        dbContext.doacao.Add(doacao);
        await dbContext.SaveChangesAsync();
        return doacao;
    }

    public async Task<Doacao?> atualizar(Doacao doacao)
    {
        dbContext.Update(doacao);
        await dbContext.SaveChangesAsync();
        return doacao;
    }

    public async Task<bool> delete(Doacao doacao)
    {
        dbContext.doacao.Remove(doacao);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Doacao> incluirVendedor(int doacaoId)
    {
        var doacao = await dbContext.doacao.Include(d => d.vendedor)
            .FirstOrDefaultAsync(d => d.id == doacaoId);
        return doacao;
    }

    public async Task<List<Doacao>> findByVendedor(int id)
    {
        return dbContext.doacao.Include(d => d.vendedor)
            .Where(d => d.vendedor.id == id).ToList();
    }
}