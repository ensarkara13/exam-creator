using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFQuestionOptionRepository : GenericRepository<QuestionOption>, IQuestionOptionRepository
  {
    public EFQuestionOptionRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}