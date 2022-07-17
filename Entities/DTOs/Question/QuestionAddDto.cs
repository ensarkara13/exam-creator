using Entities.DTOs.QuestionOption;

namespace Entities.DTOs.Question
{
  public class QuestionAddDto
  {
    public string QuestionText { get; set; }
    public Guid ExamId { get; set; }
    public List<QuestionOptionAddDto> QuestionOptions { get; set; }
  }
}