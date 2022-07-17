using Core.DTOs;

namespace Entities.DTOs.QuestionOption
{
  public class QuestionOptionGetDto : EntityGetDto
  {
    public string OptionText { get; set; }
    public bool IsRightAnswer { get; set; }
  }
}