using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Dto;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("api/doacao")]
[ApiController]
public class DoacaoController : ControllerBase
{
    private readonly DoacaoService service;

    public DoacaoController(DoacaoService userService)
    {
        service = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Save(DoacaoRequest request)
    {
        var doacao = await service.save(request);
        return Ok(doacao);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doacoes = await service.getAll();
        return Ok(doacoes);
    }

    [HttpPost("finalizar/{id}")]
    public async Task<IActionResult> FinalizarDoacao(int id)
    {
        var doacao = await service.finalizarSituacaoDoacao(id);
        return Ok(doacao);
    }

    [HttpGet("doacoes-usuario/{id}")]
    public async Task<IActionResult> GetDoacoesByUsuario(int id)
    {
        var doacoes = await service.getDoacoesById(id);
        return Ok(doacoes);
    }
}