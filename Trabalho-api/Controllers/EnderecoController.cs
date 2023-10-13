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
    public async Task<IActionResult> Save(EnderecoRequest request)
    {
        var doacao = await service.vincularEndereco(request);
        return Ok(doacao);
    }
}