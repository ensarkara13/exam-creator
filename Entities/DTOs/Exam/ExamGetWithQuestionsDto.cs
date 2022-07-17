using Core.DTOs;
using Entities.DTOs.Question;

namespace Entities.DTOs.Exam
{
  public class ExamGetWithQuestionsDto : EntityGetDto
  {
    public string Title { get; set; }
    public List<QuestionGetWithOptionsDto> Questions { get; set; }
  }
}