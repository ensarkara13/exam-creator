using Core.Entities;

namespace Entities.Concrete
{
  public class Exam : EntityBase
  {
    public string Title { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<UserExam> UserExams { get; set; }
  }
}