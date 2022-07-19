
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

    public async Task<Result> AddUserAsync(UserAddDto userAddDto)
    {
      ValidationResult validationResult = _addValidator.Validate(userAddDto);
      if (!validationResult.IsValid)
      {
        return Result.Failure(validationResult);
      }

      User user = await _repository.Get(u => u.Email == userAddDto.Email);
      if (user != null)
      {
        return Result.Failure("Kullanıcı zaten kayıtlı");
      }

      user = _mapper.Map<User>(userAddDto);
      user.Password = _passwordHasher.HashPassword(userAddDto.Email, userAddDto.Password);
      user.Role = string.IsNullOrEmpty(userAddDto.Role) ? "User" : userAddDto.Role;

      await _repository.Add(user);

      return Result.Success();
    }

    public async Task<DataResult<UserGetDto>> GetUserByEmailAsync(string email)
    {
      User user = await _repository.Get(u => u.Email == email);
      if (user == null)
      {
        return DataResult<UserGetDto>.Failure("Kullanıcı bulunamadı");
      }

      UserGetDto userGetDto = _mapper.Map<UserGetDto>(user);

      return DataResult<UserGetDto>.Success(userGetDto);
    }
  }
}