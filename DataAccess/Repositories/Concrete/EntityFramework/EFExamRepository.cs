using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFExamRepository : GenericRepository<Exam>, IExamRepository
  {
    public EFExamRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}