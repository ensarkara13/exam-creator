using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using WebAPI.Helpers;
using WebAPI.Models.DTOs;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _config;
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _config = configuration;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
      User user = await _userManager.FindByEmailAsync(registerDto.Email);
      if (user != null)
      {
        return BadRequest("Kullanıcı zaten mevcut");
      }

      user = new User()
      {
        Name = registerDto.Name,
        LastName = registerDto.LastName,
        Email = registerDto.Email,
        UserName = registerDto.UserName
      };

      IdentityResult identityResult = await _userManager.CreateAsync(user, registerDto.Password);
      if (!identityResult.Succeeded)
      {
        return BadRequest(identityResult.Errors);
      }
      await _userManager.AddToRoleAsync(user, registerDto.Role);

      return StatusCode(201, user);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
      User user = await _userManager.FindByEmailAsync(loginDto.Email);
      if (user == null)
      {
        return BadRequest("Kullanıcı bulunmamaktadır.");
      }

      var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
      if (!signInResult.Succeeded)
      {
        return BadRequest("Giriş başarısız");
      }

      string accessToken = JWTHelper.GenerateAccessToken(_config);
      
      return Ok(new { user, accessToken });
    }
  }
}