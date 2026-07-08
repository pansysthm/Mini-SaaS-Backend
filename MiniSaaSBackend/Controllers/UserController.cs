using Microsoft.AspNetCore.Mvc;
using MiniSaaSBackend.DTOs.User;
using MiniSaaSBackend.Services;

namespace MiniSaaSBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    protected readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("users")]
    public async Task<IActionResult> AllAsync(GetAllUsersRequest usersRequest)
    {
        var result = await _userService.GetAllAsync(usersRequest);
        return Ok(result);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return Ok(result);
    }
}