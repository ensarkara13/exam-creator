using Core.Entities;

namespace Entities.Concrete
{
  public class Question : EntityBase
  {
    public string QuestionText { get; set; }

    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }
    public ICollection<QuestionOption> QuestionOptions { get; set; }
  }
}