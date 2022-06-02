using System.Linq.Expressions;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
  {
    private readonly ExamCreatorDbContext _context;
    public GenericRepository(ExamCreatorDbContext context)
    {
      _context = context;
    }
    public async Task Add(T entity)
    {
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task AddRange(List<T> entities)
    {
      await _context.AddRangeAsync(entities);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
      _context.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(List<T> entities)
    {
      _context.RemoveRange(entities);
      await _context.SaveChangesAsync();
    }

    public Task<T> Get(Expression<Func<T, bool>> filter)
    {
      return _context.Set<T>().SingleOrDefaultAsync(filter);
    }

    public Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
    {
      if (filter == null)
      {
        return _context.Set<T>().ToListAsync();
      }
      return _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task HardDelete(T entity)
    {
      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
      _context.Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}