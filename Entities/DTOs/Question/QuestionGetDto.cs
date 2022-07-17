using Core.DTOs;

namespace Entities.DTOs.Question
{
  public class QuestionGetDto : EntityGetDto
  {
    public string QuestionText { get; set; }
  }
}