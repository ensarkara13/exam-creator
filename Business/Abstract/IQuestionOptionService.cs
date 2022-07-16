using Core.Utilities.Results;
using Entities.DTOs.QuestionOption;

namespace Business.Abstract
{
  public interface IQuestionOptionService
  {
    Task<Result> AddQuestionOptionsAsync(List<QuestionOptionAddDto> questionOptionAddDtos);
  }
}