using Core.DTOs;

namespace Entities.DTOs.User
{
  public class UserGetDto : EntityGetDto
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
  }
}