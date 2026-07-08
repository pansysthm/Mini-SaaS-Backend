using Microsoft.AspNetCore.Mvc;
using MiniSaaSBackend.DTOs.User;
using MiniSaaSBackend.Repositories;

namespace MiniSaaSBackend.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) 
        {
            return null;
        }

        return new UserDto
        {
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }

    public Task<IActionResult> GetAllAsync(GetAllUsersRequest usersRequest)
    {
        throw new NotImplementedException();
    }
}