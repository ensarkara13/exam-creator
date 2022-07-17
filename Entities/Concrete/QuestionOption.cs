using Core.Entities;

namespace Entities.Concrete
{
  public class QuestionOption : EntityBase
  {
    public string OptionText { get; set; }
    public bool IsRightAnswer { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
  }
}