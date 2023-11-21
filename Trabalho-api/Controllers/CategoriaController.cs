using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService service;

    public CategoriaController(CategoriaService categoriaService)
    {
        service = categoriaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoria = await service.getAll();
        return Ok(categoria);
    }
}