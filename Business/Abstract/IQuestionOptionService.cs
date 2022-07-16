

namespace Business.Abstract
{
  public interface IQuestionOptionService
  {
    Task<Result> AddQuestionOptionListAsync(List<QuestionOptionAddDto> questionOptionAddDtos);
  }
}