using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
  public class User : IdentityUser<int>
  {
    public string Name { get; set; }
    public string LastName { get; set; }

    public ICollection<UserExam> UserExams { get; set; }
  }
}