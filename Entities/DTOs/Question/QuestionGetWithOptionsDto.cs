using Core.DTOs;
using Entities.DTOs.QuestionOption;

namespace Entities.DTOs.Question
{
  public class QuestionGetWithOptionsDto : EntityGetDto
  {
    public string QuestionText { get; set; }
    public List<QuestionOptionGetDto> QuestionOptions { get; set; }
  }
}