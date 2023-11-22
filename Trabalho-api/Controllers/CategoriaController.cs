using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Models;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[ApiController]
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

    [HttpPost]
    public async Task<IActionResult> Cadastrar(string nome)
    {
        var categoria = await service.saveCategoria(nome);
        return Ok(categoria);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> editarCategoia(string nome, int id)
    {
        var categoria = await service.editarCategoria(nome, id);
        return Ok(categoria);
    }
}