using Entities.DTOs.Question;

namespace Entities.DTOs.Exam
{
  public class ExamGetWithQuestionsDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuestionGetWithOptionsDto> Questions { get; set; }
  }
}