

namespace Business.Abstract
{
  public interface IQuestionOptionService
  {
    Task<Result> AddQuestionOptionsAsync(List<QuestionOptionAddDto> questionOptionAddDtos);
  }
}