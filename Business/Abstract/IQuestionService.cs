namespace Business.Abstract
{
  public interface IQuestionService
  {
    public Task<Result> AddQuestionsAsync(List<QuestionAddDto> questionAddDtos);
    public Task<Result> DeleteQuestionAsync(int id);
  }
}