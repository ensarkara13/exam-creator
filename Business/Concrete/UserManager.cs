
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
  public class UserManager : IUserService
  {
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<UserAddDto> _addValidator;
    private readonly IPasswordHasher<string> _passwordHasher;
    public UserManager(IUserRepository repository, IMapper mapper, IValidator<UserAddDto> addValidator, IPasswordHasher<string> passwordHasher)
    {
      _repository = repository;
      _mapper = mapper;
      _addValidator = addValidator;
      _passwordHasher = passwordHasher;
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