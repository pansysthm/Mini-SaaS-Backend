using Microsoft.AspNetCore.Mvc;
using MiniSaaSBackend.DTOs.User;

namespace MiniSaaSBackend.Services;

public interface IUserService
{
    public Task<UserDto?> GetByIdAsync(Guid id);
    public Task<IActionResult> GetAllAsync(GetAllUsersRequest usersRequest);
}