using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Dto;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly AutenticacaoService autenticacaoService;

    public AutenticacaoController(AutenticacaoService AutenticacaoService)
    {
        autenticacaoService = AutenticacaoService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromQuery] string email, [FromQuery] string senha)
    {
        var user = await autenticacaoService.getUsuarioLogin(email, senha);
        if (user == null) return NotFound(new { message = "Email ou senha incorretos" });

        var token = TokenService.generateToken(user);
        return new
        {
            user = UserResponse.convertFrom(user), token
        };
    }

    [HttpGet("authenticated")]
    [Authorize]
    public async Task<IActionResult> getUsuarioAutenticado()
    {
        var userAutenticado = UserResponse.convertFrom(await autenticacaoService.getUsuarioAutenticado());
        return Ok(userAutenticado);
    }
}