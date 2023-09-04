using Microsoft.AspNetCore.Mvc;
using Trabalho_api.Data;

namespace Trabalho_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly Trabalho_apiContext _context;

    public UserController(Trabalho_apiContext context)
    {
        _context = context;
    }
    
    
}