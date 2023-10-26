using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Dto;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly UserService userService;

    public AutenticacaoController(UserService UserService)
    {
        userService = UserService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromQuery] string email, [FromQuery] string senha)
    {
        var user = await userService.findUserByEmailAndSenha(email, senha);
        if (user == null) return NotFound(new { message = "Email ou senha incorretos" });

        var token = TokenService.generateToken(user);
        return new
        {
            user = UserResponse.convertFrom(user), token
        };
    }
}