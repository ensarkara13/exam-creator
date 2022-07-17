namespace Entities.Concrete
{
  public class UserExam
  {
    public int Score { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }
  }
}