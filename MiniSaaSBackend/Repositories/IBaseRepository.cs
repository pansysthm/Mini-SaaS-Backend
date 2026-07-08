using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniSaaSBackend.Entities;

namespace MiniSaaSBackend.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    public Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(Guid id);
}