namespace Business.Mappings
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      // Add
      CreateMap<UserAddDto, User>();

      // Get
      CreateMap<User, UserGetDto>();
    }
  }
}