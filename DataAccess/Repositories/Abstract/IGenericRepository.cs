using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract
{
  public interface IGenericRepository<T> where T : class, new()
  {
    Task Add(T entity);
    Task AddRange(List<T> entities);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteRange(List<T> entities);
    Task HardDelete(T entity);
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
  }
}