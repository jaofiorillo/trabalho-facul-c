using Trabalho_api.Models;

namespace Trabalho_api.Services;

public interface IAutenticacaoService
{
    int? getUserId();
    string getUserEmail();
    Task<User?> getUsuarioAutenticado();
}