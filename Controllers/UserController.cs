using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    private UserRegisterService _userRegisterService;

    public UsuarioController(UserRegisterService userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        await _userRegisterService.UserRegister(dto);
        return Ok("Usuário cadastrado!");
    }
    
}