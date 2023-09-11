using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Dto;
using Trabalho_api.Services;

namespace Trabalho_api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService service;

    public UserController(UserService userService)
    {
        service = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserRequest request)
    {
        var user = await service.createUser(request);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await service.getAll();
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarUser(UserRequest request)
    {
        var user = await service.atualizarUser(request);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var boll = service.deleteUser(id);
        return Ok(boll);
    }
}