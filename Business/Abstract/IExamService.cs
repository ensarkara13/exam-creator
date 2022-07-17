
namespace Business.Abstract
{
  public interface IExamService
  {
    Task<Result> AddExamAsync(ExamAddDto examAddDto);
    Task<Result> DeleteExamAsync(Guid id);
    Task<Result> UpdateExamAsync(ExamUpdateDto examUpdateDto);
    Task<DataResult<List<ExamGetDto>>> GetExamListAsync();
    Task<DataResult<ExamGetWithQuestionsDto>> GetExamAsync(Guid id);
  }
}