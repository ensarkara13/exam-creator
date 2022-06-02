using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFQuestionRepository : GenericRepository<Question>, IQuestionRepository
  {
    public EFQuestionRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}