using Trabalho_api.Data;
using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public class EnderecoRepository
{
    private readonly Trabalho_apiContext dbContext;
    
    public EnderecoRepository(Trabalho_apiContext trabalhoApiContext)
    {
        dbContext = trabalhoApiContext;
    }
    
    public async Task<Endereco?> save(Endereco endereco)
    {
        dbContext.endereco.Add(endereco);
        await dbContext.SaveChangesAsync();
        return endereco;
    }
}