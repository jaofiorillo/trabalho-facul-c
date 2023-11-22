using Microsoft.EntityFrameworkCore;
using Trabalho_api.Data;
using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public class CategoriaRepository
{
    private readonly Trabalho_apiContext dbContext;

    public CategoriaRepository(Trabalho_apiContext trabalhoApiContext)
    {
        dbContext = trabalhoApiContext;
    }

    public async Task<List<Categoria?>> findAll()
    {
        return await dbContext.categoria.ToListAsync();
    }

    public async Task<Categoria?> getById(int id)
    {
        return await dbContext.categoria.FirstOrDefaultAsync(c => c.id == id);
    }
    
    public async Task<Categoria?> save(Categoria categoria)
    {
        dbContext.categoria.Add(categoria);
        await dbContext.SaveChangesAsync();
        return categoria;
    }
    
    public async Task<Categoria?> atualizar(Categoria categoria)
    {
        dbContext.Update(categoria);
        await dbContext.SaveChangesAsync();
        return categoria;
    }
}