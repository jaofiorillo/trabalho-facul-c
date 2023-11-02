using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Trabalho_api.Models;

namespace Trabalho_api.Services;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserService userService;

    public AutenticacaoService(IHttpContextAccessor httpContextAccessor, UserService UserService)
    {
        _httpContextAccessor = httpContextAccessor;
        userService = UserService;
    }

    public int? getUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId)) return userId;
        return 0;
    }

    public string getUserEmail()
    {
        return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
    }

    public async Task<User?> getUsuarioAutenticado()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            return await userService.findUserById(userId);

        throw new ValidationException("User não encontrado");
    }

    public async Task<User?> getUsuarioLogin(string email, string senha)
    {
        return await userService.findUserByEmailAndSenha(email, senha);
    }
}