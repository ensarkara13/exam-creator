using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class QuestionOptionRepository : GenericRepository<QuestionOption>, IQuestionOptionRepository
  {
    public QuestionOptionRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}