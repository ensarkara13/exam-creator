using Entities.Concrete;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Identity;
using WebAPI.Helpers;
using WebAPI.Models.DTOs;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IConfiguration _config;
    private readonly IPasswordHasher<string> _passwordHasher;
    public AuthController(IUserService userService, IConfiguration configuration, IPasswordHasher<string> passwordHasher)
    {
      _userService = userService;
      _config = configuration;
      _passwordHasher = passwordHasher;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserAddDto registerDto)
    {
      Result result = await _userService.AddUserAsync(registerDto);

      if (!result.IsSuccess)
      {
        return BadRequest(result.ErrorMessages);
      }

      return StatusCode(201, registerDto);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
      DataResult<UserGetDto> result = await _userService.GetUserByEmailAsync(loginDto.Email);

      if (!result.IsSuccess)
      {
        return NotFound(result.Message);
      }

      int verificationResult = (int)_passwordHasher.VerifyHashedPassword(result.Data.Email, result.Data.Password, loginDto.Password);

      if (verificationResult != 1)
      {
        return BadRequest("Giriş Başarısız");
      }

      // string accessToken = JWTHelper.GenerateAccessToken(_config, result.Data.Role);

      UserInfoDto userInfoDto = new UserInfoDto()
      {
        FirstName = result.Data.FirstName,
        LastName = result.Data.LastName,
        Email = result.Data.Email,
        Role = result.Data.Role,
        AccessToken = JWTHelper.GenerateAccessToken(_config, result.Data.Role)
      };

      return Ok(userInfoDto);
    }
  }
}