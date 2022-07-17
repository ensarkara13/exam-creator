using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFExamRepository : GenericRepository<Exam>, IExamRepository
  {
    private readonly ExamCreatorDbContext _context;
    public EFExamRepository(ExamCreatorDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Exam> GetExamWithQuestions(Guid id)
    {
      return await _context.Exams.Where(e => e.Id == id).Include(e => e.Questions).ThenInclude(q => q.QuestionOptions).FirstOrDefaultAsync();
    }
  }
}