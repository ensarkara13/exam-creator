using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFUserExamRepository : GenericRepository<UserExam>, IUserExamRepository
  {
    public EFUserExamRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}