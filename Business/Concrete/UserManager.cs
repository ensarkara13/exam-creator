
namespace Business.Concrete
{
  public class UserManager : IUserService
  {
    private readonly IMapper _mapper;
    public UserManager()
    {
    }

    public Task<Result> AddUserAsync(UserAddDto userAddDto)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<UserGetDto>> GetUserByEmailAsync(string email)
    {
      throw new NotImplementedException();
    }
  }
}