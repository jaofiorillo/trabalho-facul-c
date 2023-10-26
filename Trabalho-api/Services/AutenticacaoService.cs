namespace Trabalho_api.Services;

public class AutenticacaoService
{
    private readonly UserService userService;

    public AutenticacaoService(UserService UserService)
    {
        userService = UserService;
    }
}