using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Dto;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("api/endereco")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoService service;

    public EnderecoController(EnderecoService enderecoService)
    {
        service = enderecoService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Save(EnderecoRequest request)
    {
        var endereco = await service.vincularEndereco(request);
        return Ok(endereco);
    }

    [HttpGet("user/{id}")]
    [Authorize]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var enderecos = await service.getEnderecosByUserId(id);
        return Ok(enderecos);
    }
}