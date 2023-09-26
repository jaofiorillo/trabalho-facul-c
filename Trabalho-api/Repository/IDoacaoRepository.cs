using Trabalho_api.Models;

namespace Trabalho_api.Repository;

public interface IDoacaoRepository
{
    Task<List<Doacao>> findAll();
    
    Task<Doacao?> getById(int id);
    
    Task<Doacao?> save(Doacao? user);
    
    Task<Doacao?> atualizar(Doacao? user);
    
    Task<bool> delete(Doacao? user);

    Task<List<Doacao>> incluirVendedores(List<Doacao> doacoes);
}