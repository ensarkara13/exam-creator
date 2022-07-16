
namespace Business.Abstract
{
  public interface IExamService
  {
    Task<Result> AddExamAsync(ExamAddDto examAddDto);
    Task<Result> DeleteExamAsync(int id);
    Task<Result> UpdateExamAsync(ExamUpdateDto examUpdateDto);
    Task<DataResult<List<ExamGetDto>>> GetExamListAsync();
    Task<DataResult<ExamGetWithQuestionsDto>> GetExamAsync(int id);
  }
}