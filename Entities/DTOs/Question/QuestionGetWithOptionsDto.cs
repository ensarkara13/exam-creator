using Entities.DTOs.QuestionOption;

namespace Entities.DTOs.Question
{
  public class QuestionGetWithOptionsDto
  {
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public List<QuestionOptionGetDto> QuestionOptions { get; set; }
  }
}