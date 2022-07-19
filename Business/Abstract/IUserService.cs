namespace Business.Abstract
{
  public interface IUserService
  {
    Task<Result> AddUserAsync(UserAddDto userAddDto);
    Task<DataResult<UserGetDto>> GetUserByEmailAsync(string email);
  }
}