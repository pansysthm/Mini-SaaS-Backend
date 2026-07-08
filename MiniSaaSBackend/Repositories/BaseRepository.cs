using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniSaaSBackend.Data;

namespace MiniSaaSBackend.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        return await _dbSet.AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public void Dispose()
    {
        // TODO release managed resources here
        GC.SuppressFinalize(this);
    }
}