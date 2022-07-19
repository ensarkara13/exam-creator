using Core.Entities;

namespace Entities.Concrete
{
  public class User : EntityBase
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public ICollection<UserExam> UserExams { get; set; }
  }
}