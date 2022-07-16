using Entities.DTOs.Question;

namespace Entities.DTOs.Exam
{
  public class ExamAddDto
  {
    public string Title { get; set; }
    public List<QuestionAddDto> Questions { get; set; }
  }
}