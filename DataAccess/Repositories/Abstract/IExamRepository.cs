using Entities.Concrete;

namespace DataAccess.Repositories.Abstract
{
  public interface IExamRepository : IGenericRepository<Exam>
  {
    Task<Exam> GetExamWithQuestions(Guid id);
  }
}