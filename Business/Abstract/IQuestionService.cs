namespace Business.Abstract
{
  public interface IQuestionService
  {
    public Task<Result> AddQuestionListAsync(List<QuestionAddDto> questionAddDtos);
    public Task<Result> DeleteQuestionAsync(int id);
  }
}