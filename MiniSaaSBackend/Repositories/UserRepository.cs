using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniSaaSBackend.Entities;

namespace MiniSaaSBackend.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}